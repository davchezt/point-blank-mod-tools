/*
 * Created by SharpDevelop.
 * User: leonardo
 * Date: 11/21/2016
 * Time: 7:03 PM
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

namespace I3I_Tools
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
		/// Offset: 10
		/// (short) 1665 = Four CC 4 bits: DTX1
		/// (short) 1538 = Four CC 8 bits: DTX3
		/// (short) 1540 = Four CC 8 bits: DTX5
		/// </summary>
		private byte[] _surfaces = new byte[2];
		
		private byte[] _mipmap = new byte[1];
		
		private byte[] _data;
		private string _file;
		private bool _convertable;

		public MainForm()
		{
			InitializeComponent();
			lblVersion.Text = "v" + appVersion;
		}
		private void BtnOpenClick(object sender, EventArgs e)
		{
			//byte[] header;
			OpenFileDialog dialog = new OpenFileDialog();
			dialog.Filter = "I3I File|*.i3i";
			if (dialog.ShowDialog() == DialogResult.OK) {
				string fileName = dialog.FileName;
				FileInfo inf = new FileInfo(fileName);
				_file = inf.Name;
				FileStream input = new FileStream(fileName, FileMode.Open);
				BinaryReader reader = new BinaryReader(input);
				byte[] buf = reader.ReadBytes((int)input.Length);
				
				Array.Copy(buf, 8, _i3iWidth, 0, 2);
				Array.Copy(buf, 6, _i3iHeight, 0, 2);
				// Reversing From i3i
				Array.Copy(_i3iWidth, 0, _ddsHeight, 0, 2);
				Array.Copy(_i3iHeight, 0, _ddsWidth, 0, 2);
				
				Array.Copy(buf, 10, _surfaces, 0, 2);
				Array.Copy(buf, 24, _mipmap, 0, 1);
				
				_i3iHeader = new byte[60];
				Array.Copy(buf, 0, _i3iHeader, 0, 60);
				
				_data = new byte[buf.Length - 60];
				Array.Copy(buf, 60, _data, 0, buf.Length - 60);
				
				for (int crnt = 60; crnt < 120; crnt++) {
					if ((Encoding.UTF8.GetString(buf, crnt, 1) == ".") && (Encoding.UTF8.GetString(buf, crnt, 4) == ".tga"))
						lbxDetail.Items.Add("File Type\t: TGA File " + BitConverter.ToInt16(_surfaces, 0));
				}
				input.Close();
				reader.Close();
				
				lbxDetail.Items.Clear();
				tbxFile.Enabled = true;
				tbxFile.Text = inf.Name; //fileName;
				
				short surface = BitConverter.ToInt16(_surfaces, 0);
				switch (surface) {
					case (short)1665:
						gbxDetails.ForeColor = SystemColors.ControlText;
						tbxSurface.Text = "DTX1";
						lblSurfaceD.Text = "Four CC 4 bits";
						_convertable = true;
						break;
					case (short)1538:
						gbxDetails.ForeColor = SystemColors.ControlText;
						tbxSurface.Text = "DTX3";
						lblSurfaceD.Text = "Four CC 8 bits";
						_convertable = true;
						break;
					case (short)1540:
						gbxDetails.ForeColor = SystemColors.ControlText;
						tbxSurface.Text = "DTX5";
						lblSurfaceD.Text = "Four CC 8 bits";
						_convertable = true;
						break;
					default:
						gbxDetails.ForeColor = SystemColors.ControlDarkDark;
						tbxSurface.Text = "NONE";
						lblSurfaceD.Text = "Unknown surface volume";
						_convertable = false;
						break;
				}
				tbxWidthD.Text = BitConverter.ToInt16(_i3iWidth, 0).ToString();
				tbxHeightD.Text = BitConverter.ToInt16(_i3iHeight, 0).ToString();
				
				lblDivide.Visible = true;
				lblMipMap.Visible = true;
				tbxMipMap.Visible = true;
				tbxMipMap.Text = _mipmap[0].ToString();
				
				lblP1.Visible = true;
				tbxHeight.Text = BitConverter.ToInt16(_i3iHeight, 0).ToString();
				lblP2.Visible = true;
				tbxWidth.Text = BitConverter.ToInt16(_i3iWidth, 0).ToString();
				
				btnConvert.Enabled |= _convertable;
				
				if (_convertable) {
					lblInfo.BackColor = Color.GhostWhite;
					lblInfo.ForeColor = Color.Green;
					lblInfo.Text = "info: file supported to be converted.";
					lblInfo.Visible = true;
				} else {
					lblInfo.BackColor = Color.GhostWhite;
					lblInfo.ForeColor = Color.Red;
					lblInfo.Text = "warning: no surface was detected.";
					lblInfo.Visible = true;
				}
				
				lbxDetail.Items.Add("File\t: " + inf.Name);
				lbxDetail.Items.Add("Surface\t: " + tbxSurface.Text);
				lbxDetail.Items.Add("Volume\t: " + lblSurfaceD.Text);
			}
		}
		private void BtnConvertClick(object sender, EventArgs e)
		{
			short surface = BitConverter.ToInt16(_surfaces, 0);
			if (surface == 1665 || surface == 1538 || surface == 1540) {
				_ddsHeader = new byte[128];
				switch (surface) {
					case (short)1665:
						Array.Copy(Headers.DDSDTX1Header, 0, _ddsHeader, 0, 128);
						break;
					case (short)1538:
						Array.Copy(Headers.DDSDTX3Header, 0, _ddsHeader, 0, 128);
						break;
					case (short)1540:
						Array.Copy(Headers.DDSDTX5Header, 0, _ddsHeader, 0, 128);
						break;
				}
				Array.Copy(_ddsHeight, 0, _ddsHeader, 12, 2);
				//byte[] fill = new byte[] { 0x00, 0x00 };
				//Array.Copy(fill, 0, _ddsHeader, 14, 2);
				Array.Copy(_ddsWidth, 0, _ddsHeader, 16, 2);
				
				SaveFileDialog dialog = new SaveFileDialog();
				dialog.Filter = "DirectDraw Surface|*.dds";
				dialog.FileName = string.Format("new_{0}.dds", _file.Split(new char[] {
				                                                           	'.'
				                                                           })[0]);
				if (dialog.ShowDialog() == DialogResult.OK) {
					// Back-Up Header
					string headerFile = string.Format("{0}.header", dialog.FileName.Substring(0, dialog.FileName.Length - 4));
					FileStream streamHeader = new FileStream(headerFile, FileMode.Create, FileAccess.ReadWrite);
					BinaryWriter writeHeader = new BinaryWriter(streamHeader);
					writeHeader.Write(_i3iHeader);
					writeHeader.Close();
					streamHeader.Close();
					
					byte[] toWrite = new byte[_ddsHeader.Length + _data.Length];
					Array.Copy(_ddsHeader, 0, toWrite, 0, _ddsHeader.Length);
					Array.Copy(_data, 0, toWrite, _ddsHeader.Length, _data.Length);
					
					FileStream stream = new FileStream(dialog.FileName, FileMode.Create, FileAccess.ReadWrite);
					BinaryWriter write = new BinaryWriter(stream);
					write.Write(toWrite);
					write.Close();
					stream.Close();
					
					//MessageBox.Show("Converted to " + dialog.FileName);
					MessageBox.Show("Converting done!");
				}
			} else {
				MessageBox.Show("Invalid Header, Only DirectSurface are Supported!");
			}
		}
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
	}
}
