using System;

namespace Discord
{
	// Token: 0x02000017 RID: 23
	public class Config
	{
		// Token: 0x060000C3 RID: 195 RVA: 0x0000B1C8 File Offset: 0x000093C8
		public static void Init()
		{
			Config.ESP.VisualsWindow = false;
			Config.ESP.colorwindow = false;
			Config.ESP.distancewindow = false;
			Config.Aimbot.AimbotWindow = false;
			Config.Aimbot.DrawFov = false;
			Config.Aimbot.Aim = false;
			Config.Aimbot.Crosshair = false;
			Config.Misc.clearvision = false;
			Config.Misc.MiscWindow = false;
			Config.Misc.nightvision = false;
			Config.Misc.nofall = false;
			Config.Misc.RemovalsWindow = false;
			Config.Misc.norecoil = false;
			Config.Misc.speedtest = false;
			Config.Misc.nospread = false;
			Config.Misc.skillhack = false;
			Config.Misc.SprintDrain = false;
			Config.Misc.aimdrain = false;
			Config.ESP.PlayerEsp = false;
			Config.ESP.Box = false;
			Config.Misc.flyhack = false;
			Config.ESP.weaponammo = false;
			Config.ESP.health = false;
			Config.Misc.fastreload = false;
			Config.Misc.fullauto = false;
			Config.ESP.HeldWeapon = false;
			Config.Misc.thermalvision = false;
			Config.Misc.alwayssprint = false;
			Config.ESP.containercontents = false;
			Config.ESP.Skeleton = false;
			Config.ESP.scavskeleton = false;
			Config.ESP.Scav = false;
			Config.Misc.sherman = false;
			Config.ESP.drawfriend = false;
			Config.Misc.instanthit = false;
			Config.ESP.localinfo = false;
			Config.Misc.silent = false;
			Config.ESP.Corpse = false;
			Config.ESP.power = false;
			Config.ESP.chams = false;
			Config.ESP.ItemEsp.Common = false;
			Config.Misc.doorunlock = false;
			Config.ESP.testing = false;
			Config.ESP.ItemEsp.Quest = false;
			Config.Misc.weight = false;
			Config.ESP.grenade = false;
			Config.ESP.ItemEsp.Rare = false;
			Config.Misc.speedhack = false;
			Config.ESP.target = false;
			Config.ESP.ItemEsp.SuperRare = false;
			Config.ESP.ItemEsp.extraction = false;
			Config.ESP.ItemEsp.container = false;
		}

		// Token: 0x02000026 RID: 38
		internal static class Aimbot
		{
			// Token: 0x040000C3 RID: 195
			public static bool AimbotWindow;

			// Token: 0x040000C4 RID: 196
			public static bool Aim;

			// Token: 0x040000C5 RID: 197
			public static bool DrawFov;

			// Token: 0x040000C6 RID: 198
			public static bool Crosshair;
		}

		// Token: 0x02000027 RID: 39
		internal static class ESP
		{
			// Token: 0x040000C7 RID: 199
			public static bool distancewindow;

			// Token: 0x040000C8 RID: 200
			public static bool testing;

			// Token: 0x040000C9 RID: 201
			public static bool colorwindow;

			// Token: 0x040000CA RID: 202
			public static bool drawfriend;

			// Token: 0x040000CB RID: 203
			public static bool VisualsWindow;

			// Token: 0x040000CC RID: 204
			public static bool PlayerEsp;

			// Token: 0x040000CD RID: 205
			public static bool scavskeleton;

			// Token: 0x040000CE RID: 206
			public static bool localinfo;

			// Token: 0x040000CF RID: 207
			public static bool grenade;

			// Token: 0x040000D0 RID: 208
			public static bool Box;

			// Token: 0x040000D1 RID: 209
			public static bool target;

			// Token: 0x040000D2 RID: 210
			public static bool containercontents;

			// Token: 0x040000D3 RID: 211
			public static bool power;

			// Token: 0x040000D4 RID: 212
			public static bool weaponammo;

			// Token: 0x040000D5 RID: 213
			public static bool health;

			// Token: 0x040000D6 RID: 214
			public static bool HeldWeapon;

			// Token: 0x040000D7 RID: 215
			public static bool Skeleton;

			// Token: 0x040000D8 RID: 216
			public static bool Scav;

			// Token: 0x040000D9 RID: 217
			public static bool Corpse;

			// Token: 0x040000DA RID: 218
			public static bool chams;

			// Token: 0x0200002F RID: 47
			public static class ItemEsp
			{
				// Token: 0x04000104 RID: 260
				public static bool SuperRare;

				// Token: 0x04000105 RID: 261
				public static bool Rare;

				// Token: 0x04000106 RID: 262
				public static bool Common;

				// Token: 0x04000107 RID: 263
				public static bool Quest;

				// Token: 0x04000108 RID: 264
				public static bool extraction;

				// Token: 0x04000109 RID: 265
				public static bool container;
			}
		}

		// Token: 0x02000028 RID: 40
		public static class Misc
		{
			// Token: 0x040000DB RID: 219
			public static bool MiscWindow;

			// Token: 0x040000DC RID: 220
			public static bool nofall;

			// Token: 0x040000DD RID: 221
			public static bool nightvision;

			// Token: 0x040000DE RID: 222
			public static bool clearvision;

			// Token: 0x040000DF RID: 223
			public static bool weight;

			// Token: 0x040000E0 RID: 224
			public static bool sherman;

			// Token: 0x040000E1 RID: 225
			public static bool silent;

			// Token: 0x040000E2 RID: 226
			public static bool speedtest;

			// Token: 0x040000E3 RID: 227
			public static bool speedhack;

			// Token: 0x040000E4 RID: 228
			public static bool RemovalsWindow;

			// Token: 0x040000E5 RID: 229
			public static bool instanthit;

			// Token: 0x040000E6 RID: 230
			public static bool alwayssprint;

			// Token: 0x040000E7 RID: 231
			public static bool skillhack;

			// Token: 0x040000E8 RID: 232
			public static bool norecoil;

			// Token: 0x040000E9 RID: 233
			public static bool fullauto;

			// Token: 0x040000EA RID: 234
			public static bool fastreload;

			// Token: 0x040000EB RID: 235
			public static bool nospread;

			// Token: 0x040000EC RID: 236
			public static bool doorunlock;

			// Token: 0x040000ED RID: 237
			public static bool flyhack;

			// Token: 0x040000EE RID: 238
			public static bool thermalvision;

			// Token: 0x040000EF RID: 239
			public static bool SprintDrain;

			// Token: 0x040000F0 RID: 240
			public static bool aimdrain;
		}
	}
}
