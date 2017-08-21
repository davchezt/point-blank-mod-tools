/*
 * Created by SharpDevelop.
 * User: leonardo
 * Date: 11/20/2016
 * Time: 3:22 PM
 * 
 * To change this template use Tools | Options | Coding | Edit Standard Headers.
 */
using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Diagnostics;
using System.Drawing;
using System.IO;
using System.Reflection;
using System.Text;
using System.Threading;
using System.Windows.Forms;

namespace StringPacker
{
	/// <summary>
	/// Description of MainForm.
	/// </summary>
	public partial class MainForm : Form
	{
		private string _file;
		private byte[] _txtbuff = new byte[] { 0xFF, 0xFE };
		private byte[] _byte;
		private byte[] _header;
		private int _headerend;
		private string _node;
		private string _lang;
		private byte[] _nodes;
		private byte[] _body;
		private byte[] _footer;
		private int _totaltxt;
		private int _txtstart;
		private int _txtend;
		
		private SortedList<int, int> _txt = new SortedList<int, int>();
		private Dictionary<int, byte[]> _txtbyte = new Dictionary<int, byte[]>();
		private string[] textName = new string[] {
			"AICharacters", "PCCafes", "Characters", "Equipments", "SetGoods", "Quests", "Servers", "Channels",
			"StageNames", "DEFINE", "Main", "Filters01", "Filters02", "Filters03", "Filters04", "Weapons", "StagePlaces"
		};
		
		public MainForm()
		{
			InitializeComponent();
			lblVersion.Text = "v" + appVersion;
			if (!Directory.Exists("backup"))
				Directory.CreateDirectory("backup");
			if (!Directory.Exists("output"))
				Directory.CreateDirectory("output");
			if (!Directory.Exists("output\\string"))
				Directory.CreateDirectory("output\\string");
		}
		
		// Capture CTRL+A
		private void TbxOutputKeyDown(object sender, KeyEventArgs e)
		{
			if (e.Control && e.KeyCode == Keys.A) {
				if (sender != null)
					((TextBox)sender).SelectAll();
			}
		}
		
		private delegate void AddListDelegate(string text);
		public void AddList(string text)
		{
			if (lbxList.InvokeRequired) {
				lbxList.Invoke(new AddListDelegate(AddList), text);
			} else {
				lbxList.Items.Add(text);
			}
		}
		
		private delegate void AddLogDelegate(string text);
		public void AddLog(string text)
		{
			if (lblStatus.InvokeRequired) {
				lblStatus.Invoke(new AddLogDelegate(AddLog), text);
			} else {
				lblStatus.Text = string.Format("status: {0}", text);
			}
		}
		
		private delegate void setMaxProgressDelegate(int val);
		private void setMaxProgress(int val)
		{
			if (sProgress.InvokeRequired)
				sProgress.Invoke(new setMaxProgressDelegate(setMaxProgress), val);
			else
				sProgress.Maximum = val;
		}

		private delegate void UpdateProgressDelegate(int val);
		private void UpdateProgress(int val)
		{
			if (sProgress.InvokeRequired)
				sProgress.Invoke(new UpdateProgressDelegate(UpdateProgress), val);
			else
				sProgress.Value = val;
		}
		
		private void BtnOpenClick(object sender, EventArgs e)
		{
			OpenFileDialog dialog = new OpenFileDialog();
			dialog.Filter = "String File|String.i3pack";
			dialog.FileName = "String.i3pack";
			if (dialog.ShowDialog() == DialogResult.OK) {
				tbxFile.Text = dialog.FileName;
				tbxFile.Enabled = true;
				lbxList.Enabled = true;
				btnSave.Enabled = true;
				btnApply.Enabled = true;
				_file = dialog.FileName;
				lbxList.Items.Clear();
				//if (File.Exists(_file))
				//File.Copy(_file, string.Format("backup\\backup-{0:yyyy-MM-dd-HH-mm-ss}-String.i3Pack", DateTime.Now));
				WORKER.RunWorkerAsync();
			}
		}
		
