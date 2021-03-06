/*
	Generated by KBEngine!
	Please do not modify this file!
	Please inherit this module, such as: (class Avatar : AvatarBase)
	tools = kbcmd
*/

namespace KBEngine
{
	using UnityEngine;
	using System;
	using System.Collections;
	using System.Collections.Generic;

	// defined in */scripts/entity_defs/Avatar.def
	// Please inherit and implement "class Avatar : AvatarBase"
	public abstract class AvatarBase : Entity
	{
		public EntityBaseEntityCall_AvatarBase baseEntityCall = null;
		public EntityCellEntityCall_AvatarBase cellEntityCall = null;

		public FrameSyncReportBase componentFrameSync = null;
		public SByte gameStateC = 0;
		public virtual void onGameStateCChanged(SByte oldValue) {}
		public Int32 heroId = 0;
		public virtual void onHeroIdChanged(Int32 oldValue) {}
		public SByte level = 0;
		public virtual void onLevelChanged(SByte oldValue) {}
		public string name = "";
		public virtual void onNameChanged(string oldValue) {}
		public SByte roundCount = 0;
		public virtual void onRoundCountChanged(SByte oldValue) {}
		public SByte seatNo = 0;
		public virtual void onSeatNoChanged(SByte oldValue) {}
		public Int32 teamId = 0;
		public virtual void onTeamIdChanged(Int32 oldValue) {}
		public SByte winRate = 0;
		public virtual void onWinRateChanged(SByte oldValue) {}

		public abstract void onExitMatch(Int32 arg1); 
		public abstract void onHeroIdChanged(Int32 arg1, Int32 arg2); 
		public abstract void onLoadingToReadyBattleState(); 
		public abstract void onPushAvatarCurrentScene(UInt32 arg1); 
		public abstract void onPushMatchPlayersData(MATCHING_INFOS_LIST arg1); 
		public abstract void onPushStatisticalResult(Int32 arg1); 
		public abstract void onReadyBattle(); 
		public abstract void onReqsChooseHeroResult(HERO_INFOS arg1, SKILL_INFOS_LIST arg2); 
		public abstract void onReqsSkillLstResult(SKILL_INFOS_LIST arg1); 

		public AvatarBase()
		{
			foreach (System.Reflection.Assembly ass in AppDomain.CurrentDomain.GetAssemblies())
			{
				Type entityComponentScript = ass.GetType("KBEngine.FrameSyncReport");
				if(entityComponentScript != null)
				{
					componentFrameSync = (FrameSyncReportBase)Activator.CreateInstance(entityComponentScript);
					componentFrameSync.owner = this;
					componentFrameSync.entityComponentPropertyID = 17;
				}
			}

			if(componentFrameSync == null)
				throw new Exception("Please inherit and implement, such as: \"class FrameSyncReport : FrameSyncReportBase\"");

		}

		public override void onGetBase()
		{
			baseEntityCall = new EntityBaseEntityCall_AvatarBase(id, className);
		}

		public override void onGetCell()
		{
			cellEntityCall = new EntityCellEntityCall_AvatarBase(id, className);
		}

		public override void onLoseCell()
		{
			cellEntityCall = null;
		}

		public override EntityCall getBaseEntityCall()
		{
			return baseEntityCall;
		}

		public override EntityCall getCellEntityCall()
		{
			return cellEntityCall;
		}

		public override void attachComponents()
		{
			componentFrameSync.onAttached(this);
		}

		public override void detachComponents()
		{
			componentFrameSync.onDetached(this);
		}

		public override void onRemoteMethodCall(MemoryStream stream)
		{
			ScriptModule sm = EntityDef.moduledefs["Avatar"];

			UInt16 methodUtype = 0;
			UInt16 componentPropertyUType = 0;

			if(sm.useMethodDescrAlias)
			{
				componentPropertyUType = stream.readUint8();
				methodUtype = stream.readUint8();
			}
			else
			{
				componentPropertyUType = stream.readUint16();
				methodUtype = stream.readUint16();
			}

			Method method = null;

			if(componentPropertyUType == 0)
			{
				method = sm.idmethods[methodUtype];
			}
			else
			{
				Property pComponentPropertyDescription = sm.idpropertys[componentPropertyUType];
				switch(pComponentPropertyDescription.properUtype)
				{
					case 17:
						componentFrameSync.onRemoteMethodCall(methodUtype, stream);
						break;
					default:
						break;
				}

				return;
			}

			switch(method.methodUtype)
			{
				case 18:
					Int32 onExitMatch_arg1 = stream.readInt32();
					onExitMatch(onExitMatch_arg1);
					break;
				case 15:
					Int32 onHeroIdChanged_arg1 = stream.readInt32();
					Int32 onHeroIdChanged_arg2 = stream.readInt32();
					onHeroIdChanged(onHeroIdChanged_arg1, onHeroIdChanged_arg2);
					break;
				case 16:
					onLoadingToReadyBattleState();
					break;
				case 13:
					UInt32 onPushAvatarCurrentScene_arg1 = stream.readUint32();
					onPushAvatarCurrentScene(onPushAvatarCurrentScene_arg1);
					break;
				case 14:
					MATCHING_INFOS_LIST onPushMatchPlayersData_arg1 = ((DATATYPE_MATCHING_INFOS_LIST)method.args[0]).createFromStreamEx(stream);
					onPushMatchPlayersData(onPushMatchPlayersData_arg1);
					break;
				case 12:
					Int32 onPushStatisticalResult_arg1 = stream.readInt32();
					onPushStatisticalResult(onPushStatisticalResult_arg1);
					break;
				case 17:
					onReadyBattle();
					break;
				case 10:
					HERO_INFOS onReqsChooseHeroResult_arg1 = ((DATATYPE_HERO_INFOS)method.args[0]).createFromStreamEx(stream);
					SKILL_INFOS_LIST onReqsChooseHeroResult_arg2 = ((DATATYPE_SKILL_INFOS_LIST)method.args[1]).createFromStreamEx(stream);
					onReqsChooseHeroResult(onReqsChooseHeroResult_arg1, onReqsChooseHeroResult_arg2);
					break;
				case 11:
					SKILL_INFOS_LIST onReqsSkillLstResult_arg1 = ((DATATYPE_SKILL_INFOS_LIST)method.args[0]).createFromStreamEx(stream);
					onReqsSkillLstResult(onReqsSkillLstResult_arg1);
					break;
				default:
					break;
			};
		}

