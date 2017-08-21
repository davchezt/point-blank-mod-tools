/*
 * Created by SharpDevelop.
 * User: leonardo
 * Date: 11/22/2016
 * Time: 3:44 PM
 * 
 * To change this template use Tools | Options | Coding | Edit Standard Headers.
 */
using System;
using System.Collections.Generic;
using System.Diagnostics;
using System.Drawing;
using System.IO;
using System.Reflection;
using System.Text;
using System.Windows.Forms;

namespace DDS_Tools
{
	/// <summary>
	/// Description of MainForm.
	/// </summary>
	public partial class MainForm : Form
	{
		private byte[] _i3iHeader;// = new byte[60];
		private byte[] _ddsHeader;// = new byte[128];
		
		/// <summary>
		/// i3i: offset +8 (short)
		/// </summary>
		private byte[] _i3iHeight = new byte[2];
		
		/// <summary>
		/// i3i: offset +6 (short)
		/// </summary>
		private byte[] _i3iWidth = new byte[2];
		
		/// <summary>
		/// offset +12 / +0x0C (short)
		/// </summary>
		private byte[] _ddsHeight = new byte[2];
		
		/// <summary>
		/// offset +16 / +0x10 (short)
		/// </summary>
		private byte[] _ddsWidth = new byte[2];

		/// <summary>
		/// I3I Offset: 10
		/// (short) 1665 = Four CC 4 bits: DTX1
		/// (short) 1538 = Four CC 8 bits: DTX3
		/// (short) 1540 = Four CC 8 bits: DTX5
		/// </summary>
		private byte[] _i3isurfaces = new byte[2];
		/// <summary>
		/// DDS Offset: 84
		/// Encoding.UTF8.GetString(buff, 84, 4);
		/// </summary>
		private byte[] _ddssurfaces = new byte[4];
		
		private byte[] _i3imipmap = new byte[] { 0x01 };
		
		private byte[] _data;
		private string _ddsfile;
		private string _i3ifile;
		private string _destination;
		
		// DTX1, DTX3, DTX5 -> true
		private bool _convertable;
		private bool _useorigin;
		
		private void lblAuthor_MouseEnter(object sender, EventArgs e)
		{
			lblAuthor.Font = new Font(lblAuthor.Font, FontStyle.Underline);
			lblAuthor.ForeColor = SystemColors.Highlight;
		}
		private void lblAuthor_MouseLeave(object sender, EventArgs e)
		{
			lblAuthor.Font = new Font(lblAuthor.Font, FontStyle.Regular);
			lblAuthor.ForeColor = SystemColors.ControlDarkDark;
		}
		private void lblAuthor_MouseDown(object sender, MouseEventArgs e)
		{
			Process.Start("http://facebook.com/vchezt");
		}
		private string appVersion = Assembly.GetExecutingAssembly().GetName().Version.ToString();

