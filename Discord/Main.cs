using System;
using System.Collections;
using System.Collections.Generic;
using System.Linq;
using System.Reflection;
using BSG.CameraEffects;
using Discord;
using EFT;
using EFT.Ballistics;
using EFT.Interactive;
using EFT.InventoryLogic;
using EFT.UI;
using UnityEngine;

// Token: 0x02000007 RID: 7
public class Main : MonoBehaviour
{
	// Token: 0x06000042 RID: 66 RVA: 0x000047DC File Offset: 0x000029DC
	private static void DoorUnlock()
	{
		try
		{
			bool flag = !(Misc.LocalPlayer == null) && !(Misc.MainCamera == null);
			if (flag)
			{
				bool keyDown = Input.GetKeyDown(285);
				if (keyDown)
				{
					foreach (Door door in Object.FindObjectsOfType<Door>())
					{
						bool flag2 = door.DoorState != 4 && Vector3.Distance(door.transform.position, Misc.LocalPlayer.Position) <= 10f;
						if (flag2)
						{
							door.DoorState = 2;
						}
					}
				}
			}
		}
		catch
		{
		}
	}

	// Token: 0x06000043 RID: 67 RVA: 0x00004898 File Offset: 0x00002A98
	private static void keycarddoor()
	{
		try
		{
			bool flag = !(Misc.LocalPlayer == null) && !(Misc.MainCamera == null);
			if (flag)
			{
				bool keyDown = Input.GetKeyDown(286);
				if (keyDown)
				{
					foreach (LootableContainer lootableContainer in Object.FindObjectsOfType<LootableContainer>())
					{
						bool flag2 = lootableContainer.DoorState != 4 && Vector3.Distance(lootableContainer.transform.position, Misc.LocalPlayer.Position) <= 10f;
						if (flag2)
						{
							lootableContainer.DoorState = 2;
						}
					}
				}
			}
		}
		catch
		{
		}
	}

	// Token: 0x06000044 RID: 68 RVA: 0x00004954 File Offset: 0x00002B54
	public void Start()
	{
		base.StartCoroutine(this.SaveAndDownload());
	}

	// Token: 0x06000045 RID: 69 RVA: 0x00004964 File Offset: 0x00002B64
	private IEnumerator SaveAndDownload()
	{
		WWW www = WWW.LoadFromCacheOrDownload(this.url, this.ver);
		yield return www;
		bool flag = www.error == null;
		if (flag)
		{
			Main.Skin = www.assetBundle.LoadAllAssets<GUISkin>().First<GUISkin>();
		}
		else
		{
			Debug.LogError(www.error);
		}
		yield break;
	}