		public override void onUpdatePropertys(MemoryStream stream)
		{
			ScriptModule sm = EntityDef.moduledefs["Avatar"];
			Dictionary<UInt16, Property> pdatas = sm.idpropertys;

			while(stream.length() > 0)
			{
				UInt16 _t_utype = 0;
				UInt16 _t_child_utype = 0;

				{
					if(sm.usePropertyDescrAlias)
					{
						_t_utype = stream.readUint8();
						_t_child_utype = stream.readUint8();
					}
					else
					{
						_t_utype = stream.readUint16();
						_t_child_utype = stream.readUint16();
					}
				}

				Property prop = null;

				if(_t_utype == 0)
				{
					prop = pdatas[_t_child_utype];
				}
				else
				{
					Property pComponentPropertyDescription = pdatas[_t_utype];
					switch(pComponentPropertyDescription.properUtype)
					{
						case 17:
							componentFrameSync.onUpdatePropertys(_t_child_utype, stream, -1);
							break;
						default:
							break;
					}

					return;
				}

				switch(prop.properUtype)
				{
					case 17:
						componentFrameSync.createFromStream(stream);
						break;
					case 40001:
						Vector3 oldval_direction = direction;
						direction = stream.readVector3();

						if(prop.isBase())
						{
							if(inited)
								onDirectionChanged(oldval_direction);
						}
						else
						{
							if(inWorld)
								onDirectionChanged(oldval_direction);
						}

						break;
					case 13:
						SByte oldval_gameStateC = gameStateC;
						gameStateC = stream.readInt8();

						if(prop.isBase())
						{
							if(inited)
								onGameStateCChanged(oldval_gameStateC);
						}
						else
						{
							if(inWorld)
								onGameStateCChanged(oldval_gameStateC);
						}

						break;
					case 5:
						Int32 oldval_heroId = heroId;
						heroId = stream.readInt32();

						if(prop.isBase())
						{
							if(inited)
								onHeroIdChanged(oldval_heroId);
						}
						else
						{
							if(inWorld)
								onHeroIdChanged(oldval_heroId);
						}

						break;
					case 15:
						SByte oldval_level = level;
						level = stream.readInt8();

						if(prop.isBase())
						{
							if(inited)
								onLevelChanged(oldval_level);
						}
						else
						{
							if(inWorld)
								onLevelChanged(oldval_level);
						}

						break;
					case 3:
						string oldval_name = name;
						name = stream.readUnicode();

						if(prop.isBase())
						{
							if(inited)
								onNameChanged(oldval_name);
						}
						else
						{
							if(inWorld)
								onNameChanged(oldval_name);
						}

						break;
					case 40000:
						Vector3 oldval_position = position;
						position = stream.readVector3();

						if(prop.isBase())
						{
							if(inited)
								onPositionChanged(oldval_position);
						}
						else
						{
							if(inWorld)
								onPositionChanged(oldval_position);
						}

						break;
					case 12:
						SByte oldval_roundCount = roundCount;
						roundCount = stream.readInt8();

						if(prop.isBase())
						{
							if(inited)
								onRoundCountChanged(oldval_roundCount);
						}
						else
						{
							if(inWorld)
								onRoundCountChanged(oldval_roundCount);
						}

						break;
					case 14:
						SByte oldval_seatNo = seatNo;
						seatNo = stream.readInt8();

						if(prop.isBase())
						{
							if(inited)
								onSeatNoChanged(oldval_seatNo);
						}
						else
						{
							if(inWorld)
								onSeatNoChanged(oldval_seatNo);
						}

						break;
					case 40002:
						stream.readUint32();
						break;
					case 9:
						Int32 oldval_teamId = teamId;
						teamId = stream.readInt32();

						if(prop.isBase())
						{
							if(inited)
								onTeamIdChanged(oldval_teamId);
						}
						else
						{
							if(inWorld)
								onTeamIdChanged(oldval_teamId);
						}

						break;
					case 11:
						SByte oldval_winRate = winRate;
						winRate = stream.readInt8();

						if(prop.isBase())
						{
							if(inited)
								onWinRateChanged(oldval_winRate);
						}
						else
						{
							if(inWorld)
								onWinRateChanged(oldval_winRate);
						}

						break;
					default:
						break;
				};
			}
		}

