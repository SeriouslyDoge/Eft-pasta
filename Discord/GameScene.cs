using System;
using UnityEngine.SceneManagement;

namespace Discord
{
	// Token: 0x0200000D RID: 13
	internal class GameScene
	{
		// Token: 0x06000074 RID: 116 RVA: 0x00009B78 File Offset: 0x00007D78
		private static string GetSceneName()
		{
			return GameScene.CurrentGameScene.name;
		}

		// Token: 0x06000075 RID: 117 RVA: 0x00009B94 File Offset: 0x00007D94
		public static bool IsLoaded()
		{
			return GameScene.CurrentGameScene.isLoaded;
		}

		// Token: 0x06000076 RID: 118 RVA: 0x00009BB0 File Offset: 0x00007DB0
		public static bool InMatch()
		{
			return GameScene.GetSceneName() != "EnvironmentUIScene" && GameScene.GetSceneName() != "MenuUIScene" && GameScene.GetSceneName() != "CommonUIScene" && GameScene.GetSceneName() != "MainScene" && GameScene.GetSceneName() != "";
		}

		// Token: 0x06000077 RID: 119 RVA: 0x00009C18 File Offset: 0x00007E18
		public static void GetScene()
		{
			GameScene.CurrentGameScene = SceneManager.GetActiveScene();
		}

		// Token: 0x0400005C RID: 92
		public static Scene CurrentGameScene;
	}
}
