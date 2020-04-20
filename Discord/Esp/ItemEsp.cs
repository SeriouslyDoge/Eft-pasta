using System;
using System.Collections.Generic;
using Discord;
using EFT.Interactive;
using EFT.UI;
using UnityEngine;

namespace Esp
{
	// Token: 0x0200001F RID: 31
	public class ItemEsp : MonoBehaviour
	{
		// Token: 0x17000027 RID: 39
		// (get) Token: 0x060000FF RID: 255 RVA: 0x0000E375 File Offset: 0x0000C575
		// (set) Token: 0x06000100 RID: 256 RVA: 0x0000E37D File Offset: 0x0000C57D
		public LootItemRarity LootItemRarity { get; private set; }

		// Token: 0x06000101 RID: 257 RVA: 0x0000E388 File Offset: 0x0000C588
		public void Update()
		{
			try
			{
				bool superRare = Config.ESP.ItemEsp.SuperRare;
				if (superRare)
				{
					this.LootItemRarity = LootItemRarity.Special;
					bool flag = Time.time >= this._nextLootItemCacheTime && Misc.GameWorld != null && Misc.GameWorld.LootItems != null && Misc.LocalPlayer != null && !MonoBehaviourSingleton<PreloaderUI>.Instance.IsBackgroundBlackActive && Misc.MainCamera != null;
					if (flag)
					{
						this._gameLootItems.Clear();
						for (int i = 0; i < Misc.GameWorld.LootItems.Count; i++)
						{
							LootItem byIndex = Misc.GameWorld.LootItems.GetByIndex(i);
							bool flag2 = this.IsSpecialLootItem(byIndex);
							bool flag3 = this.LootItemRarity != LootItemRarity.Special || flag2;
							if (flag3)
							{
								bool flag4 = GameUtils.IsLootItemValid(byIndex) && Vector3.Distance(Misc.MainCamera.transform.position, byIndex.transform.position) <= Misc.distance;
								if (flag4)
								{
									this._gameLootItems.Add(new GameLootItem(byIndex));
								}
							}
						}
						this._nextLootItemCacheTime = Time.time + ItemEsp.CacheLootItemsInterval1;
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

		// Token: 0x06000102 RID: 258 RVA: 0x0000E540 File Offset: 0x0000C740
		public void Start()
		{
			ItemEsp.SpecialLootItems = new List<string>
			{
				"Keycard",
				"Tetriz",
				"Sugar",
				"Green",
				"LEDX",
				"Red",
				"Violet",
				"Badge",
				"Blue",
				"0.2BTC",
				"GP",
				"RB-PS81",
				"Med.St.",
				"T-7",
				"#11SR",
				"T H I C C",
				"Keytool",
				"OFZ",
				"Black",
				"USEC key",
				"HEPS",
				"Lk.MO",
				"#21WS",
				"Defibrillator",
				"Graphics card",
				"Moonshine",
				"Prokill",
				"WCase",
				"Dfuel",
				"SSD",
				"REAP-IR",
				"KIBA",
				"KIBA 2",
				"Intelligence",
				"M995",
				"Ophthalmoscope",
				"Docs",
				"Roler",
				"Paracord",
				"Flash drive",
				"SJ6 TGLabs",
				"Lupo's",
				"7N37",
				"Magbox",
				"VPX",
				"MCase",
				"RS-32",
				"Yellow",
				"GoldenStar",
				"RFIDR",
				"Skull",
				"Dogtags"
			};
		}

		// Token: 0x06000103 RID: 259 RVA: 0x0000E7C8 File Offset: 0x0000C9C8
		public bool IsSpecialLootItem(LootItem lootItem)
		{
			bool flag = !(lootItem == null) && lootItem.Item != null;
			bool result;
			if (flag)
			{
				string item = \uE4E3.Localized(lootItem.Item.Name);
				string item2 = \uE4E3.Localized(lootItem.Item.ShortName);
				result = (ItemEsp.SpecialLootItems.Contains(item) || ItemEsp.SpecialLootItems.Contains(item2));
			}
			else
			{
				result = false;
			}
			return result;
		}

		// Token: 0x06000104 RID: 260 RVA: 0x0000E838 File Offset: 0x0000CA38
		private void OnGUI()
		{
			try
			{
				bool superRare = Config.ESP.ItemEsp.SuperRare;
				if (superRare)
				{
					foreach (GameLootItem gameLootItem in this._gameLootItems)
					{
						bool flag = gameLootItem.IsOnScreen && gameLootItem.Distance <= Misc.distance && GameUtils.IsLootItemValid(gameLootItem.LootItem);
						if (flag)
						{
							string arg = \uE4E3.Localized(gameLootItem.LootItem.Item.ShortName) + " [" + gameLootItem.FormattedDistance + "]";
							Rendering.DrawString1(new Vector2(gameLootItem.ScreenPosition.x - 50f, gameLootItem.ScreenPosition.y), string.Format("{0}", arg), Main.superrareitemcolor, true, 8, FontStyle.Bold, 1);
						}
					}
				}
			}
			catch
			{
			}
		}

		// Token: 0x040000AB RID: 171
		private float _nextLootItemCacheTime;

		// Token: 0x040000AC RID: 172
		private List<GameLootItem> _gameLootItems = new List<GameLootItem>();

		// Token: 0x040000AD RID: 173
		private static readonly float CacheLootItemsInterval1 = 1.5f;

		// Token: 0x040000AE RID: 174
		public static List<string> SpecialLootItems;
	}
}
