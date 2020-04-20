using System;
using UnityEngine;

namespace Discord
{
	// Token: 0x0200000A RID: 10
	internal class Grenade444
	{
		// Token: 0x17000001 RID: 1
		// (get) Token: 0x06000057 RID: 87 RVA: 0x0000962C File Offset: 0x0000782C
		public Throwable LootableContainer { get; }

		// Token: 0x17000002 RID: 2
		// (get) Token: 0x06000058 RID: 88 RVA: 0x00009634 File Offset: 0x00007834
		public Vector3 ScreenPosition
		{
			get
			{
				return this.screenPosition;
			}
		}

		// Token: 0x17000003 RID: 3
		// (get) Token: 0x06000059 RID: 89 RVA: 0x0000963C File Offset: 0x0000783C
		// (set) Token: 0x0600005A RID: 90 RVA: 0x00009644 File Offset: 0x00007844
		public bool IsOnScreen { get; private set; }

		// Token: 0x17000004 RID: 4
		// (get) Token: 0x0600005B RID: 91 RVA: 0x0000964D File Offset: 0x0000784D
		// (set) Token: 0x0600005C RID: 92 RVA: 0x00009655 File Offset: 0x00007855
		public float Distance { get; private set; }

		// Token: 0x17000005 RID: 5
		// (get) Token: 0x0600005D RID: 93 RVA: 0x0000965E File Offset: 0x0000785E
		public string FormattedDistance
		{
			get
			{
				return string.Format("{0}m", Math.Round((double)this.Distance));
			}
		}

		// Token: 0x0600005E RID: 94 RVA: 0x0000967C File Offset: 0x0000787C
		public Grenade444(Throwable lootableContainer)
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

		// Token: 0x0600005F RID: 95 RVA: 0x000096C8 File Offset: 0x000078C8
		public void RecalculateDynamics()
		{
			bool flag = !GameUtils.isgrenadevalid(this.LootableContainer);
			if (!flag)
			{
				this.screenPosition = GameUtils.WorldPointToScreenPoint(this.LootableContainer.transform.position);
				this.IsOnScreen = GameUtils.IsScreenPointVisible(this.screenPosition);
				this.Distance = Vector3.Distance(Misc.MainCamera.transform.position, this.LootableContainer.transform.position);
			}
		}

		// Token: 0x04000052 RID: 82
		private Vector3 screenPosition;
	}
}