		private void Initialize()
		{
			try {
				if (!File.Exists(_file)) {
					MessageBox.Show("No String.Pack file selected!");
					return;
				}
				FileInfo inf = new FileInfo(_file);
				FileStream input = new FileStream(_file, FileMode.Open);
				BinaryReader reader = new BinaryReader(input);
				_byte = reader.ReadBytes((int)input.Length);

				_totaltxt = 0;
				
				int id = 0;
				int index = 0;
				int lastNode = 0;
				int lastOffset = 0;
				int nodeID = 0;
				string nodeSatu = "";
				bool node = true;
				bool QA = false;
				setMaxProgress(_byte.Length);
				for (int crnt = 0; crnt < _byte.Length; crnt++) {
					if ((Encoding.ASCII.GetString(_byte, crnt, 1) == "i") && (Encoding.ASCII.GetString(_byte, crnt, 10) == "i3PackNode"))
					{
						//AddLog("i3PackNode offset: " + crnt);
						crnt += 10;
						AddLog("end header at " + crnt);
						if (_byte[crnt] == 0x0D || _byte[crnt+1] == 0x0A) {
							AddLog("strating node at " + crnt);
							crnt += 2;
							lastNode = crnt;
							UpdateProgress(crnt);
						}
						lastOffset = crnt;
						_header = new byte[crnt];
						_headerend = crnt;
						Array.Copy(_byte, 0, _header, 0, crnt);
					}
					// Node Title
					if (node && _byte[crnt] == 0x0D && _byte[crnt+1] == 0x0A) {
						AddLog(string.Format("found node {0} at {1}", nodeID, Encoding.ASCII.GetString(_byte, lastNode, crnt - lastNode)));
						//AddLog(string.Format("Node {0} offset at {1}", nodeID, crnt));
						if (nodeID == 0) _lang = Encoding.ASCII.GetString(_byte, lastNode, crnt - lastNode);
						if (nodeID == 1) _node = Encoding.ASCII.GetString(_byte, lastNode, crnt - lastNode);
						//if (nodeID == 1 && (_node != null || _node != "")) AddList(_node);
						crnt += 2;
						lastNode = crnt;
						lastOffset = crnt;
						nodeID++;
						UpdateProgress(crnt);
					}
					// *QA
					if ((Encoding.ASCII.GetString(_byte, crnt, 1) == "Q") && (Encoding.ASCII.GetString(_byte, crnt, 2) == "QA") /*&& buf[crnt + 8] == 0x01 */&& (Encoding.ASCII.GetString(_byte, crnt - nodeSatu.Length, nodeSatu.Length) == nodeSatu))
					{
						AddLog("found QA offset at " + crnt);
						if (_node != "") {
							AddLog(Encoding.ASCII.GetString(_byte, crnt - (nodeSatu.Length + 1), nodeSatu.Length + 1));
						}
						node = false;
						QA = true;
						crnt += 2;
						lastOffset = crnt;
						UpdateProgress(crnt);
					}
					// *TRN
					if ((Encoding.ASCII.GetString(_byte, crnt, 1) == "T") && (Encoding.ASCII.GetString(_byte, crnt, 4) == "TRN3"))
					{
						AddLog(string.Format("found TRN3 #{0} offset at {1}", id, crnt));
						if ((Encoding.ASCII.GetString(_byte, crnt-_node.Length, _node.Length) == _node)) {
							_nodes = new byte[_txtstart-_headerend];
							Array.Copy(_byte, _headerend, _nodes, 0, _txtstart-_headerend);
							
							_txtend = crnt-_node.Length;
							_footer = new byte[_byte.Length-_txtend];
							Array.Copy(_byte, _txtend, _footer, 0, _byte.Length-_txtend);
							AddLog("hit end point");
						}
						node = false;
						id++;
						crnt += 4;
						lastOffset = crnt;
						if (QA && _byte[crnt] == 0xFF && _byte[crnt + 1] == 0xFE) {
							crnt += 2;
							lastOffset = crnt;
						}
						UpdateProgress(crnt);
					}
					// Text
					if (QA && _byte[crnt] == 0xFF && _byte[crnt + 1] == 0xFE) {
						AddLog(string.Format("found string  #{1} at {0}", (crnt+2), (_totaltxt + 1)));
						AddList(string.Format("{0}_{1}_{2}", _lang, _node, textName[index]));
						crnt += 2;
						if (_totaltxt == 0) _txtstart = crnt;
						_totaltxt++;
						if (_txt.ContainsKey(index))
							_txt.Remove(index);
						_txt.Add(index, crnt);
						index++;
						lastOffset = crnt;
						UpdateProgress(crnt);
					}
				}
				reader.Close();
				input.Close();
			} catch (Exception ex) {
				//MessageBox.Show(string.Format("Error: {0}", ex.Message));
			}
		}
		
