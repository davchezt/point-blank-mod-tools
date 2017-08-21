/*
 * Created by SharpDevelop.
 * User: leonardo
 * Date: 11/23/2016
 * Time: 12:54 PM
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
using System.Windows.Forms;
using i3Pack_Tools;

namespace i3Pack_Tools
{
	partial class MainForm : Form
	{
		Crc32 crc = new Crc32();
		About aForm = new About();
		private SortedList<int, Model> _anu = new SortedList<int, Model>();
		private Dictionary<int, byte[]> _bodyPack = new Dictionary<int, byte[]>();
		
		private Dictionary<int, int> _breakPoint = new Dictionary<int, int>();
		private Dictionary<int, byte[]> _bodyByte = new Dictionary<int, byte[]>();
		
		private SortedList<int, int> _trn = new SortedList<int, int>();
		
		private bool _contentStarted, _nodeEnd, _QA;
		private int _contentStart, _contentEnd, _contentId, _infOffset, _infcOffset;
		
		// Offset Collections
		private SortedList<int, string> _nodes = new SortedList<int, string>();
		private int _nodeStart, _nodeStop, _nodeLength, _nodeId;
		
		private uint _oggPage;
		
		private string _packFile, _outputFile;
		private byte[] _bytes, _packHeader, _packBody, _repacked;
		
		private DateTime _times;

		private string[] textName = Strings.textName;
		
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
			lblVersion.Text = string.Format("v{0}", appVersion);
			lbxList.Enabled = false;
			btnUnpack.BackColor = btnUnpack.Enabled ? SystemColors.Window : SystemColors.Control;
			btnRepack.BackColor = btnRepack.Enabled ? SystemColors.Window : SystemColors.Control;
		}

		protected override void OnClosing(CancelEventArgs e)
		{
			//this.Hide();

			e.Cancel = true;
			//base.OnClosing(e);
			if (MessageBox.Show("Exit Now?", "", MessageBoxButtons.OKCancel, MessageBoxIcon.Question) == DialogResult.OK) {
				Application.Exit();
			}
		}
		private delegate void AddTreeDelegate(string text);
		public void AddTree(string text)
		{
			if (trView.InvokeRequired) {
				trView.Invoke(new AddTreeDelegate(AddTree), text);
			} else {
				trView.Nodes.Add(text);
			}
		}
		
		private delegate void AddSubTreeDelegate(string text, bool insub, bool insub1, bool insub2);
		public void AddSubTree(string text, bool insub, bool insub1, bool insub2)
		{
			if (trView.InvokeRequired) {
				trView.Invoke(new AddSubTreeDelegate(AddSubTree), text, insub, insub1 ,insub2);
			} else {
				if (insub)
					trView.Nodes[0].Nodes[0].Nodes.Add(text);
				else if (insub1)
					trView.Nodes[0].Nodes[0].Nodes[0].Nodes.Add(text);
				else if (insub2)
					trView.Nodes[0].Nodes[0].Nodes[0].Nodes[0].Nodes.Add(text);
				else
					trView.Nodes[0].Nodes.Add(text);
			}
		}
		
		/// <summary>
		/// Image Index
		/// </summary>
		/// <param name="text">judul</param>
		/// <param name="img">img 0 = txt, 1 = i3i, 2 = dds, 3 = wav/ogg</param>
		private delegate void AddViewDelegate(string text, int img);
		public void AddView(string text, int img)
		{
			if (lsView.InvokeRequired) {
				lsView.Invoke(new AddViewDelegate(AddView), text, img);
			} else {
				lsView.Items.Add(text, img);
			}
		}

		private delegate void AddSubViewDelegate(int index, string text);
		public void AddSubView(int index, string text)
		{
			if (lsView.InvokeRequired) {
				lsView.Invoke(new AddSubViewDelegate(AddSubView), index, text);
			} else {
				lsView.Items[index].SubItems.Add(text);
			}
		}
		
		private delegate void AddListDelegate(string text);
		public void AddList(string text)
		{
			if (lbxList.InvokeRequired) {
				lbxList.Invoke(new AddListDelegate(AddList), text);
			} else {
				lbxList.Items.Add("log> " + text);
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
			if (workProgress.InvokeRequired)
				workProgress.Invoke(new setMaxProgressDelegate(setMaxProgress), val);
			else
				workProgress.Maximum = val;
		}

		private delegate void UpdateProgressDelegate(int val);
		private void UpdateProgress(int val)
		{
			if (workProgress.InvokeRequired)
				workProgress.Invoke(new UpdateProgressDelegate(UpdateProgress), val);
			else
				workProgress.Value = val;
		}
		
		private void WORKERDoWork(object sender, DoWorkEventArgs e)
		{
			BackgroundWorker bw = sender as BackgroundWorker;
			_times = DateTime.Now;
			Working();
		}
		
		private void WORKERRunWorkerCompleted(object sender, RunWorkerCompletedEventArgs e)
		{
			DateTime after = DateTime.Now;
			long finih = ((after.ToFileTime() - _times.ToFileTime()) / 1000) / 1000;
			string excute = finih.ToString("D");
			
			AddLog(string.Format("done. time execution: {0} miliseconds.", excute));
			AddList("scaning complite.");
			AddList(string.Format("time execution: {0} miliseconds.", excute));
			
			setMaxProgress(100);
			UpdateProgress(100);
			lsView.Enabled = true;
			lsView.ForeColor = SystemColors.WindowText;
			trView.Enabled = true;
			if (trView.Nodes.Count != 0) {
				//trView.ExpandAll();
				//trView.Focus();
			}
			pnlIfno.Enabled = true;
			lblInfos.Text = String.Format("Found {0} i3PackNode path, with {1} files inside", _nodes.Count, _anu.Count);
			initializeView();
		}
		
		private void registerPack()
		{
			// Assign Header block
			_packHeader = new byte[ _breakPoint[0]];
			Array.Copy(_bytes, 0, _packHeader, 0, _breakPoint[0]);
			int length = 0;
			for (int i = 0; i < _breakPoint.Count; i++) {
				Model item = getItemByOffset(_breakPoint[i]);
				if (i == _breakPoint.Count - 1) {
					length = _bytes.Length - _breakPoint[_breakPoint.Count - 1];
					byte[] lb = new byte[length];
					Array.Copy(_bytes, _breakPoint[i], lb, 0, length);
					_bodyByte.Add(i, lb);
				}
				else {
					if (item != null) {
						length = _bodyPack[item.getItemID()].Length;
						_bodyByte.Add(i, _bodyPack[item.getItemID()]);
					}
					else {
						length = _breakPoint[i + 1] - _breakPoint[i];
						byte[] buf = new byte[length];
						Array.Copy(_bytes, _breakPoint[i], buf, 0, length);
						_bodyByte.Add(i, buf);
					}
				}
			}

			int id = 0;
			int tottal = 0;
			for (int i = 0; i < _bodyByte.Count; i++) {
				tottal += _bodyByte[i].Length;
			}
			_packBody = new byte[tottal];
			for (int i = 0; i < _bodyByte.Count; i++) {
				Array.Copy(_bodyByte[i], 0, _packBody, id, _bodyByte[i].Length);
				id += _bodyByte[i].Length;
			}
			_repacked = new byte[_packHeader.Length + _packBody.Length];
			Array.Copy(_packHeader, 0, _repacked, 0, _packHeader.Length);
			Array.Copy(_packBody, 0, _repacked, _packHeader.Length, _packBody.Length);
		}
		
		private void initializeView()
		{
			/*
			if (lbxList.InvokeRequired) {
				BeginInvoke((Action)delegate { lbxList.Items.Clear(); });
			}
			else {
				lbxList.Items.Clear();
			}*/
			for (int i = 0; i < _trn.Count; i++) {
				foreach (Model item in _anu.Values) {
					if (item.getItemNode() == i) {
						/*
						AddList("==================================");
						AddList("item ID: " + item.getItemID().ToString("X2"));
						AddList("item Offset: " + item.getItemOffset().ToString("X"));
						AddList("item Type: " + item.getItemType().ToString("X2"));
						AddList("item Node: " + item.getItemNode().ToString("X2"));
						AddList("item Node Name: " + _nodes[item.getItemNode()]);
						AddList("==================================");
						 */
						if (item.getItemID() < _anu.Values.Count - 1 &&
						    item.getItemNode() != _anu[item.getItemID() + 1].getItemNode()) {
							AddList("Nex offset " + _trn[_anu[item.getItemID() + 1].getItemNode()].ToString("X") + " crnt: " + item.getItemOffset().ToString("X"));
						}
						int range = 0;
						byte[] data;
						
						if (_anu.ContainsKey(item.getItemID() + 1)) {
							if (item.getItemNode() != _anu[item.getItemID() + 1].getItemNode()) {
								int id =  _anu[item.getItemID() + 1].getItemNode();
								range =  _trn[id] - item.getItemOffset();
							} else {
								range = _anu[item.getItemID() + 1].getItemOffset() - item.getItemOffset();
							}
						}
						else {
							range = _trn[item.getItemNode() + 1] - item.getItemOffset();
						}
						data = new byte[range];
						Array.Copy(_bytes, item.getItemOffset(), data, 0, range);
						_bodyPack.Add(item.getItemID(), data);
						/*switch(item.getItemType()) {
							case 0:
								AddView(string.Format("{0}_{1}_{2}.i3R", _nodes[item.getItemNode()], _nodes[item.getItemNode() + 1], item.getItemID()), 0);
								break;
							case 1:
								AddView(string.Format("{0}_{1}_{2}.txt", _nodes[item.getItemNode()], _nodes[item.getItemNode() + 1], textName[item.getItemID()]), 0);
								break;
							case 2:
								AddView(string.Format("{0}_{1}_{2}.i3i", _nodes[item.getItemNode()], _nodes[item.getItemNode() + 1], item.getItemID()), 1);
								break;
							case 3:
								AddView(string.Format("{0}_{1}_config.txt", _nodes[item.getItemNode()], _nodes[item.getItemNode() + 1]), 0);
								break;
							case 4:
								AddView(string.Format("{0}_{1}_{2}.wav", _nodes[item.getItemNode()], _nodes[item.getItemNode() + 1], item.getItemID()), 3);
								break;
							case 5:
								AddView(string.Format("{0}_{1}_{2}.ogg", _nodes[item.getItemNode()], _nodes[item.getItemNode() + 1], item.getItemID()), 3);
								break;
							case 6:
								AddView(string.Format("{0}_{1}_{2}.dds", _nodes[item.getItemNode()], _nodes[item.getItemNode() + 1], item.getItemID()), 2);
								break;
						}
						string size = "";
						if (range / 1000 == 0)
							size = "1 KB";
						else
							size = (range / 1000).ToString("D") + " KB";
						
						AddSubView(item.getItemID(), size);//Math.Round(size) + "KB" // ((double)range / 1000) + "KB"
						AddSubView(item.getItemID(), item.getItemOffset().ToString("X"));
						AddSubView(item.getItemID(), crc.Get(_bodyPack[item.getItemID()]).ToUpper());*/
					}
				}
			}
		}
		
		private void getListView(int nodeID, string nodeName)
		{
			lsView.Items.Clear();
			int listID = 0;
			foreach (Model item in _anu.Values) {
				if (item.getItemNode() == nodeID) {
					switch(item.getItemType()) {
						case 0:
							AddView(string.Format("{0}_{1}_{2}.i3s", _nodes[item.getItemNode()], _nodes[item.getItemNode() + 1], item.getItemID()), 0);
							break;
						case 1:
							AddView(string.Format("{0}_{1}_{2}_{3}.txt", _nodes[item.getItemNode()], _nodes[item.getItemNode() + 1], textName[item.getItemID()], item.getItemID()), 5);
							break;
						case 2:
							AddView(string.Format("{0}_{1}_{2}.i3i", _nodes[item.getItemNode()], _nodes[item.getItemNode() + 1], item.getItemID()), 1);
							break;
						case 3:
							AddView(string.Format("{0}_{1}_config_{2}.txt", _nodes[item.getItemNode()], _nodes[item.getItemNode() + 1], item.getItemID()), 5);
							break;
						case 4:
							AddView(string.Format("{0}_{1}_{2}.wav", _nodes[item.getItemNode()], _nodes[item.getItemNode() + 1], item.getItemID()), 3);
							break;
						case 5:
							AddView(string.Format("{0}_{1}_{2}.ogg", _nodes[item.getItemNode()], _nodes[item.getItemNode() + 1], item.getItemID()), 6);
							break;
						case 6:
							AddView(string.Format("{0}_{1}_{2}.dds", _nodes[item.getItemNode()], _nodes[item.getItemNode() + 1], item.getItemID()), 2);
							break;
					}
					string size = "";
					int range = _bodyPack[item.getItemID()].Length;
					if (range / 1000 == 0)
						size = "1 KB";
					else
						size = (range / 1000).ToString("D") + " KB";
					
					AddSubView(listID, size);//Math.Round(size) + "KB" // ((double)range / 1000) + "KB"
					AddSubView(listID, item.getItemOffset().ToString("X"));
					AddSubView(listID, crc.Get(_bodyPack[item.getItemID()]).ToUpper());
					listID++;
				}
			}
			lblInfos.Visible = true;
			Info.Text = "Node Info";
			if (nodeName == "/") {
				nodeName = "Root";
			}
			btnUnpack.Enabled = listID != 0 ? true : false;
			btnUnpack.BackColor = btnUnpack.Enabled ? SystemColors.Window : SystemColors.Control;
			btnRepack.BackColor = btnRepack.Enabled ? SystemColors.Window : SystemColors.Control;
			
			lblInfos.Text = nodeName;
			lblInfos.Text += string.Format(" —— node index \x23{0}\r\n", nodeID);
			lblInfos.Text += string.Format("{0} file(s) listed on this node", listID);			
		}
		
		private string getString(byte[] buff, int index, int count)
		{
			if (buff.Length < index || buff.Length < count) {
				return string.Empty;
			}
			else {
				return Encoding.ASCII.GetString(buff, index, count);
			}
		}
		
		private void Working()
		{
			if (_packFile != "") {
				try {
					if (!File.Exists(_packFile)) {
						MessageBox.Show("i3Pack file not found!");
						return;
					}
					FileInfo inf = new FileInfo(_packFile);
					FileStream input = new FileStream(_packFile, FileMode.Open);
					BinaryReader reader = new BinaryReader(input);
					
					byte[] buff = reader.ReadBytes((int)input.Length);
					_bytes = buff;
					
					setMaxProgress(buff.Length);
					int nodeId = 0, nodeStart = 0, nodeLength = 0, nodeStop = 0;
					int trnID = 0, i3iID = 0, ddsID = 0, txtID = 0, wavID = 0, oggID = 0;
					
					bool endNode = false;
					uint oggPage = 0;
					int lastTrn = 0;
					_contentId = 0;
					_infcOffset = 0;
					_infOffset = 0;
					
					_QA = false;
					
					int breakPoint = 0;
					for (int curentByte = 0; curentByte < buff.Length; curentByte++)
					{
						if ((Equals(getString(buff, curentByte, 1), "i")) &&
						    (Equals(getString(buff, curentByte, 10), "i3PackNode")))
						{
							curentByte += 10;
							nodeStart = curentByte;
							
							AddList(string.Format("reading i3PackNode at {0}", curentByte.ToString("X")));
							AddLog(string.Format("found i3PackNode at {0}", curentByte.ToString("X")));
							
							UpdateProgress(curentByte);
						}
						else if(!endNode && (buff[curentByte] == 0x0D) &&
						        (buff[curentByte + 1] == 0x0A))
						{
							nodeLength = (curentByte - nodeStart) - 2;
							AddList("node #"+nodeId+" text at " + curentByte.ToString("X") + ": " + getString(buff, nodeStart + 2, nodeLength));
							AddLog("node text at " + curentByte.ToString("X") + ": " + getString(buff, nodeStart + 2, nodeLength));
							
							_nodes.Add(nodeId, getString(buff, nodeStart + 2, nodeLength));

							nodeStart = curentByte;
							nodeId++;

							curentByte += 2;
							UpdateProgress(curentByte);
						}
						else if (!endNode && (nodeId != 0) &&
						         (buff[curentByte] == 0x00) &&
						         (buff[curentByte + 1] == 0x00))
						{
							nodeLength = curentByte - (nodeStart + 2);
							AddList("node #"+nodeId+" text at " + curentByte.ToString("X") + ": " + getString(buff, nodeStart + 2, nodeLength));
							AddLog("node text at " + curentByte.ToString("X") + ": " + getString(buff, nodeStart + 2, nodeLength));
							
							_nodes.Add(nodeId, getString(buff, nodeStart + 2, nodeLength));
							if (_nodes.ContainsKey(4)) {
								string rootNode = "";
								if (_nodes[4].Contains(":/")) {
									string[] anu = _nodes[4].Split(new char[] {'/'});
									rootNode = anu[anu.Length - 1];
									AddTree(rootNode);
								}
								else {
									if (Equals(_nodes[4], "/"))
										AddTree("Root");
									else
										AddTree(_nodes[4]);
								}
								
								AddSubTree(_nodes[3], false, false, false);
								AddSubTree(_nodes[2], true, false, false);
								AddSubTree(_nodes[1], false, true, false);
								AddSubTree(_nodes[0], false, false, true);
							}
							else if (_nodes.ContainsKey(3)) {
								/*if (_nodes[3].Contains(_nodes[0] + "QA")) {
									AddTree(_nodes[2]);
									AddSubTree(_nodes[1], false, false, false);
									AddSubTree(_nodes[0], true, false, false);
								}
								else {*/
								string rootNode = "";
								if (_nodes[3].Contains(":/")) {
									string[] anu = _nodes[3].Split(new char[] {'/'});
									rootNode = anu[anu.Length - 1];
									AddTree(rootNode);
								}
								else {
									if (Equals(_nodes[3], "/"))
										AddTree("Root");
									else
										AddTree(_nodes[3]);
								}

								AddSubTree(_nodes[2], false, false, false);
								AddSubTree(_nodes[1], true, false, false);
								AddSubTree(_nodes[0], false, true, false);
								/*}*/
							}
							else {
								string rootNode = "";
								if (_nodes[2].Contains(":/")) {
									string[] anu = _nodes[2].Split(new char[] {'/'});
									rootNode = anu[anu.Length - 1];
									AddTree(rootNode);
								}
								else {
									if (Equals(_nodes[2], "/"))
										AddTree("Root");
									else
										AddTree(_nodes[2]);
								}
								AddSubTree(_nodes[1], false, false, false);
								AddSubTree(_nodes[0], true, false, false);
							}
							endNode = true;
							nodeStop = curentByte;
							
							curentByte += 2;
							UpdateProgress(curentByte);
						}
						else if ((getString(buff, curentByte, 1) == "Q") &&
						         (getString(buff, curentByte, 2) == "QA") &&
						         (getString(buff, curentByte - _nodes[0].Length, _nodes[0].Length) == _nodes[0]))
						{
							AddList("found QA offset at " + curentByte.ToString("X"));
							AddLog("found QA offset at " + curentByte.ToString("X"));
							_QA = true;
							
							curentByte += 2;
							UpdateProgress(curentByte);
						}
						else if ((Equals(getString(buff, curentByte, 1), "T")) &&
						         (Equals(getString(buff, curentByte, 4), "TRN3")))
						{
							AddList("found TRN3 #" + trnID + " at " +  curentByte.ToString("X"));
							AddList(string.Format("look into {0} at {1}", getString(buff, curentByte - _nodes[trnID].Length, _nodes[trnID].Length + 4), (curentByte - _nodes[trnID].Length - 1).ToString("X")));
							AddLog("found TRN3 at" + curentByte.ToString("X"));
							
							int offset = (curentByte - _nodes[trnID].Length) - 1;
							_trn.Add(trnID, offset);
							lastTrn = trnID;
							//MessageBox.Show("Sebelum *TRN: " + buff[offset].ToString("X2"));
							
							trnID++;
							
							_breakPoint.Add(breakPoint, offset);
							breakPoint++;
							
							curentByte += 4;
							UpdateProgress(curentByte);
						}
						else if (buff[curentByte] == 0x49 && buff[curentByte + 1] == 0x9A &&
						         buff[curentByte + 2] == 0x91 && buff[curentByte + 3] == 0x90)
						{
							AddList("found i3s header at " + curentByte.ToString("X"));
							AddLog("found i3s header at " + curentByte.ToString("X"));
							Model item = new Model {
								ItemID = _contentId,
								ItemNode = lastTrn,
								ItemOffset = curentByte,
								itemType = 0
							};
							_anu.Add(item.getItemID(), item);
							_contentId++;

							_breakPoint.Add(breakPoint, curentByte);
							breakPoint++;
							
							curentByte += 4;
							UpdateProgress(curentByte);
						}
						else if (curentByte != 0 &&
						         (Equals(getString(buff, curentByte, 1), "I")) &&
						         (Equals(getString(buff, curentByte, 4), "I3R2")))
						{
							AddList("found i3Pack header at " + curentByte.ToString("X"));
							AddLog("found i3Pack header at " + curentByte.ToString("X"));
							Model item = new Model {
								ItemID = _contentId,
								ItemNode = lastTrn,
								ItemOffset = curentByte,
								itemType = 0
							};
							_anu.Add(item.getItemID(), item);
							_contentId++;

							_breakPoint.Add(breakPoint, curentByte);
							breakPoint++;
							
							curentByte += 4;
							UpdateProgress(curentByte);
						}
						else if (_QA && buff[curentByte] == 0xFF &&
						         buff[curentByte + 1] == 0xFE)
						{
							AddList("found text at " + curentByte.ToString("X"));
							AddList("text node: " + lastTrn);
							AddLog("found text at " + curentByte.ToString("X"));
							AddList(string.Format("{0}_{1}_{2}.txt", _nodes[0], _nodes[1], textName[txtID]));
							txtID++;
							Model item = new Model {
								ItemID = _contentId,
								ItemNode = lastTrn,
								ItemOffset = curentByte,
								itemType = 1
							};
							_anu.Add(item.getItemID(), item);
							_contentId++;

							_breakPoint.Add(breakPoint, curentByte);
							breakPoint++;
							
							curentByte += 2;
							UpdateProgress(curentByte);
						}
						else if ((Equals(getString(buff, curentByte, 1), "I")) &&
						         (Equals(getString(buff, curentByte, 4), "I3IB")))
						{
							if ((Equals(getString(buff, curentByte + 61, 2), ":/")))
							{
								AddList("found Encripted TGA at " + curentByte.ToString("X"));
								AddLog("found Encripted TGA at " + curentByte.ToString("X"));
							}
							else {
								AddList("found I3I at " + curentByte.ToString("X"));
								AddLog("found I3I at " + curentByte.ToString("X"));
							}

							AddList(string.Format("{0}_{1}_{2}.i3i", _nodes[0], _nodes[1], i3iID));
							i3iID++;
							Model item = new Model {
								ItemID = _contentId,
								ItemNode = lastTrn,
								ItemOffset = curentByte,
								itemType = 2
							};
							_anu.Add(item.getItemID(), item);
							_contentId++;

							_breakPoint.Add(breakPoint, curentByte);
							breakPoint++;
							
							curentByte += 60;
							UpdateProgress(curentByte);
						}
						else if ((Equals(getString(buff, curentByte, 1), ";")) &&
						         buff[curentByte + 1] == 0xC6 &&
						         buff[curentByte + 2] == 0xC4 &&
						         buff[curentByte + 3] == 0xC0)
						{
							AddLog("found comment map info at " + curentByte.ToString("X"));
							_infcOffset = curentByte;
							curentByte += 4;
							UpdateProgress(curentByte);
						}
						else if ((Equals(getString(buff, curentByte, 1), "[")) &&
						         (Equals(getString(buff, curentByte, 4), "[Def")) &&
						         (Equals(getString(buff, curentByte, 8), "[Default")))
						{
							_infOffset = _infcOffset != 0 ? _infcOffset : curentByte;
							
							AddList("found map info at " + curentByte.ToString("X"));
							AddLog("found map info at " + curentByte.ToString("X"));
							AddList(string.Format("{0}_{1}_config.txt", _nodes[0], _nodes[1]));
							Model item = new Model {
								ItemID = _contentId,
								ItemNode = lastTrn,
								ItemOffset = _infOffset,
								itemType = 3
							};
							_anu.Add(item.getItemID(), item);
							_contentId++;

							_breakPoint.Add(breakPoint, _infOffset);
							breakPoint++;

							curentByte += 8;
							UpdateProgress(curentByte);
						}
						else if ((Equals(getString(buff, curentByte, 1), "R")) &&
						         (Equals(getString(buff, curentByte, 4), "RIFF")))
						{
							AddList("found WAV at " + curentByte.ToString("X"));
							AddLog("found WAV at " + curentByte.ToString("X"));
							AddList(string.Format("{0}_{1}_{2}.wav", _nodes[0], _nodes[1], wavID));
							wavID++;
							Model item = new Model {
								ItemID = _contentId,
								ItemNode = lastTrn,
								ItemOffset = curentByte,
								itemType = 4
							};
							_anu.Add(item.getItemID(), item);
							_contentId++;
							
							_breakPoint.Add(breakPoint, curentByte);
							breakPoint++;
							
							curentByte += 4;
							UpdateProgress(curentByte);
						}
						else if ((Equals(getString(buff, curentByte, 1), "O")) &&
						         (Equals(getString(buff, curentByte, 4), "OggS")))
						{
							if (BitConverter.ToUInt32(buff, curentByte + 18) <= oggPage) {
								oggPage = BitConverter.ToUInt32(buff, curentByte + 18);
								AddList("found OGG at " + curentByte.ToString("X"));
								AddLog("found OGG at " + curentByte.ToString("X"));
								AddList(string.Format("{0}_{1}_{2}.ogg", _nodes[0], _nodes[1], oggID));
								oggID++;
								Model item = new Model {
									ItemID = _contentId,
									ItemNode = lastTrn,
									ItemOffset = curentByte,
									itemType = 5
								};
								_anu.Add(item.getItemID(), item);
								_contentId++;
								
								_breakPoint.Add(breakPoint, curentByte);
								breakPoint++;
								
								curentByte += 4;
							}
							else {
								AddLog("scaning OGG at " + curentByte.ToString("X"));
							}
							UpdateProgress(curentByte);
						}
						else if ((Equals(getString(buff, curentByte, 1), "D")) &&
						         (Equals(getString(buff, curentByte, 3), "DDS")))
						{
							if (buff[curentByte + 84] == 0x44 &&
							    buff[curentByte + 85] == 0x58 &&
							    buff[curentByte + 86] == 0x54) {
								AddList("found DDS at " + curentByte.ToString("X"));
								AddLog("found DDS at " + curentByte.ToString("X"));
								UpdateProgress(curentByte);
							}
							else {
								AddLog("scaning at " + curentByte.ToString("X"));
							}
							AddList(string.Format("{0}_{1}_{2}.dds", _nodes[0], _nodes[1], ddsID));
							ddsID++;
							Model item = new Model {
								ItemID = _contentId,
								ItemNode = lastTrn,
								ItemOffset = curentByte,
								itemType = 6
							};
							_anu.Add(item.getItemID(), item);
							_contentId++;
							
							_breakPoint.Add(breakPoint, curentByte);
							breakPoint++;

							curentByte += 128;
							UpdateProgress(curentByte);
						}
					}
					input.Close();
					reader.Close();
				} catch (Exception ex) {
					
				}
			}
		}
		
		private void BtnOpenClick(object sender, EventArgs e)
		{
			OpenFileDialog opDialog = new OpenFileDialog();
			opDialog.Filter = "Point Blank Pack file|*.i3Pack";
			if (opDialog.ShowDialog() == DialogResult.OK) {
				_packFile = opDialog.FileName;
				FileInfo packInfo = new FileInfo(_packFile);
				tbxFileName.Text = packInfo.Name;
				tbxFileName.Focus();
				lsView.Enabled = false;
				lsView.ForeColor = SystemColors.ControlDarkDark;
				lbxList.Items.Clear();
				lbxList.Enabled = true;
				lsView.Items.Clear();
				trView.Nodes.Clear();
				trView.Enabled = false;
				
				_anu.Clear();
				_nodes.Clear();
				_breakPoint.Clear();
				_trn.Clear();
				_bodyPack.Clear();
				//_contentStarted = false;
				_QA = false;
				
				lblInfos.Visible = true;
				lblInfos.Text = "Open i3Pack file to start.";
				pnlIfno.Enabled = false;
				Info.Text = "Info";
				
				btnUnpack.Enabled = false;
				btnUnpack.BackColor = btnUnpack.Enabled ? SystemColors.Window : SystemColors.Control;
				btnRepack.Enabled = false;
				btnRepack.BackColor = btnRepack.Enabled ? SystemColors.Window : SystemColors.Control;
				
				// Run Worker
				WORKER.RunWorkerAsync();
			}
		}
		private void CopyToClipboardToolStripMenuItemClick(object sender, EventArgs e)
		{
			if (sender == null)
				return;
			try {
				Clipboard.Clear();
				StringBuilder buffer = new StringBuilder();
				for (int i = 0; lbxList.Items.Count > i; i++) {
					buffer.Append(lbxList.Items[i] + "\r\n");
				}
				Clipboard.SetText(buffer.ToString());
			} catch (Exception ex) {
			}
		}
		private void ClearLogToolStripMenuItemClick(object sender, EventArgs e)
		{
			lbxList.Items.Clear();
		}
		private void SaveLogToolStripMenuItemClick(object sender, EventArgs e)
		{
			FileInfo fInfo = new FileInfo(_packFile);
			
			SaveFileDialog save = new SaveFileDialog();
			save.Filter = "Text Doccument|*.txt";
			save.FileName = fInfo.Name.Split('.')[0] + "_log.txt";
			if (save.ShowDialog() == DialogResult.OK) {
				string fileName = save.FileName;
				try {
					StringBuilder buffer = new StringBuilder();
					for (int i = 0; lbxList.Items.Count > i; i++) {
						buffer.Append(lbxList.Items[i] + "\r\n");
					}
					File.WriteAllText(fileName, buffer.ToString(), Encoding.UTF8);
					MessageBox.Show("Saved!");
				} catch (Exception ex) {
					//MessageBox.Show(string.Format("Error: {0}", ex.Message), "Error Saving File!");
				}
			}
		}
		
		private Model getItemByID(int id)
		{
			foreach (Model item in _anu.Values)
			{
				if (item.getItemID() == id)
					return item;
			}
			return null;
		}
		
		private Model getItemByOffset(int offset)
		{
			foreach (Model item in _anu.Values)
			{
				if (item.getItemOffset() == offset)
					return item;
			}
			return null;
		}
		
		private void LsViewSelectedIndexChanged(object sender, EventArgs e)
		{
			foreach (ListViewItem item in lsView.SelectedItems) {
				Info.Text = "File Info";
				lblInfos.Visible = false;
				
				string xanu = item.Text.Split('.')[0];
				string[] yanu = xanu.Split('_');
				int fileID = int.Parse(yanu[yanu.Length - 1]);
				AddList("file ID: " + yanu[yanu.Length - 1]);
				Model file = getItemByID(fileID);
				int size = _bodyPack[file.getItemID()].Length / 1000;
				lblFileName.Text = item.Text;
				lblOffset.Text = file.getItemOffset().ToString("X");
				lblSize.Text = string.Format("{0} Bytes", _bodyPack[file.getItemID()].Length);
				lblCRC.Text = crc.Get(_bodyPack[file.getItemID()]).ToUpper();
				lblPathName.Text = _nodes[file.getItemNode()];
				AddList("filename: " + item.Text);
				AddList("file index: " + item.Index);
			}
		}
		private void TrViewAfterSelect(object sender, TreeViewEventArgs e)
		{
			// MessageBox.Show(e.Node.FullPath.ToString());
			string[] nodes = e.Node.FullPath.Split('\\');
			// AddList("node count: " + nodes.Length);
			string nodeName = nodes[nodes.Length - 1];
			AddList("selected node name: " + nodeName);
			if (Equals(nodes[nodes.Length - 1], "Root"))
				nodes[nodes.Length - 1] = "/";
			
			int nodeID = _nodes.Count - 1;
			foreach(int i in _nodes.Keys) {
				if (_nodes[i] == nodes[nodes.Length - 1]) {
					nodeID = i;
				}
			}
			AddList("selected node id: " + nodeID);
			getListView(nodeID, nodeName);
		}
		
		private void BtnRepackClick(object sender, EventArgs e)
		{
			FileInfo packInfo = new FileInfo(_packFile);
			SaveFileDialog save = new SaveFileDialog();
			save.Filter = "i3Pack File|*.i3Pack";
			save.FileName = packInfo.Name;
			if (save.ShowDialog() == DialogResult.OK) {
				string fileName = save.FileName;
				registerPack();

				FileStream stream = new FileStream(fileName, FileMode.Create, FileAccess.ReadWrite);
				BinaryWriter write = new BinaryWriter(stream);
				write.Write(_repacked);
				write.Close();
				stream.Close();
				MessageBox.Show("Done!");
			}
		}
		private void BtnUnpackClick(object sender, EventArgs e)
		{
			if (lsView.Items.Count == 0) {
				MessageBox.Show("This Node is empty, no file to be exported!");
				return;
			}
			FileInfo inf = new FileInfo(_packFile);
			FolderBrowserDialog open = new FolderBrowserDialog();
			if (open.ShowDialog() == DialogResult.OK) {
				string output = open.SelectedPath;
				foreach (ListViewItem item in lsView.Items) {
					AddList("exporting " + item.Text);
					string xanu = item.Text.Split('.')[0];
					string[] yanu = xanu.Split('_');
					int fileID = int.Parse(yanu[yanu.Length - 1]);

					Model file = getItemByID(fileID);
					int length = _bodyPack[file.getItemID()].Length;
					int posision = 0;
					byte[] buff = _bodyPack[file.getItemID()];
					if (buff[0] == 0xFF && buff[1] == 0xFE) {
						length = _bodyPack[file.getItemID()].Length - 2;
						posision = 2;
					}
					string content = Encoding.Unicode.GetString(buff, posision, length);
					File.WriteAllText(output + "\\" + item.Text, content, Encoding.Unicode);
				}
				MessageBox.Show("All Done!");
				AddList("exporting done");
			}
		}
		
		private void ExportThisToolStripMenuItemClick(object sender, EventArgs e)
		{
			SaveFileDialog save = new SaveFileDialog();
			foreach (ListViewItem item in lsView.SelectedItems) {
				string[] xanu = item.Text.Split('.');
				string[] yanu = xanu[0].Split('_');
				int fileID = int.Parse(yanu[yanu.Length - 1]);

				Model file = getItemByID(fileID);
				save.FileName = item.Text;
				save.Filter = "|*." + xanu[1];
				int length = _bodyPack[file.getItemID()].Length;
				int position = 0;
				byte[] buff = _bodyPack[file.getItemID()];
				if (buff[0] == 0xFF && buff[1] == 0xFE) {
					length = _bodyPack[file.getItemID()].Length - 2;
					position = 2;
				}
				if (save.ShowDialog() == DialogResult.OK) {
					FileStream stream = new FileStream(save.FileName, FileMode.Create, FileAccess.ReadWrite);
					BinaryWriter write = new BinaryWriter(stream);
					write.Write(buff, position, length);
					write.Close();
					stream.Close();
					MessageBox.Show("Saved!");
				}
			}
		}
		private void ReplaceWithToolStripMenuItemClick(object sender, EventArgs e)
		{
			OpenFileDialog open = new OpenFileDialog();
			foreach (ListViewItem item in lsView.SelectedItems) {
				string[] xanu = item.Text.Split('.');
				string[] yanu = xanu[0].Split('_');
				int fileID = int.Parse(yanu[yanu.Length - 1]);

				Model file = getItemByID(fileID);
				open.FileName = item.Text;
				open.Filter = "|*." + xanu[1];
				if (open.ShowDialog() == DialogResult.OK) {
					string fileName = open.FileName;
					byte[] newByte;
					FileStream input = new FileStream(fileName, FileMode.Open);
					BinaryReader reader = new BinaryReader(input);
					newByte = reader.ReadBytes((int)input.Length);
					//Array.Copy(buf, 0, newByte, 0, buf.Length);
					if (_bodyPack.ContainsKey(file.getItemID())) {
						_bodyPack[file.getItemID()] = newByte;
						btnRepack.Enabled = true;
						btnRepack.BackColor = btnRepack.Enabled ? SystemColors.Window : SystemColors.Control;
						//MessageBox.Show("Selected file replaced, remeber to click Repack after you think done replaced some or all file to apply changes!");
						getListView(file.getItemNode(), _nodes[file.getItemNode()]);
					}
					input.Close();
					reader.Close();
				}
			}
		}
		private void ExitToolStripMenuItemClick(object sender, EventArgs e)
		{
			if (MessageBox.Show("Exit Now?", "", MessageBoxButtons.OKCancel, MessageBoxIcon.Question) == DialogResult.OK) {
				Application.Exit();
			}
		}
		private void AboutToolStripMenuItemClick(object sender, EventArgs e)
		{
			aForm.Show();
		}
	}
}
