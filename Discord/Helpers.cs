using System;
using System.Collections.Generic;
using System.Linq;
using Diz.Skinning;
using EFT;
using UnityEngine;

namespace Discord
{
	// Token: 0x02000014 RID: 20
	public static class Helpers
	{
		// Token: 0x060000AC RID: 172 RVA: 0x0000A9D8 File Offset: 0x00008BD8
		public static Vector3 GetBonePosByID(Player player, int id)
		{
			Vector3 result;
			try
			{
				result = Helpers.SkeletonBonePos(player.PlayerBones.AnimatedTransform.Original.gameObject.GetComponent<PlayerBody>().SkeletonRootJoint, id);
			}
			catch (Exception)
			{
				result = Vector3.zero;
			}
			return result;
		}

		// Token: 0x060000AD RID: 173 RVA: 0x0000AA30 File Offset: 0x00008C30
		public static Vector3 SkeletonBonePos(Skeleton skeleton, int id)
		{
			return skeleton.Bones.ElementAt(id).Value.position;
		}
	}
}