	// Token: 0x06000046 RID: 70 RVA: 0x00004974 File Offset: 0x00002B74
	private void miscstuff()
	{
		bool flag = Misc.LocalPlayer == null && GameScene.IsLoaded() && GameScene.InMatch();
		if (!flag)
		{
			bool silent = Config.Misc.silent;
			if (silent)
			{
				bool flag2 = Main.not_hooked;
				if (flag2)
				{
					Main.create_shot_hook = new DumbHook();
					Main.create_shot_hook.Init(typeof(BallisticsCalculator).GetMethod("CreateShot"), typeof(silent_aim).GetMethod("ouchthathurt"));
					Main.create_shot_hook.Hook();
					Main.not_hooked = false;
				}
			}
			bool speedhack = Config.Misc.speedhack;
			if (speedhack)
			{
				bool flag3 = Main.not_hooked1;
				if (flag3)
				{
					Main.specialhook = new DumbHook();
					Main.specialhook.Init(typeof(BallisticsCalculator).GetMethod("GetAmmoPenetrationPower"), typeof(silent_aim).GetMethod("wow"));
					Main.specialhook.Hook();
					Main.not_hooked1 = false;
				}
			}
			bool weight = Config.Misc.weight;
			if (weight)
			{
				bool flag4 = Main.not_hooked2;
				if (flag4)
				{
					Main.testinggggg = new DumbHook();
					Main.testinggggg.Init(typeof(Player).Assembly.GetType("").GetMethod("UpdateWeightLimits"), typeof(silent_aim).GetMethod("UpdateWeightLimitshk"));
					Main.testinggggg.Hook();
					Main.not_hooked2 = false;
				}
			}
			bool flyhack = Config.Misc.flyhack;
			if (flyhack)
			{
				bool flag5 = Input.GetKey(306);
				if (flag5)
				{
					Misc.LocalPlayer.MovementContext.FreefallTime = -0.05797062f;
				}
			}
			bool flag6 = Input.GetKeyDown(286) && Config.Misc.sherman;
			if (flag6)
			{
				Main.keycarddoor();
			}
			bool flag7 = Input.GetKeyDown(285) && Config.Misc.doorunlock;
			if (flag7)
			{
				Main.DoorUnlock();
			}
			bool norecoil = Config.Misc.norecoil;
			if (norecoil)
			{
				bool norecoil2 = Config.Misc.norecoil;
				if (norecoil2)
				{
					Misc.LocalPlayer.ProceduralWeaponAnimation.Shootingg.Intensity = 0f;
					Misc.LocalPlayer.ProceduralWeaponAnimation.ForceReact.Intensity = 0f;
					Misc.LocalPlayer.ProceduralWeaponAnimation.Breath.Overweight = 0f;
					Misc.LocalPlayer.ProceduralWeaponAnimation.Pitch = 0f;
					Misc.LocalPlayer.ProceduralWeaponAnimation.SwayFalloff = 0f;
				}
				bool flag8 = !Config.Misc.norecoil;
				if (flag8)
				{
					Misc.LocalPlayer.ProceduralWeaponAnimation.Shootingg.Intensity = 1f;
				}
			}
			bool alwayssprint = Config.Misc.alwayssprint;
			if (alwayssprint)
			{
				Misc.LocalPlayer.RemoveStateSpeedLimit(0);
				Misc.LocalPlayer.RemoveStateSpeedLimit(7);
				Misc.LocalPlayer.RemoveStateSpeedLimit(1);
				Misc.LocalPlayer.RemoveStateSpeedLimit(6);
				Misc.LocalPlayer.RemoveStateSpeedLimit(4);
				Misc.LocalPlayer.RemoveStateSpeedLimit(5);
				Misc.LocalPlayer.RemoveStateSpeedLimit(3);
				Misc.LocalPlayer.EnableSprint(true);
				Misc.LocalPlayer.MovementContext.EnableSprint(true);
				Misc.LocalPlayer.CurrentState.EnableSprint(true, false);
			}
			bool nospread = Config.Misc.nospread;
			if (nospread)
			{
				bool nospread2 = Config.Misc.nospread;
				if (nospread2)
				{
					Misc.LocalPlayer.ProceduralWeaponAnimation.Breath.Intensity = 0f;
					Misc.LocalPlayer.ProceduralWeaponAnimation.WalkEffectorEnabled = false;
					Misc.LocalPlayer.ProceduralWeaponAnimation.Walk.Intensity = 0f;
					Misc.LocalPlayer.ProceduralWeaponAnimation.MotionReact.Intensity = 0f;
					Misc.LocalPlayer.ProceduralWeaponAnimation.ForceReact.Intensity = 0f;
				}
				bool flag9 = !Config.Misc.nospread;
				if (flag9)
				{
					Misc.LocalPlayer.ProceduralWeaponAnimation.Breath.Intensity = 1f;
					Misc.LocalPlayer.ProceduralWeaponAnimation.WalkEffectorEnabled = true;
					Misc.LocalPlayer.ProceduralWeaponAnimation.Walk.Intensity = 1f;
					Misc.LocalPlayer.ProceduralWeaponAnimation.MotionReact.Intensity = 1f;
					Misc.LocalPlayer.ProceduralWeaponAnimation.ForceReact.Intensity = 1f;
				}
			}
			bool sprintDrain = Config.Misc.SprintDrain;
			if (sprintDrain)
			{
				Misc.LocalPlayer.Physical.StaminaParameters.AimDrainRate = 0f;
				Misc.LocalPlayer.Physical.StaminaParameters.SprintDrainRate = 0f;
				Misc.LocalPlayer.Physical.StaminaParameters.JumpConsumption = 0f;
				Misc.LocalPlayer.Physical.StaminaParameters.ExhaustedMeleeSpeed = 10000f;
			}
			bool flag10 = Config.Misc.skillhack && Misc.LocalPlayer.Skills.GetSkill(43).Level != 51 && Misc.LocalPlayer.Skills.GetSkill(1).Level != 51 && Misc.LocalPlayer.Skills.GetSkill(5).Level != 51 && Misc.LocalPlayer.Skills.GetSkill(11).Level != 51 && Misc.LocalPlayer.Skills.GetSkill(13).Level != 51 && Misc.LocalPlayer.Skills.GetSkill(9).Level != 51 && Misc.LocalPlayer.Skills.GetSkill(0).Level != 51 && Misc.LocalPlayer.Skills.GetSkill(16).Level != 51 && Misc.LocalPlayer.Skills.GetSkill(2).Level != 51 && Misc.LocalPlayer.Skills.GetSkill(18).Level != 51 && Misc.LocalPlayer.Skills.GetSkill(15).Level != 51 && Misc.LocalPlayer.Skills.GetSkill(17).Level != 51 && Misc.LocalPlayer.Skills.GetSkill(14).Level != 51 && Misc.LocalPlayer.Skills.GetSkill(7).Level != 51 && Misc.LocalPlayer.Skills.GetSkill(25).Level != 51 && Misc.LocalPlayer.Skills.GetSkill(12).Level != 51 && Misc.LocalPlayer.Skills.GetSkill(42).Level != 51 && Misc.LocalPlayer.Skills.GetSkill(19).Level != 51 && Misc.LocalPlayer.Skills.GetSkill(21).Level != 51 && Misc.LocalPlayer.Skills.GetSkill(8).Level != 51 && Misc.LocalPlayer.Skills.GetSkill(3).Level != 51 && Misc.LocalPlayer.Skills.GetSkill(26).Level != 51 && Misc.LocalPlayer.Skills.GetSkill(31).Level != 51 && Misc.LocalPlayer.Skills.GetSkill(4).Level != 51 && Misc.LocalPlayer.Skills.GetSkill(35).Level != 51 && Misc.LocalPlayer.Skills.GetSkill(34).Level != 51 && Misc.LocalPlayer.Skills.GetSkill(6).Level != 51 && Misc.LocalPlayer.Skills.GetSkill(10).Level != 51 && Misc.LocalPlayer.Skills.GetSkill(20).Level != 51 && Misc.LocalPlayer.Skills.GetSkill(22).Level != 51 && Misc.LocalPlayer.Skills.GetSkill(29).Level != 51 && Misc.LocalPlayer.Skills.GetSkill(32).Level != 51 && Misc.LocalPlayer.Skills.GetSkill(33).Level != 51 && Misc.LocalPlayer.Skills.GetSkill(36).Level != 51 && Misc.LocalPlayer.Skills.GetSkill(37).Level != 51 && Misc.LocalPlayer.Skills.GetSkill(38).Level != 51 && Misc.LocalPlayer.Skills.GetSkill(40).Level != 51 && Misc.LocalPlayer.Skills.GetSkill(39).Level != 51 && Misc.LocalPlayer.Skills.GetSkill(41).Level != 51 && Misc.LocalPlayer.Skills.GetSkill(44).Level != 51 && Misc.LocalPlayer.Skills.GetSkill(45).Level != 51 && Misc.LocalPlayer.Skills.GetSkill(46).Level != 51 && Misc.LocalPlayer.Skills.GetSkill(47).Level != 51 && Misc.LocalPlayer.Skills.GetSkill(49).Level != 51 && Misc.LocalPlayer.Skills.GetSkill(48).Level != 51 && Misc.LocalPlayer.Skills.GetSkill(50).Level != 51 && Misc.LocalPlayer.Skills.GetSkill(26).Level != 51;
			if (flag10)
			{
				Misc.LocalPlayer.Skills.GetSkill(43).SetLevel(51);
				Misc.LocalPlayer.Skills.GetSkill(11).SetLevel(51);
				Misc.LocalPlayer.Skills.GetSkill(5).SetLevel(51);
				Misc.LocalPlayer.Skills.GetSkill(13).SetLevel(51);
				Misc.LocalPlayer.Skills.GetSkill(1).SetLevel(51);
				Misc.LocalPlayer.Skills.GetSkill(9).SetLevel(51);
				Misc.LocalPlayer.Skills.GetSkill(16).SetLevel(51);
				Misc.LocalPlayer.Skills.GetSkill(0).SetLevel(51);
				Misc.LocalPlayer.Skills.GetSkill(2).SetLevel(51);
				Misc.LocalPlayer.Skills.GetSkill(4).SetLevel(51);
				Misc.LocalPlayer.Skills.GetSkill(31).SetLevel(51);
				Misc.LocalPlayer.Skills.GetSkill(18).SetLevel(51);
				Misc.LocalPlayer.Skills.GetSkill(15).SetLevel(51);
				Misc.LocalPlayer.Skills.GetSkill(17).SetLevel(51);
				Misc.LocalPlayer.Skills.GetSkill(14).SetLevel(51);
				Misc.LocalPlayer.Skills.GetSkill(7).SetLevel(51);
				Misc.LocalPlayer.Skills.GetSkill(25).SetLevel(51);
				Misc.LocalPlayer.Skills.GetSkill(12).SetLevel(51);
				Misc.LocalPlayer.Skills.GetSkill(42).SetLevel(51);
				Misc.LocalPlayer.Skills.GetSkill(19).SetLevel(51);
				Misc.LocalPlayer.Skills.GetSkill(21).SetLevel(51);
				Misc.LocalPlayer.Skills.GetSkill(8).SetLevel(51);
				Misc.LocalPlayer.Skills.GetSkill(6).SetLevel(51);
				Misc.LocalPlayer.Skills.GetSkill(3).SetLevel(51);
				Misc.LocalPlayer.Skills.GetSkill(34).SetLevel(51);
				Misc.LocalPlayer.Skills.GetSkill(35).SetLevel(51);
				Misc.LocalPlayer.Skills.GetSkill(26).SetLevel(51);
				Misc.LocalPlayer.Skills.GetSkill(10).SetLevel(51);
				Misc.LocalPlayer.Skills.GetSkill(20).SetLevel(51);
				Misc.LocalPlayer.Skills.GetSkill(22).SetLevel(51);
				Misc.LocalPlayer.Skills.GetSkill(29).SetLevel(51);
				Misc.LocalPlayer.Skills.GetSkill(32).SetLevel(51);
				Misc.LocalPlayer.Skills.GetSkill(33).SetLevel(51);
				Misc.LocalPlayer.Skills.GetSkill(36).SetLevel(51);
				Misc.LocalPlayer.Skills.GetSkill(37).SetLevel(51);
				Misc.LocalPlayer.Skills.GetSkill(38).SetLevel(51);
				Misc.LocalPlayer.Skills.GetSkill(40).SetLevel(51);
				Misc.LocalPlayer.Skills.GetSkill(39).SetLevel(51);
				Misc.LocalPlayer.Skills.GetSkill(41).SetLevel(51);
				Misc.LocalPlayer.Skills.GetSkill(44).SetLevel(51);
				Misc.LocalPlayer.Skills.GetSkill(45).SetLevel(51);
				Misc.LocalPlayer.Skills.GetSkill(46).SetLevel(51);
				Misc.LocalPlayer.Skills.GetSkill(47).SetLevel(51);
				Misc.LocalPlayer.Skills.GetSkill(49).SetLevel(51);
				Misc.LocalPlayer.Skills.GetSkill(48).SetLevel(51);
				Misc.LocalPlayer.Skills.GetSkill(50).SetLevel(51);
				Misc.LocalPlayer.Skills.GetSkill(26).SetLevel(51);
			}
			bool thermalvision = Config.Misc.thermalvision;
			if (thermalvision)
			{
				Misc.MainCamera.GetComponent<ThermalVision>().On = true;
			}
			else
			{
				Misc.MainCamera.GetComponent<ThermalVision>().On = false;
			}
			bool nightvision = Config.Misc.nightvision;
			if (nightvision)
			{
				Misc.MainCamera.GetComponent<NightVision>().SetPrivateField("_on", true);
			}
			else
			{
				Misc.MainCamera.GetComponent<NightVision>().SetPrivateField("_on", false);
			}
			bool instanthit = Config.Misc.instanthit;
			if (instanthit)
			{
				Misc.LocalPlayer.Weapon.CurrentAmmoTemplate.InitialSpeed = 10000f;
				Misc.LocalPlayer.Weapon.Template.DefAmmoTemplate.InitialSpeed = 10000f;
			}
			bool clearvision = Config.Misc.clearvision;
			if (clearvision)
			{
				bool clearvision2 = Config.Misc.clearvision;
				if (clearvision2)
				{
					Misc.MainCamera.GetComponent<VisorEffect>().Intensity = 0f;
					Misc.MainCamera.GetComponent<VisorEffect>().enabled = true;
				}
				else
				{
					bool flag11 = !Config.Misc.clearvision;
					if (flag11)
					{
						Misc.MainCamera.GetComponent<VisorEffect>().Intensity = 1f;
						Misc.MainCamera.GetComponent<VisorEffect>().enabled = true;
					}
				}
			}
			bool fullauto = Config.Misc.fullauto;
			if (fullauto)
			{
				Misc.LocalPlayer.Weapon.GetItemComponent<FireModeComponent>().FireMode = 0;
				Misc.LocalPlayer.GetComponent<Player.FirearmController>().Item.Template.BoltAction = false;
			}
		}
	}

