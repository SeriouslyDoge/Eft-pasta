using System;
using System.Collections.Generic;
using Discord;
using EFT.Interactive;
using EFT.UI;
using UnityEngine;

namespace Esp
{
	// Token: 0x0200001D RID: 29
	public class CorpseEsp : MonoBehaviour
	{
		// Token: 0x17000025 RID: 37
		// (get) Token: 0x060000F3 RID: 243 RVA: 0x0000DCDA File Offset: 0x0000BEDA
		// (set) Token: 0x060000F4 RID: 244 RVA: 0x0000DCE2 File Offset: 0x0000BEE2
		public LootItemRarity LootItemRarity { get; private set; }

		// Token: 0x060000F5 RID: 245 RVA: 0x0000DCEC File Offset: 0x0000BEEC
		private void Update()
		{
			try
			{
				bool corpse = Config.ESP.Corpse;
				if (corpse)
				{
					bool flag = Time.time >= this._nextLootItemCacheTime && Misc.GameWorld != null && Misc.GameWorld.LootItems != null && Misc.LocalPlayer != null && !MonoBehaviourSingleton<PreloaderUI>.Instance.IsBackgroundBlackActive && Misc.MainCamera != null;
					if (flag)
					{
						this._gameLootItems.Clear();
						for (int i = 0; i < Misc.GameWorld.LootItems.Count; i++)
						{
							LootItem byIndex = Misc.GameWorld.LootItems.GetByIndex(i);
							bool flag2 = \uE4E3.Localized(byIndex.Item.ShortName) == "Default Inventory";
							if (flag2)
							{
								bool flag3 = GameUtils.IsLootItemValid(byIndex) && Vector3.Distance(Misc.MainCamera.transform.position, byIndex.transform.position) <= 500f;
								if (flag3)
								{
									this._gameLootItems.Add(new GameLootItem(byIndex));
								}
							}
						}
						this._nextLootItemCacheTime = Time.time + CorpseEsp.CacheLootItemsInterval1;
					}
					foreach (GameLootItem gameLootItem in this._gameLootItems)
					{
						gameLootItem.RecalculateDynamics();
					}
				}
			}
			catch
			{
			}
		}

		// Token: 0x060000F6 RID: 246 RVA: 0x0000DEA0 File Offset: 0x0000C0A0
		private void OnGUI()
		{
			try
			{
				bool corpse = Config.ESP.Corpse;
				if (corpse)
				{
					foreach (GameLootItem gameLootItem in this._gameLootItems)
					{
						bool flag = GameUtils.IsLootItemValid(gameLootItem.LootItem) && gameLootItem.IsOnScreen;
						if (flag)
						{
							int num = (int)Vector3.Distance(Misc.MainCamera.transform.position, gameLootItem.LootItem.transform.position);
							bool flag2 = gameLootItem.Distance <= Misc.playerdistance;
							if (flag2)
							{
								string text = gameLootItem.LootItem.Item.ShortName + " [" + gameLootItem.FormattedDistance + "]";
								Rendering.DrawString1(new Vector2(gameLootItem.ScreenPosition.x - 50f, gameLootItem.ScreenPosition.y), string.Format("{0} [{1}]", "Corpse", gameLootItem.FormattedDistance), Main.PlayerColor, true, 8, FontStyle.Bold, 1);
							}
						}
					}
				}
			}
			catch
			{
			}
		}

		// Token: 0x0400009F RID: 159
		private float _nextLootItemCacheTime;

		// Token: 0x040000A0 RID: 160
		private List<GameLootItem> _gameLootItems = new List<GameLootItem>();

		// Token: 0x040000A1 RID: 161
		private static readonly float CacheLootItemsInterval1 = 1.5f;

		// Token: 0x040000A2 RID: 162
		public static List<string> SpecialLootItems;
	}
}
