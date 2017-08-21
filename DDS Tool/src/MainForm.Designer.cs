/*
 * Created by SharpDevelop.
 * User: leonardo
 * Date: 11/22/2016
 * Time: 3:44 PM
 * 
 * To change this template use Tools | Options | Coding | Edit Standard Headers.
 */
namespace DDS_Tools
{
	partial class MainForm
	{
		/// <summary>
		/// Designer variable used to keep track of non-visual components.
		/// </summary>
		private System.ComponentModel.IContainer components = null;
		private System.Windows.Forms.TextBox tbxFile;
		private System.Windows.Forms.Button btnOpen;
		private System.Windows.Forms.GroupBox gbxDetails;
		private System.Windows.Forms.Label lblDivide;
		private System.Windows.Forms.Label lblMipMap;
		private System.Windows.Forms.TextBox tbxMipMap;
		private System.Windows.Forms.Label lblSurface;
		private System.Windows.Forms.Label lblP2;
		private System.Windows.Forms.Label lblP1;
		private System.Windows.Forms.Label lblWidth;
		private System.Windows.Forms.Label lblHeight;
		private System.Windows.Forms.Label label2;
		private System.Windows.Forms.Label lblDimension;
		private System.Windows.Forms.TextBox tbxHeight;
		private System.Windows.Forms.TextBox tbxWidth;
		private System.Windows.Forms.TextBox tbxHeightD;
		private System.Windows.Forms.TextBox tbxWidthD;
		private System.Windows.Forms.TextBox tbxSurface;
		private System.Windows.Forms.Button btnI3I;
		private System.Windows.Forms.TextBox tbxI3I;
		private System.Windows.Forms.GroupBox gbx3IDetails;
		private System.Windows.Forms.Label lbl3IDivide;
		private System.Windows.Forms.Label lbl3IMipMap;
		private System.Windows.Forms.TextBox tbx3IMipMap;
		private System.Windows.Forms.Label label4;
		private System.Windows.Forms.Label label9;
		private System.Windows.Forms.Label label10;
		private System.Windows.Forms.TextBox tbx3IHeight;
		private System.Windows.Forms.TextBox tbx3IWidth;
		private System.Windows.Forms.TextBox tbxI3ISurface;
		private System.Windows.Forms.Label lblSurfaceD;
		private System.Windows.Forms.Label lblI3ISurface;
		private System.Windows.Forms.Button btnConvert;
		private System.Windows.Forms.CheckBox cbxUseOriginal;
		private System.Windows.Forms.Panel panel1;
		private System.Windows.Forms.Label lblAuthor;
		private System.Windows.Forms.Label lblVersion;
		
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
			this.gbxDetails = new System.Windows.Forms.GroupBox();
			this.lblSurfaceD = new System.Windows.Forms.Label();
			this.lblDivide = new System.Windows.Forms.Label();
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
			this.btnI3I = new System.Windows.Forms.Button();
			this.tbxI3I = new System.Windows.Forms.TextBox();
			this.gbx3IDetails = new System.Windows.Forms.GroupBox();
			this.lblI3ISurface = new System.Windows.Forms.Label();
			this.lbl3IDivide = new System.Windows.Forms.Label();
			this.lbl3IMipMap = new System.Windows.Forms.Label();
			this.tbx3IMipMap = new System.Windows.Forms.TextBox();
			this.label4 = new System.Windows.Forms.Label();
			this.label9 = new System.Windows.Forms.Label();
			this.label10 = new System.Windows.Forms.Label();
			this.tbx3IHeight = new System.Windows.Forms.TextBox();
			this.tbx3IWidth = new System.Windows.Forms.TextBox();
			this.tbxI3ISurface = new System.Windows.Forms.TextBox();
			this.btnConvert = new System.Windows.Forms.Button();
			this.cbxUseOriginal = new System.Windows.Forms.CheckBox();
			this.panel1 = new System.Windows.Forms.Panel();
			this.lblAuthor = new System.Windows.Forms.Label();
			this.lblVersion = new System.Windows.Forms.Label();
			this.gbxDetails.SuspendLayout();
			this.gbx3IDetails.SuspendLayout();
			this.panel1.SuspendLayout();
			this.SuspendLayout();
			// 
			// tbxFile
			// 
			this.tbxFile.Enabled = false;
			this.tbxFile.Font = new System.Drawing.Font("Consolas", 8.25F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
			this.tbxFile.Location = new System.Drawing.Point(12, 12);
			this.tbxFile.Name = "tbxFile";
			this.tbxFile.ReadOnly = true;
			this.tbxFile.Size = new System.Drawing.Size(237, 20);
			this.tbxFile.TabIndex = 0;
			// 
			// btnOpen
			// 
			this.btnOpen.Location = new System.Drawing.Point(248, 11);
			this.btnOpen.Name = "btnOpen";
			this.btnOpen.Size = new System.Drawing.Size(25, 22);
			this.btnOpen.TabIndex = 1;
			this.btnOpen.Text = "...";
			this.btnOpen.UseVisualStyleBackColor = true;
			this.btnOpen.Click += new System.EventHandler(this.BtnOpenClick);
			// 
			// gbxDetails
			// 
			this.gbxDetails.Controls.Add(this.lblSurfaceD);
			this.gbxDetails.Controls.Add(this.lblDivide);
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
			this.gbxDetails.Location = new System.Drawing.Point(12, 35);
			this.gbxDetails.Name = "gbxDetails";
			this.gbxDetails.Size = new System.Drawing.Size(260, 111);
			this.gbxDetails.TabIndex = 2;
			this.gbxDetails.TabStop = false;
			this.gbxDetails.Text = "DDS";
			// 
			// lblSurfaceD
			// 
			this.lblSurfaceD.Location = new System.Drawing.Point(116, 85);
			this.lblSurfaceD.Name = "lblSurfaceD";
			this.lblSurfaceD.Size = new System.Drawing.Size(138, 15);
			this.lblSurfaceD.TabIndex = 33;
			// 
			// lblDivide
			// 
			this.lblDivide.Location = new System.Drawing.Point(172, 18);
			this.lblDivide.Name = "lblDivide";
			this.lblDivide.Size = new System.Drawing.Size(10, 15);
			this.lblDivide.TabIndex = 32;
			this.lblDivide.Text = ":";
			this.lblDivide.TextAlign = System.Drawing.ContentAlignment.TopCenter;
			this.lblDivide.Visible = false;
			// 
			// lblMipMap
			// 
			this.lblMipMap.Location = new System.Drawing.Point(214, 17);
			this.lblMipMap.Name = "lblMipMap";
			this.lblMipMap.Size = new System.Drawing.Size(43, 15);
			this.lblMipMap.TabIndex = 31;
			this.lblMipMap.Text = "mipmap";
			this.lblMipMap.TextAlign = System.Drawing.ContentAlignment.MiddleLeft;
			this.lblMipMap.Visible = false;
			// 
			// tbxMipMap
			// 
			this.tbxMipMap.Enabled = false;
			this.tbxMipMap.ForeColor = System.Drawing.SystemColors.ControlText;
			this.tbxMipMap.Location = new System.Drawing.Point(183, 15);
			this.tbxMipMap.Name = "tbxMipMap";
			this.tbxMipMap.ReadOnly = true;
			this.tbxMipMap.Size = new System.Drawing.Size(30, 20);
			this.tbxMipMap.TabIndex = 30;
			this.tbxMipMap.Text = "1/11";
			this.tbxMipMap.TextAlign = System.Windows.Forms.HorizontalAlignment.Center;
			this.tbxMipMap.Visible = false;
			// 
			// lblSurface
			// 
			this.lblSurface.Location = new System.Drawing.Point(12, 85);
			this.lblSurface.Name = "lblSurface";
			this.lblSurface.Size = new System.Drawing.Size(63, 15);
			this.lblSurface.TabIndex = 29;
			this.lblSurface.Text = "Surface";
			// 
			// lblP2
			// 
			this.lblP2.Location = new System.Drawing.Point(117, 61);
			this.lblP2.Name = "lblP2";
			this.lblP2.Size = new System.Drawing.Size(60, 15);
			this.lblP2.TabIndex = 28;
			this.lblP2.Text = "pixeles";
			this.lblP2.Visible = false;
			// 
			// lblP1
			// 
			this.lblP1.Location = new System.Drawing.Point(117, 40);
			this.lblP1.Name = "lblP1";
			this.lblP1.Size = new System.Drawing.Size(60, 15);
			this.lblP1.TabIndex = 27;
			this.lblP1.Text = "pixeles";
			this.lblP1.Visible = false;
			// 
			// lblWidth
			// 
			this.lblWidth.Location = new System.Drawing.Point(12, 40);
			this.lblWidth.Name = "lblWidth";
			this.lblWidth.Size = new System.Drawing.Size(63, 15);
			this.lblWidth.TabIndex = 26;
			this.lblWidth.Text = "Width";
			// 
			// lblHeight
			// 
			this.lblHeight.Location = new System.Drawing.Point(12, 62);
			this.lblHeight.Name = "lblHeight";
			this.lblHeight.Size = new System.Drawing.Size(63, 15);
			this.lblHeight.TabIndex = 25;
			this.lblHeight.Text = "Height";
			// 
			// label2
			// 
			this.label2.Location = new System.Drawing.Point(118, 17);
			this.label2.Name = "label2";
			this.label2.Size = new System.Drawing.Size(12, 15);
			this.label2.TabIndex = 24;
			this.label2.Text = "x";
			this.label2.TextAlign = System.Drawing.ContentAlignment.TopCenter;
			// 
			// lblDimension
			// 
			this.lblDimension.Location = new System.Drawing.Point(12, 18);
			this.lblDimension.Name = "lblDimension";
			this.lblDimension.Size = new System.Drawing.Size(63, 15);
			this.lblDimension.TabIndex = 23;
			this.lblDimension.Text = "Dimensions";
			// 
			// tbxHeight
			// 
			this.tbxHeight.Enabled = false;
			this.tbxHeight.ForeColor = System.Drawing.SystemColors.ControlText;
			this.tbxHeight.Location = new System.Drawing.Point(76, 59);
			this.tbxHeight.Name = "tbxHeight";
			this.tbxHeight.ReadOnly = true;
			this.tbxHeight.Size = new System.Drawing.Size(40, 20);
			this.tbxHeight.TabIndex = 22;
			this.tbxHeight.TextAlign = System.Windows.Forms.HorizontalAlignment.Center;
			// 
			// tbxWidth
			// 
			this.tbxWidth.Enabled = false;
			this.tbxWidth.ForeColor = System.Drawing.SystemColors.ControlText;
			this.tbxWidth.Location = new System.Drawing.Point(76, 37);
			this.tbxWidth.Name = "tbxWidth";
			this.tbxWidth.ReadOnly = true;
			this.tbxWidth.Size = new System.Drawing.Size(40, 20);
			this.tbxWidth.TabIndex = 21;
			this.tbxWidth.TextAlign = System.Windows.Forms.HorizontalAlignment.Center;
			// 
			// tbxHeightD
			// 
			this.tbxHeightD.Enabled = false;
			this.tbxHeightD.ForeColor = System.Drawing.SystemColors.ControlText;
			this.tbxHeightD.Location = new System.Drawing.Point(131, 15);
			this.tbxHeightD.Name = "tbxHeightD";
			this.tbxHeightD.ReadOnly = true;
			this.tbxHeightD.Size = new System.Drawing.Size(40, 20);
			this.tbxHeightD.TabIndex = 20;
			this.tbxHeightD.TextAlign = System.Windows.Forms.HorizontalAlignment.Center;
			// 
			// tbxWidthD
			// 
			this.tbxWidthD.Enabled = false;
			this.tbxWidthD.ForeColor = System.Drawing.SystemColors.ControlText;
			this.tbxWidthD.Location = new System.Drawing.Point(76, 15);
			this.tbxWidthD.Name = "tbxWidthD";
			this.tbxWidthD.ReadOnly = true;
			this.tbxWidthD.Size = new System.Drawing.Size(40, 20);
			this.tbxWidthD.TabIndex = 19;
			this.tbxWidthD.TextAlign = System.Windows.Forms.HorizontalAlignment.Center;
			// 
			// tbxSurface
			// 
			this.tbxSurface.Enabled = false;
			this.tbxSurface.ForeColor = System.Drawing.SystemColors.ControlText;
			this.tbxSurface.Location = new System.Drawing.Point(76, 82);
			this.tbxSurface.Name = "tbxSurface";
			this.tbxSurface.ReadOnly = true;
			this.tbxSurface.Size = new System.Drawing.Size(40, 20);
			this.tbxSurface.TabIndex = 18;
			this.tbxSurface.TextAlign = System.Windows.Forms.HorizontalAlignment.Center;
			// 
			// btnI3I
			// 
			this.btnI3I.Enabled = false;
			this.btnI3I.Location = new System.Drawing.Point(248, 150);
			this.btnI3I.Name = "btnI3I";
			this.btnI3I.Size = new System.Drawing.Size(25, 22);
			this.btnI3I.TabIndex = 4;
			this.btnI3I.Text = "...";
			this.btnI3I.UseVisualStyleBackColor = true;
			this.btnI3I.Click += new System.EventHandler(this.BtnI3IClick);
			// 
			// tbxI3I
			// 
			this.tbxI3I.Enabled = false;
			this.tbxI3I.Font = new System.Drawing.Font("Consolas", 8.25F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
			this.tbxI3I.Location = new System.Drawing.Point(12, 151);
			this.tbxI3I.Name = "tbxI3I";
			this.tbxI3I.ReadOnly = true;
			this.tbxI3I.Size = new System.Drawing.Size(237, 20);
			this.tbxI3I.TabIndex = 3;
			// 
			// gbx3IDetails
			// 
			this.gbx3IDetails.Controls.Add(this.lblI3ISurface);
			this.gbx3IDetails.Controls.Add(this.lbl3IDivide);
			this.gbx3IDetails.Controls.Add(this.lbl3IMipMap);
			this.gbx3IDetails.Controls.Add(this.tbx3IMipMap);
			this.gbx3IDetails.Controls.Add(this.label4);
			this.gbx3IDetails.Controls.Add(this.label9);
			this.gbx3IDetails.Controls.Add(this.label10);
			this.gbx3IDetails.Controls.Add(this.tbx3IHeight);
			this.gbx3IDetails.Controls.Add(this.tbx3IWidth);
			this.gbx3IDetails.Controls.Add(this.tbxI3ISurface);
			this.gbx3IDetails.ForeColor = System.Drawing.SystemColors.ControlDarkDark;
			this.gbx3IDetails.Location = new System.Drawing.Point(12, 174);
			this.gbx3IDetails.Name = "gbx3IDetails";
			this.gbx3IDetails.Size = new System.Drawing.Size(260, 71);
			this.gbx3IDetails.TabIndex = 5;
			this.gbx3IDetails.TabStop = false;
			this.gbx3IDetails.Text = "I3I";
			// 
			// lblI3ISurface
			// 
			this.lblI3ISurface.Location = new System.Drawing.Point(117, 42);
			this.lblI3ISurface.Name = "lblI3ISurface";
			this.lblI3ISurface.Size = new System.Drawing.Size(138, 15);
			this.lblI3ISurface.TabIndex = 33;
			// 
			// lbl3IDivide
			// 
			this.lbl3IDivide.Location = new System.Drawing.Point(172, 18);
			this.lbl3IDivide.Name = "lbl3IDivide";
			this.lbl3IDivide.Size = new System.Drawing.Size(10, 15);
			this.lbl3IDivide.TabIndex = 32;
			this.lbl3IDivide.Text = ":";
			this.lbl3IDivide.TextAlign = System.Drawing.ContentAlignment.TopCenter;
			this.lbl3IDivide.Visible = false;
			// 
			// lbl3IMipMap
			// 
			this.lbl3IMipMap.Location = new System.Drawing.Point(203, 17);
			this.lbl3IMipMap.Name = "lbl3IMipMap";
			this.lbl3IMipMap.Size = new System.Drawing.Size(45, 15);
			this.lbl3IMipMap.TabIndex = 31;
			this.lbl3IMipMap.Text = "mipmap";
			this.lbl3IMipMap.TextAlign = System.Drawing.ContentAlignment.MiddleLeft;
			this.lbl3IMipMap.Visible = false;
			// 
			// tbx3IMipMap
			// 
			this.tbx3IMipMap.Enabled = false;
			this.tbx3IMipMap.ForeColor = System.Drawing.SystemColors.ControlText;
			this.tbx3IMipMap.Location = new System.Drawing.Point(183, 15);
			this.tbx3IMipMap.Name = "tbx3IMipMap";
			this.tbx3IMipMap.ReadOnly = true;
			this.tbx3IMipMap.Size = new System.Drawing.Size(19, 20);
			this.tbx3IMipMap.TabIndex = 30;
			this.tbx3IMipMap.Text = "1";
			this.tbx3IMipMap.TextAlign = System.Windows.Forms.HorizontalAlignment.Center;
			this.tbx3IMipMap.Visible = false;
			// 
			// label4
			// 
			this.label4.Location = new System.Drawing.Point(12, 42);
			this.label4.Name = "label4";
			this.label4.Size = new System.Drawing.Size(63, 15);
			this.label4.TabIndex = 29;
			this.label4.Text = "Surface";
			// 
			// label9
			// 
			this.label9.Location = new System.Drawing.Point(118, 17);
			this.label9.Name = "label9";
			this.label9.Size = new System.Drawing.Size(12, 15);
			this.label9.TabIndex = 24;
			this.label9.Text = "x";
			this.label9.TextAlign = System.Drawing.ContentAlignment.TopCenter;
			// 
			// label10
			// 
			this.label10.Location = new System.Drawing.Point(12, 18);
			this.label10.Name = "label10";
			this.label10.Size = new System.Drawing.Size(63, 15);
			this.label10.TabIndex = 23;
			this.label10.Text = "Dimensions";
			// 
			// tbx3IHeight
			// 
			this.tbx3IHeight.Enabled = false;
			this.tbx3IHeight.ForeColor = System.Drawing.SystemColors.ControlText;
			this.tbx3IHeight.Location = new System.Drawing.Point(131, 15);
			this.tbx3IHeight.Name = "tbx3IHeight";
			this.tbx3IHeight.ReadOnly = true;
			this.tbx3IHeight.Size = new System.Drawing.Size(40, 20);
			this.tbx3IHeight.TabIndex = 20;
			this.tbx3IHeight.TextAlign = System.Windows.Forms.HorizontalAlignment.Center;
			// 
			// tbx3IWidth
			// 
			this.tbx3IWidth.Enabled = false;
			this.tbx3IWidth.ForeColor = System.Drawing.SystemColors.ControlText;
			this.tbx3IWidth.Location = new System.Drawing.Point(76, 15);
			this.tbx3IWidth.Name = "tbx3IWidth";
			this.tbx3IWidth.ReadOnly = true;
			this.tbx3IWidth.Size = new System.Drawing.Size(40, 20);
			this.tbx3IWidth.TabIndex = 19;
			this.tbx3IWidth.TextAlign = System.Windows.Forms.HorizontalAlignment.Center;
			// 
			// tbxI3ISurface
			// 
			this.tbxI3ISurface.Enabled = false;
			this.tbxI3ISurface.ForeColor = System.Drawing.SystemColors.ControlText;
			this.tbxI3ISurface.Location = new System.Drawing.Point(76, 39);
			this.tbxI3ISurface.Name = "tbxI3ISurface";
			this.tbxI3ISurface.ReadOnly = true;
			this.tbxI3ISurface.Size = new System.Drawing.Size(40, 20);
			this.tbxI3ISurface.TabIndex = 18;
			this.tbxI3ISurface.TextAlign = System.Windows.Forms.HorizontalAlignment.Center;
			// 
			// btnConvert
			// 
			this.btnConvert.Enabled = false;
			this.btnConvert.Location = new System.Drawing.Point(197, 251);
			this.btnConvert.Name = "btnConvert";
			this.btnConvert.Size = new System.Drawing.Size(75, 23);
			this.btnConvert.TabIndex = 6;
			this.btnConvert.Text = "Convert";
			this.btnConvert.UseVisualStyleBackColor = true;
			this.btnConvert.Click += new System.EventHandler(this.BtnConvertClick);
			// 
			// cbxUseOriginal
			// 
			this.cbxUseOriginal.Enabled = false;
			this.cbxUseOriginal.FlatStyle = System.Windows.Forms.FlatStyle.Flat;
			this.cbxUseOriginal.Location = new System.Drawing.Point(12, 249);
			this.cbxUseOriginal.Name = "cbxUseOriginal";
			this.cbxUseOriginal.Size = new System.Drawing.Size(146, 24);
			this.cbxUseOriginal.TabIndex = 7;
			this.cbxUseOriginal.Text = "use original i3i file";
			this.cbxUseOriginal.UseVisualStyleBackColor = true;
			this.cbxUseOriginal.CheckedChanged += new System.EventHandler(this.CbxUseOriginalCheckedChanged);
			// 
			// panel1
			// 
			this.panel1.BackColor = System.Drawing.SystemColors.Window;
			this.panel1.Controls.Add(this.lblAuthor);
			this.panel1.Controls.Add(this.lblVersion);
			this.panel1.Location = new System.Drawing.Point(2, 280);
			this.panel1.Name = "panel1";
			this.panel1.Size = new System.Drawing.Size(280, 26);
			this.panel1.TabIndex = 8;
			// 
			// lblAuthor
			// 
			this.lblAuthor.Font = new System.Drawing.Font("Ebrima", 8.25F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
			this.lblAuthor.ForeColor = System.Drawing.SystemColors.ControlDarkDark;
			this.lblAuthor.Location = new System.Drawing.Point(95, 6);
			this.lblAuthor.Name = "lblAuthor";
			this.lblAuthor.Size = new System.Drawing.Size(178, 15);
			this.lblAuthor.TabIndex = 3;
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
			this.lblVersion.Location = new System.Drawing.Point(7, 6);
			this.lblVersion.Name = "lblVersion";
			this.lblVersion.Size = new System.Drawing.Size(92, 15);
			this.lblVersion.TabIndex = 2;
			this.lblVersion.Text = "version";
			// 
			// MainForm
			// 
			this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 13F);
			this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
			this.ClientSize = new System.Drawing.Size(284, 308);
			this.Controls.Add(this.panel1);
			this.Controls.Add(this.cbxUseOriginal);
			this.Controls.Add(this.btnConvert);
			this.Controls.Add(this.gbx3IDetails);
			this.Controls.Add(this.tbxFile);
			this.Controls.Add(this.tbxI3I);
			this.Controls.Add(this.btnI3I);
			this.Controls.Add(this.gbxDetails);
			this.Controls.Add(this.btnOpen);
			this.Icon = ((System.Drawing.Icon)(resources.GetObject("$this.Icon")));
			this.MaximizeBox = false;
			this.Name = "MainForm";
			this.StartPosition = System.Windows.Forms.FormStartPosition.CenterScreen;
			this.Text = "DDS Conversion Tools";
			this.gbxDetails.ResumeLayout(false);
			this.gbxDetails.PerformLayout();
			this.gbx3IDetails.ResumeLayout(false);
			this.gbx3IDetails.PerformLayout();
			this.panel1.ResumeLayout(false);
			this.ResumeLayout(false);
			this.PerformLayout();

		}
	}
}