		private void showText(int start, int length)
		{
			tbxEditor.Enabled = true;
			tbxEditor.Text = Encoding.Unicode.GetString(_byte, start, length);
		}
		
		private void showEditor(int index)
		{
			tbxEditor.Text = Encoding.Unicode.GetString(_txtbyte[index], 0, _txtbyte[index].Length-2);
			AddLog(string.Format("selected {0}_{1}_{2}", _lang, _node, textName[index]));
		}
		
		private void WORKERDoWork(object sender, DoWorkEventArgs e)
		{
			BackgroundWorker bw = sender as BackgroundWorker;
			AddLog("initializing...");
			Initialize();
		}
		
		private void WORKERRunWorkerCompleted(object sender, RunWorkerCompletedEventArgs e)
		{
			if(lbxList.Items.Count > 0) {
			setMaxProgress(100);
			UpdateProgress(100);
			AddLog("unpacked done.");
			byte[] buff;
			int offset;
			int length;
			for (int index = 0; index < lbxList.Items.Count; index++) {
				if (index == (lbxList.Items.Count - 1)) {
					AddLog("backing-up index " + index);
					length = _txtend - _txt[index];
					buff = new byte[length + 4];
					Array.Copy(_txtbuff, 0, buff, 0, 2);
					Array.Copy(_byte, _txt[index], buff, 2, length);
					Array.Copy(_txtbuff, 0, buff, buff.Length-2, 2);
					if (_txtbyte.ContainsKey(index))
						_txtbyte.Remove(index);
					_txtbyte.Add(index, buff);
				}
				else {
					AddLog("backing-up index " + index);
					length = _txt[index + 1] - _txt[index];
					buff = new byte[length + 2];
					Array.Copy(_txtbuff, 0, buff, 0, 2);
					Array.Copy(_byte, _txt[index], buff, 2, length);
					if (_txtbyte.ContainsKey(index))
						_txtbyte.Remove(index);
					_txtbyte.Add(index, buff);
				}
			}
			showEditor(0);
			lbxList.SelectedIndex = 0;
			lblInfo.Visible = true;
			setMaxProgress(100);
			Thread.Sleep(500);
			tbxEditor.Enabled = true;
			AddLog("done.");
			UpdateProgress(0);
			} else {
				MessageBox.Show("Pack file is not supported!.\r\nOnly newest PB version are supported");
				AddLog("aborted");
			}
		}
		
		private void SaveAsToolStripMenuItemClick(object sender, EventArgs e)
		{
			int index = lbxList.SelectedIndex;
			string textTowrite = "";
			string textTowriteb = "";
			SaveFileDialog dialog = new SaveFileDialog();
			dialog.Filter = "Text Document|*.txt";
			dialog.FileName = string.Format("{0}_{1}_{2}.txt", _lang, _node, textName[index]);
			//dialog.CheckFileExists = true;
			dialog.InitialDirectory = Application.StartupPath + "\\output\\string";
			if (dialog.ShowDialog() == DialogResult.OK) {
				// Back Up Original Text
				if (lbxList.SelectedIndex == _totaltxt-1) {
					textTowriteb = Encoding.Unicode.GetString(_byte, _txt[index], (_txtend - _txt[index]));
				} else {
					textTowriteb = Encoding.Unicode.GetString(_byte, _txt[index], (_txt[index+1] - _txt[index]));
				}
				File.WriteAllText(string.Format("backup\\{0}_{1}_{2}.txt", _lang, _node, textName[index]), textTowriteb, Encoding.Unicode);
				textTowrite = Encoding.Unicode.GetString(_txtbyte[index], 0, _txtbyte[index].Length-2);
				File.WriteAllText(dialog.FileName, textTowrite, Encoding.Unicode);
				MessageBox.Show(string.Format("File saved at {0}", dialog.FileName), "Success!", MessageBoxButtons.OK, MessageBoxIcon.Information);
			}
		}
		
