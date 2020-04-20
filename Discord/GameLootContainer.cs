using System;
using EFT.Interactive;
using UnityEngine;

namespace Discord
{
	// Token: 0x02000015 RID: 21
	internal class GameLootContainer
	{
		// Token: 0x17000016 RID: 22
		// (get) Token: 0x060000AE RID: 174 RVA: 0x0000AA5B File Offset: 0x00008C5B
		public LootableContainer LootableContainer { get; }

		// Token: 0x17000017 RID: 23
		// (get) Token: 0x060000AF RID: 175 RVA: 0x0000AA63 File Offset: 0x00008C63
		public Vector3 ScreenPosition
		{
			get
			{
				return this.screenPosition;
			}
		}

		// Token: 0x17000018 RID: 24
		// (get) Token: 0x060000B0 RID: 176 RVA: 0x0000AA6B File Offset: 0x00008C6B
		// (set) Token: 0x060000B1 RID: 177 RVA: 0x0000AA73 File Offset: 0x00008C73
		public bool IsOnScreen { get; private set; }

		// Token: 0x17000019 RID: 25
		// (get) Token: 0x060000B2 RID: 178 RVA: 0x0000AA7C File Offset: 0x00008C7C
		// (set) Token: 0x060000B3 RID: 179 RVA: 0x0000AA84 File Offset: 0x00008C84
		public float Distance { get; private set; }

		// Token: 0x1700001A RID: 26
		// (get) Token: 0x060000B4 RID: 180 RVA: 0x0000AA8D File Offset: 0x00008C8D
		public string FormattedDistance
		{
			get
			{
				return string.Format("{0}m", Math.Round((double)this.Distance));
			}
		}

		// Token: 0x060000B5 RID: 181 RVA: 0x0000AAAC File Offset: 0x00008CAC
		public GameLootContainer(LootableContainer lootableContainer)
		{
			bool flag = lootableContainer == null;
			if (flag)
			{
				throw new ArgumentNullException("lootableContainer");
			}
			this.LootableContainer = lootableContainer;
			this.screenPosition = default(Vector3);
			this.Distance = 0f;
		}

		// Token: 0x060000B6 RID: 182 RVA: 0x0000AAF8 File Offset: 0x00008CF8
		public void RecalculateDynamics()
		{
			bool flag = !GameUtils.IsLootableContainerValid(this.LootableContainer);
			if (!flag)
			{
				this.screenPosition = GameUtils.WorldPointToScreenPoint(this.LootableContainer.transform.position);
				this.IsOnScreen = GameUtils.IsScreenPointVisible(this.screenPosition);
				this.Distance = Vector3.Distance(Misc.MainCamera.transform.position, this.LootableContainer.transform.position);
			}
		}

		// Token: 0x0400006F RID: 111
		private Vector3 screenPosition;
	}
}
