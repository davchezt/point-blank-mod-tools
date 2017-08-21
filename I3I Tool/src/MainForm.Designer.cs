/*
 * Created by SharpDevelop.
 * User: leonardo
 * Date: 11/21/2016
 * Time: 7:03 PM
 * 
 * To change this template use Tools | Options | Coding | Edit Standard Headers.
 */
namespace I3I_Tools
{
	partial class MainForm
	{
		/// <summary>
		/// Designer variable used to keep track of non-visual components.
		/// </summary>
		private System.ComponentModel.IContainer components = null;
		private System.Windows.Forms.TextBox tbxFile;
		private System.Windows.Forms.Button btnOpen;
		private System.Windows.Forms.ListBox lbxDetail;
		private System.Windows.Forms.Button btnConvert;
		private System.Windows.Forms.GroupBox gbxDetails;
		private System.Windows.Forms.TextBox tbxSurface;
		private System.Windows.Forms.TextBox tbxHeight;
		private System.Windows.Forms.TextBox tbxWidth;
		private System.Windows.Forms.TextBox tbxHeightD;
		private System.Windows.Forms.TextBox tbxWidthD;
		private System.Windows.Forms.Label lblWidth;
		private System.Windows.Forms.Label lblHeight;
		private System.Windows.Forms.Label label2;
		private System.Windows.Forms.Label lblDimension;
		private System.Windows.Forms.Label lblP2;
		private System.Windows.Forms.Label lblP1;
		private System.Windows.Forms.Label lblSurface;
		private System.Windows.Forms.TextBox tbxMipMap;
		private System.Windows.Forms.Label lblMipMap;
		private System.Windows.Forms.Label lblInfo;
		private System.Windows.Forms.Label lblSurfaceD;
		private System.Windows.Forms.Label lblDivide;
		private System.Windows.Forms.Panel panel1;
		private System.Windows.Forms.Label lblVersion;
		private System.Windows.Forms.Label lblAuthor;
		
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
			System.ComponentModel.ComponentResourceManager resources = new System.ComponentModel.ComponentResourceManager(typeof(MainForm));
			this.tbxFile = new System.Windows.Forms.TextBox();
			this.btnOpen = new System.Windows.Forms.Button();
			this.lbxDetail = new System.Windows.Forms.ListBox();
			this.btnConvert = new System.Windows.Forms.Button();
			this.gbxDetails = new System.Windows.Forms.GroupBox();
			this.lblDivide = new System.Windows.Forms.Label();
			this.lblSurfaceD = new System.Windows.Forms.Label();
			this.lblMipMap = new System.Windows.Forms.Label();
			this.tbxMipMap = new System.Windows.Forms.TextBox();
			this.lblSurface = new System.Windows.Forms.Label();
			this.lblP2 = new System.Windows.Forms.Label();
			this.lblP1 = new System.Windows.Forms.Label();
			this.lblWidth = new System.Windows.Forms.Label();
			this.lblHeight = new System.Windows.Forms.Label();
			this.label2 = new System.Windows.Forms.Label();
			this.lblDimension = new System.Windows.Forms.Label();
			this.tbxHeight = new System.Windows.Forms.TextBox();
			this.tbxWidth = new System.Windows.Forms.TextBox();
			this.tbxHeightD = new System.Windows.Forms.TextBox();
			this.tbxWidthD = new System.Windows.Forms.TextBox();
			this.tbxSurface = new System.Windows.Forms.TextBox();
			this.lblInfo = new System.Windows.Forms.Label();
			this.panel1 = new System.Windows.Forms.Panel();
			this.lblAuthor = new System.Windows.Forms.Label();
			this.lblVersion = new System.Windows.Forms.Label();
			this.gbxDetails.SuspendLayout();
			this.panel1.SuspendLayout();
			this.SuspendLayout();
			// 
			// tbxFile
			// 
			this.tbxFile.AllowDrop = true;
			this.tbxFile.Location = new System.Drawing.Point(12, 12);
			this.tbxFile.Name = "tbxFile";
			this.tbxFile.ReadOnly = true;
			this.tbxFile.Size = new System.Drawing.Size(238, 20);
			this.tbxFile.TabIndex = 1;
			// 
			// btnOpen
			// 
			this.btnOpen.Location = new System.Drawing.Point(248, 11);
			this.btnOpen.Name = "btnOpen";
			this.btnOpen.Size = new System.Drawing.Size(25, 22);
			this.btnOpen.TabIndex = 2;
			this.btnOpen.Text = "...";
			this.btnOpen.UseVisualStyleBackColor = true;
			this.btnOpen.Click += new System.EventHandler(this.BtnOpenClick);
			// 
			// lbxDetail
			// 
			this.lbxDetail.BackColor = System.Drawing.SystemColors.ButtonFace;
			this.lbxDetail.Enabled = false;
			this.lbxDetail.Font = new System.Drawing.Font("Consolas", 8.25F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
			this.lbxDetail.FormattingEnabled = true;
			this.lbxDetail.Location = new System.Drawing.Point(12, 38);
			this.lbxDetail.Name = "lbxDetail";
			this.lbxDetail.Size = new System.Drawing.Size(260, 43);
			this.lbxDetail.TabIndex = 2;
			// 
			// btnConvert
			// 
			this.btnConvert.Enabled = false;
			this.btnConvert.Location = new System.Drawing.Point(198, 228);
			this.btnConvert.Name = "btnConvert";
			this.btnConvert.Size = new System.Drawing.Size(75, 23);
			this.btnConvert.TabIndex = 3;
			this.btnConvert.Text = "Convert";
			this.btnConvert.UseVisualStyleBackColor = true;
			this.btnConvert.Click += new System.EventHandler(this.BtnConvertClick);
			// 
			// gbxDetails
			// 
			this.gbxDetails.Controls.Add(this.lblDivide);
			this.gbxDetails.Controls.Add(this.lblSurfaceD);
			this.gbxDetails.Controls.Add(this.lblMipMap);
			this.gbxDetails.Controls.Add(this.tbxMipMap);
			this.gbxDetails.Controls.Add(this.lblSurface);
			this.gbxDetails.Controls.Add(this.lblP2);
			this.gbxDetails.Controls.Add(this.lblP1);
			this.gbxDetails.Controls.Add(this.lblWidth);
			this.gbxDetails.Controls.Add(this.lblHeight);
			this.gbxDetails.Controls.Add(this.label2);
			this.gbxDetails.Controls.Add(this.lblDimension);
			this.gbxDetails.Controls.Add(this.tbxHeight);
			this.gbxDetails.Controls.Add(this.tbxWidth);
			this.gbxDetails.Controls.Add(this.tbxHeightD);
			this.gbxDetails.Controls.Add(this.tbxWidthD);
			this.gbxDetails.Controls.Add(this.tbxSurface);
			this.gbxDetails.ForeColor = System.Drawing.SystemColors.ControlDarkDark;
			this.gbxDetails.Location = new System.Drawing.Point(12, 100);
			this.gbxDetails.Name = "gbxDetails";
			this.gbxDetails.Size = new System.Drawing.Size(260, 122);
			this.gbxDetails.TabIndex = 5;
			this.gbxDetails.TabStop = false;
			// 
			// lblDivide
			// 
			this.lblDivide.Location = new System.Drawing.Point(171, 22);
			this.lblDivide.Name = "lblDivide";
			this.lblDivide.Size = new System.Drawing.Size(10, 15);
			this.lblDivide.TabIndex = 17;
			this.lblDivide.Text = ":";
			this.lblDivide.TextAlign = System.Drawing.ContentAlignment.TopCenter;
			this.lblDivide.Visible = false;
			// 
			// lblSurfaceD
			// 
			this.lblSurfaceD.Location = new System.Drawing.Point(115, 89);
			this.lblSurfaceD.Name = "lblSurfaceD";
			this.lblSurfaceD.Size = new System.Drawing.Size(138, 15);
			this.lblSurfaceD.TabIndex = 16;
			// 
			// lblMipMap
			// 
			this.lblMipMap.Location = new System.Drawing.Point(202, 21);
			this.lblMipMap.Name = "lblMipMap";
			this.lblMipMap.Size = new System.Drawing.Size(45, 15);
			this.lblMipMap.TabIndex = 15;
			this.lblMipMap.Text = "mipmap";
			this.lblMipMap.TextAlign = System.Drawing.ContentAlignment.MiddleLeft;
			this.lblMipMap.Visible = false;
			// 
			// tbxMipMap
			// 
			this.tbxMipMap.Enabled = false;
			this.tbxMipMap.ForeColor = System.Drawing.SystemColors.ControlText;
			this.tbxMipMap.Location = new System.Drawing.Point(182, 19);
			this.tbxMipMap.Name = "tbxMipMap";
			this.tbxMipMap.ReadOnly = true;
			this.tbxMipMap.Size = new System.Drawing.Size(19, 20);
			this.tbxMipMap.TabIndex = 14;
			this.tbxMipMap.TextAlign = System.Windows.Forms.HorizontalAlignment.Center;
			this.tbxMipMap.Visible = false;
			// 
			// lblSurface
			// 
			this.lblSurface.Location = new System.Drawing.Point(11, 89);
			this.lblSurface.Name = "lblSurface";
			this.lblSurface.Size = new System.Drawing.Size(63, 15);
			this.lblSurface.TabIndex = 13;
			this.lblSurface.Text = "Surface";
			// 
			// lblP2
			// 
			this.lblP2.Location = new System.Drawing.Point(116, 65);
			this.lblP2.Name = "lblP2";
			this.lblP2.Size = new System.Drawing.Size(60, 15);
			this.lblP2.TabIndex = 12;
			this.lblP2.Text = "pixeles";
			this.lblP2.Visible = false;
			// 
			// lblP1
			// 
			this.lblP1.Location = new System.Drawing.Point(116, 44);
			this.lblP1.Name = "lblP1";
			this.lblP1.Size = new System.Drawing.Size(60, 15);
			this.lblP1.TabIndex = 11;
			this.lblP1.Text = "pixeles";
			this.lblP1.Visible = false;
			// 
			// lblWidth
			// 
			this.lblWidth.Location = new System.Drawing.Point(11, 44);
			this.lblWidth.Name = "lblWidth";
			this.lblWidth.Size = new System.Drawing.Size(63, 15);
			this.lblWidth.TabIndex = 10;
			this.lblWidth.Text = "Width";
			// 
			// lblHeight
			// 
			this.lblHeight.Location = new System.Drawing.Point(11, 66);
			this.lblHeight.Name = "lblHeight";
			this.lblHeight.Size = new System.Drawing.Size(63, 15);
			this.lblHeight.TabIndex = 9;
			this.lblHeight.Text = "Height";
			// 
			// label2
			// 
			this.label2.Location = new System.Drawing.Point(117, 21);
			this.label2.Name = "label2";
			this.label2.Size = new System.Drawing.Size(12, 15);
			this.label2.TabIndex = 8;
			this.label2.Text = "x";
			this.label2.TextAlign = System.Drawing.ContentAlignment.TopCenter;
			// 
			// lblDimension
			// 
			this.lblDimension.Location = new System.Drawing.Point(11, 22);
			this.lblDimension.Name = "lblDimension";
			this.lblDimension.Size = new System.Drawing.Size(63, 15);
			this.lblDimension.TabIndex = 7;
			this.lblDimension.Text = "Dimensions";
			// 
			// tbxHeight
			// 
			this.tbxHeight.Enabled = false;
			this.tbxHeight.ForeColor = System.Drawing.SystemColors.ControlText;
			this.tbxHeight.Location = new System.Drawing.Point(75, 63);
			this.tbxHeight.Name = "tbxHeight";
			this.tbxHeight.ReadOnly = true;
			this.tbxHeight.Size = new System.Drawing.Size(40, 20);
			this.tbxHeight.TabIndex = 6;
			this.tbxHeight.TextAlign = System.Windows.Forms.HorizontalAlignment.Center;
			// 
			// tbxWidth
			// 
			this.tbxWidth.Enabled = false;
			this.tbxWidth.ForeColor = System.Drawing.SystemColors.ControlText;
			this.tbxWidth.Location = new System.Drawing.Point(75, 41);
			this.tbxWidth.Name = "tbxWidth";
			this.tbxWidth.ReadOnly = true;
			this.tbxWidth.Size = new System.Drawing.Size(40, 20);
			this.tbxWidth.TabIndex = 5;
			this.tbxWidth.TextAlign = System.Windows.Forms.HorizontalAlignment.Center;
			// 
			// tbxHeightD
			// 
			this.tbxHeightD.Enabled = false;
			this.tbxHeightD.ForeColor = System.Drawing.SystemColors.ControlText;
			this.tbxHeightD.Location = new System.Drawing.Point(130, 19);
			this.tbxHeightD.Name = "tbxHeightD";
			this.tbxHeightD.ReadOnly = true;
			this.tbxHeightD.Size = new System.Drawing.Size(40, 20);
			this.tbxHeightD.TabIndex = 4;
			this.tbxHeightD.TextAlign = System.Windows.Forms.HorizontalAlignment.Center;
			// 
			// tbxWidthD
			// 
			this.tbxWidthD.Enabled = false;
			this.tbxWidthD.ForeColor = System.Drawing.SystemColors.ControlText;
			this.tbxWidthD.Location = new System.Drawing.Point(75, 19);
			this.tbxWidthD.Name = "tbxWidthD";
			this.tbxWidthD.ReadOnly = true;
			this.tbxWidthD.Size = new System.Drawing.Size(40, 20);
			this.tbxWidthD.TabIndex = 3;
			this.tbxWidthD.TextAlign = System.Windows.Forms.HorizontalAlignment.Center;
			// 
			// tbxSurface
			// 
			this.tbxSurface.Enabled = false;
			this.tbxSurface.ForeColor = System.Drawing.SystemColors.ControlText;
			this.tbxSurface.Location = new System.Drawing.Point(75, 86);
			this.tbxSurface.Name = "tbxSurface";
			this.tbxSurface.ReadOnly = true;
			this.tbxSurface.Size = new System.Drawing.Size(40, 20);
			this.tbxSurface.TabIndex = 1;
			this.tbxSurface.TextAlign = System.Windows.Forms.HorizontalAlignment.Center;
			// 
			// lblInfo
			// 
			this.lblInfo.BackColor = System.Drawing.Color.GhostWhite;
			this.lblInfo.ForeColor = System.Drawing.Color.DarkOrange;
			this.lblInfo.Location = new System.Drawing.Point(12, 86);
			this.lblInfo.Name = "lblInfo";
			this.lblInfo.Size = new System.Drawing.Size(259, 15);
			this.lblInfo.TabIndex = 6;
			this.lblInfo.Text = "info: selet file that need to be converted into DDS";
			// 
			// panel1
			// 
			this.panel1.BackColor = System.Drawing.SystemColors.ControlLightLight;
			this.panel1.Controls.Add(this.lblAuthor);
			this.panel1.Controls.Add(this.lblVersion);
			this.panel1.Location = new System.Drawing.Point(0, 257);
			this.panel1.Name = "panel1";
			this.panel1.Size = new System.Drawing.Size(284, 27);
			this.panel1.TabIndex = 7;
			// 
			// lblAuthor
			// 
			this.lblAuthor.Font = new System.Drawing.Font("Ebrima", 8.25F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
			this.lblAuthor.ForeColor = System.Drawing.SystemColors.ControlDarkDark;
			this.lblAuthor.Location = new System.Drawing.Point(98, 6);
			this.lblAuthor.Name = "lblAuthor";
			this.lblAuthor.Size = new System.Drawing.Size(178, 15);
			this.lblAuthor.TabIndex = 4;
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
			this.lblVersion.Location = new System.Drawing.Point(10, 6);
			this.lblVersion.Name = "lblVersion";
			this.lblVersion.Size = new System.Drawing.Size(92, 15);
			this.lblVersion.TabIndex = 0;
			this.lblVersion.Text = "version";
			// 
			// MainForm
			// 
			this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 13F);
			this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
			this.ClientSize = new System.Drawing.Size(284, 284);
			this.Controls.Add(this.tbxFile);
			this.Controls.Add(this.panel1);
			this.Controls.Add(this.lblInfo);
			this.Controls.Add(this.gbxDetails);
			this.Controls.Add(this.btnConvert);
			this.Controls.Add(this.lbxDetail);
			this.Controls.Add(this.btnOpen);
			this.FormBorderStyle = System.Windows.Forms.FormBorderStyle.FixedSingle;
			this.Icon = ((System.Drawing.Icon)(resources.GetObject("$this.Icon")));
			this.MaximizeBox = false;
			this.Name = "MainForm";
			this.StartPosition = System.Windows.Forms.FormStartPosition.CenterScreen;
			this.Text = "I3I Conversion Tools";
			this.gbxDetails.ResumeLayout(false);
			this.gbxDetails.PerformLayout();
			this.panel1.ResumeLayout(false);
			this.ResumeLayout(false);
			this.PerformLayout();

		}
	}
}
