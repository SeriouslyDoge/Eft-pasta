using System;
using System.Collections.Generic;
using System.Linq;
using Discord;
using EFT.Interactive;
using EFT.InventoryLogic;
using EFT.UI;
using UnityEngine;

namespace Esp
{
	// Token: 0x0200001C RID: 28
	public class ContainerEsp : MonoBehaviour
	{
		// Token: 0x17000024 RID: 36
		// (get) Token: 0x060000EB RID: 235 RVA: 0x0000D2C1 File Offset: 0x0000B4C1
		// (set) Token: 0x060000EC RID: 236 RVA: 0x0000D2C9 File Offset: 0x0000B4C9
		public LootItemRarity LootItemRarity { get; private set; }

		// Token: 0x060000ED RID: 237 RVA: 0x0000D2D4 File Offset: 0x0000B4D4
		public void Start()
		{
			this._gameLootContainers = new List<GameLootContainer>();
			ContainerEsp.SpecialLootItems = new List<string>
			{
				"Keycard",
				"Tetriz",
				"Sugar",
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

		// Token: 0x060000EE RID: 238 RVA: 0x0000D55C File Offset: 0x0000B75C
		private void Update()
		{
			try
			{
				bool flag = Config.ESP.ItemEsp.container || Config.ESP.containercontents;
				if (flag)
				{
					bool flag2 = Time.time >= this._nextLootContainerCacheTime;
					if (flag2)
					{
						bool flag3 = Misc.GameWorld != null && Misc.GameWorld.LootItems != null;
						if (flag3)
						{
							this._gameLootContainers.Clear();
							foreach (LootableContainer lootableContainer in Object.FindObjectsOfType<LootableContainer>())
							{
								Item item = \uE6E5.GetAllItems(lootableContainer.ItemOwner.RootItem, true).First<Item>();
								this.LootItemRarity = LootItemRarity.Special;
								foreach (Item lootItem in \uE6E5.GetAllItems(item, false))
								{
									bool flag4 = this.IsSpecialLootItem(lootItem);
									bool flag5 = this.LootItemRarity != LootItemRarity.Special || flag4;
									if (flag5)
									{
										bool flag6 = !GameUtils.IsLootableContainerValid(lootableContainer) || Vector3.Distance(Misc.MainCamera.transform.position, lootableContainer.transform.position) > 500f;
										if (!flag6)
										{
											this._gameLootContainers.Add(new GameLootContainer(lootableContainer));
										}
									}
								}
							}
							this._nextLootContainerCacheTime = Time.time + ContainerEsp.CacheLootItemsInterval;
						}
					}
					foreach (GameLootContainer gameLootContainer in this._gameLootContainers)
					{
						bool flag7 = gameLootContainer != null;
						if (flag7)
						{
							gameLootContainer.RecalculateDynamics();
						}
					}
				}
			}
			catch
			{
			}
		}

		// Token: 0x060000EF RID: 239 RVA: 0x0000D768 File Offset: 0x0000B968
		public bool IsSpecialLootItem(Item lootItem)
		{
			bool flag = lootItem != null;
			bool result;
			if (flag)
			{
				string item = \uE4E3.Localized(lootItem.Name);
				string item2 = \uE4E3.Localized(lootItem.ShortName);
				result = (ContainerEsp.SpecialLootItems.Contains(item) || ContainerEsp.SpecialLootItems.Contains(item2));
			}
			else
			{
				result = false;
			}
			return result;
		}

		// Token: 0x060000F0 RID: 240 RVA: 0x0000D7BC File Offset: 0x0000B9BC
		private void OnGUI()
		{
			try
			{
				bool container = Config.ESP.ItemEsp.container;
				if (container)
				{
					foreach (GameLootContainer gameLootContainer in this._gameLootContainers)
					{
						bool flag = gameLootContainer.IsOnScreen && GameUtils.IsLootableContainerValid(gameLootContainer.LootableContainer);
						if (flag)
						{
							bool flag2 = gameLootContainer.Distance <= Misc.containerdistance;
							if (flag2)
							{
								Item item = \uE6E5.GetAllItems(gameLootContainer.LootableContainer.ItemOwner.RootItem, true).First<Item>();
								foreach (Item item2 in \uE6E5.GetAllItems(item, false))
								{
									string text = "RareLootContainer [" + gameLootContainer.FormattedDistance + "]";
									Rendering.DrawString1(new Vector2(gameLootContainer.ScreenPosition.x - 50f, gameLootContainer.ScreenPosition.y), text, Main.containercolor, true, 8, FontStyle.Bold, 1);
								}
							}
						}
					}
				}
				bool containercontents = Config.ESP.containercontents;
				if (containercontents)
				{
					Dictionary<LootableContainer, int> dictionary = new Dictionary<LootableContainer, int>();
					Vector2 vector;
					vector..ctor((float)Screen.width / 2f, (float)Screen.height / 2f);
					Vector3 zero = Vector3.zero;
					int num = -20;
					foreach (GameLootContainer gameLootContainer2 in this._gameLootContainers)
					{
						int num2 = (int)Vector2.Distance(Misc.MainCamera.WorldToScreenPoint(gameLootContainer2.LootableContainer.transform.position), vector);
						int num3 = (int)Vector3.Distance(Misc.LocalPlayer.Transform.position, gameLootContainer2.LootableContainer.transform.position);
						Vector3 vector2 = gameLootContainer2.LootableContainer.transform.position - Misc.MainCamera.transform.position;
						bool flag3 = !MonoBehaviourSingleton<PreloaderUI>.Instance.IsBackgroundBlackActive && (float)num3 <= 5000f && (float)num2 <= 5000f && Vector3.Dot(Misc.MainCamera.transform.TransformDirection(Vector3.forward), vector2) > 0f;
						if (flag3)
						{
							dictionary.Add(gameLootContainer2.LootableContainer, num2);
						}
					}
					bool flag4 = (double)dictionary.Count > 0.01;
					if (flag4)
					{
						dictionary = (from pair in dictionary
						orderby pair.Value
						select pair).ToDictionary((KeyValuePair<LootableContainer, int> pair) => pair.Key, (KeyValuePair<LootableContainer, int> pair) => pair.Value);
						LootableContainer lootableContainer = dictionary.Keys.First<LootableContainer>();
						Vector3 vector3 = Camera.main.WorldToScreenPoint(lootableContainer.transform.position);
						int num4 = (int)Vector3.Distance(Misc.MainCamera.transform.position, lootableContainer.transform.position);
						Vector3 position = lootableContainer.transform.position;
						Vector3 vector4 = Camera.main.WorldToScreenPoint(lootableContainer.transform.position);
						Item item3 = \uE6E5.GetAllItems(lootableContainer.ItemOwner.RootItem, true).First<Item>();
						string arg = \uE4E3.Localized(item3.Name);
						bool flag5 = (double)vector4.z > 0.01;
						if (flag5)
						{
							foreach (Item item4 in \uE6E5.GetAllItems(item3, false))
							{
								bool flag6 = \uE6E5.GetAllItems(item3, false).First<Item>() == item4;
								if (flag6)
								{
									arg = \uE4E3.Localized(item4.ShortName);
								}
								else
								{
									arg = \uE4E3.Localized(item4.ShortName);
								}
								Rendering.DrawString1(new Vector2((float)Screen.width - 240f, 188.695633f - (float)num), string.Format("{0}", arg), Main.containercolor, true, 10, FontStyle.Bold, 1);
								num -= 20;
							}
						}
					}
				}
			}
			catch
			{
			}
		}

		// Token: 0x04000097 RID: 151
		private static readonly float CacheLootItemsInterval = 100f;

		// Token: 0x04000098 RID: 152
		private float _nextLootContainerCacheTime;

		// Token: 0x04000099 RID: 153
		private List<GameLootContainer> _gameLootContainers;

		// Token: 0x0400009A RID: 154
		private static readonly Color LootableContainerColor = new Color(1f, 0.2f, 0.09f);

		// Token: 0x0400009B RID: 155
		public static float containerdistance;

		// Token: 0x0400009C RID: 156
		public static List<string> SpecialLootItems;
	}
}
