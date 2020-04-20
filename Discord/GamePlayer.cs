using System;
using EFT;
using UnityEngine;

namespace Discord
{
	// Token: 0x02000011 RID: 17
	public class GamePlayer
	{
		// Token: 0x1700000F RID: 15
		// (get) Token: 0x06000094 RID: 148 RVA: 0x0000A58A File Offset: 0x0000878A
		public Player Player
		{
			get
			{
				return this.player;
			}
		}

		// Token: 0x17000010 RID: 16
		// (get) Token: 0x06000095 RID: 149 RVA: 0x0000A592 File Offset: 0x00008792
		public Vector3 ScreenPosition
		{
			get
			{
				return this.screenPosition;
			}
		}

		// Token: 0x17000011 RID: 17
		// (get) Token: 0x06000096 RID: 150 RVA: 0x0000A59A File Offset: 0x0000879A
		public Vector3 HeadScreenPosition
		{
			get
			{
				return this.headScreenPosition;
			}
		}

		// Token: 0x17000012 RID: 18
		// (get) Token: 0x06000097 RID: 151 RVA: 0x0000A5A2 File Offset: 0x000087A2
		// (set) Token: 0x06000098 RID: 152 RVA: 0x0000A5AA File Offset: 0x000087AA
		public bool IsOnScreen { get; private set; }

		// Token: 0x17000013 RID: 19
		// (get) Token: 0x06000099 RID: 153 RVA: 0x0000A5B3 File Offset: 0x000087B3
		// (set) Token: 0x0600009A RID: 154 RVA: 0x0000A5BB File Offset: 0x000087BB
		public float Distance { get; private set; }

		// Token: 0x17000014 RID: 20
		// (get) Token: 0x0600009B RID: 155 RVA: 0x0000A5C4 File Offset: 0x000087C4
		// (set) Token: 0x0600009C RID: 156 RVA: 0x0000A5CC File Offset: 0x000087CC
		public bool Scav { get; private set; }

		// Token: 0x17000015 RID: 21
		// (get) Token: 0x0600009D RID: 157 RVA: 0x0000A5D5 File Offset: 0x000087D5
		public string FormattedDistance
		{
			get
			{
				return string.Format("{0}m", (int)Math.Round((double)this.Distance));
			}
		}

		// Token: 0x0600009E RID: 158 RVA: 0x0000A5F4 File Offset: 0x000087F4
		public GamePlayer(Player player)
		{
			bool flag = player == null;
			if (flag)
			{
				throw new ArgumentNullException("player");
			}
			this.player = player;
			this.screenPosition = default(Vector3);
			this.headScreenPosition = default(Vector3);
			this.IsOnScreen = false;
			this.Distance = 0f;
			this.Scav = true;
		}

		// Token: 0x0600009F RID: 159 RVA: 0x0000A65C File Offset: 0x0000885C
		public void RecalculateDynamics()
		{
			bool flag = !GameUtils.IsPlayerValid(this.player);
			if (!flag)
			{
				this.screenPosition = GameUtils.WorldPointToScreenPoint(this.player.Transform.position);
				bool flag2 = this.player.PlayerBones != null;
				if (flag2)
				{
					this.headScreenPosition = GameUtils.WorldPointToScreenPoint(this.player.PlayerBones.Head.position + new Vector3(0f, 0.4f, 0f));
				}
				this.IsOnScreen = GameUtils.IsScreenPointVisible(this.screenPosition);
				this.Distance = Vector3.Distance(Misc.MainCamera.transform.position, this.player.Transform.position);
				bool flag3 = this.player.Profile != null && this.player.Profile.Info != null;
				if (flag3)
				{
					this.Scav = (this.player.Profile.Info.RegistrationDate <= 0);
				}
			}
		}

		// Token: 0x04000063 RID: 99
		private readonly Player player;

		// Token: 0x04000064 RID: 100
		private Vector3 screenPosition;

		// Token: 0x04000065 RID: 101
		private Vector3 headScreenPosition;
	}
}
