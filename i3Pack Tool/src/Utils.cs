/*
 * Created by SharpDevelop.
 * User: leonardo
 * Date: 11/23/2016
 * Time: 1:57 PM
 * 
 * To change this template use Tools | Options | Coding | Edit Standard Headers.
 */
using System;
using System.Text;

namespace i3Pack_Tools
{
	/// <summary>
	/// Description of Utils.
	/// </summary>
	static class Util
	{
		public static string getString(byte[] buff, int index, int count)
		{
			if (buff.Length < index || buff.Length < count) {
				return string.Empty;
			}
			else {
				return Encoding.ASCII.GetString(buff, index, count);
			}
		}
	}
}
