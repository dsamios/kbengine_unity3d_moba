/*
	Generated by KBEngine!
	Please do not modify this file!
	
	tools = kbcmd
*/

namespace KBEngine
{
	using UnityEngine;
	using System;
	using System.Collections;
	using System.Collections.Generic;

	// defined in */scripts/entity_defs/MatchRoomReport.def
	public class EntityBaseEntityCall_MatchRoomReportBase : EntityCall
	{
		public UInt16 entityComponentPropertyID = 0;

		public EntityBaseEntityCall_MatchRoomReportBase(UInt16 ecpID, Int32 eid) : base(eid, "MatchRoomReport")
		{
			entityComponentPropertyID = ecpID;
			type = ENTITYCALL_TYPE.ENTITYCALL_TYPE_BASE;
		}

	}

	public class EntityCellEntityCall_MatchRoomReportBase : EntityCall
	{
		public UInt16 entityComponentPropertyID = 0;

		public EntityCellEntityCall_MatchRoomReportBase(UInt16 ecpID, Int32 eid) : base(eid, "MatchRoomReport")
		{
			entityComponentPropertyID = ecpID;
			className = "MatchRoomReport";
			type = ENTITYCALL_TYPE.ENTITYCALL_TYPE_CELL;
		}

	}
	}
