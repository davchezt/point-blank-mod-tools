/*
 * Created by SharpDevelop.
 * User: leonardo
 * Date: 11/26/2016
 * Time: 11:53 PM
 * 
 * To change this template use Tools | Options | Coding | Edit Standard Headers.
 */
using System;
using System.ComponentModel;
using System.Diagnostics;
using System.Drawing;
using System.Reflection;
using System.Windows.Forms;

namespace i3Pack_Tools
{
	/// <summary>
	/// Description of About.
	/// </summary>
	public partial class About : Form
	{
		public About()
		{
			InitializeComponent();
			lblVersion.Text = string.Format("v{0}", appVersion);
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
		protected override void OnClosing(CancelEventArgs e)
		{
			this.Hide();

			e.Cancel = true;
			base.OnClosing(e);
		}
	}
}
