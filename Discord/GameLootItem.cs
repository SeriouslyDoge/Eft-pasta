using System;
using EFT.Interactive;
using UnityEngine;

namespace Discord
{
	// Token: 0x0200000C RID: 12
	public class GameLootItem
	{
		// Token: 0x17000008 RID: 8
		// (get) Token: 0x0600006B RID: 107 RVA: 0x00009A61 File Offset: 0x00007C61
		public LootItem LootItem { get; }

		// Token: 0x17000009 RID: 9
		// (get) Token: 0x0600006C RID: 108 RVA: 0x00009A69 File Offset: 0x00007C69
		public Vector3 ScreenPosition
		{
			get
			{
				return this.screenPosition;
			}
		}

		// Token: 0x1700000A RID: 10
		// (get) Token: 0x0600006D RID: 109 RVA: 0x00009A71 File Offset: 0x00007C71
		// (set) Token: 0x0600006E RID: 110 RVA: 0x00009A79 File Offset: 0x00007C79
		public bool IsOnScreen { get; private set; }

		// Token: 0x1700000B RID: 11
		// (get) Token: 0x0600006F RID: 111 RVA: 0x00009A82 File Offset: 0x00007C82
		// (set) Token: 0x06000070 RID: 112 RVA: 0x00009A8A File Offset: 0x00007C8A
		public float Distance { get; private set; }

		// Token: 0x1700000C RID: 12
		// (get) Token: 0x06000071 RID: 113 RVA: 0x00009A93 File Offset: 0x00007C93
		public string FormattedDistance
		{
			get
			{
				return string.Format("{0}m", Math.Round((double)this.Distance));
			}
		}

		// Token: 0x06000072 RID: 114 RVA: 0x00009AB0 File Offset: 0x00007CB0
		public GameLootItem(LootItem lootItem)
		{
			bool flag = lootItem == null;
			if (flag)
			{
				throw new ArgumentNullException("lootItem");
			}
			this.LootItem = lootItem;
			this.screenPosition = default(Vector3);
			this.Distance = 0f;
		}

		// Token: 0x06000073 RID: 115 RVA: 0x00009AFC File Offset: 0x00007CFC
		public void RecalculateDynamics()
		{
			bool flag = !GameUtils.IsLootItemValid(this.LootItem);
			if (!flag)
			{
				this.screenPosition = GameUtils.WorldPointToScreenPoint(this.LootItem.transform.position);
				this.IsOnScreen = GameUtils.IsScreenPointVisible(this.screenPosition);
				this.Distance = Vector3.Distance(Misc.MainCamera.transform.position, this.LootItem.transform.position);
			}
		}

		// Token: 0x0400005B RID: 91
		private Vector3 screenPosition;
	}
}
