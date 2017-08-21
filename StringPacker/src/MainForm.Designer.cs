/*
 * Created by SharpDevelop.
 * User: leonardo
 * Date: 11/20/2016
 * Time: 3:22 PM
 * 
 * To change this template use Tools | Options | Coding | Edit Standard Headers.
 */
namespace StringPacker
{
	partial class MainForm
	{
		/// <summary>
		/// Designer variable used to keep track of non-visual components.
		/// </summary>
		private System.ComponentModel.IContainer components = null;
		private System.Windows.Forms.TextBox tbxFile;
		private System.Windows.Forms.TextBox tbxEditor;
		private System.Windows.Forms.Button btnOpen;
		private System.Windows.Forms.ProgressBar sProgress;
		private System.Windows.Forms.Button btnSave;
		private System.Windows.Forms.Label lblStatus;
		private System.Windows.Forms.ListBox lbxList;
		private System.ComponentModel.BackgroundWorker WORKER;
		private System.Windows.Forms.ContextMenuStrip contextMenus;
		private System.Windows.Forms.ToolStripMenuItem saveAsToolStripMenuItem;
		private System.Windows.Forms.ToolStripMenuItem replaceWIthToolStripMenuItem;
		private System.Windows.Forms.Button btnApply;
		private System.Windows.Forms.Label lblInfo;
		private System.Windows.Forms.Panel panel1;
		private System.Windows.Forms.Label lblVersion;
		private System.Windows.Forms.Label lblAuthor;
		private System.Windows.Forms.Label lblEditorInfo;
		private System.Windows.Forms.ToolStripMenuItem exportAllToolStripMenuItem;
		
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
			this.tbxFile = new System.Windows.Forms.TextBox();
			this.tbxEditor = new System.Windows.Forms.TextBox();
			this.btnOpen = new System.Windows.Forms.Button();
			this.sProgress = new System.Windows.Forms.ProgressBar();
			this.btnSave = new System.Windows.Forms.Button();
			this.lblStatus = new System.Windows.Forms.Label();
			this.lbxList = new System.Windows.Forms.ListBox();
			this.contextMenus = new System.Windows.Forms.ContextMenuStrip(this.components);
			this.replaceWIthToolStripMenuItem = new System.Windows.Forms.ToolStripMenuItem();
			this.saveAsToolStripMenuItem = new System.Windows.Forms.ToolStripMenuItem();
			this.exportAllToolStripMenuItem = new System.Windows.Forms.ToolStripMenuItem();
			this.WORKER = new System.ComponentModel.BackgroundWorker();
			this.btnApply = new System.Windows.Forms.Button();
			this.lblInfo = new System.Windows.Forms.Label();
			this.panel1 = new System.Windows.Forms.Panel();
			this.lblAuthor = new System.Windows.Forms.Label();
			this.lblVersion = new System.Windows.Forms.Label();
			this.lblEditorInfo = new System.Windows.Forms.Label();
			this.contextMenus.SuspendLayout();
			this.panel1.SuspendLayout();
			this.SuspendLayout();
			// 
			// tbxFile
			// 
			this.tbxFile.Font = new System.Drawing.Font("Consolas", 8.25F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
			this.tbxFile.Location = new System.Drawing.Point(12, 12);
			this.tbxFile.Name = "tbxFile";
			this.tbxFile.ReadOnly = true;
			this.tbxFile.Size = new System.Drawing.Size(184, 20);
			this.tbxFile.TabIndex = 1;
			this.tbxFile.Text = "String.i3Pack";
			// 
			// tbxEditor
			// 
			this.tbxEditor.AcceptsReturn = true;
			this.tbxEditor.AcceptsTab = true;
			this.tbxEditor.Anchor = ((System.Windows.Forms.AnchorStyles)((((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Bottom) 
			| System.Windows.Forms.AnchorStyles.Left) 
			| System.Windows.Forms.AnchorStyles.Right)));
			this.tbxEditor.Enabled = false;
			this.tbxEditor.Font = new System.Drawing.Font("Consolas", 8.25F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
			this.tbxEditor.Location = new System.Drawing.Point(229, 12);
			this.tbxEditor.Multiline = true;
			this.tbxEditor.Name = "tbxEditor";
			this.tbxEditor.ScrollBars = System.Windows.Forms.ScrollBars.Both;
			this.tbxEditor.Size = new System.Drawing.Size(483, 317);
			this.tbxEditor.TabIndex = 4;
			this.tbxEditor.WordWrap = false;
			this.tbxEditor.TextChanged += new System.EventHandler(this.TbxEditorTextChanged);
			this.tbxEditor.KeyDown += new System.Windows.Forms.KeyEventHandler(this.TbxOutputKeyDown);
			// 
			// btnOpen
			// 
			this.btnOpen.Location = new System.Drawing.Point(194, 11);
			this.btnOpen.Name = "btnOpen";
			this.btnOpen.Size = new System.Drawing.Size(30, 22);
			this.btnOpen.TabIndex = 2;
			this.btnOpen.Text = "...";
			this.btnOpen.UseVisualStyleBackColor = true;
			this.btnOpen.Click += new System.EventHandler(this.BtnOpenClick);
			// 
			// sProgress
			// 
			this.sProgress.Anchor = ((System.Windows.Forms.AnchorStyles)(((System.Windows.Forms.AnchorStyles.Bottom | System.Windows.Forms.AnchorStyles.Left) 
			| System.Windows.Forms.AnchorStyles.Right)));
			this.sProgress.Location = new System.Drawing.Point(12, 348);
			this.sProgress.Name = "sProgress";
			this.sProgress.Size = new System.Drawing.Size(538, 23);
			this.sProgress.TabIndex = 6;
			// 
			// btnSave
			// 
			this.btnSave.Anchor = ((System.Windows.Forms.AnchorStyles)((System.Windows.Forms.AnchorStyles.Bottom | System.Windows.Forms.AnchorStyles.Right)));
			this.btnSave.Enabled = false;
			this.btnSave.Location = new System.Drawing.Point(556, 347);
			this.btnSave.Name = "btnSave";
			this.btnSave.Size = new System.Drawing.Size(75, 25);
			this.btnSave.TabIndex = 5;
			this.btnSave.Text = "Save As";
			this.btnSave.UseVisualStyleBackColor = true;
			this.btnSave.Click += new System.EventHandler(this.BtnSaveClick);
			// 
			// lblStatus
			// 
			this.lblStatus.Anchor = ((System.Windows.Forms.AnchorStyles)((System.Windows.Forms.AnchorStyles.Bottom | System.Windows.Forms.AnchorStyles.Left)));
			this.lblStatus.Location = new System.Drawing.Point(10, 332);
			this.lblStatus.Name = "lblStatus";
			this.lblStatus.Size = new System.Drawing.Size(507, 15);
			this.lblStatus.TabIndex = 7;
			this.lblStatus.Text = "status: ready";
			// 
			// lbxList
			// 
			this.lbxList.Anchor = ((System.Windows.Forms.AnchorStyles)(((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Bottom) 
			| System.Windows.Forms.AnchorStyles.Left)));
			this.lbxList.ContextMenuStrip = this.contextMenus;
			this.lbxList.Enabled = false;
			this.lbxList.Font = new System.Drawing.Font("Consolas", 8.25F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
			this.lbxList.FormattingEnabled = true;
			this.lbxList.Location = new System.Drawing.Point(12, 38);
			this.lbxList.Name = "lbxList";
			this.lbxList.Size = new System.Drawing.Size(211, 290);
			this.lbxList.TabIndex = 8;
			this.lbxList.SelectedValueChanged += new System.EventHandler(this.LbxListSelectedValueChanged);
			// 
			// contextMenus
			// 
			this.contextMenus.Items.AddRange(new System.Windows.Forms.ToolStripItem[] {
			this.replaceWIthToolStripMenuItem,
			this.saveAsToolStripMenuItem,
			this.exportAllToolStripMenuItem});
			this.contextMenus.Name = "contextMenus";
			this.contextMenus.RenderMode = System.Windows.Forms.ToolStripRenderMode.System;
			this.contextMenus.Size = new System.Drawing.Size(144, 70);
			// 
			// replaceWIthToolStripMenuItem
			// 
			this.replaceWIthToolStripMenuItem.Name = "replaceWIthToolStripMenuItem";
			this.replaceWIthToolStripMenuItem.Size = new System.Drawing.Size(143, 22);
			this.replaceWIthToolStripMenuItem.Text = "Replace WIth";
			this.replaceWIthToolStripMenuItem.Click += new System.EventHandler(this.ReplaceWIthToolStripMenuItemClick);
			// 
			// saveAsToolStripMenuItem
			// 
			this.saveAsToolStripMenuItem.Name = "saveAsToolStripMenuItem";
			this.saveAsToolStripMenuItem.Size = new System.Drawing.Size(143, 22);
			this.saveAsToolStripMenuItem.Text = "Save File As";
			this.saveAsToolStripMenuItem.Click += new System.EventHandler(this.SaveAsToolStripMenuItemClick);
			// 
			// exportAllToolStripMenuItem
			// 
			this.exportAllToolStripMenuItem.Name = "exportAllToolStripMenuItem";
			this.exportAllToolStripMenuItem.Size = new System.Drawing.Size(143, 22);
			this.exportAllToolStripMenuItem.Text = "Export All";
			this.exportAllToolStripMenuItem.Click += new System.EventHandler(this.ExportAllToolStripMenuItemClick);
			// 
			// WORKER
			// 
			this.WORKER.DoWork += new System.ComponentModel.DoWorkEventHandler(this.WORKERDoWork);
			this.WORKER.RunWorkerCompleted += new System.ComponentModel.RunWorkerCompletedEventHandler(this.WORKERRunWorkerCompleted);
			// 
			// btnApply
			// 
			this.btnApply.Anchor = ((System.Windows.Forms.AnchorStyles)((System.Windows.Forms.AnchorStyles.Bottom | System.Windows.Forms.AnchorStyles.Right)));
			this.btnApply.Enabled = false;
			this.btnApply.Location = new System.Drawing.Point(637, 347);
			this.btnApply.Name = "btnApply";
			this.btnApply.Size = new System.Drawing.Size(75, 25);
			this.btnApply.TabIndex = 9;
			this.btnApply.Text = "Apply";
			this.btnApply.UseVisualStyleBackColor = true;
			this.btnApply.Click += new System.EventHandler(this.BtnApplyClick);
			// 
			// lblInfo
			// 
			this.lblInfo.Anchor = ((System.Windows.Forms.AnchorStyles)((System.Windows.Forms.AnchorStyles.Bottom | System.Windows.Forms.AnchorStyles.Left)));
			this.lblInfo.Location = new System.Drawing.Point(14, 311);
			this.lblInfo.Name = "lblInfo";
			this.lblInfo.Size = new System.Drawing.Size(208, 15);
			this.lblInfo.TabIndex = 10;
			this.lblInfo.Text = "info: right click on selected item for more...";
			this.lblInfo.Visible = false;
			// 
			// panel1
			// 
			this.panel1.Anchor = ((System.Windows.Forms.AnchorStyles)(((System.Windows.Forms.AnchorStyles.Bottom | System.Windows.Forms.AnchorStyles.Left) 
			| System.Windows.Forms.AnchorStyles.Right)));
			this.panel1.BackColor = System.Drawing.SystemColors.Window;
			this.panel1.Controls.Add(this.lblAuthor);
			this.panel1.Controls.Add(this.lblVersion);
			this.panel1.Location = new System.Drawing.Point(0, 380);
			this.panel1.Name = "panel1";
			this.panel1.Size = new System.Drawing.Size(723, 25);
			this.panel1.TabIndex = 11;
			// 
			// lblAuthor
			// 
			this.lblAuthor.Anchor = ((System.Windows.Forms.AnchorStyles)((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Right)));
			this.lblAuthor.Font = new System.Drawing.Font("Ebrima", 8.25F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
			this.lblAuthor.ForeColor = System.Drawing.SystemColors.ControlDarkDark;
			this.lblAuthor.Location = new System.Drawing.Point(464, 5);
			this.lblAuthor.Name = "lblAuthor";
			this.lblAuthor.Size = new System.Drawing.Size(252, 15);
			this.lblAuthor.TabIndex = 1;
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
			this.lblVersion.Location = new System.Drawing.Point(9, 5);
			this.lblVersion.Name = "lblVersion";
			this.lblVersion.Size = new System.Drawing.Size(100, 15);
			this.lblVersion.TabIndex = 0;
			this.lblVersion.Text = "version";
			// 
			// lblEditorInfo
			// 
			this.lblEditorInfo.Anchor = ((System.Windows.Forms.AnchorStyles)(((System.Windows.Forms.AnchorStyles.Bottom | System.Windows.Forms.AnchorStyles.Left) 
			| System.Windows.Forms.AnchorStyles.Right)));
			this.lblEditorInfo.BackColor = System.Drawing.SystemColors.Info;
			this.lblEditorInfo.Location = new System.Drawing.Point(230, 330);
			this.lblEditorInfo.Name = "lblEditorInfo";
			this.lblEditorInfo.Size = new System.Drawing.Size(481, 15);
			this.lblEditorInfo.TabIndex = 12;
			this.lblEditorInfo.Text = "Important: always click apply to store changes on editor, before you save (save a" +
	"s) all changes";
			this.lblEditorInfo.Visible = false;
			// 
			// MainForm
			// 
			this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 13F);
			this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
			this.ClientSize = new System.Drawing.Size(724, 405);
			this.Controls.Add(this.tbxFile);
			this.Controls.Add(this.lblEditorInfo);
			this.Controls.Add(this.panel1);
			this.Controls.Add(this.lblInfo);
			this.Controls.Add(this.btnApply);
			this.Controls.Add(this.lbxList);
			this.Controls.Add(this.lblStatus);
			this.Controls.Add(this.btnSave);
			this.Controls.Add(this.sProgress);
			this.Controls.Add(this.btnOpen);
			this.Controls.Add(this.tbxEditor);
			this.FormBorderStyle = System.Windows.Forms.FormBorderStyle.FixedSingle;
			this.Icon = ((System.Drawing.Icon)(resources.GetObject("$this.Icon")));
			this.Name = "MainForm";
			this.StartPosition = System.Windows.Forms.FormStartPosition.CenterScreen;
			this.Text = "PB String Pack Tools";
			this.contextMenus.ResumeLayout(false);
			this.panel1.ResumeLayout(false);
			this.ResumeLayout(false);
			this.PerformLayout();

		}
	}
}