		private void ReplaceWIthToolStripMenuItemClick(object sender, EventArgs e)
		{
			int index = lbxList.SelectedIndex;
			//string textTowrite = "";
			OpenFileDialog dialog = new OpenFileDialog();
			dialog.Filter = "Text Document|*.txt";
			dialog.FileName = string.Format("{0}_{1}_{2}.txt", _lang, _node, textName[index]);
			if (dialog.ShowDialog() == DialogResult.OK) {
				string fileName = dialog.FileName;
				byte[] newByte;
				FileInfo inf = new FileInfo(fileName);
				try {
					FileStream input = new FileStream(fileName, FileMode.Open);
					BinaryReader reader = new BinaryReader(input);
					byte[] buf = reader.ReadBytes((int)input.Length);
					if (buf[buf.Length-1] == 0xFE && buf[buf.Length-2] == 0xFF) {
						newByte = new byte[buf.Length];
						Array.Copy(buf, 0, newByte, 0, buf.Length);
					} else {
						newByte = new byte[buf.Length + 2];
						Array.Copy(buf, 0, newByte, 0, buf.Length);
						Array.Copy(_txtbuff, 0, newByte, newByte.Length - 2, 2);
					}
					if(_txtbyte.ContainsKey(index)) {
						_txtbyte[index] = newByte;
						tbxEditor.Clear();
						showEditor(index);
					}
				} catch(Exception ex) {
					MessageBox.Show(string.Format("Error: {0}", ex.Message));
				}
			}
		}
		
		private void BtnApplyClick(object sender, EventArgs e)
		{
			int index = lbxList.SelectedIndex;
			string content = tbxEditor.Text;
			byte[] newContent = Encoding.Unicode.GetBytes(content);
			byte[] newByte;// = new byte[newContent.Length + 2];
			//Array.Copy(newContent, 0, newByte, 0, newContent.Length);
			//Array.Copy(_txtbuff, 0, newByte, newByte.Length - 2, 2);
			if (newContent[newContent.Length-1] == 0xFE && newContent[newContent.Length-2] == 0xFF) {
				newByte = new byte[newContent.Length];
				Array.Copy(newContent, 0, newByte, 0, newContent.Length);
			} else {
				newByte = new byte[newContent.Length + 2];
				Array.Copy(newContent, 0, newByte, 0, newContent.Length);
				Array.Copy(_txtbuff, 0, newByte, newByte.Length - 2, 2);
			}
			if(_txtbyte.ContainsKey(index)) {
				if (BitConverter.ToString(_txtbyte[index]) == BitConverter.ToString(newByte)) {
					MessageBox.Show("You have no changes on this file.");
				} else {
					_txtbyte[index] = newByte;
					AddLog(string.Format("file {0}_{1}_{2} updated.", _lang, _node, textName[index]));
					MessageBox.Show("File on stack updated.", "Success!", MessageBoxButtons.OK, MessageBoxIcon.Information);
					tbxEditor.Clear();
					showEditor(index);
				}
			}
		}

		private void LbxListSelectedValueChanged(object sender, EventArgs e)
		{
			int index = lbxList.SelectedIndex;
			// Ver 1
			/*if (lbxList.SelectedIndex == _totaltxt-1) {
				showText(Convert.ToInt32(_txt[lbxList.SelectedIndex]), Convert.ToInt32(_txtend - _txt[lbxList.SelectedIndex]));
			} else {
				showText(Convert.ToInt32(_txt[lbxList.SelectedIndex]), Convert.ToInt32(_txt[lbxList.SelectedIndex+1] - _txt[lbxList.SelectedIndex]));
			}*/
			// Ver 2
			showEditor(index);
		}
		
