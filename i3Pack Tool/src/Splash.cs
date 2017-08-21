/*
 * Created by SharpDevelop.
 * User: leonardo
 * Date: 11/28/2016
 * Time: 3:25 PM
 * 
 * To change this template use Tools | Options | Coding | Edit Standard Headers.
 */
using System;
using System.ComponentModel;
using System.Drawing;
using System.Reflection;
using System.Threading;
using System.Windows.Forms;

namespace i3Pack_Tools
{
	/// <summary>
	/// Description of Splash.
	/// </summary>
	public partial class Splash : Form
	{
		MainForm mForm = new MainForm();
		public Splash()
		{
			InitializeComponent();
			lblVersion.Text = appVersion;
		}
		
		private string appVersion = Assembly.GetExecutingAssembly().GetName().Version.ToString();
		private void Timer1Tick(object sender, EventArgs e)
		{
			lblStatus.Text = "loading: " + loadProgress.Value + "%";;
			if (loadProgress.Value < 100) {
				loadProgress.Value += 4;
			} else {
				timer1.Enabled = false;
				Hide();
				mForm.Show();
			}
		}
	}
}