	// Token: 0x06000047 RID: 71 RVA: 0x00005984 File Offset: 0x00003B84
	private void OnGUI()
	{
		try
		{
			this.guishit();
			Event current = Event.current;
			bool flag = current.isKey || current.isMouse;
			if (flag)
			{
				bool flag2 = Main.binds;
				if (flag2)
				{
					Main.aimkey = current.keyCode;
					Main.binds = false;
				}
				bool flag3 = Main.binds2;
				if (flag3)
				{
					Main.aimkey1 = current.keyCode;
					Main.binds2 = false;
				}
			}
			bool drawFov = Config.Aimbot.DrawFov;
			if (drawFov)
			{
				Drawing1.DrawCircle(new Vector2((float)(Screen.width / 2), (float)(Screen.height / 2)), Main.distancefromcenter, new Color32(byte.MaxValue, 0, 0, byte.MaxValue), 1f, true, 30);
			}
			bool target = Config.ESP.target;
			if (target)
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
					bool flag4 = !Misc.friendsList.Contains(gamePlayer.Player.Profile.Info.Nickname) && !MonoBehaviourSingleton<PreloaderUI>.Instance.IsBackgroundBlackActive && (float)num2 <= Main.distancefrome && (float)num <= Main.distancefromcenter && Vector3.Dot(Misc.MainCamera.transform.TransformDirection(Vector3.forward), vector2) > 0f;
					if (flag4)
					{
						dictionary.Add(gamePlayer.Player, num);
					}
				}
				bool flag5 = (double)dictionary.Count > 0.01;
				if (flag5)
				{
					dictionary = (from pair in dictionary
					orderby pair.Value
					select pair).ToDictionary((KeyValuePair<Player, int> pair) => pair.Key, (KeyValuePair<Player, int> pair) => pair.Value);
					Player player = dictionary.Keys.First<Player>();
					Vector3 vector3 = Camera.main.WorldToScreenPoint(player.Transform.position);
					int num3 = (int)Vector3.Distance(Misc.MainCamera.transform.position, player.Transform.position);
					Vector3 vector4 = player.PlayerBones.Head.position + new Vector3(0f, 0.07246377f, 0f);
					Vector3 vector5 = Camera.main.WorldToScreenPoint(player.PlayerBones.Head.position);
					Weapon weapon = Misc.LocalPlayer.Weapon;
					bool flag6 = player.Profile.Info.Nickname == "Chasepasetson";
					bool flag7 = player.Profile.Info.Nickname == "HNICOS";
					bool flag8 = (double)vector5.z > 0.01 && weapon != null && !flag6 && !flag7;
					if (flag8)
					{
						Drawing1.DrawLine(new Vector2((float)Screen.width / 2f, (float)Screen.height / 2f), new Vector2(vector5.x, (float)Screen.height - vector5.y), new Color32(byte.MaxValue, 0, 0, byte.MaxValue), 2f, true);
					}
				}
			}
			bool crosshair = Config.Aimbot.Crosshair;
			if (crosshair)
			{
				Drawing1.DrawLine(new Vector2((float)(Screen.width / 2), (float)(Screen.height / 2 - 9)), new Vector2((float)(Screen.width / 2), (float)(Screen.height / 2 + 9)), Main.umcolor, 1f, true);
				Drawing1.DrawLine(new Vector2((float)(Screen.width / 2 - 9), (float)(Screen.height / 2)), new Vector2((float)(Screen.width / 2 + 9), (float)(Screen.height / 2)), Main.umcolor, 1f, true);
			}
			bool flag9 = Config.Aimbot.Aim && Input.GetKey(Main.aimkey);
			if (flag9)
			{
				this.Aim();
			}
		}
		catch
		{
		}
	}

	// Token: 0x06000048 RID: 72 RVA: 0x00005E90 File Offset: 0x00004090
	private void Aim()
	{
		Dictionary<Player, int> dictionary = new Dictionary<Player, int>();
		Vector2 vector;
		vector..ctor((float)Screen.width / 2f, (float)Screen.height / 2f);
		Vector3 vector2 = Vector3.zero;
		foreach (GamePlayer gamePlayer in Misc.GamePlayers)
		{
			int num = (int)Vector2.Distance(Misc.MainCamera.WorldToScreenPoint(gamePlayer.Player.PlayerBones.Head.position), vector);
			int num2 = (int)Vector3.Distance(Misc.LocalPlayer.Transform.position, gamePlayer.Player.Transform.position);
			Vector3 vector3 = gamePlayer.Player.Transform.position - Misc.MainCamera.transform.position;
			bool flag = !Misc.friendsList.Contains(gamePlayer.Player.Profile.Info.Nickname) && !MonoBehaviourSingleton<PreloaderUI>.Instance.IsBackgroundBlackActive && (float)num2 <= Main.distancefrome && (float)num <= Main.distancefromcenter && Vector3.Dot(Misc.MainCamera.transform.TransformDirection(Vector3.forward), vector3) > 0f;
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
			Player player = dictionary.Keys.First<Player>();
			Vector3 vector4 = Camera.main.WorldToScreenPoint(player.Transform.position);
			int num3 = (int)Vector3.Distance(Misc.MainCamera.transform.position, player.Transform.position);
			Vector3 vector5 = player.PlayerBones.Head.position + new Vector3(0f, 0.07246377f, 0f);
			Vector3 vector6 = Camera.main.WorldToScreenPoint(player.Transform.position);
			Weapon weapon = Misc.LocalPlayer.Weapon;
			bool flag3 = player.Profile.Info.Nickname == "Chasepasteson";
			bool flag4 = player.Profile.Info.Nickname == "HNICOS";
			bool flag5 = (double)vector6.z > 0.01 && weapon != null && !flag3 && !flag4;
			if (flag5)
			{
				float num4 = (float)num3;
				float num5 = (float)num3 / Misc.LocalPlayer.Weapon.CurrentAmmoTemplate.InitialSpeed;
				vector5.x += player.Velocity.x * num5;
				vector5.y += player.Velocity.y * num5;
				vector2 = vector5;
				Rendering.DrawString1(new Vector2(vector4.x, (float)Screen.height - vector4.y - -20f), string.Format("{0}", "Target"), new Color32(byte.MaxValue, 0, 0, byte.MaxValue), true, 8, FontStyle.Bold, 1);
			}
		}
		bool flag6 = vector2 != Vector3.zero;
		if (flag6)
		{
			Main.AimAtPos(vector2);
		}
	}

	// Token: 0x06000049 RID: 73 RVA: 0x00006264 File Offset: 0x00004464
	public static void AimAtPos(Vector3 pos)
	{
		bool flag = Misc.LocalPlayer.Weapon != null;
		if (flag)
		{
			Vector3 eulerAngles = Quaternion.LookRotation((pos - Misc.LocalPlayer.Fireport.position).normalized).eulerAngles;
			bool flag2 = eulerAngles.x > 180f;
			if (flag2)
			{
				eulerAngles.x -= 360f;
			}
			Misc.LocalPlayer.MovementContext.Rotation = new Vector2(eulerAngles.y, eulerAngles.x);
		}
	}

	// Token: 0x0600004A RID: 74 RVA: 0x000062F4 File Offset: 0x000044F4
	public static Vector3 GetShootPos()
	{
		bool flag = Misc.LocalPlayer == null;
		Vector3 result;
		if (flag)
		{
			result = Vector3.zero;
		}
		else
		{
			Player.FirearmController firearmController = Misc.LocalPlayer.HandsController as Player.FirearmController;
			bool flag2 = firearmController == null;
			if (flag2)
			{
				result = Vector3.zero;
			}
			else
			{
				result = firearmController.Fireport.position + Misc.MainCamera.transform.forward * 1f;
			}
		}
		return result;
	}

	// Token: 0x0600004B RID: 75 RVA: 0x0000636C File Offset: 0x0000456C
	private void guishit()
	{
		bool isActive = Main.IsActive;
		if (isActive)
		{
			GUI.skin = Main.Skin;
			Main.RenderUI();
		}
	}

	// Token: 0x0600004C RID: 76 RVA: 0x00006398 File Offset: 0x00004598
	public void Update()
	{
		bool keyDown = Input.GetKeyDown(127);
		if (keyDown)
		{
			Main.shouldDrawMainMenu = !Main.shouldDrawMainMenu;
		}
		bool keyDown2 = Input.GetKeyDown(279);
		if (keyDown2)
		{
			Main.IsActive = !Main.IsActive;
		}
		try
		{
			this.miscstuff();
		}
		catch
		{
		}
	}

	// Token: 0x0600004D RID: 77 RVA: 0x000063FC File Offset: 0x000045FC
	public static void RenderUI()
	{
		Main.MainWindowRect = GUI.Window(0, Main.MainWindowRect, new GUI.WindowFunction(Main.RenderWindows), "Chase pasta");
		bool flag = Config.ESP.VisualsWindow;
		bool flag2 = flag;
		if (flag2)
		{
			Main.VisualsWindowRect = GUI.Window(1, Main.VisualsWindowRect, new GUI.WindowFunction(Main.RenderWindows), "                 ");
		}
		bool flag3 = Config.Aimbot.AimbotWindow;
		bool flag4 = flag3;
		if (flag4)
		{
			Main.AimbotWindowRect = GUI.Window(2, Main.AimbotWindowRect, new GUI.WindowFunction(Main.RenderWindows), "                 ");
		}
		bool flag5 = Config.Misc.RemovalsWindow;
		bool flag6 = flag5;
		if (flag6)
		{
			Main.RemovalsWindowRect = GUI.Window(3, Main.RemovalsWindowRect, new GUI.WindowFunction(Main.RenderWindows), "                 ");
		}
		bool flag7 = Config.Misc.MiscWindow;
		bool flag8 = flag7;
		if (flag8)
		{
			Main.MiscWindowRect = GUI.Window(4, Main.MiscWindowRect, new GUI.WindowFunction(Main.RenderWindows), "                 ");
		}
		bool distancewindow = Config.ESP.distancewindow;
		bool flag9 = distancewindow;
		if (flag9)
		{
			Main.DistWindowRect = GUI.Window(5, Main.DistWindowRect, new GUI.WindowFunction(Main.RenderWindows), "                 ");
		}
		bool colorwindow = Config.ESP.colorwindow;
		bool flag10 = colorwindow;
		if (flag10)
		{
			Main.ColorWindowRect = GUI.Window(6, Main.ColorWindowRect, new GUI.WindowFunction(Main.RenderWindows), "                 ");
		}
	}

	// Token: 0x0600004E RID: 78 RVA: 0x00006550 File Offset: 0x00004750
	public static void RenderWindows(int windowId)
	{
		switch (windowId)
		{
		case 0:
		{
			GUI.BeginGroup(new Rect(2f, 17f, Main.MainWindowRect.width - 4f, Main.MainWindowRect.height - 15f));
			bool flag = GUI.Button(new Rect(5f, 5f, 100f, 25f), "Aimbot");
			bool flag2 = flag;
			if (flag2)
			{
				Config.ESP.VisualsWindow = !Config.ESP.VisualsWindow;
			}
			bool flag3 = GUI.Button(new Rect(106.7416f, 5f, 100f, 25f), "Player");
			bool flag4 = flag3;
			if (flag4)
			{
				Config.Aimbot.AimbotWindow = !Config.Aimbot.AimbotWindow;
			}
			bool flag5 = GUI.Button(new Rect(209.4832f, 5f, 100f, 25f), "World");
			bool flag6 = flag5;
			if (flag6)
			{
				Config.Misc.RemovalsWindow = !Config.Misc.RemovalsWindow;
			}
			bool flag7 = GUI.Button(new Rect(311.2248f, 5f, 100f, 25f), "Misc");
			bool flag8 = flag7;
			if (flag8)
			{
				Config.Misc.MiscWindow = !Config.Misc.MiscWindow;
			}
			bool flag9 = GUI.Button(new Rect(411.9664f, 5f, 100f, 25f), "Distance");
			bool flag10 = flag9;
			if (flag10)
			{
				Config.ESP.distancewindow = !Config.ESP.distancewindow;
			}
			bool flag11 = GUI.Button(new Rect(513.708f, 5f, 100f, 25f), "Colors");
			bool flag12 = flag11;
			if (flag12)
			{
				Config.ESP.colorwindow = !Config.ESP.colorwindow;
			}
			GUI.EndGroup();
			break;
		}
		case 1:
		{
			GUI.BeginGroup(new Rect(2f, 17f, Main.VisualsWindowRect.width - 4f, Main.VisualsWindowRect.height - 15f));
			Config.Aimbot.Aim = GUI.Toggle(new Rect(5f, 5f, 100f, 25f), Config.Aimbot.Aim, "Aimbot");
			Config.Aimbot.Crosshair = GUI.Toggle(new Rect(5f, 30f, 100f, 25f), Config.Aimbot.Crosshair, "Crosshair");
			Config.Aimbot.DrawFov = GUI.Toggle(new Rect(5f, 55f, 100f, 25f), Config.Aimbot.DrawFov, "DrawFov");
			Config.Misc.silent = GUI.Toggle(new Rect(5f, 80f, 150f, 25f), Config.Misc.silent, "SilentAim");
			GUI.Label(new Rect(5f, 105f, 150f, 25f), "Aimbot FOV: " + Main.distancefromcenter.ToString());
			Main.distancefromcenter = GUI.HorizontalSlider(new Rect(5f, 115f, 150f, 25f), Main.distancefromcenter, 0f, 750f);
			GUI.Label(new Rect(5f, 140f, 200f, 25f), "Aimbot Max Distance: " + Main.distancefrome.ToString());
			Main.distancefrome = GUI.HorizontalSlider(new Rect(5f, 150f, 150f, 25f), Main.distancefrome, 0f, 750f);
			bool flag13 = GUI.Button(new Rect(5f, 175f, 150f, 25f), "Aim key:" + Main.aimkey.ToString().ToLower(), "box");
			if (flag13)
			{
				Main.binds = true;
			}
			GUI.EndGroup();
			break;
		}
		case 2:
			GUI.BeginGroup(new Rect(2f, 17f, Main.AimbotWindowRect.width - 4f, Main.AimbotWindowRect.height - 15f));
			Config.ESP.PlayerEsp = GUI.Toggle(new Rect(5f, 5f, 150f, 25f), Config.ESP.PlayerEsp, "Username + Distance");
			Config.ESP.Box = GUI.Toggle(new Rect(5f, 30f, 150f, 25f), Config.ESP.Box, "Box");
			Config.ESP.HeldWeapon = GUI.Toggle(new Rect(5f, 55f, 150f, 25f), Config.ESP.HeldWeapon, "HeldWeapon");
			Config.ESP.Skeleton = GUI.Toggle(new Rect(5f, 80f, 150f, 25f), Config.ESP.Skeleton, "Skeleton");
			Config.ESP.chams = GUI.Toggle(new Rect(5f, 105f, 150f, 25f), Config.ESP.chams, "Chams");
			Config.ESP.health = GUI.Toggle(new Rect(5f, 130f, 150f, 25f), Config.ESP.health, "HealthBar");
			Config.ESP.Scav = GUI.Toggle(new Rect(5f, 155f, 150f, 25f), Config.ESP.Scav, "Scav");
			Config.ESP.scavskeleton = GUI.Toggle(new Rect(5f, 180f, 150f, 25f), Config.ESP.scavskeleton, "ScavSkeleton");
			Config.ESP.Corpse = GUI.Toggle(new Rect(5f, 205f, 150f, 25f), Config.ESP.Corpse, "Corpse");
			Config.ESP.weaponammo = GUI.Toggle(new Rect(5f, 230f, 150f, 25f), Config.ESP.weaponammo, "EnemyWeaponInfo");
			Config.ESP.localinfo = GUI.Toggle(new Rect(5f, 255f, 150f, 25f), Config.ESP.localinfo, "LocalWeaponInfo");
			Config.ESP.drawfriend = GUI.Toggle(new Rect(5f, 280f, 150f, 25f), Config.ESP.drawfriend, "DrawFriends");
			Config.ESP.target = GUI.Toggle(new Rect(5f, 305f, 150f, 25f), Config.ESP.target, "Target Snapline");
			GUI.Label(new Rect(5f, 330f, 150f, 25f), "SkeletonThickness: " + Main.skeletonthickkkk.ToString());
			Main.skeletonthickkkk = GUI.HorizontalSlider(new Rect(5f, 340f, 150f, 25f), Main.skeletonthickkkk, 0f, 4f);
			GUI.Label(new Rect(5f, 365f, 150f, 25f), "AddFriends[F6]");
			GUI.EndGroup();
			break;
		case 3:
			GUI.BeginGroup(new Rect(2f, 17f, Main.RemovalsWindowRect.width - 4f, Main.RemovalsWindowRect.height - 15f));
			Config.ESP.ItemEsp.SuperRare = GUI.Toggle(new Rect(5f, 5f, 150f, 25f), Config.ESP.ItemEsp.SuperRare, "SuperRareItems");
			Config.ESP.ItemEsp.extraction = GUI.Toggle(new Rect(5f, 30f, 150f, 25f), Config.ESP.ItemEsp.extraction, "Extraction");
			Config.ESP.ItemEsp.container = GUI.Toggle(new Rect(5f, 55f, 150f, 25f), Config.ESP.ItemEsp.container, "Containers");
			Config.ESP.containercontents = GUI.Toggle(new Rect(5f, 80f, 150f, 25f), Config.ESP.containercontents, "ContainerContents");
			Config.ESP.ItemEsp.Quest = GUI.Toggle(new Rect(5f, 105f, 150f, 25f), Config.ESP.ItemEsp.Quest, "QuestItems");
			Config.ESP.grenade = GUI.Toggle(new Rect(5f, 130f, 150f, 25f), Config.ESP.grenade, "Grenades");
			GUI.EndGroup();
			break;
		case 4:
			GUI.BeginGroup(new Rect(2f, 17f, Main.MiscWindowRect.width - 4f, Main.MiscWindowRect.height - 15f));
			Config.Misc.norecoil = GUI.Toggle(new Rect(5f, 5f, 150f, 25f), Config.Misc.norecoil, "NoRecoil");
			Config.Misc.nospread = GUI.Toggle(new Rect(5f, 30f, 150f, 25f), Config.Misc.nospread, "NoSpread");
			Config.Misc.SprintDrain = GUI.Toggle(new Rect(5f, 55f, 150f, 25f), Config.Misc.SprintDrain, "UnlimitedSprint");
			Config.Misc.skillhack = GUI.Toggle(new Rect(5f, 80f, 150f, 25f), Config.Misc.skillhack, "Skillhack");
			Config.Misc.speedtest = GUI.Toggle(new Rect(5f, 105f, 150f, 25f), Config.Misc.speedtest, "BulletPenetration");
			Config.Misc.nightvision = GUI.Toggle(new Rect(5f, 130f, 150f, 25f), Config.Misc.nightvision, "NightVision");
			Config.Misc.thermalvision = GUI.Toggle(new Rect(5f, 155f, 150f, 25f), Config.Misc.thermalvision, "ThermalVision");
			Config.Misc.speedhack = GUI.Toggle(new Rect(5f, 180f, 150f, 25f), Config.Misc.speedhack, "Speedhack");
			Config.Misc.clearvision = GUI.Toggle(new Rect(5f, 205f, 150f, 25f), Config.Misc.clearvision, "ClearVision");
			Config.Misc.instanthit = GUI.Toggle(new Rect(5f, 230f, 150f, 25f), Config.Misc.instanthit, "InstantHit");
			Config.Misc.fullauto = GUI.Toggle(new Rect(5f, 255f, 150f, 25f), Config.Misc.fullauto, "FullAuto");
			Config.Misc.alwayssprint = GUI.Toggle(new Rect(5f, 280f, 150f, 25f), Config.Misc.alwayssprint, "AlwaysSprint");
			Config.Misc.doorunlock = GUI.Toggle(new Rect(5f, 305f, 150f, 25f), Config.Misc.doorunlock, "UnlockAllDoors[F4]");
			Config.Misc.sherman = GUI.Toggle(new Rect(5f, 330f, 150f, 25f), Config.Misc.sherman, "UnlockBossCrate[F5]");
			Config.Misc.flyhack = GUI.Toggle(new Rect(5f, 355f, 150f, 25f), Config.Misc.flyhack, "Flyhack[Ctrl]");
			Config.Misc.weight = GUI.Toggle(new Rect(5f, 380f, 150f, 25f), Config.Misc.weight, "RunWhileFat[xaxa]");
			GUI.Label(new Rect(5f, 405f, 150f, 25f), "SpeedValue: " + Misc.speedvalue.ToString());
			Misc.speedvalue = GUI.HorizontalSlider(new Rect(5f, 430f, 150f, 25f), Misc.speedvalue, 0f, 1.1f);
			GUI.DragWindow();
			GUI.EndGroup();
			break;
		case 5:
			GUI.BeginGroup(new Rect(2f, 17f, Main.DistWindowRect.width - 4f, Main.DistWindowRect.height - 15f));
			GUI.Label(new Rect(5f, 5f, 150f, 25f), "PlayerDistance: " + Misc.playerdistance.ToString());
			Misc.playerdistance = GUI.HorizontalSlider(new Rect(5f, 15f, 150f, 25f), Misc.playerdistance, 0f, 750f);
			GUI.Label(new Rect(5f, 40f, 150f, 25f), "ScavDistance: " + Misc.scavdistance.ToString());
			Misc.scavdistance = GUI.HorizontalSlider(new Rect(5f, 50f, 150f, 25f), Misc.scavdistance, 0f, 750f);
			GUI.Label(new Rect(5f, 75f, 150f, 25f), "ItemsDistance: " + Misc.distance.ToString());
			Misc.distance = GUI.HorizontalSlider(new Rect(5f, 85f, 150f, 25f), Misc.distance, 0f, 1500f);
			GUI.Label(new Rect(5f, 110f, 150f, 25f), "ContainerDistance: " + Misc.containerdistance.ToString());
			Misc.containerdistance = GUI.HorizontalSlider(new Rect(5f, 120f, 150f, 25f), Misc.containerdistance, 0f, 750f);
			GUI.Label(new Rect(5f, 145f, 150f, 25f), "QuestItemDistance: " + Misc.questitemdistance.ToString());
			Misc.questitemdistance = GUI.HorizontalSlider(new Rect(5f, 155f, 150f, 25f), Misc.questitemdistance, 0f, 750f);
			GUI.DragWindow();
			GUI.EndGroup();
			break;
		case 6:
		{
			GUI.BeginGroup(new Rect(2f, 17f, Main.ColorWindowRect.width - 4f, Main.ColorWindowRect.height - 15f));
			GUI.Label(new Rect(125f, 85f, 150f, 25f), "PlayerColor");
			bool flag14 = GUI.Button(new Rect(5f, 105f, 100f, 25f), "Blue");
			if (flag14)
			{
				Main.PlayerColor = Color.blue;
			}
			bool flag15 = GUI.Button(new Rect(5f, 135f, 100f, 25f), "Green");
			if (flag15)
			{
				Main.PlayerColor = Color.green;
			}
			bool flag16 = GUI.Button(new Rect(110f, 135f, 100f, 25f), "Cyan");
			if (flag16)
			{
				Main.PlayerColor = Color.cyan;
			}
			bool flag17 = GUI.Button(new Rect(110f, 105f, 100f, 25f), "Yellow");
			if (flag17)
			{
				Main.PlayerColor = Color.yellow;
			}
			bool flag18 = GUI.Button(new Rect(215f, 135f, 100f, 25f), "Gray");
			if (flag18)
			{
				Main.PlayerColor = Color.gray;
			}
			bool flag19 = GUI.Button(new Rect(215f, 105f, 100f, 25f), "White");
			if (flag19)
			{
				Main.PlayerColor = Color.white;
			}
			GUI.Label(new Rect(125f, 160f, 150f, 25f), "ScavColor");
			bool flag20 = GUI.Button(new Rect(5f, 180f, 100f, 25f), "Blue");
			if (flag20)
			{
				Main.scavcolor = Color.blue;
			}
			bool flag21 = GUI.Button(new Rect(5f, 210f, 100f, 25f), "Green");
			if (flag21)
			{
				Main.scavcolor = Color.green;
			}
			bool flag22 = GUI.Button(new Rect(110f, 210f, 100f, 25f), "Cyan");
			if (flag22)
			{
				Main.scavcolor = Color.cyan;
			}
			bool flag23 = GUI.Button(new Rect(110f, 180f, 100f, 25f), "Yellow");
			if (flag23)
			{
				Main.scavcolor = Color.yellow;
			}
			bool flag24 = GUI.Button(new Rect(215f, 210f, 100f, 25f), "Gray");
			if (flag24)
			{
				Main.scavcolor = Color.gray;
			}
			bool flag25 = GUI.Button(new Rect(215f, 180f, 100f, 25f), "White");
			if (flag25)
			{
				Main.scavcolor = Color.white;
			}
			GUI.Label(new Rect(125f, 5f, 150f, 25f), "SuperRareItemColor");
			bool flag26 = GUI.Button(new Rect(5f, 30f, 100f, 25f), "Blue");
			if (flag26)
			{
				Main.superrareitemcolor = Color.blue;
			}
			bool flag27 = GUI.Button(new Rect(5f, 60f, 100f, 25f), "Green");
			if (flag27)
			{
				Main.superrareitemcolor = Color.green;
			}
			bool flag28 = GUI.Button(new Rect(110f, 60f, 100f, 25f), "Cyan");
			if (flag28)
			{
				Main.superrareitemcolor = Color.cyan;
			}
			bool flag29 = GUI.Button(new Rect(110f, 30f, 100f, 25f), "Yellow");
			if (flag29)
			{
				Main.superrareitemcolor = Color.yellow;
			}
			bool flag30 = GUI.Button(new Rect(215f, 60f, 100f, 25f), "Gray");
			if (flag30)
			{
				Main.superrareitemcolor = Color.gray;
			}
			bool flag31 = GUI.Button(new Rect(215f, 30f, 100f, 25f), "White");
			if (flag31)
			{
				Main.superrareitemcolor = Color.white;
			}
			GUI.Label(new Rect(125f, 235f, 150f, 25f), "RareItemColor");
			bool flag32 = GUI.Button(new Rect(5f, 255f, 100f, 25f), "Blue");
			if (flag32)
			{
				Main.superrareitemcolor = Color.blue;
			}
			bool flag33 = GUI.Button(new Rect(5f, 285f, 100f, 25f), "Green");
			if (flag33)
			{
				Main.superrareitemcolor = Color.green;
			}
			bool flag34 = GUI.Button(new Rect(110f, 285f, 100f, 25f), "Cyan");
			if (flag34)
			{
				Main.superrareitemcolor = Color.cyan;
			}
			bool flag35 = GUI.Button(new Rect(110f, 255f, 100f, 25f), "Yellow");
			if (flag35)
			{
				Main.superrareitemcolor = Color.yellow;
			}
			bool flag36 = GUI.Button(new Rect(215f, 285f, 100f, 25f), "Gray");
			if (flag36)
			{
				Main.superrareitemcolor = Color.gray;
			}
			bool flag37 = GUI.Button(new Rect(215f, 255f, 100f, 25f), "White");
			if (flag37)
			{
				Main.superrareitemcolor = Color.white;
			}
			GUI.Label(new Rect(125f, 310f, 150f, 25f), "ContainerColor");
			bool flag38 = GUI.Button(new Rect(5f, 330f, 100f, 25f), "Blue");
			if (flag38)
			{
				Main.containercolor = Color.blue;
			}
			bool flag39 = GUI.Button(new Rect(5f, 360f, 100f, 25f), "Green");
			if (flag39)
			{
				Main.containercolor = Color.green;
			}
			bool flag40 = GUI.Button(new Rect(110f, 360f, 100f, 25f), "Cyan");
			if (flag40)
			{
				Main.containercolor = Color.cyan;
			}
			bool flag41 = GUI.Button(new Rect(110f, 330f, 100f, 25f), "Yellow");
			if (flag41)
			{
				Main.containercolor = Color.yellow;
			}
			bool flag42 = GUI.Button(new Rect(215f, 360f, 100f, 25f), "Gray");
			if (flag42)
			{
				Main.containercolor = Color.gray;
			}
			bool flag43 = GUI.Button(new Rect(215f, 330f, 100f, 25f), "White");
			if (flag43)
			{
				Main.containercolor = Color.white;
			}
			GUI.Label(new Rect(125f, 385f, 150f, 25f), "ExtractionColor");
			bool flag44 = GUI.Button(new Rect(5f, 405f, 100f, 25f), "Blue");
			if (flag44)
			{
				Main.extractioncolor = Color.blue;
			}
			bool flag45 = GUI.Button(new Rect(5f, 435f, 100f, 25f), "Green");
			if (flag45)
			{
				Main.extractioncolor = Color.green;
			}
			bool flag46 = GUI.Button(new Rect(110f, 435f, 100f, 25f), "Cyan");
			if (flag46)
			{
				Main.extractioncolor = Color.cyan;
			}
			bool flag47 = GUI.Button(new Rect(110f, 405f, 100f, 25f), "Yellow");
			if (flag47)
			{
				Main.extractioncolor = Color.yellow;
			}
			bool flag48 = GUI.Button(new Rect(215f, 435f, 100f, 25f), "Gray");
			if (flag48)
			{
				Main.extractioncolor = Color.gray;
			}
			bool flag49 = GUI.Button(new Rect(215f, 405f, 100f, 25f), "White");
			if (flag49)
			{
				Main.extractioncolor = Color.white;
			}
			GUI.Label(new Rect(125f, 460f, 150f, 25f), "QuestItemColor");
			bool flag50 = GUI.Button(new Rect(5f, 480f, 100f, 25f), "Blue");
			if (flag50)
			{
				Main.questitemcolor = Color.blue;
			}
			bool flag51 = GUI.Button(new Rect(5f, 510f, 100f, 25f), "Green");
			if (flag51)
			{
				Main.questitemcolor = Color.green;
			}
			bool flag52 = GUI.Button(new Rect(110f, 510f, 100f, 25f), "Cyan");
			if (flag52)
			{
				Main.questitemcolor = Color.cyan;
			}
			bool flag53 = GUI.Button(new Rect(110f, 480f, 100f, 25f), "Yellow");
			if (flag53)
			{
				Main.questitemcolor = Color.yellow;
			}
			bool flag54 = GUI.Button(new Rect(215f, 510f, 100f, 25f), "Gray");
			if (flag54)
			{
				Main.questitemcolor = Color.gray;
			}
			bool flag55 = GUI.Button(new Rect(215f, 480f, 100f, 25f), "White");
			if (flag55)
			{
				Main.questitemcolor = Color.white;
			}
			GUI.DragWindow();
			GUI.EndGroup();
			break;
		}
		}
		GUI.DragWindow();
	}

	// Token: 0x0400001B RID: 27
	public static bool shouldDrawMainMenu = false;

	// Token: 0x0400001C RID: 28
	public static bool IsActive = true;

	// Token: 0x0400001D RID: 29
	public const int mainWindow = 0;

	// Token: 0x0400001E RID: 30
	public const int visualsWindow = 1;

	// Token: 0x0400001F RID: 31
	public const int aimbotWindow = 2;

	// Token: 0x04000020 RID: 32
	public const int removalsWindow = 3;

	// Token: 0x04000021 RID: 33
	public const int miscWindow = 4;

	// Token: 0x04000022 RID: 34
	public static Rect MainWindowRect = new Rect(5f, 5f, 625f, 60f);

	// Token: 0x04000023 RID: 35
	public static Rect VisualsWindowRect = new Rect(5f, 100f, 250f, 330f);

	// Token: 0x04000024 RID: 36
	public static Rect AimbotWindowRect = new Rect(255f, 100f, 250f, 450f);

	// Token: 0x04000025 RID: 37
	public static Rect RemovalsWindowRect = new Rect(505f, 100f, 270f, 185f);

	// Token: 0x04000026 RID: 38
	public static Rect MiscWindowRect = new Rect(775f, 100f, 230f, 480f);

	// Token: 0x04000027 RID: 39
	public static Rect DistWindowRect = new Rect(1005f, 100f, 250f, 420f);

	// Token: 0x04000028 RID: 40
	public static Rect ColorWindowRect = new Rect(1255f, 100f, 325f, 570f);

	// Token: 0x04000029 RID: 41
	public bool VisualsWindow = false;

	// Token: 0x0400002A RID: 42
	public bool AimbotWindow = false;

	// Token: 0x0400002B RID: 43
	public bool RemovalsWindow = false;

	// Token: 0x0400002C RID: 44
	public bool MiscWindow = false;

	// Token: 0x0400002D RID: 45
	public static FieldInfo _multiMesh = null;

	// Token: 0x0400002E RID: 46
	public static Shader chamShader;

	// Token: 0x0400002F RID: 47
	public static Dictionary<string, Shader> dictShaders = new Dictionary<string, Shader>();

	// Token: 0x04000030 RID: 48
	public static float fuckingnigger;

	// Token: 0x04000031 RID: 49
	public static float fuckingnigger1;

	// Token: 0x04000032 RID: 50
	public static Color32 umcolor = new Color32(byte.MaxValue, 0, 0, byte.MaxValue);

	// Token: 0x04000033 RID: 51
	public static float distancefrome;

	// Token: 0x04000034 RID: 52
	public static float distancefromcenter;

	// Token: 0x04000035 RID: 53
	public static KeyCode key;

	// Token: 0x04000036 RID: 54
	public static Color testing = Color.cyan;

	// Token: 0x04000037 RID: 55
	public static Color PlayerColor = Color.cyan;

	// Token: 0x04000038 RID: 56
	public static Color scavcolor = Color.cyan;

	// Token: 0x04000039 RID: 57
	public static Color superrareitemcolor = Color.green;

	// Token: 0x0400003A RID: 58
	public static Color rareitemcolor = Color.cyan;

	// Token: 0x0400003B RID: 59
	public static Color commonitemcolor = Color.white;

	// Token: 0x0400003C RID: 60
	public static Color questitemcolor = Color.yellow;

	// Token: 0x0400003D RID: 61
	public static Color containercolor = Color.gray;

	// Token: 0x0400003E RID: 62
	public static Color extractioncolor = Color.yellow;

	// Token: 0x0400003F RID: 63
	public static float skeletonthickkkk = 1f;

	// Token: 0x04000040 RID: 64
	public static GUISkin Skin;

	// Token: 0x04000041 RID: 65
	public static DumbHook create_shot_hook;

	// Token: 0x04000042 RID: 66
	public static DumbHook specialhook;

	// Token: 0x04000043 RID: 67
	public static DumbHook testinggggg;

	// Token: 0x04000044 RID: 68
	public static bool not_hooked = true;

	// Token: 0x04000045 RID: 69
	public static bool not_hooked1 = true;

	// Token: 0x04000046 RID: 70
	public static bool not_hooked2 = true;

	// Token: 0x04000047 RID: 71
	public static List<GamePlayer> GamePlayers = new List<GamePlayer>();

	// Token: 0x04000048 RID: 72
	public string url = "https://niggers.host/quantum.assets";

	// Token: 0x04000049 RID: 73
	public bool alreadyDownloaded = false;

	// Token: 0x0400004A RID: 74
	private int ver = 1;

	// Token: 0x0400004B RID: 75
	public static KeyCode aimkey = 304;

	// Token: 0x0400004C RID: 76
	public static KeyCode aimkey1 = 304;

	// Token: 0x0400004D RID: 77
	public static bool binds;

	// Token: 0x0400004E RID: 78
	public static bool binds2;
}
