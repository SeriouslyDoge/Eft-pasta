using System;
using System.Collections.Generic;
using System.Linq;
using Diz.Skinning;
using EFT;
using EFT.Interactive;
using UnityEngine;

namespace Discord
{
	// Token: 0x02000012 RID: 18
	public static class GameUtils
	{
		// Token: 0x060000A0 RID: 160 RVA: 0x0000A770 File Offset: 0x00008970
		public static float Map(float value, float sourceFrom, float sourceTo, float destinationFrom, float destinationTo)
		{
			return (value - sourceFrom) / (sourceTo - sourceFrom) * (destinationTo - destinationFrom) + destinationFrom;
		}

		// Token: 0x060000A1 RID: 161 RVA: 0x0000A790 File Offset: 0x00008990
		public static bool IsPlayerValid(Player player)
		{
			return player != null && player.Transform != null && player.PlayerBones != null && player.PlayerBones.transform != null;
		}

		// Token: 0x060000A2 RID: 162 RVA: 0x0000A7D8 File Offset: 0x000089D8
		public static bool isgrenadevalid(Throwable player)
		{
			return player != null;
		}

		// Token: 0x060000A3 RID: 163 RVA: 0x0000A7F4 File Offset: 0x000089F4
		public static bool IsExfiltrationPointValid(ExfiltrationPoint lootItem)
		{
			return lootItem != null;
		}

		// Token: 0x060000A4 RID: 164 RVA: 0x0000A810 File Offset: 0x00008A10
		public static bool IsLootItemValid(LootItem lootItem)
		{
			return lootItem != null && lootItem.Item != null && lootItem.Item.Template != null;
		}

		// Token: 0x060000A5 RID: 165 RVA: 0x0000A844 File Offset: 0x00008A44
		public static bool IsLootableContainerValid(LootableContainer lootableContainer)
		{
			return lootableContainer != null && lootableContainer.Template != null;
		}

		// Token: 0x060000A6 RID: 166 RVA: 0x0000A86C File Offset: 0x00008A6C
		public static bool IsThermalValid(ThermalVision lootableContainer)
		{
			return lootableContainer != null;
		}

		// Token: 0x060000A7 RID: 167 RVA: 0x0000A888 File Offset: 0x00008A88
		public static bool IsPlayerAlive(Player player)
		{
			bool flag = !GameUtils.IsPlayerValid(player);
			bool result;
			if (flag)
			{
				result = false;
			}
			else
			{
				bool flag2 = player.HealthController == null;
				result = (!flag2 && player.HealthController.IsAlive);
			}
			return result;
		}

		// Token: 0x060000A8 RID: 168 RVA: 0x0000A8C8 File Offset: 0x00008AC8
		public static Vector3 WorldPointToScreenPoint(Vector3 worldPoint)
		{
			Vector3 vector = Misc.MainCamera.WorldToScreenPoint(worldPoint);
			vector.y = (float)Screen.height - vector.y;
			return vector;
		}

		// Token: 0x060000A9 RID: 169 RVA: 0x0000A8FC File Offset: 0x00008AFC
		public static bool IsScreenPointVisible(Vector3 screenPoint)
		{
			return screenPoint.z > 0.01f && screenPoint.x > -5f && screenPoint.y > -5f && screenPoint.x < (float)Screen.width && screenPoint.y < (float)Screen.height;
		}

		// Token: 0x060000AA RID: 170 RVA: 0x0000A954 File Offset: 0x00008B54
		public static Vector3 GetBonePosByID(Player player, int id)
		{
			Vector3 result;
			try
			{
				result = GameUtils.SkeletonBonePos(player.PlayerBones.AnimatedTransform.Original.gameObject.GetComponent<PlayerBody>().SkeletonRootJoint, id);
			}
			catch (Exception)
			{
				result = Vector3.zero;
			}
			return result;
		}

		// Token: 0x060000AB RID: 171 RVA: 0x0000A9AC File Offset: 0x00008BAC
		public static Vector3 SkeletonBonePos(Skeleton skeleton, int id)
		{
			return skeleton.Bones.ElementAt(id).Value.position;
		}
	}
}
