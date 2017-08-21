/*
 * Created by SharpDevelop.
 * User: leonardo
 * Date: 11/23/2016
 * Time: 12:54 PM
 * 
 * To change this template use Tools | Options | Coding | Edit Standard Headers.
 */
namespace i3Pack_Tools
{
	partial class MainForm
	{
		/// <summary>
		/// Designer variable used to keep track of non-visual components.
		/// </summary>
		private System.ComponentModel.IContainer components = null;
		private System.Windows.Forms.Button btnOpen;
		private System.Windows.Forms.TextBox tbxFileName;
		private System.Windows.Forms.ProgressBar workProgress;
		private System.Windows.Forms.ListBox lbxList;
		private System.ComponentModel.BackgroundWorker WORKER;
		private System.Windows.Forms.Label lblStatus;
		private System.Windows.Forms.Panel panel1;
		private System.Windows.Forms.Label lblAuthor;
		private System.Windows.Forms.Label lblVersion;
		private System.Windows.Forms.ContextMenuStrip contextMenuItem;
		private System.Windows.Forms.ToolStripMenuItem replaceWithToolStripMenuItem;
		private System.Windows.Forms.ToolStripMenuItem exportThisToolStripMenuItem;
		private System.Windows.Forms.ToolStripMenuItem exportAllToolStripMenuItem;
		private System.Windows.Forms.ListView lsView;
		private System.Windows.Forms.ColumnHeader columnHeader1;
		private System.Windows.Forms.ColumnHeader columnHeader2;
		private System.Windows.Forms.ColumnHeader columnHeader3;
		private System.Windows.Forms.ColumnHeader columnHeader4;
		private System.Windows.Forms.Panel panel2;
		private System.Windows.Forms.TreeView trView;
		private System.Windows.Forms.Button btnRepack;
		private System.Windows.Forms.Button btnUnpack;
		private System.Windows.Forms.Panel pnlIfno;
		private System.Windows.Forms.ContextMenuStrip contextMenuLog;
		private System.Windows.Forms.ToolStripMenuItem copyToClipboardToolStripMenuItem;
		private System.Windows.Forms.ToolStripMenuItem clearLogToolStripMenuItem;
		private System.Windows.Forms.ToolStripMenuItem saveLogToolStripMenuItem;
		private System.Windows.Forms.Label Info;
		private System.Windows.Forms.Label lblCRCT;
		private System.Windows.Forms.Label lblOffsetT;
		private System.Windows.Forms.Label lblSizeT;
		private System.Windows.Forms.Label lblFilenameT;
		private System.Windows.Forms.Label lblCRC;
		private System.Windows.Forms.Label lblOffset;
		private System.Windows.Forms.Label lblSize;
		private System.Windows.Forms.Label lblFileName;
		private System.Windows.Forms.Label lblD4;
		private System.Windows.Forms.Label lblD3;
		private System.Windows.Forms.Label lblD2;
		private System.Windows.Forms.Label lblD1;
		private System.Windows.Forms.Label lblD5;
		private System.Windows.Forms.Label lblPathName;
		private System.Windows.Forms.Label lblPathnameT;
		private System.Windows.Forms.GroupBox gbxFileInfo;
		private System.Windows.Forms.Label lblInfos;
		private System.Windows.Forms.ToolStripSeparator toolStripSeparator1;
		private System.Windows.Forms.ToolStripSeparator toolStripSeparator2;
		private System.Windows.Forms.ImageList iconList;
		private System.Windows.Forms.MenuStrip menuStrip1;
		private System.Windows.Forms.ToolStripMenuItem fileToolStripMenuItem;
		private System.Windows.Forms.ToolStripMenuItem openToolStripMenuItem;
		private System.Windows.Forms.ToolStripMenuItem exitToolStripMenuItem;
		private System.Windows.Forms.ToolStripMenuItem helpToolStripMenuItem;
		private System.Windows.Forms.ToolStripMenuItem aboutToolStripMenuItem;
		private System.Windows.Forms.ToolStripSeparator toolStripSeparator3;
		
		/// <summary>
		/// Disposes resources used by the form.
		/// </summary>
		/// <param name="disposing">true if managed resources should be disposed; otherwise, false.</param>
		protected override void Dispose(bool disposing)
		{
			if (disposing) {
				if (components != null) {
					components.Dispose();
				}
			}
			base.Dispose(disposing);
		}
		