		public override void callPropertysSetMethods()
		{
			ScriptModule sm = EntityDef.moduledefs["Avatar"];
			Dictionary<UInt16, Property> pdatas = sm.idpropertys;

			componentFrameSync.callPropertysSetMethods();

			Vector3 oldval_direction = direction;
			Property prop_direction = pdatas[2];
			if(prop_direction.isBase())
			{
				if(inited && !inWorld)
					onDirectionChanged(oldval_direction);
			}
			else
			{
				if(inWorld)
				{
					if(prop_direction.isOwnerOnly() && !isPlayer())
					{
					}
					else
					{
						onDirectionChanged(oldval_direction);
					}
				}
			}

			SByte oldval_gameStateC = gameStateC;
			Property prop_gameStateC = pdatas[5];
			if(prop_gameStateC.isBase())
			{
				if(inited && !inWorld)
					onGameStateCChanged(oldval_gameStateC);
			}
			else
			{
				if(inWorld)
				{
					if(prop_gameStateC.isOwnerOnly() && !isPlayer())
					{
					}
					else
					{
						onGameStateCChanged(oldval_gameStateC);
					}
				}
			}

			Int32 oldval_heroId = heroId;
			Property prop_heroId = pdatas[6];
			if(prop_heroId.isBase())
			{
				if(inited && !inWorld)
					onHeroIdChanged(oldval_heroId);
			}
			else
			{
				if(inWorld)
				{
					if(prop_heroId.isOwnerOnly() && !isPlayer())
					{
					}
					else
					{
						onHeroIdChanged(oldval_heroId);
					}
				}
			}

			SByte oldval_level = level;
			Property prop_level = pdatas[7];
			if(prop_level.isBase())
			{
				if(inited && !inWorld)
					onLevelChanged(oldval_level);
			}
			else
			{
				if(inWorld)
				{
					if(prop_level.isOwnerOnly() && !isPlayer())
					{
					}
					else
					{
						onLevelChanged(oldval_level);
					}
				}
			}

			string oldval_name = name;
			Property prop_name = pdatas[8];
			if(prop_name.isBase())
			{
				if(inited && !inWorld)
					onNameChanged(oldval_name);
			}
			else
			{
				if(inWorld)
				{
					if(prop_name.isOwnerOnly() && !isPlayer())
					{
					}
					else
					{
						onNameChanged(oldval_name);
					}
				}
			}

			Vector3 oldval_position = position;
			Property prop_position = pdatas[1];
			if(prop_position.isBase())
			{
				if(inited && !inWorld)
					onPositionChanged(oldval_position);
			}
			else
			{
				if(inWorld)
				{
					if(prop_position.isOwnerOnly() && !isPlayer())
					{
					}
					else
					{
						onPositionChanged(oldval_position);
					}
				}
			}

			SByte oldval_roundCount = roundCount;
			Property prop_roundCount = pdatas[9];
			if(prop_roundCount.isBase())
			{
				if(inited && !inWorld)
					onRoundCountChanged(oldval_roundCount);
			}
			else
			{
				if(inWorld)
				{
					if(prop_roundCount.isOwnerOnly() && !isPlayer())
					{
					}
					else
					{
						onRoundCountChanged(oldval_roundCount);
					}
				}
			}

			SByte oldval_seatNo = seatNo;
			Property prop_seatNo = pdatas[10];
			if(prop_seatNo.isBase())
			{
				if(inited && !inWorld)
					onSeatNoChanged(oldval_seatNo);
			}
			else
			{
				if(inWorld)
				{
					if(prop_seatNo.isOwnerOnly() && !isPlayer())
					{
					}
					else
					{
						onSeatNoChanged(oldval_seatNo);
					}
				}
			}

			Int32 oldval_teamId = teamId;
			Property prop_teamId = pdatas[11];
			if(prop_teamId.isBase())
			{
				if(inited && !inWorld)
					onTeamIdChanged(oldval_teamId);
			}
			else
			{
				if(inWorld)
				{
					if(prop_teamId.isOwnerOnly() && !isPlayer())
					{
					}
					else
					{
						onTeamIdChanged(oldval_teamId);
					}
				}
			}

			SByte oldval_winRate = winRate;
			Property prop_winRate = pdatas[12];
			if(prop_winRate.isBase())
			{
				if(inited && !inWorld)
					onWinRateChanged(oldval_winRate);
			}
			else
			{
				if(inWorld)
				{
					if(prop_winRate.isOwnerOnly() && !isPlayer())
					{
					}
					else
					{
						onWinRateChanged(oldval_winRate);
					}
				}
			}

		}
	}
}