		public MainForm()
		{
			InitializeComponent();
			lblVersion.Text = "v" + appVersion;
		}
		private void BtnOpenClick(object sender, EventArgs e)
		{
			//byte[] header;
			OpenFileDialog dialog = new OpenFileDialog();
			dialog.Filter = "DirectDraw Surface|*.dds";
			if (dialog.ShowDialog() == DialogResult.OK) {
				string fileName = dialog.FileName;
				FileInfo inf = new FileInfo(fileName);
				_ddsfile = fileName;
				_destination = inf.Directory.FullName;
				// Read File
				FileStream input = new FileStream(_ddsfile, FileMode.Open);
				BinaryReader reader = new BinaryReader(input);
				byte[] buf = reader.ReadBytes((int)input.Length);
				// Copy Header
				_ddsHeader = new byte[128];
				Array.Copy(buf, 0, _ddsHeader, 0, _ddsHeader.Length);
				// Copy Body (data)
				_data = new byte[buf.Length - _ddsHeader.Length];
				Array.Copy(buf, _ddsHeader.Length, _data, 0, _data.Length);
				// DDS Height
				Array.Copy(buf, 12, _ddsHeight, 0, 2);
				Array.Copy(buf, 12, _i3iHeight, 0, 2);
				// DDS Width
				Array.Copy(buf, 16, _ddsWidth, 0, 2);
				Array.Copy(buf, 16, _i3iWidth, 0, 2);
				// DDS Surface
				Array.Copy(buf, 84, _ddssurfaces, 0, 4);
				input.Close();
				reader.Close();
				
				tbxFile.Text = inf.Name;
				tbxSurface.Text = Encoding.UTF8.GetString(_ddssurfaces, 0, _ddssurfaces.Length);
				string surface = Encoding.Default.GetString(_ddssurfaces, 0, _ddssurfaces.Length);
				switch (surface) {
					case "DXT1":
						gbxDetails.ForeColor = SystemColors.ControlText;
						gbx3IDetails.ForeColor = SystemColors.ControlText;
						lblSurfaceD.Text = "Four CC 4 bits: " + _ddsHeader[76] + " bit depth";
						_convertable = true;
						Array.Copy(Headers.I3IDTX1Surface, 0, _i3isurfaces, 0, 2);
						break;
					case "DXT3":
						gbxDetails.ForeColor = SystemColors.ControlText;
						gbx3IDetails.ForeColor = SystemColors.ControlText;
						lblSurfaceD.Text = "Four CC 8 bits: " + _ddsHeader[76] + " bit depth";
						_convertable = true;
						Array.Copy(Headers.I3IDTX3Surface, 0, _i3isurfaces, 0, 2);
						break;
					case "DXT5":
						gbxDetails.ForeColor = SystemColors.ControlText;
						gbx3IDetails.ForeColor = SystemColors.ControlText;
						lblSurfaceD.Text = "Four CC 8 bits: " + _ddsHeader[76] + " bit depth";
						_convertable = true;
						Array.Copy(Headers.I3IDTX5Surface, 0, _i3isurfaces, 0, 2);
						break;
					default:
						gbxDetails.ForeColor = SystemColors.ControlDarkDark;
						gbx3IDetails.ForeColor = SystemColors.ControlDarkDark;
						tbxSurface.Text = "NONE";
						lblSurfaceD.Text = "Unknown surface volume: " + _ddsHeader[76] + " bit depth";
						_convertable = true;
						break;
				}
				btnConvert.Enabled |= _convertable;
				tbxWidthD.Text = BitConverter.ToInt16(_ddsWidth, 0).ToString();
				tbxHeightD.Text = BitConverter.ToInt16(_ddsHeight, 0).ToString();
				
				tbxWidth.Text = tbxWidthD.Text;
				lblP1.Visible = true;
				tbxHeight.Text = tbxHeightD.Text;
				lblP2.Visible = true;
				
				if (_ddsHeader[110] == 64 && BitConverter.ToInt16(_ddsHeader, 108) == (short)4104) {
					lblDivide.Visible = true;
					tbxMipMap.Visible = true;
					tbxMipMap.Text = "1/" + _ddsHeader[28];
					lblMipMap.Visible = true;
				} else {
					lblDivide.Visible = false;
					tbxMipMap.Visible = false;
					lblMipMap.Visible = false;
				}
				_i3ifile = string.Format("{0}\\{1}.i3i", _destination, inf.Name.Split(new char[] {'.'})[0]);
				tbxI3I.Text = string.Format("{0}.i3i", inf.Name.Split(new char[] {'.'})[0]);
				tbx3IHeight.Text = tbxHeight.Text;
				tbx3IWidth.Text = tbxWidth.Text;
				tbxI3ISurface.Text = tbxSurface.Text;
				lblI3ISurface.Text = lblSurfaceD.Text.Split(new char[] {':'})[0];
				lbl3IDivide.Visible = true;
				tbx3IMipMap.Visible = true;
				tbx3IMipMap.Text = _i3imipmap[0].ToString();;
				lbl3IMipMap.Visible = true;
				
				cbxUseOriginal.Enabled = true;
				cbxUseOriginal.Checked = false;
				_useorigin = false;

			}
		}
		private void BtnI3IClick(object sender, EventArgs e)
		{
			int error = 0;
			OpenFileDialog dialog = new OpenFileDialog();
			dialog.Filter = "I3I File|*.i3i";
			dialog.FileName = tbxI3I.Text.Replace("new_", "");
			if (dialog.ShowDialog() == DialogResult.OK) {
				string fileName = dialog.FileName;
				FileInfo inf = new FileInfo(fileName);
				
				FileStream input = new FileStream(fileName, FileMode.Open);
				BinaryReader reader = new BinaryReader(input);
				byte[] buf = reader.ReadBytes((int)input.Length);
				if (BitConverter.ToInt16(buf, 10) != BitConverter.ToInt16(_i3isurfaces, 0))
					error = 1; // Invalid Surface
				if (BitConverter.ToInt16(buf, 8) != BitConverter.ToInt16(_i3iHeight, 0))
					error = 2; // Invalid Height
				if (BitConverter.ToInt16(buf, 6) != BitConverter.ToInt16(_i3iWidth, 0))
					error = 3; // Invalid Width
				
				if (error == 0) {
					_i3ifile = fileName;
					tbxI3I.Text = inf.Name;
				} else {
					switch (error) {
						case 1:
							MessageBox.Show("I3I Surface not fit with this DDS.\r\nPlease generate new i3i file by click \"Convert\" without check \"use original i3i file\", intead of useing original file.", "", MessageBoxButtons.OK, MessageBoxIcon.Error);
							break;
						case 2:
							MessageBox.Show("I3I Height is not equal with this DDS.\r\nPlease generate new i3i file by click \"Convert\" without check \"use original i3i file\", intead of useing original file.", "", MessageBoxButtons.OK, MessageBoxIcon.Error);
							break;
						case 3:
							MessageBox.Show("I3I Width is not equal with this DDS.\r\nPlease generate new i3i file by click \"Convert\" without check \"use original i3i file\", intead of useing original file.", "", MessageBoxButtons.OK, MessageBoxIcon.Error);
							break;
					}
					cbxUseOriginal.Checked = false;
					btnI3I.Enabled = false;
					_useorigin = false;
				}
			} else {
				_useorigin = false;
				cbxUseOriginal.Checked = false;
				btnI3I.Enabled = false;
			}
		}
		private void CbxUseOriginalCheckedChanged(object sender, EventArgs e)
		{
			if (cbxUseOriginal.Checked) {
				if (MessageBox.Show("Are you sure?\r\nOriginal i3i file will be overwriten", "", MessageBoxButtons.OKCancel, MessageBoxIcon.Question) == DialogResult.OK) {
					_useorigin = true;
					btnI3I.Enabled = true;
					btnI3I.Focus();
					BtnI3IClick(sender, e);
				} else {
					cbxUseOriginal.Checked = false;
					_useorigin = false;
				}
			} else {
				btnI3I.Enabled = false;
			}
		}
		private void BtnConvertClick(object sender, EventArgs e)
		{
			_i3iHeader = new byte[60];
			string backupedHeader = _ddsfile.Split(new char[] {'.'})[0] + ".header";
			if (_useorigin) {
				FileStream input = new FileStream(_i3ifile, FileMode.Open);
				BinaryReader reader = new BinaryReader(input);
				byte[] buf = reader.ReadBytes((int)input.Length);
				Array.Copy(buf, 0, _i3iHeader, 0, 60);
			} else if (File.Exists(backupedHeader) && MessageBox.Show("Found old i3i header, use that old i3i header?\r\nif no lets make new fresh i3i file", "", MessageBoxButtons.YesNo, MessageBoxIcon.Question) == DialogResult.Yes) {
				FileStream input = new FileStream(backupedHeader, FileMode.Open);
				BinaryReader reader = new BinaryReader(input);
				byte[] buf = reader.ReadBytes((int)input.Length);
				Array.Copy(buf, 0, _i3iHeader, 0, 60);
			}
			else {
				string surface = Encoding.Default.GetString(_ddssurfaces, 0, _ddssurfaces.Length);
				switch (surface) {
					case "DXT1":
						Array.Copy(Headers.I3IDTX1Header, 0, _i3iHeader, 0, 60);
						break;
					case "DXT3":
						Array.Copy(Headers.I3IDTX3Header, 0, _i3iHeader, 0, 60);
						break;
					case "DXT5":
						Array.Copy(Headers.I3IDTX5Header, 0, _i3iHeader, 0, 60);
						break;
				}
				Array.Copy(_i3iWidth, 0, _i3iHeader, 6, _i3iWidth.Length);
				Array.Copy(_i3iHeight, 0, _i3iHeader, 8, _i3iHeight.Length);
			}
			
			byte[] toWrite = new byte[_i3iHeader.Length + _data.Length];
			Array.Copy(_i3iHeader, 0, toWrite, 0, _i3iHeader.Length);
			Array.Copy(_data, 0, toWrite, _i3iHeader.Length, _data.Length);
			
			FileStream stream = new FileStream(_i3ifile, FileMode.Create, FileAccess.ReadWrite);
			BinaryWriter write = new BinaryWriter(stream);
			write.Write(toWrite);
			write.Close();
			stream.Close();
			MessageBox.Show("Converting done!");
		}
	}
}
