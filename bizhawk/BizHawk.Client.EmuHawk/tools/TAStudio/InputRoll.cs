﻿using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Windows.Forms;

using BizHawk.Client.EmuHawk.CustomControls;

namespace BizHawk.Client.EmuHawk
{
	public class InputRoll : Control
	{
		private readonly GDIRenderer gdi;
		private readonly RollColumns _columns = new RollColumns();
		
		public InputRoll()
		{
			CellPadding = 3;
			//SetStyle(ControlStyles.OptimizedDoubleBuffer, true);
			SetStyle(ControlStyles.AllPaintingInWmPaint, true);
			SetStyle(ControlStyles.SupportsTransparentBackColor, true);
			SetStyle(ControlStyles.Opaque, true);
			this.Font = new Font("Courier New", 8);
			//BackColor = Color.Transparent;

			gdi = new GDIRenderer(this);
		}

		#region Properties

		/// <summary>
		/// Gets or sets the amount of padding on the text inside a cell
		/// </summary>
		[DefaultValue(3)]
		public int CellPadding { get; set; }

		// TODO: remove this, it is put here for more convenient replacing of a virtuallistview in tools with the need to refactor code
		public bool VirtualMode { get; set; }

		/// <summary>
		/// Gets or sets whether the control is horizontal or vertical
		/// </summary>
		[Category("Behavior")]
		public bool HorizontalOrientation { get; set; }

		/// <summary>
		/// Gets or sets the sets the virtual number of items to be displayed.
		/// </summary>
		[Category("Behavior")]
		public int ItemCount { get; set; }

		/// <summary>
		/// Gets or sets the sets the columns can be resized
		/// </summary>
		[Category("Behavior")]
		public bool AllowColumnResize { get; set; }

		/// <summary>
		/// Gets or sets the sets the columns can be reordered
		/// </summary>
		[Category("Behavior")]
		public bool AllowColumnReorder { get; set; }

		/// <summary>
		/// Column data
		/// </summary>
		[Category("Behavior")]
		public RollColumns Columns
		{
			get
			{
				return _columns;
			}
		}

		#endregion

		#region Event Handlers

		/// <summary>
		/// Retrieve the background color for a Listview cell (item and subitem).
		/// </summary>
		/// <param name="item">Listview item (row).</param>
		/// <param name="subItem">Listview subitem (column).</param>
		/// <param name="color">Background color to use</param>
		public delegate void QueryItemBkColorHandler(int item, int subItem, ref Color color);

		/// <summary>
		/// Retrieve the text for a Listview cell (item and subitem).
		/// </summary>
		/// <param name="item">Listview item (row).</param>
		/// <param name="subItem">Listview subitem (column).</param>
		/// <param name="text">Text to display.</param>
		public delegate void QueryItemTextHandler(int item, int subItem, out string text);

		/// <summary>
		/// Fire the QueryItemBkColor event which requests the background color for the passed Listview cell
		/// </summary>
		//[Category("Virtual")] // TODO: can I make these up?
		//public event QueryItemBkColorHandler QueryItemBkColor;

		/// <summary>
		/// Fire the QueryItemText event which requests the text for the passed Listview cell.
		/// </summary>
		//[Category("Virtual")]
		//public event QueryItemTextHandler QueryItemText;

		#endregion

		#region Public Methods

		public string UserSettingsSerialized()
		{
			return string.Empty; // TODO
		}

		#endregion

		#region Paint

		private void DrawColumnBg(GDIRenderer ntr, PaintEventArgs e)
		{
			ntr.SetBrush(SystemColors.ControlLight);
			
			if (HorizontalOrientation)
			{
				var colWidth = HorizontalOrientedColumnWidth;
				ntr.DrawRectangle(0, 0, colWidth, Height - 2);
				ntr.FillRectangle(1, 1, colWidth - 1, Height - 3);

				int start = 0;
				foreach (var column in Columns)
				{
					start += CellHeight;
					ntr.Line(0, start, colWidth, start);
					
				}
			}
			else
			{
				ntr.DrawRectangle(0, 0, Width - 2, CellHeight);
				ntr.FillRectangle(1, 1, Width - 3, CellHeight - 1);

				int start = 0;
				foreach (var column in Columns)
				{
					start += column.Width;
					ntr.Line(start, 0, start, CellHeight);
				}
			}
		}

		private void DrawBg(GDIRenderer ntr, PaintEventArgs e)
		{
			var start = StartBg;

			ntr.SetBrush(Color.White); 
			ntr.FillRectangle(StartBg.X, StartBg.Y, Width, Height);
			ntr.DrawRectangle(StartBg.X, StartBg.Y, Width, Height);

			if (HorizontalOrientation)
			{

			}
			else
			{

			}
		}

		protected override void OnPaintBackground(PaintEventArgs pevent)
		{
			// Do nothing, and this should never be called
		}

		private void DrawColumnText(GDIRenderer ntr, PaintEventArgs e)
		{
			if (HorizontalOrientation)
			{
				int start = 0;
				foreach (var column in Columns)
				{
					ntr.DrawString(column.Text, this.Font, Color.Black, new Point(CellPadding, start + CellPadding));
					start += CellHeight;
				}
			}
			else
			{
				int start = 0;
				foreach(var column in Columns)
				{
					ntr.DrawString(column.Text, this.Font, Color.Black, new Point(start + CellPadding, CellPadding));
					start += column.Width;
				}
			}
		}

		

		protected override void OnPaint(PaintEventArgs e)
		{
			// Header
			if (Columns.Any())
			{
				DrawColumnBg(gdi, e);
				DrawColumnText(gdi, e);
			}

			// Background
			DrawBg(gdi, e);

			// ForeGround
		}

		#endregion

		#region Mouse and Key Events

		protected override void OnKeyDown(KeyEventArgs e)
		{
			if (e.Control && !e.Alt && !e.Shift && e.KeyCode == Keys.R) // Ctrl + R
			{
				HorizontalOrientation ^= true;
			}

			base.OnKeyDown(e);
		}

		#endregion

		#region Helpers

		private bool NeedToUpdateScrollbar()
		{
			return true;
		}

		private Point StartBg
		{
			get
			{
				if (Columns.Any())
				{
					if (HorizontalOrientation)
					{
						var x = HorizontalOrientedColumnWidth;
						var y = 0;
						return new Point(x, y);
					}
					else
					{
						var x = 0;
						var y = CellHeight;
						return new Point(x, y);
					}
				}

				return new Point(0, 0);
			}
		}

		private int HorizontalOrientedColumnWidth
		{
			get
			{
				return (Columns.Max(c => c.Text.Length) * TextWidth) + (CellPadding * 2);
			}
		}

		private int CellHeight
		{
			get
			{
				return this.Font.Height + (CellPadding * 2);
			}
		}

		private int TextWidth
		{
			get
			{
				return 15;
			}
		}

		private bool NeedsScrollbar
		{
			get
			{
				if (HorizontalOrientation)
				{
					return Width / TextWidth > ItemCount;
				}

				return Height / CellHeight > ItemCount;
			}
		}

		#endregion
	}

	public class RollColumns : List<RollColumn>
	{
		public void Add(string name, string text, int width, RollColumn.InputType type = RollColumn.InputType.Text)
		{
			Add(new RollColumn
			{
				Name = name,
				Text = text,
				Width = width,
				Type = type
			});
		}
	}

	public class RollColumn
	{
		public enum InputType { Boolean, Float, Text }

		public int Width { get; set; }
		public string Name { get; set; }
		public string Text { get; set; }
		public InputType Type { get; set; }
	}
}