		private void Anu()
		{
			/*FileInfo inf = new FileInfo(_file);
			FileStream streamH = new FileStream("output\\" + inf.Name.Split(new char[] {'.'})[0] + "_Header.txt", FileMode.Create, FileAccess.ReadWrite);
			BinaryWriter writerH = new BinaryWriter(streamH);
			writerH.Write(_header);
			writerH.Close();
			streamH.Close();*/
			
		}
		private void BtnSaveClick(object sender, EventArgs e)
		{
			int packLength = 0;
			byte [] pack;
			int packOffset = 0;
			int bodyLength = 0;
			int offset = 0;
			SaveFileDialog dialog = new SaveFileDialog();
			dialog.Filter = "String File|*.i3pack";
			dialog.FileName = string.Format("{0:yyyy-MM-dd-HH-mm-ss}-String.i3Pack", DateTime.Now);
			//dialog.CheckFileExists = true;
			dialog.InitialDirectory = Application.StartupPath + "\\output";
			if (dialog.ShowDialog() == DialogResult.OK) {
				packLength += _header.Length;
				packLength += _nodes.Length - 2;
				for (int i = 0; i < _txtbyte.Count; i++) {
					bodyLength += _txtbyte[i].Length - 2;
				}
				_body = new byte[bodyLength];
				for (int b = 0; b < _txtbyte.Count; b++) {
					int length = _txtbyte[b].Length - 2;
					Array.Copy(_txtbyte[b], 0, _body, offset, length);
					offset += length;
				}
				packLength += _body.Length;
				packLength += _footer.Length;
				pack = new byte[packLength];
				Array.Copy(_header, 0, pack, packOffset, _header.Length);
				packOffset += _header.Length;
				Array.Copy(_nodes, 0, pack, packOffset, _nodes.Length-2);
				packOffset += _nodes.Length-2;
				Array.Copy(_body, 0, pack, packOffset, _body.Length);
				packOffset += _body.Length;
				Array.Copy(_footer, 0, pack, packOffset, _footer.Length);
				packOffset += _footer.Length;
				
				FileStream stream = new FileStream(dialog.FileName, FileMode.Create, FileAccess.ReadWrite);
				BinaryWriter write = new BinaryWriter(stream);
				write.Write(pack);
				write.Close();
				stream.Close();
				
				//MessageBox.Show("Pack Length: " + (double)pack.Length/1000 + "B" + " from original " + (double)_byte.Length/1000 + "B");
				MessageBox.Show("File saved at " + dialog.FileName, "Success!", MessageBoxButtons.OK, MessageBoxIcon.Information);
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
		
		private void TbxEditorTextChanged(object sender, EventArgs e)
		{
			lblEditorInfo.Visible = true;
		}
		
		private void ExportAllToolStripMenuItemClick(object sender, EventArgs e)
		{
			string destination;
			FolderBrowserDialog dialog = new FolderBrowserDialog();
			dialog.SelectedPath = Application.StartupPath + "\\backup";
			if (dialog.ShowDialog() == DialogResult.OK) {
				destination = dialog.SelectedPath;
				setMaxProgress(_txtbyte.Count);
				for (int i = 0; i < _txtbyte.Count; i++) {
					string fileName = string.Format("{0}_{1}_{2}.txt", _lang, _node, textName[i]);
					string content = Encoding.Unicode.GetString(_txtbyte[i], 0, _txtbyte[i].Length-2);
					File.WriteAllText(destination + "\\" + fileName, content, Encoding.Unicode);
					AddLog("saving " + fileName);
					UpdateProgress(i+1);
				}
				if (MessageBox.Show("All files saved successfully!\r\nOpen output folder now?", "Info", MessageBoxButtons.OKCancel, MessageBoxIcon.Information) == DialogResult.OK) {
					setMaxProgress(100);
					UpdateProgress(0);
					string strArgs = string.Format("/e,{0}", destination);
					Process.Start("explorer.exe", strArgs);
				} else {
					setMaxProgress(100);
					UpdateProgress(0);					
				}
			}
		}
	}
}