		/// <summary>
		/// This method is required for Windows Forms designer support.
		/// Do not change the method contents inside the source code editor. The Forms designer might
		/// not be able to load this method if it was changed manually.
		/// </summary>
		private void InitializeComponent()
		{
			this.components = new System.ComponentModel.Container();
			System.ComponentModel.ComponentResourceManager resources = new System.ComponentModel.ComponentResourceManager(typeof(MainForm));
			this.btnOpen = new System.Windows.Forms.Button();
			this.tbxFileName = new System.Windows.Forms.TextBox();
			this.workProgress = new System.Windows.Forms.ProgressBar();
			this.lbxList = new System.Windows.Forms.ListBox();
			this.contextMenuLog = new System.Windows.Forms.ContextMenuStrip(this.components);
			this.copyToClipboardToolStripMenuItem = new System.Windows.Forms.ToolStripMenuItem();
			this.saveLogToolStripMenuItem = new System.Windows.Forms.ToolStripMenuItem();
			this.toolStripSeparator1 = new System.Windows.Forms.ToolStripSeparator();
			this.clearLogToolStripMenuItem = new System.Windows.Forms.ToolStripMenuItem();
			this.contextMenuItem = new System.Windows.Forms.ContextMenuStrip(this.components);
			this.replaceWithToolStripMenuItem = new System.Windows.Forms.ToolStripMenuItem();
			this.exportThisToolStripMenuItem = new System.Windows.Forms.ToolStripMenuItem();
			this.toolStripSeparator2 = new System.Windows.Forms.ToolStripSeparator();
			this.exportAllToolStripMenuItem = new System.Windows.Forms.ToolStripMenuItem();
			this.WORKER = new System.ComponentModel.BackgroundWorker();
			this.lblStatus = new System.Windows.Forms.Label();
			this.panel1 = new System.Windows.Forms.Panel();
			this.lblAuthor = new System.Windows.Forms.Label();
			this.lblVersion = new System.Windows.Forms.Label();
			this.lsView = new System.Windows.Forms.ListView();
			this.columnHeader1 = new System.Windows.Forms.ColumnHeader();
			this.columnHeader2 = new System.Windows.Forms.ColumnHeader();
			this.columnHeader3 = new System.Windows.Forms.ColumnHeader();
			this.columnHeader4 = new System.Windows.Forms.ColumnHeader();
			this.iconList = new System.Windows.Forms.ImageList(this.components);
			this.panel2 = new System.Windows.Forms.Panel();
			this.trView = new System.Windows.Forms.TreeView();
			this.btnRepack = new System.Windows.Forms.Button();
			this.btnUnpack = new System.Windows.Forms.Button();
			this.pnlIfno = new System.Windows.Forms.Panel();
			this.Info = new System.Windows.Forms.Label();
			this.gbxFileInfo = new System.Windows.Forms.GroupBox();
			this.lblInfos = new System.Windows.Forms.Label();
			this.lblFilenameT = new System.Windows.Forms.Label();
			this.lblD5 = new System.Windows.Forms.Label();
			this.lblSizeT = new System.Windows.Forms.Label();
			this.lblPathnameT = new System.Windows.Forms.Label();
			this.lblOffsetT = new System.Windows.Forms.Label();
			this.lblPathName = new System.Windows.Forms.Label();
			this.lblCRCT = new System.Windows.Forms.Label();
			this.lblFileName = new System.Windows.Forms.Label();
			this.lblSize = new System.Windows.Forms.Label();
			this.lblOffset = new System.Windows.Forms.Label();
			this.lblD4 = new System.Windows.Forms.Label();
			this.lblCRC = new System.Windows.Forms.Label();
			this.lblD1 = new System.Windows.Forms.Label();
			this.lblD3 = new System.Windows.Forms.Label();
			this.lblD2 = new System.Windows.Forms.Label();
			this.menuStrip1 = new System.Windows.Forms.MenuStrip();
			this.fileToolStripMenuItem = new System.Windows.Forms.ToolStripMenuItem();
			this.openToolStripMenuItem = new System.Windows.Forms.ToolStripMenuItem();
			this.toolStripSeparator3 = new System.Windows.Forms.ToolStripSeparator();
			this.exitToolStripMenuItem = new System.Windows.Forms.ToolStripMenuItem();
			this.helpToolStripMenuItem = new System.Windows.Forms.ToolStripMenuItem();
			this.aboutToolStripMenuItem = new System.Windows.Forms.ToolStripMenuItem();
			this.contextMenuLog.SuspendLayout();
			this.contextMenuItem.SuspendLayout();
			this.panel1.SuspendLayout();
			this.panel2.SuspendLayout();
			this.pnlIfno.SuspendLayout();
			this.gbxFileInfo.SuspendLayout();
			this.menuStrip1.SuspendLayout();
			this.SuspendLayout();
			// 
			// btnOpen
			// 
			this.btnOpen.BackColor = System.Drawing.SystemColors.ButtonHighlight;
			this.btnOpen.BackgroundImageLayout = System.Windows.Forms.ImageLayout.Center;
			this.btnOpen.FlatAppearance.BorderColor = System.Drawing.SystemColors.MenuHighlight;
			this.btnOpen.FlatAppearance.MouseDownBackColor = System.Drawing.SystemColors.InactiveBorder;
			this.btnOpen.FlatAppearance.MouseOverBackColor = System.Drawing.SystemColors.InactiveBorder;
			this.btnOpen.FlatStyle = System.Windows.Forms.FlatStyle.Flat;
			this.btnOpen.ForeColor = System.Drawing.SystemColors.Highlight;
			this.btnOpen.Location = new System.Drawing.Point(11, 37);
			this.btnOpen.Name = "btnOpen";
			this.btnOpen.Size = new System.Drawing.Size(25, 22);
			this.btnOpen.TabIndex = 10;
			this.btnOpen.Text = "...";
			this.btnOpen.TextAlign = System.Drawing.ContentAlignment.TopCenter;
			this.btnOpen.UseVisualStyleBackColor = false;
			this.btnOpen.Click += new System.EventHandler(this.BtnOpenClick);
			// 
			// tbxFileName
			// 
			this.tbxFileName.BackColor = System.Drawing.SystemColors.InactiveBorder;
			this.tbxFileName.Font = new System.Drawing.Font("Consolas", 8.25F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
			this.tbxFileName.ForeColor = System.Drawing.SystemColors.ControlDarkDark;
			this.tbxFileName.Location = new System.Drawing.Point(35, 37);
			this.tbxFileName.Multiline = true;
			this.tbxFileName.Name = "tbxFileName";
			this.tbxFileName.ReadOnly = true;
			this.tbxFileName.Size = new System.Drawing.Size(236, 22);
			this.tbxFileName.TabIndex = 1;
			// 
			// workProgress
			// 
			this.workProgress.Location = new System.Drawing.Point(11, 64);
			this.workProgress.Name = "workProgress";
			this.workProgress.Size = new System.Drawing.Size(260, 20);
			this.workProgress.TabIndex = 2;
			// 
			// lbxList
			// 
			this.lbxList.Anchor = ((System.Windows.Forms.AnchorStyles)(((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Bottom) 
			| System.Windows.Forms.AnchorStyles.Left)));
			this.lbxList.BackColor = System.Drawing.SystemColors.ButtonFace;
			this.lbxList.ContextMenuStrip = this.contextMenuLog;
			this.lbxList.Font = new System.Drawing.Font("Consolas", 8.25F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
			this.lbxList.ForeColor = System.Drawing.SystemColors.ControlDarkDark;
			this.lbxList.FormattingEnabled = true;
			this.lbxList.HorizontalScrollbar = true;
			this.lbxList.Location = new System.Drawing.Point(11, 203);
			this.lbxList.Name = "lbxList";
			this.lbxList.Size = new System.Drawing.Size(260, 134);
			this.lbxList.TabIndex = 3;
			// 
			// contextMenuLog
			// 
			this.contextMenuLog.Items.AddRange(new System.Windows.Forms.ToolStripItem[] {
			this.copyToClipboardToolStripMenuItem,
			this.saveLogToolStripMenuItem,
			this.toolStripSeparator1,
			this.clearLogToolStripMenuItem});
			this.contextMenuLog.Name = "contextMenuLog";
			this.contextMenuLog.RenderMode = System.Windows.Forms.ToolStripRenderMode.System;
			this.contextMenuLog.ShowCheckMargin = true;
			this.contextMenuLog.ShowImageMargin = false;
			this.contextMenuLog.Size = new System.Drawing.Size(172, 76);
			// 
			// copyToClipboardToolStripMenuItem
			// 
			this.copyToClipboardToolStripMenuItem.Name = "copyToClipboardToolStripMenuItem";
			this.copyToClipboardToolStripMenuItem.Size = new System.Drawing.Size(171, 22);
			this.copyToClipboardToolStripMenuItem.Text = "Copy to Clipboard";
			this.copyToClipboardToolStripMenuItem.Click += new System.EventHandler(this.CopyToClipboardToolStripMenuItemClick);
			// 
			// saveLogToolStripMenuItem
			// 
			this.saveLogToolStripMenuItem.Name = "saveLogToolStripMenuItem";
			this.saveLogToolStripMenuItem.Size = new System.Drawing.Size(171, 22);
			this.saveLogToolStripMenuItem.Text = "Save Log";
			this.saveLogToolStripMenuItem.Click += new System.EventHandler(this.SaveLogToolStripMenuItemClick);
			// 
			// toolStripSeparator1
			// 
			this.toolStripSeparator1.Name = "toolStripSeparator1";
			this.toolStripSeparator1.Size = new System.Drawing.Size(168, 6);
			// 
			// clearLogToolStripMenuItem
			// 
			this.clearLogToolStripMenuItem.Name = "clearLogToolStripMenuItem";
			this.clearLogToolStripMenuItem.Size = new System.Drawing.Size(171, 22);
			this.clearLogToolStripMenuItem.Text = "Clear Log";
			this.clearLogToolStripMenuItem.Click += new System.EventHandler(this.ClearLogToolStripMenuItemClick);
			// 
			// contextMenuItem
			// 
			this.contextMenuItem.Items.AddRange(new System.Windows.Forms.ToolStripItem[] {
			this.replaceWithToolStripMenuItem,
			this.exportThisToolStripMenuItem,
			this.toolStripSeparator2,
			this.exportAllToolStripMenuItem});
			this.contextMenuItem.Name = "contextMenuItem";
			this.contextMenuItem.RenderMode = System.Windows.Forms.ToolStripRenderMode.System;
			this.contextMenuItem.Size = new System.Drawing.Size(191, 76);
			// 
			// replaceWithToolStripMenuItem
			// 
			this.replaceWithToolStripMenuItem.Name = "replaceWithToolStripMenuItem";
			this.replaceWithToolStripMenuItem.Size = new System.Drawing.Size(190, 22);
			this.replaceWithToolStripMenuItem.Text = "Replace Selected With";
			this.replaceWithToolStripMenuItem.Click += new System.EventHandler(this.ReplaceWithToolStripMenuItemClick);
			// 
			// exportThisToolStripMenuItem
			// 
			this.exportThisToolStripMenuItem.Name = "exportThisToolStripMenuItem";
			this.exportThisToolStripMenuItem.Size = new System.Drawing.Size(190, 22);
			this.exportThisToolStripMenuItem.Text = "Export Selected";
			this.exportThisToolStripMenuItem.Click += new System.EventHandler(this.ExportThisToolStripMenuItemClick);
			// 
			// toolStripSeparator2
			// 
			this.toolStripSeparator2.Name = "toolStripSeparator2";
			this.toolStripSeparator2.Size = new System.Drawing.Size(187, 6);
			// 
			// exportAllToolStripMenuItem
			// 
			this.exportAllToolStripMenuItem.Name = "exportAllToolStripMenuItem";
			this.exportAllToolStripMenuItem.Size = new System.Drawing.Size(190, 22);
			this.exportAllToolStripMenuItem.Text = "Export All";
			this.exportAllToolStripMenuItem.Click += new System.EventHandler(this.BtnUnpackClick);
			// 
			// WORKER
			// 
			this.WORKER.DoWork += new System.ComponentModel.DoWorkEventHandler(this.WORKERDoWork);
			this.WORKER.RunWorkerCompleted += new System.ComponentModel.RunWorkerCompletedEventHandler(this.WORKERRunWorkerCompleted);
			// 
			// lblStatus
			// 
			this.lblStatus.BackColor = System.Drawing.Color.GhostWhite;
			this.lblStatus.Font = new System.Drawing.Font("Ebrima", 8.25F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
			this.lblStatus.ForeColor = System.Drawing.Color.Green;
			this.lblStatus.Location = new System.Drawing.Point(3, 4);
			this.lblStatus.Name = "lblStatus";
			this.lblStatus.Size = new System.Drawing.Size(254, 15);
			this.lblStatus.TabIndex = 4;
			this.lblStatus.Text = "status: ready";
			// 
			// panel1
			// 
			this.panel1.Anchor = ((System.Windows.Forms.AnchorStyles)(((System.Windows.Forms.AnchorStyles.Bottom | System.Windows.Forms.AnchorStyles.Left) 
			| System.Windows.Forms.AnchorStyles.Right)));
			this.panel1.BackColor = System.Drawing.Color.GhostWhite;
			this.panel1.Controls.Add(this.lblAuthor);
			this.panel1.Controls.Add(this.lblVersion);
			this.panel1.Location = new System.Drawing.Point(1, 500);
			this.panel1.Name = "panel1";
			this.panel1.Size = new System.Drawing.Size(784, 25);
			this.panel1.TabIndex = 5;
			// 
			// lblAuthor
			// 
			this.lblAuthor.Anchor = ((System.Windows.Forms.AnchorStyles)((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Right)));
			this.lblAuthor.Font = new System.Drawing.Font("Ebrima", 8.25F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
			this.lblAuthor.ForeColor = System.Drawing.SystemColors.ControlDarkDark;
			this.lblAuthor.Location = new System.Drawing.Point(597, 5);
			this.lblAuthor.Name = "lblAuthor";
			this.lblAuthor.Size = new System.Drawing.Size(178, 15);
			this.lblAuthor.TabIndex = 5;
			this.lblAuthor.Text = "© 2016 Leonardo DaVchezt";
			this.lblAuthor.TextAlign = System.Drawing.ContentAlignment.TopRight;
			this.lblAuthor.MouseDown += new System.Windows.Forms.MouseEventHandler(this.lblAuthor_MouseDown);
			this.lblAuthor.MouseEnter += new System.EventHandler(this.lblAuthor_MouseEnter);
			this.lblAuthor.MouseLeave += new System.EventHandler(this.lblAuthor_MouseLeave);
			// 
			// lblVersion
			// 
			this.lblVersion.Font = new System.Drawing.Font("Ebrima", 8.25F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
			this.lblVersion.ForeColor = System.Drawing.SystemColors.ControlDarkDark;
			this.lblVersion.Location = new System.Drawing.Point(8, 5);
			this.lblVersion.Name = "lblVersion";
			this.lblVersion.Size = new System.Drawing.Size(92, 15);
			this.lblVersion.TabIndex = 4;
			this.lblVersion.Text = "version";
			// 
			// lsView
			// 
			this.lsView.Anchor = ((System.Windows.Forms.AnchorStyles)((((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Bottom) 
			| System.Windows.Forms.AnchorStyles.Left) 
			| System.Windows.Forms.AnchorStyles.Right)));
			this.lsView.BorderStyle = System.Windows.Forms.BorderStyle.FixedSingle;
			this.lsView.Columns.AddRange(new System.Windows.Forms.ColumnHeader[] {
			this.columnHeader1,
			this.columnHeader2,
			this.columnHeader3,
			this.columnHeader4});
			this.lsView.ContextMenuStrip = this.contextMenuItem;
			this.lsView.Enabled = false;
			this.lsView.Font = new System.Drawing.Font("Microsoft Sans Serif", 8.25F);
			this.lsView.ForeColor = System.Drawing.SystemColors.ControlDarkDark;
			this.lsView.FullRowSelect = true;
			this.lsView.HeaderStyle = System.Windows.Forms.ColumnHeaderStyle.Nonclickable;
			this.lsView.HideSelection = false;
			this.lsView.Location = new System.Drawing.Point(278, 36);
			this.lsView.MultiSelect = false;
			this.lsView.Name = "lsView";
			this.lsView.Size = new System.Drawing.Size(494, 423);
			this.lsView.SmallImageList = this.iconList;
			this.lsView.TabIndex = 7;
			this.lsView.UseCompatibleStateImageBehavior = false;
			this.lsView.View = System.Windows.Forms.View.Details;
			this.lsView.SelectedIndexChanged += new System.EventHandler(this.LsViewSelectedIndexChanged);
			// 
			// columnHeader1
			// 
			this.columnHeader1.Text = "Filename";
			this.columnHeader1.Width = 235;
			// 
			// columnHeader2
			// 
			this.columnHeader2.Text = "Size";
			this.columnHeader2.TextAlign = System.Windows.Forms.HorizontalAlignment.Right;
			this.columnHeader2.Width = 80;
			// 
			// columnHeader3
			// 
			this.columnHeader3.Text = "Offset";
			this.columnHeader3.Width = 90;
			// 
			// columnHeader4
			// 
			this.columnHeader4.Text = "CRC";
			this.columnHeader4.TextAlign = System.Windows.Forms.HorizontalAlignment.Center;
			this.columnHeader4.Width = 88;
			// 
			// iconList
			// 
			this.iconList.ImageStream = ((System.Windows.Forms.ImageListStreamer)(resources.GetObject("iconList.ImageStream")));
			this.iconList.TransparentColor = System.Drawing.Color.Transparent;
			this.iconList.Images.SetKeyName(0, "file.png");
			this.iconList.Images.SetKeyName(1, "gif.png");
			this.iconList.Images.SetKeyName(2, "5.png");
			this.iconList.Images.SetKeyName(3, "8.png");
			this.iconList.Images.SetKeyName(4, "directory.png");
			this.iconList.Images.SetKeyName(5, "page.png");
			this.iconList.Images.SetKeyName(6, "mp3.png");
			this.iconList.Images.SetKeyName(7, "directory.png");
			// 
			// panel2
			// 
			this.panel2.BackColor = System.Drawing.Color.GhostWhite;
			this.panel2.Controls.Add(this.lblStatus);
			this.panel2.Location = new System.Drawing.Point(11, 90);
			this.panel2.Name = "panel2";
			this.panel2.Size = new System.Drawing.Size(260, 22);
			this.panel2.TabIndex = 8;
			// 
			// trView
			// 
			this.trView.ForeColor = System.Drawing.SystemColors.ActiveCaptionText;
			this.trView.HideSelection = false;
			this.trView.ImageIndex = 4;
			this.trView.ImageList = this.iconList;
			this.trView.Location = new System.Drawing.Point(11, 118);
			this.trView.Name = "trView";
			this.trView.SelectedImageIndex = 4;
			this.trView.Size = new System.Drawing.Size(260, 86);
			this.trView.TabIndex = 9;
			this.trView.AfterSelect += new System.Windows.Forms.TreeViewEventHandler(this.TrViewAfterSelect);
			// 
			// btnRepack
			// 
			this.btnRepack.Anchor = ((System.Windows.Forms.AnchorStyles)((System.Windows.Forms.AnchorStyles.Bottom | System.Windows.Forms.AnchorStyles.Left)));
			this.btnRepack.BackColor = System.Drawing.SystemColors.ControlLightLight;
			this.btnRepack.Enabled = false;
			this.btnRepack.FlatAppearance.BorderColor = System.Drawing.SystemColors.MenuHighlight;
			this.btnRepack.FlatAppearance.MouseDownBackColor = System.Drawing.SystemColors.InactiveBorder;
			this.btnRepack.FlatAppearance.MouseOverBackColor = System.Drawing.SystemColors.InactiveBorder;
			this.btnRepack.FlatStyle = System.Windows.Forms.FlatStyle.Flat;
			this.btnRepack.ForeColor = System.Drawing.SystemColors.Highlight;
			this.btnRepack.Location = new System.Drawing.Point(278, 466);
			this.btnRepack.Name = "btnRepack";
			this.btnRepack.Size = new System.Drawing.Size(75, 23);
			this.btnRepack.TabIndex = 10;
			this.btnRepack.Text = "Repack";
			this.btnRepack.UseVisualStyleBackColor = false;
			this.btnRepack.Click += new System.EventHandler(this.BtnRepackClick);
			// 
			// btnUnpack
			// 
			this.btnUnpack.Anchor = ((System.Windows.Forms.AnchorStyles)((System.Windows.Forms.AnchorStyles.Bottom | System.Windows.Forms.AnchorStyles.Right)));
			this.btnUnpack.BackColor = System.Drawing.SystemColors.Window;
			this.btnUnpack.Enabled = false;
			this.btnUnpack.FlatAppearance.BorderColor = System.Drawing.SystemColors.Highlight;
			this.btnUnpack.FlatAppearance.MouseDownBackColor = System.Drawing.SystemColors.InactiveBorder;
			this.btnUnpack.FlatAppearance.MouseOverBackColor = System.Drawing.SystemColors.InactiveBorder;
			this.btnUnpack.FlatStyle = System.Windows.Forms.FlatStyle.Flat;
			this.btnUnpack.ForeColor = System.Drawing.SystemColors.Highlight;
			this.btnUnpack.Location = new System.Drawing.Point(697, 466);
			this.btnUnpack.Name = "btnUnpack";
			this.btnUnpack.Size = new System.Drawing.Size(75, 23);
			this.btnUnpack.TabIndex = 11;
			this.btnUnpack.Text = "Unpack";
			this.btnUnpack.UseVisualStyleBackColor = false;
			this.btnUnpack.Click += new System.EventHandler(this.BtnUnpackClick);
			// 
			// pnlIfno
			// 
			this.pnlIfno.Anchor = ((System.Windows.Forms.AnchorStyles)((System.Windows.Forms.AnchorStyles.Bottom | System.Windows.Forms.AnchorStyles.Left)));
			this.pnlIfno.BackColor = System.Drawing.Color.GhostWhite;
			this.pnlIfno.BorderStyle = System.Windows.Forms.BorderStyle.FixedSingle;
			this.pnlIfno.Controls.Add(this.Info);
			this.pnlIfno.Controls.Add(this.gbxFileInfo);
			this.pnlIfno.ForeColor = System.Drawing.SystemColors.ControlDarkDark;
			this.pnlIfno.Location = new System.Drawing.Point(11, 341);
			this.pnlIfno.Name = "pnlIfno";
			this.pnlIfno.Size = new System.Drawing.Size(260, 118);
			this.pnlIfno.TabIndex = 12;
			// 
			// Info
			// 
			this.Info.Font = new System.Drawing.Font("Ebrima", 9F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
			this.Info.ForeColor = System.Drawing.SystemColors.ActiveCaptionText;
			this.Info.Location = new System.Drawing.Point(3, 3);
			this.Info.Name = "Info";
			this.Info.Size = new System.Drawing.Size(100, 17);
			this.Info.TabIndex = 0;
			this.Info.Text = "Info";
			// 
			// gbxFileInfo
			// 
			this.gbxFileInfo.BackColor = System.Drawing.Color.Transparent;
			this.gbxFileInfo.Controls.Add(this.lblInfos);
			this.gbxFileInfo.Controls.Add(this.lblFilenameT);
			this.gbxFileInfo.Controls.Add(this.lblD5);
			this.gbxFileInfo.Controls.Add(this.lblSizeT);
			this.gbxFileInfo.Controls.Add(this.lblPathnameT);
			this.gbxFileInfo.Controls.Add(this.lblOffsetT);
			this.gbxFileInfo.Controls.Add(this.lblPathName);
			this.gbxFileInfo.Controls.Add(this.lblCRCT);
			this.gbxFileInfo.Controls.Add(this.lblFileName);
			this.gbxFileInfo.Controls.Add(this.lblSize);
			this.gbxFileInfo.Controls.Add(this.lblOffset);
			this.gbxFileInfo.Controls.Add(this.lblD4);
			this.gbxFileInfo.Controls.Add(this.lblCRC);
			this.gbxFileInfo.Controls.Add(this.lblD1);
			this.gbxFileInfo.Controls.Add(this.lblD3);
			this.gbxFileInfo.Controls.Add(this.lblD2);
			this.gbxFileInfo.Location = new System.Drawing.Point(0, 14);
			this.gbxFileInfo.Name = "gbxFileInfo";
			this.gbxFileInfo.Size = new System.Drawing.Size(258, 103);
			this.gbxFileInfo.TabIndex = 16;
			this.gbxFileInfo.TabStop = false;
			// 
			// lblInfos
			// 
			this.lblInfos.Location = new System.Drawing.Point(7, 13);
			this.lblInfos.Name = "lblInfos";
			this.lblInfos.Size = new System.Drawing.Size(245, 83);
			this.lblInfos.TabIndex = 0;
			this.lblInfos.Text = "Open i3Pack file to start.";
			// 
			// lblFilenameT
			// 
			this.lblFilenameT.Location = new System.Drawing.Point(8, 13);
			this.lblFilenameT.Name = "lblFilenameT";
			this.lblFilenameT.Size = new System.Drawing.Size(50, 15);
			this.lblFilenameT.TabIndex = 1;
			this.lblFilenameT.Text = "Filename";
			// 
			// lblD5
			// 
			this.lblD5.Location = new System.Drawing.Point(60, 79);
			this.lblD5.Name = "lblD5";
			this.lblD5.Size = new System.Drawing.Size(10, 15);
			this.lblD5.TabIndex = 15;
			this.lblD5.Text = ":";
			// 
			// lblSizeT
			// 
			this.lblSizeT.Location = new System.Drawing.Point(8, 30);
			this.lblSizeT.Name = "lblSizeT";
			this.lblSizeT.Size = new System.Drawing.Size(46, 15);
			this.lblSizeT.TabIndex = 2;
			this.lblSizeT.Text = "Size";
			// 
			// lblPathnameT
			// 
			this.lblPathnameT.Location = new System.Drawing.Point(8, 79);
			this.lblPathnameT.Name = "lblPathnameT";
			this.lblPathnameT.Size = new System.Drawing.Size(62, 15);
			this.lblPathnameT.TabIndex = 13;
			this.lblPathnameT.Text = "Pathname";
			// 
			// lblOffsetT
			// 
			this.lblOffsetT.Location = new System.Drawing.Point(8, 47);
			this.lblOffsetT.Name = "lblOffsetT";
			this.lblOffsetT.Size = new System.Drawing.Size(46, 15);
			this.lblOffsetT.TabIndex = 3;
			this.lblOffsetT.Text = "Offset";
			// 
			// lblPathName
			// 
			this.lblPathName.Location = new System.Drawing.Point(76, 79);
			this.lblPathName.Name = "lblPathName";
			this.lblPathName.Size = new System.Drawing.Size(158, 15);
			this.lblPathName.TabIndex = 14;
			// 
			// lblCRCT
			// 
			this.lblCRCT.Location = new System.Drawing.Point(8, 64);
			this.lblCRCT.Name = "lblCRCT";
			this.lblCRCT.Size = new System.Drawing.Size(46, 15);
			this.lblCRCT.TabIndex = 4;
			this.lblCRCT.Text = "CRC";
			// 
			// lblFileName
			// 
			this.lblFileName.Location = new System.Drawing.Point(76, 13);
			this.lblFileName.Name = "lblFileName";
			this.lblFileName.Size = new System.Drawing.Size(158, 15);
			this.lblFileName.TabIndex = 5;
			// 
			// lblSize
			// 
			this.lblSize.Location = new System.Drawing.Point(76, 30);
			this.lblSize.Name = "lblSize";
			this.lblSize.Size = new System.Drawing.Size(158, 15);
			this.lblSize.TabIndex = 6;
			// 
			// lblOffset
			// 
			this.lblOffset.Location = new System.Drawing.Point(76, 47);
			this.lblOffset.Name = "lblOffset";
			this.lblOffset.Size = new System.Drawing.Size(158, 15);
			this.lblOffset.TabIndex = 7;
			// 
			// lblD4
			// 
			this.lblD4.Location = new System.Drawing.Point(60, 64);
			this.lblD4.Name = "lblD4";
			this.lblD4.Size = new System.Drawing.Size(10, 15);
			this.lblD4.TabIndex = 12;
			this.lblD4.Text = ":";
			// 
			// lblCRC
			// 
			this.lblCRC.Location = new System.Drawing.Point(76, 64);
			this.lblCRC.Name = "lblCRC";
			this.lblCRC.Size = new System.Drawing.Size(158, 15);
			this.lblCRC.TabIndex = 8;
			// 
			// lblD1
			// 
			this.lblD1.Location = new System.Drawing.Point(60, 13);
			this.lblD1.Name = "lblD1";
			this.lblD1.Size = new System.Drawing.Size(10, 16);
			this.lblD1.TabIndex = 9;
			this.lblD1.Text = ":";
			// 
			// lblD3
			// 
			this.lblD3.Location = new System.Drawing.Point(60, 47);
			this.lblD3.Name = "lblD3";
			this.lblD3.Size = new System.Drawing.Size(10, 15);
			this.lblD3.TabIndex = 11;
			this.lblD3.Text = ":";
			// 
			// lblD2
			// 
			this.lblD2.Location = new System.Drawing.Point(60, 30);
			this.lblD2.Name = "lblD2";
			this.lblD2.Size = new System.Drawing.Size(10, 14);
			this.lblD2.TabIndex = 10;
			this.lblD2.Text = ":";
			// 
			// menuStrip1
			// 
			this.menuStrip1.BackColor = System.Drawing.SystemColors.Window;
			this.menuStrip1.BackgroundImageLayout = System.Windows.Forms.ImageLayout.None;
			this.menuStrip1.Items.AddRange(new System.Windows.Forms.ToolStripItem[] {
			this.fileToolStripMenuItem,
			this.helpToolStripMenuItem});
			this.menuStrip1.Location = new System.Drawing.Point(0, 0);
			this.menuStrip1.Name = "menuStrip1";
			this.menuStrip1.Size = new System.Drawing.Size(785, 24);
			this.menuStrip1.TabIndex = 13;
			this.menuStrip1.Text = "menuStrip1";
			// 
			// fileToolStripMenuItem
			// 
			this.fileToolStripMenuItem.DropDownItems.AddRange(new System.Windows.Forms.ToolStripItem[] {
			this.openToolStripMenuItem,
			this.toolStripSeparator3,
			this.exitToolStripMenuItem});
			this.fileToolStripMenuItem.Name = "fileToolStripMenuItem";
			this.fileToolStripMenuItem.Size = new System.Drawing.Size(37, 20);
			this.fileToolStripMenuItem.Text = "File";
			// 
			// openToolStripMenuItem
			// 
			this.openToolStripMenuItem.Name = "openToolStripMenuItem";
			this.openToolStripMenuItem.Size = new System.Drawing.Size(103, 22);
			this.openToolStripMenuItem.Text = "Open";
			this.openToolStripMenuItem.Click += new System.EventHandler(this.BtnOpenClick);
			// 
			// toolStripSeparator3
			// 
			this.toolStripSeparator3.Name = "toolStripSeparator3";
			this.toolStripSeparator3.Size = new System.Drawing.Size(100, 6);
			// 
			// exitToolStripMenuItem
			// 
			this.exitToolStripMenuItem.Name = "exitToolStripMenuItem";
			this.exitToolStripMenuItem.Size = new System.Drawing.Size(103, 22);
			this.exitToolStripMenuItem.Text = "Exit";
			this.exitToolStripMenuItem.Click += new System.EventHandler(this.ExitToolStripMenuItemClick);
			// 
			// helpToolStripMenuItem
			// 
			this.helpToolStripMenuItem.DropDownItems.AddRange(new System.Windows.Forms.ToolStripItem[] {
			this.aboutToolStripMenuItem});
			this.helpToolStripMenuItem.Name = "helpToolStripMenuItem";
			this.helpToolStripMenuItem.Size = new System.Drawing.Size(44, 20);
			this.helpToolStripMenuItem.Text = "Help";
			// 
			// aboutToolStripMenuItem
			// 
			this.aboutToolStripMenuItem.Name = "aboutToolStripMenuItem";
			this.aboutToolStripMenuItem.Size = new System.Drawing.Size(107, 22);
			this.aboutToolStripMenuItem.Text = "About";
			this.aboutToolStripMenuItem.Click += new System.EventHandler(this.AboutToolStripMenuItemClick);
			// 
			// MainForm
			// 
			this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 13F);
			this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
			this.BackColor = System.Drawing.SystemColors.ButtonFace;
			this.ClientSize = new System.Drawing.Size(785, 526);
			this.Controls.Add(this.menuStrip1);
			this.Controls.Add(this.btnUnpack);
			this.Controls.Add(this.btnRepack);
			this.Controls.Add(this.trView);
			this.Controls.Add(this.panel2);
			this.Controls.Add(this.panel1);
			this.Controls.Add(this.workProgress);
			this.Controls.Add(this.tbxFileName);
			this.Controls.Add(this.btnOpen);
			this.Controls.Add(this.lbxList);
			this.Controls.Add(this.lsView);
			this.Controls.Add(this.pnlIfno);
			this.Icon = ((System.Drawing.Icon)(resources.GetObject("$this.Icon")));
			this.MainMenuStrip = this.menuStrip1;
			this.Name = "MainForm";
			this.StartPosition = System.Windows.Forms.FormStartPosition.CenterScreen;
			this.Text = "i3Pack Tools";
			this.contextMenuLog.ResumeLayout(false);
			this.contextMenuItem.ResumeLayout(false);
			this.panel1.ResumeLayout(false);
			this.panel2.ResumeLayout(false);
			this.pnlIfno.ResumeLayout(false);
			this.gbxFileInfo.ResumeLayout(false);
			this.menuStrip1.ResumeLayout(false);
			this.menuStrip1.PerformLayout();
			this.ResumeLayout(false);
			this.PerformLayout();

		}
	}
}
