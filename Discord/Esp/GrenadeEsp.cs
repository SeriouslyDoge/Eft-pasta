using System;
using System.Collections.Generic;
using Discord;
using EFT.UI;
using UnityEngine;

namespace Esp
{
	// Token: 0x0200001E RID: 30
	public class GrenadeEsp : MonoBehaviour
	{
		// Token: 0x17000026 RID: 38
		// (get) Token: 0x060000F9 RID: 249 RVA: 0x0000E01C File Offset: 0x0000C21C
		// (set) Token: 0x060000FA RID: 250 RVA: 0x0000E024 File Offset: 0x0000C224
		public LootItemRarity LootItemRarity { get; private set; }

		// Token: 0x060000FB RID: 251 RVA: 0x0000E030 File Offset: 0x0000C230
		private void Update()
		{
			try
			{
				bool grenade = Config.ESP.grenade;
				if (grenade)
				{
					bool flag = Time.time >= this._nextLootItemCacheTime && Misc.GameWorld != null && Misc.GameWorld.LootItems != null && Misc.LocalPlayer != null && !MonoBehaviourSingleton<PreloaderUI>.Instance.IsBackgroundBlackActive && Misc.MainCamera != null;
					if (flag)
					{
						\uE1DE<int, Throwable> grenades = Misc.GameWorld.Grenades;
						float num = (float)grenades.Count;
						this._grenades.Clear();
						int num2 = 0;
						while ((float)num2 < num)
						{
							Throwable byIndex = grenades.GetByIndex(num2);
							bool flag2 = GameUtils.isgrenadevalid(byIndex) && Vector3.Distance(Misc.MainCamera.transform.position, byIndex.transform.position) <= 5000f;
							if (flag2)
							{
								this._grenades.Add(new Grenade444(byIndex));
							}
							num2++;
						}
						this._nextLootItemCacheTime = Time.time + GrenadeEsp.grenadeinterval;
					}
					foreach (Grenade444 grenade2 in this._grenades)
					{
						bool flag3 = grenade2 != null;
						if (flag3)
						{
							grenade2.RecalculateDynamics();
						}
					}
				}
			}
			catch
			{
			}
		}

		// Token: 0x060000FC RID: 252 RVA: 0x0000E1CC File Offset: 0x0000C3CC
		private void OnGUI()
		{
			try
			{
				bool grenade = Config.ESP.grenade;
				if (grenade)
				{
					foreach (Grenade444 grenade2 in this._grenades)
					{
						Vector3 vector = Misc.MainCamera.WorldToScreenPoint(grenade2.LootableContainer.transform.position);
						bool flag = vector.z > 0f;
						if (flag)
						{
							bool flag2 = grenade2 != null;
							if (flag2)
							{
								int num = (int)Vector3.Distance(Misc.MainCamera.transform.position, grenade2.LootableContainer.transform.position);
								bool flag3 = (float)num <= 300f;
								if (flag3)
								{
									string arg = "Grenade [" + grenade2.FormattedDistance + "]";
									Rendering.DrawString1(new Vector2(grenade2.ScreenPosition.x - 50f, grenade2.ScreenPosition.y), string.Format("{0}", arg), new Color32(byte.MaxValue, 0, 0, byte.MaxValue), true, 8, FontStyle.Bold, 1);
								}
							}
						}
					}
				}
			}
			catch
			{
			}
		}

		// Token: 0x040000A4 RID: 164
		private float _nextLootItemCacheTime;

		// Token: 0x040000A5 RID: 165
		private List<GameLootItem> _gameLootItems = new List<GameLootItem>();

		// Token: 0x040000A6 RID: 166
		private static readonly float CacheLootItemsInterval1 = 1.5f;

		// Token: 0x040000A7 RID: 167
		public static List<string> SpecialLootItems;

		// Token: 0x040000A8 RID: 168
		private List<Grenade444> _grenades = new List<Grenade444>();

		// Token: 0x040000A9 RID: 169
		private static readonly float grenadeinterval = 0.5f;
	}
}
