using System;
using System.Collections.Generic;
using System.Linq;
using EFT;
using EFT.InventoryLogic;
using EFT.UI;
using UnityEngine;

namespace Discord
{
	// Token: 0x0200000F RID: 15
	public class nibba : MonoBehaviour
	{
		// Token: 0x06000089 RID: 137 RVA: 0x00009F58 File Offset: 0x00008158
		public void OnGUI()
		{
			try
			{
				bool localinfo = Config.ESP.localinfo;
				if (localinfo)
				{
					Weapon weapon = Misc.LocalPlayer.Weapon;
					Rect rect;
					rect..ctor((float)Screen.width - 250f, 120f, 200f, 51f);
					Renders.DrawRadarBackground(rect);
					bool flag = weapon != null;
					if (flag)
					{
						Renders.DrawString(new Vector2((float)Screen.width - 240f, 120.86956f), string.Format("{0}]", "LocalWeaponInfo"), Color.green, false, 12, true);
						Renders.DrawString(new Vector2((float)Screen.width - 240f, 137.82608f), string.Format("{0}+{1}/{2} [{3}]", new object[]
						{
							weapon.GetCurrentMagazine().Count,
							weapon.ChamberAmmoCount,
							weapon.GetCurrentMagazine().MaxCount,
							weapon.SelectedFireMode.ToString()
						}), Color.green, false, 12, true);
					}
				}
				bool weaponammo = Config.ESP.weaponammo;
				if (weaponammo)
				{
					Dictionary<Player, int> dictionary = new Dictionary<Player, int>();
					Vector2 vector;
					vector..ctor((float)Screen.width / 2f, (float)Screen.height / 2f);
					Vector3 zero = Vector3.zero;
					foreach (GamePlayer gamePlayer in Misc.GamePlayers)
					{
						int num = (int)Vector2.Distance(Misc.MainCamera.WorldToScreenPoint(gamePlayer.Player.PlayerBones.Head.position), vector);
						int num2 = (int)Vector3.Distance(Misc.LocalPlayer.Transform.position, gamePlayer.Player.Transform.position);
						Vector3 vector2 = gamePlayer.Player.Transform.position - Misc.MainCamera.transform.position;
						bool flag2 = !MonoBehaviourSingleton<PreloaderUI>.Instance.IsBackgroundBlackActive && (float)num2 <= 5000f && (float)num <= 5000f && Vector3.Dot(Misc.MainCamera.transform.TransformDirection(Vector3.forward), vector2) > 0f;
						if (flag2)
						{
							dictionary.Add(gamePlayer.Player, num);
						}
					}
					bool flag3 = (double)dictionary.Count > 0.01;
					if (flag3)
					{
						dictionary = (from pair in dictionary
						orderby pair.Value
						select pair).ToDictionary((KeyValuePair<Player, int> pair) => pair.Key, (KeyValuePair<Player, int> pair) => pair.Value);
						Player player = dictionary.Keys.First<Player>();
						Vector3 vector3 = Camera.main.WorldToScreenPoint(player.Transform.position);
						int num3 = (int)Vector3.Distance(Misc.MainCamera.transform.position, player.Transform.position);
						Vector3 position = player.PlayerBones.Head.position;
						Vector3 vector4 = Camera.main.WorldToScreenPoint(player.Transform.position);
						Weapon weapon2 = player.Weapon;
						Rect rect2;
						rect2..ctor((float)Screen.width - 250f, 50f, 200f, 35f);
						Renders.DrawRadarBackground(rect2);
						bool flag4 = (double)vector4.z > 0.01 && weapon2 != null;
						if (flag4)
						{
							Renders.DrawString(new Vector2((float)Screen.width - 240f, 53.04348f), string.Format("{0}]", "EnemyWeaponInfo"), Color.white, false, 12, true);
							Renders.DrawString(new Vector2((float)Screen.width - 240f, 70f), string.Format("{0}+{1}/{2} [{3}]", new object[]
							{
								weapon2.GetCurrentMagazine().Count,
								weapon2.ChamberAmmoCount,
								weapon2.GetCurrentMagazine().MaxCount,
								weapon2.SelectedFireMode.ToString()
							}), Color.white, false, 12, true);
						}
					}
				}
			}
			catch
			{
			}
		}

		// Token: 0x0400005F RID: 95
		private List<GameLootContainer> _gameLootContainers;
	}
}
