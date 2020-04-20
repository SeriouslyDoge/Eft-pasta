using System;
using Esp;
using Thermal;
using UnityEngine;

namespace Discord
{
	// Token: 0x02000019 RID: 25
	public class Loader
	{
		// Token: 0x060000C9 RID: 201 RVA: 0x0000B3CC File Offset: 0x000095CC
		public static void Load()
		{
			Config.Init();
			Loader.gameObject = new GameObject();
			Loader.gameObject.AddComponent<Main>();
			Loader.gameObject.AddComponent<ThermalShits>();
			Loader.gameObject.AddComponent<nibba>();
			Loader.gameObject.AddComponent<ItemEsp>();
			Loader.gameObject.AddComponent<ContainerEsp>();
			Loader.gameObject.AddComponent<CorpseEsp>();
			Loader.gameObject.AddComponent<GrenadeEsp>();
			Loader.gameObject.AddComponent<Misc>();
			Object.DontDestroyOnLoad(Loader.gameObject);
		}

		// Token: 0x04000075 RID: 117
		private static GameObject gameObject;
	}
}
