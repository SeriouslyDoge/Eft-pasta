using System;
using Discord;
using UnityEngine;

namespace Thermal
{
	// Token: 0x02000008 RID: 8
	public class ThermalShits : MonoBehaviour
	{
		// Token: 0x06000051 RID: 81 RVA: 0x00007EE4 File Offset: 0x000060E4
		public void OnGUI()
		{
			try
			{
				foreach (GamePlayer gamePlayer in Misc.GamePlayers)
				{
					bool flag = !gamePlayer.IsOnScreen || gamePlayer.Distance > Misc.scavdistance;
					if (!flag)
					{
						bool flag2 = Config.ESP.scavskeleton && gamePlayer.Player.Profile.Info.RegistrationDate <= 0 && gamePlayer.Scav && !Misc.friendsList.Contains(gamePlayer.Player.Profile.Info.Nickname);
						if (flag2)
						{
							float current = gamePlayer.Player.HealthController.GetBodyPartHealth(1, false).Current;
							float current2 = gamePlayer.Player.HealthController.GetBodyPartHealth(7, false).Current;
							float current3 = gamePlayer.Player.HealthController.GetBodyPartHealth(0, false).Current;
							float current4 = gamePlayer.Player.HealthController.GetBodyPartHealth(3, false).Current;
							float current5 = gamePlayer.Player.HealthController.GetBodyPartHealth(5, false).Current;
							float current6 = gamePlayer.Player.HealthController.GetBodyPartHealth(4, false).Current;
							float current7 = gamePlayer.Player.HealthController.GetBodyPartHealth(6, false).Current;
							float current8 = gamePlayer.Player.HealthController.GetBodyPartHealth(2, false).Current;
							Vector3 vector;
							vector..ctor(Camera.main.WorldToScreenPoint(gamePlayer.Player.PlayerBones.RightPalm.position).x, Camera.main.WorldToScreenPoint(gamePlayer.Player.PlayerBones.RightPalm.position).y, Camera.main.WorldToScreenPoint(gamePlayer.Player.PlayerBones.RightPalm.position).z);
							Vector3 vector2;
							vector2..ctor(Camera.main.WorldToScreenPoint(gamePlayer.Player.PlayerBones.LeftPalm.position).x, Camera.main.WorldToScreenPoint(gamePlayer.Player.PlayerBones.LeftPalm.position).y, Camera.main.WorldToScreenPoint(gamePlayer.Player.PlayerBones.LeftPalm.position).z);
							Vector3 vector3;
							vector3..ctor(Camera.main.WorldToScreenPoint(gamePlayer.Player.PlayerBones.LeftShoulder.position).x, Camera.main.WorldToScreenPoint(gamePlayer.Player.PlayerBones.LeftShoulder.position).y, Camera.main.WorldToScreenPoint(gamePlayer.Player.PlayerBones.LeftShoulder.position).z);
							Vector3 vector4;
							vector4..ctor(Camera.main.WorldToScreenPoint(gamePlayer.Player.PlayerBones.RightShoulder.position).x, Camera.main.WorldToScreenPoint(gamePlayer.Player.PlayerBones.RightShoulder.position).y, Camera.main.WorldToScreenPoint(gamePlayer.Player.PlayerBones.RightShoulder.position).z);
							Vector3 vector5;
							vector5..ctor(Camera.main.WorldToScreenPoint(gamePlayer.Player.PlayerBones.Neck.position).x, Camera.main.WorldToScreenPoint(gamePlayer.Player.PlayerBones.Neck.position).y, Camera.main.WorldToScreenPoint(gamePlayer.Player.PlayerBones.Neck.position).z);
							Vector3 vector6;
							vector6..ctor(Camera.main.WorldToScreenPoint(gamePlayer.Player.PlayerBones.Pelvis.position).x, Camera.main.WorldToScreenPoint(gamePlayer.Player.PlayerBones.Pelvis.position).y, Camera.main.WorldToScreenPoint(gamePlayer.Player.PlayerBones.Pelvis.position).z);
							Vector3 vector7;
							vector7..ctor(Camera.main.WorldToScreenPoint(gamePlayer.Player.PlayerBones.KickingFoot.position).x, Camera.main.WorldToScreenPoint(gamePlayer.Player.PlayerBones.KickingFoot.position).y, Camera.main.WorldToScreenPoint(gamePlayer.Player.PlayerBones.KickingFoot.position).z);
							Vector3 vector8;
							vector8..ctor(Camera.main.WorldToScreenPoint(Helpers.GetBonePosByID(gamePlayer.Player, 18)).x, Camera.main.WorldToScreenPoint(Helpers.GetBonePosByID(gamePlayer.Player, 18)).y, Camera.main.WorldToScreenPoint(Helpers.GetBonePosByID(gamePlayer.Player, 18)).z);
							Vector3 vector9;
							vector9..ctor(Camera.main.WorldToScreenPoint(Helpers.GetBonePosByID(gamePlayer.Player, 91)).x, Camera.main.WorldToScreenPoint(Helpers.GetBonePosByID(gamePlayer.Player, 91)).y, Camera.main.WorldToScreenPoint(Helpers.GetBonePosByID(gamePlayer.Player, 91)).z);
							Vector3 vector10;
							vector10..ctor(Camera.main.WorldToScreenPoint(Helpers.GetBonePosByID(gamePlayer.Player, 112)).x, Camera.main.WorldToScreenPoint(Helpers.GetBonePosByID(gamePlayer.Player, 112)).y, Camera.main.WorldToScreenPoint(Helpers.GetBonePosByID(gamePlayer.Player, 112)).z);
							Vector3 vector11;
							vector11..ctor(Camera.main.WorldToScreenPoint(Helpers.GetBonePosByID(gamePlayer.Player, 17)).x, Camera.main.WorldToScreenPoint(Helpers.GetBonePosByID(gamePlayer.Player, 17)).y, Camera.main.WorldToScreenPoint(Helpers.GetBonePosByID(gamePlayer.Player, 17)).z);
							Vector3 vector12;
							vector12..ctor(Camera.main.WorldToScreenPoint(Helpers.GetBonePosByID(gamePlayer.Player, 22)).x, Camera.main.WorldToScreenPoint(Helpers.GetBonePosByID(gamePlayer.Player, 22)).y, Camera.main.WorldToScreenPoint(Helpers.GetBonePosByID(gamePlayer.Player, 22)).z);
							Drawing1.DrawLine(new Vector2(vector5.x, (float)Screen.height - vector5.y), new Vector2(vector6.x, (float)Screen.height - vector6.y), Main.scavcolor, Main.skeletonthickkkk, true);
							Drawing1.DrawLine(new Vector2(vector3.x, (float)Screen.height - vector3.y), new Vector2(vector9.x, (float)Screen.height - vector9.y), Main.scavcolor, Main.skeletonthickkkk, true);
							Drawing1.DrawLine(new Vector2(vector4.x, (float)Screen.height - vector4.y), new Vector2(vector10.x, (float)Screen.height - vector10.y), Main.scavcolor, Main.skeletonthickkkk, true);
							Drawing1.DrawLine(new Vector2(vector9.x, (float)Screen.height - vector9.y), new Vector2(vector2.x, (float)Screen.height - vector2.y), Main.scavcolor, Main.skeletonthickkkk, true);
							Drawing1.DrawLine(new Vector2(vector10.x, (float)Screen.height - vector10.y), new Vector2(vector.x, (float)Screen.height - vector.y), Main.scavcolor, Main.skeletonthickkkk, true);
							Drawing1.DrawLine(new Vector2(vector4.x, (float)Screen.height - vector4.y), new Vector2(vector3.x, (float)Screen.height - vector3.y), Main.scavcolor, Main.skeletonthickkkk, true);
							Drawing1.DrawLine(new Vector2(vector11.x, (float)Screen.height - vector11.y), new Vector2(vector6.x, (float)Screen.height - vector6.y), Main.scavcolor, Main.skeletonthickkkk, true);
							Drawing1.DrawLine(new Vector2(vector12.x, (float)Screen.height - vector12.y), new Vector2(vector6.x, (float)Screen.height - vector6.y), Main.scavcolor, Main.skeletonthickkkk, true);
							Drawing1.DrawLine(new Vector2(vector11.x, (float)Screen.height - vector11.y), new Vector2(vector8.x, (float)Screen.height - vector8.y), Main.scavcolor, Main.skeletonthickkkk, true);
							Drawing1.DrawLine(new Vector2(vector12.x, (float)Screen.height - vector12.y), new Vector2(vector7.x, (float)Screen.height - vector7.y), Main.scavcolor, Main.skeletonthickkkk, true);
						}
					}
				}
				bool flag3 = !Config.ESP.Skeleton;
				if (!flag3)
				{
					foreach (GamePlayer gamePlayer2 in Misc.GamePlayers)
					{
						bool flag4 = !gamePlayer2.IsOnScreen || gamePlayer2.Distance > Misc.playerdistance;
						if (!flag4)
						{
							bool flag5 = Config.ESP.Skeleton && !gamePlayer2.Scav && !Misc.friendsList.Contains(gamePlayer2.Player.Profile.Info.Nickname);
							if (flag5)
							{
								float current9 = gamePlayer2.Player.HealthController.GetBodyPartHealth(1, false).Current;
								float current10 = gamePlayer2.Player.HealthController.GetBodyPartHealth(7, false).Current;
								float current11 = gamePlayer2.Player.HealthController.GetBodyPartHealth(0, false).Current;
								float current12 = gamePlayer2.Player.HealthController.GetBodyPartHealth(3, false).Current;
								float current13 = gamePlayer2.Player.HealthController.GetBodyPartHealth(5, false).Current;
								float current14 = gamePlayer2.Player.HealthController.GetBodyPartHealth(4, false).Current;
								float current15 = gamePlayer2.Player.HealthController.GetBodyPartHealth(6, false).Current;
								float current16 = gamePlayer2.Player.HealthController.GetBodyPartHealth(2, false).Current;
								Vector3 vector13;
								vector13..ctor(Camera.main.WorldToScreenPoint(gamePlayer2.Player.PlayerBones.RightPalm.position).x, Camera.main.WorldToScreenPoint(gamePlayer2.Player.PlayerBones.RightPalm.position).y, Camera.main.WorldToScreenPoint(gamePlayer2.Player.PlayerBones.RightPalm.position).z);
								Vector3 vector14;
								vector14..ctor(Camera.main.WorldToScreenPoint(gamePlayer2.Player.PlayerBones.LeftPalm.position).x, Camera.main.WorldToScreenPoint(gamePlayer2.Player.PlayerBones.LeftPalm.position).y, Camera.main.WorldToScreenPoint(gamePlayer2.Player.PlayerBones.LeftPalm.position).z);
								Vector3 vector15;
								vector15..ctor(Camera.main.WorldToScreenPoint(gamePlayer2.Player.PlayerBones.LeftShoulder.position).x, Camera.main.WorldToScreenPoint(gamePlayer2.Player.PlayerBones.LeftShoulder.position).y, Camera.main.WorldToScreenPoint(gamePlayer2.Player.PlayerBones.LeftShoulder.position).z);
								Vector3 vector16;
								vector16..ctor(Camera.main.WorldToScreenPoint(gamePlayer2.Player.PlayerBones.RightShoulder.position).x, Camera.main.WorldToScreenPoint(gamePlayer2.Player.PlayerBones.RightShoulder.position).y, Camera.main.WorldToScreenPoint(gamePlayer2.Player.PlayerBones.RightShoulder.position).z);
								Vector3 vector17;
								vector17..ctor(Camera.main.WorldToScreenPoint(gamePlayer2.Player.PlayerBones.Neck.position).x, Camera.main.WorldToScreenPoint(gamePlayer2.Player.PlayerBones.Neck.position).y, Camera.main.WorldToScreenPoint(gamePlayer2.Player.PlayerBones.Neck.position).z);
								Vector3 vector18;
								vector18..ctor(Camera.main.WorldToScreenPoint(gamePlayer2.Player.PlayerBones.Pelvis.position).x, Camera.main.WorldToScreenPoint(gamePlayer2.Player.PlayerBones.Pelvis.position).y, Camera.main.WorldToScreenPoint(gamePlayer2.Player.PlayerBones.Pelvis.position).z);
								Vector3 vector19;
								vector19..ctor(Camera.main.WorldToScreenPoint(gamePlayer2.Player.PlayerBones.KickingFoot.position).x, Camera.main.WorldToScreenPoint(gamePlayer2.Player.PlayerBones.KickingFoot.position).y, Camera.main.WorldToScreenPoint(gamePlayer2.Player.PlayerBones.KickingFoot.position).z);
								Vector3 vector20;
								vector20..ctor(Camera.main.WorldToScreenPoint(Helpers.GetBonePosByID(gamePlayer2.Player, 18)).x, Camera.main.WorldToScreenPoint(Helpers.GetBonePosByID(gamePlayer2.Player, 18)).y, Camera.main.WorldToScreenPoint(Helpers.GetBonePosByID(gamePlayer2.Player, 18)).z);
								Vector3 vector21;
								vector21..ctor(Camera.main.WorldToScreenPoint(Helpers.GetBonePosByID(gamePlayer2.Player, 91)).x, Camera.main.WorldToScreenPoint(Helpers.GetBonePosByID(gamePlayer2.Player, 91)).y, Camera.main.WorldToScreenPoint(Helpers.GetBonePosByID(gamePlayer2.Player, 91)).z);
								Vector3 vector22;
								vector22..ctor(Camera.main.WorldToScreenPoint(Helpers.GetBonePosByID(gamePlayer2.Player, 112)).x, Camera.main.WorldToScreenPoint(Helpers.GetBonePosByID(gamePlayer2.Player, 112)).y, Camera.main.WorldToScreenPoint(Helpers.GetBonePosByID(gamePlayer2.Player, 112)).z);
								Vector3 vector23;
								vector23..ctor(Camera.main.WorldToScreenPoint(Helpers.GetBonePosByID(gamePlayer2.Player, 17)).x, Camera.main.WorldToScreenPoint(Helpers.GetBonePosByID(gamePlayer2.Player, 17)).y, Camera.main.WorldToScreenPoint(Helpers.GetBonePosByID(gamePlayer2.Player, 17)).z);
								Vector3 vector24;
								vector24..ctor(Camera.main.WorldToScreenPoint(Helpers.GetBonePosByID(gamePlayer2.Player, 22)).x, Camera.main.WorldToScreenPoint(Helpers.GetBonePosByID(gamePlayer2.Player, 22)).y, Camera.main.WorldToScreenPoint(Helpers.GetBonePosByID(gamePlayer2.Player, 22)).z);
								Drawing1.DrawLine(new Vector2(vector17.x, (float)Screen.height - vector17.y), new Vector2(vector18.x, (float)Screen.height - vector18.y), Main.PlayerColor, Main.skeletonthickkkk, true);
								Drawing1.DrawLine(new Vector2(vector15.x, (float)Screen.height - vector15.y), new Vector2(vector21.x, (float)Screen.height - vector21.y), Main.PlayerColor, Main.skeletonthickkkk, true);
								Drawing1.DrawLine(new Vector2(vector16.x, (float)Screen.height - vector16.y), new Vector2(vector22.x, (float)Screen.height - vector22.y), Main.PlayerColor, Main.skeletonthickkkk, true);
								Drawing1.DrawLine(new Vector2(vector21.x, (float)Screen.height - vector21.y), new Vector2(vector14.x, (float)Screen.height - vector14.y), Main.PlayerColor, Main.skeletonthickkkk, true);
								Drawing1.DrawLine(new Vector2(vector22.x, (float)Screen.height - vector22.y), new Vector2(vector13.x, (float)Screen.height - vector13.y), Main.PlayerColor, Main.skeletonthickkkk, true);
								Drawing1.DrawLine(new Vector2(vector16.x, (float)Screen.height - vector16.y), new Vector2(vector15.x, (float)Screen.height - vector15.y), Main.PlayerColor, Main.skeletonthickkkk, true);
								Drawing1.DrawLine(new Vector2(vector23.x, (float)Screen.height - vector23.y), new Vector2(vector18.x, (float)Screen.height - vector18.y), Main.PlayerColor, Main.skeletonthickkkk, true);
								Drawing1.DrawLine(new Vector2(vector24.x, (float)Screen.height - vector24.y), new Vector2(vector18.x, (float)Screen.height - vector18.y), Main.PlayerColor, Main.skeletonthickkkk, true);
								Drawing1.DrawLine(new Vector2(vector23.x, (float)Screen.height - vector23.y), new Vector2(vector20.x, (float)Screen.height - vector20.y), Main.PlayerColor, Main.skeletonthickkkk, true);
								Drawing1.DrawLine(new Vector2(vector24.x, (float)Screen.height - vector24.y), new Vector2(vector19.x, (float)Screen.height - vector19.y), Main.PlayerColor, Main.skeletonthickkkk, true);
							}
						}
					}
				}
			}
			catch
			{
			}
		}
	}
}
