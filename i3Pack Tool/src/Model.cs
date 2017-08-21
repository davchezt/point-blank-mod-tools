/*
 * Created by SharpDevelop.
 * User: leonardo
 * Date: 11/25/2016
 * Time: 4:30 PM
 * 
 * To change this template use Tools | Options | Coding | Edit Standard Headers.
 */
using System;

namespace i3Pack_Tools
{
	public class Model
	{
		/// <summary>
		/// _contentId, offset buffer
		/// </summary>
		public int ItemID, ItemOffset;
		
		/// <summary>
		/// _nodes, trnID
		/// </summary>
		public int ItemNode;
		
		/// <summary>
		/// <value>0 = i3pack header</value>
		/// <value>1 = text</value>
		/// <value>2 = i3i</value>
		/// <value>3 = map txt</value>
		/// <value>4 = wav</value>
		/// <value>5 = ogg</value>
		/// <value>6 = dds</value>
		/// </summary>
		public int itemType;
		
		public int getItemID()
		{
			return ItemID;
		}
		
		public int getItemOffset()
		{
			return ItemOffset;
		}
		
		public int getItemNode()
		{
			return ItemNode;
		}
		
		public int getItemType()
		{
			return itemType;
		}
	}
}
