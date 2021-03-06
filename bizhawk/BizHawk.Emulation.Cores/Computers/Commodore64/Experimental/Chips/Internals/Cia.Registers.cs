﻿using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

namespace BizHawk.Emulation.Cores.Computers.Commodore64.Experimental
{
	sealed public partial class Cia
	{
		public int Peek(int addr)
		{
			return 0xFF;
		}

		public void Poke(int addr, int val)
		{
		}

		public int Read(int addr)
		{
			return Peek(addr);
		}

		public void Write(int addr, int val)
		{
			Poke(addr, val);
		}
	}
}
