﻿using System;

using BizHawk.Common;

namespace BizHawk.Emulation.Cores.Nintendo.SNES
{
	unsafe partial class LibsnesApi
	{
		bool Handle_BRK(eMessage msg)
		{
			switch (msg)
			{
				default:
					return false;

				case eMessage.eMessage_BRK_hook_exec:
					{
						var addr = brPipe.ReadInt32();
						ExecHook((uint)addr);
						break;
					}
				case eMessage.eMessage_BRK_hook_read:
					{
						var addr = brPipe.ReadInt32();
						ReadHook((uint)addr);
						break;
					}
				case eMessage.eMessage_BRK_hook_write:
					{
						var addr = brPipe.ReadInt32();
						var value = brPipe.ReadByte();
						WriteHook((uint)addr, value);
						break;
					}
				case eMessage.eMessage_BRK_hook_nmi:
					break;
				case eMessage.eMessage_BRK_hook_irq:
					break;
			} //switch(msg)
			return true;
		}
	}
}