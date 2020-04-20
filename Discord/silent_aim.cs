using System;
using System.Collections.Generic;
using System.Linq;
using EFT;
using EFT.InventoryLogic;
using EFT.UI;
using UnityEngine;

namespace Discord
{
	// Token: 0x02000009 RID: 9
	public class silent_aim
	{
		// Token: 0x06000053 RID: 83 RVA: 0x000091AC File Offset: 0x000073AC
		public void UpdateWeightLimitshk()
		{
			bool flag = Misc.LocalPlayer && Config.Misc.weight;
			if (flag)
			{
				Misc.LocalPlayer.Physical.WalkOverweightLimits.Set(1f, 10000f);
				Misc.LocalPlayer.Physical.BaseOverweightLimits.Set(1f, 10000f);
				Misc.LocalPlayer.Physical.SprintOverweightLimits.Set(1f, 10000f);
				Misc.LocalPlayer.Physical.WalkSpeedOverweightLimits.Set(1f, 10000f);
			}
		}

		// Token: 0x06000054 RID: 84 RVA: 0x00009250 File Offset: 0x00007450
		public object ouchthathurt(object ammo, Vector3 origin, Vector3 direction, int fireIndex, Player player, Item weapon, float speedFactor = 1f, int fragmentIndex = 0)
		{
			bool silent = Config.Misc.silent;
			if (silent)
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
					bool flag = !Misc.friendsList.Contains(gamePlayer.Player.Profile.Info.Nickname) && !MonoBehaviourSingleton<PreloaderUI>.Instance.IsBackgroundBlackActive && (float)num2 <= Main.distancefrome && (float)num <= Main.distancefromcenter && Vector3.Dot(Misc.MainCamera.transform.TransformDirection(Vector3.forward), vector2) > 0f;
					if (flag)
					{
						dictionary.Add(gamePlayer.Player, num);
					}
				}
				bool flag2 = (double)dictionary.Count > 0.01;
				if (flag2)
				{
					dictionary = (from pair in dictionary
					orderby pair.Value
					select pair).ToDictionary((KeyValuePair<Player, int> pair) => pair.Key, (KeyValuePair<Player, int> pair) => pair.Value);
					Player player2 = dictionary.Keys.First<Player>();
					Vector3 vector3 = Camera.main.WorldToScreenPoint(player2.Transform.position);
					int num3 = (int)Vector3.Distance(Misc.MainCamera.transform.position, player2.Transform.position);
					Vector3 vector4 = player2.PlayerBones.Head.position + new Vector3(0f, 0.07246377f, 0f);
					Vector3 vector5 = Camera.main.WorldToScreenPoint(player2.Transform.position);
					Weapon weapon2 = Misc.LocalPlayer.Weapon;
					bool flag3 = player2.Profile.Info.Nickname == "ChaseNelson";
					bool flag4 = player2.Profile.Info.Nickname == "HNICOS";
					bool flag5 = (double)vector5.z > 0.01 && weapon2 != null && !flag3 && !flag4;
					if (flag5)
					{
						direction = (player2.PlayerBones.Head.position - origin).normalized;
					}
				}
			}
			Main.create_shot_hook.Unhook();
			object[] parameters = new object[]
			{
				ammo,
				origin,
				direction,
				fireIndex,
				player,
				weapon,
				speedFactor,
				fragmentIndex
			};
			object result = Main.create_shot_hook.OriginalMethod.Invoke(this, parameters);
			Main.create_shot_hook.Hook();
			return result;
		}

		// Token: 0x06000055 RID: 85 RVA: 0x0000960C File Offset: 0x0000780C
		public static float wow(object ammo, int randomInt, object randoms)
		{
			return 500000f;
		}
	}
}
