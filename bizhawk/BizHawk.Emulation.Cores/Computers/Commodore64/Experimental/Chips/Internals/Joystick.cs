﻿using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

using BizHawk.Common;

namespace BizHawk.Emulation.Cores.Computers.Commodore64.Experimental
{
	public class Joystick
	{
		virtual public int Data { get { return 0xFF; } }
		public int OutputData() { return Data; }
		public int OutputPot() { return Pot; }
		virtual public int Pot { get { return 0xFF; } }
		virtual public void SyncState(Serializer ser) { SaveState.SyncObject(ser, this); }
	}
}
