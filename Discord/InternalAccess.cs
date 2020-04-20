using System;
using System.Reflection;

// Token: 0x02000004 RID: 4
internal static class InternalAccess
{
	// Token: 0x0600000B RID: 11 RVA: 0x00002578 File Offset: 0x00000778
	internal static object GetPublicField(this object internalobj, string name)
	{
		return internalobj.GetType().GetField(name, BindingFlags.Instance | BindingFlags.Public).GetValue(internalobj);
	}

	// Token: 0x0600000C RID: 12 RVA: 0x000025A0 File Offset: 0x000007A0
	internal static T GetPublicField<T>(this object internalobj, string name)
	{
		return (T)((object)internalobj.GetType().GetField(name, BindingFlags.Instance | BindingFlags.Public).GetValue(internalobj));
	}

	// Token: 0x0600000D RID: 13 RVA: 0x000025CC File Offset: 0x000007CC
	internal static T GetPublicProperty<T>(this object internalobj, string name)
	{
		return (T)((object)internalobj.GetType().GetProperty(name, BindingFlags.Instance | BindingFlags.Public).GetValue(internalobj, null));
	}

	// Token: 0x0600000E RID: 14 RVA: 0x000025F8 File Offset: 0x000007F8
	internal static T GetPublicProperty<T>(this Type type, string name)
	{
		return (T)((object)type.GetProperty(name, BindingFlags.Static | BindingFlags.Public).GetValue(null, null));
	}

	// Token: 0x0600000F RID: 15 RVA: 0x0000261F File Offset: 0x0000081F
	internal static void SetPublicField(this object internalobj, string name, object value)
	{
		internalobj.GetType().GetField(name, BindingFlags.Instance | BindingFlags.Public).SetValue(internalobj, value);
	}

	// Token: 0x06000010 RID: 16 RVA: 0x00002638 File Offset: 0x00000838
	internal static void SetPublicProperty(this object internalobj, string name, object value)
	{
		internalobj.GetType().GetProperty(name, BindingFlags.Instance | BindingFlags.Public).SetValue(internalobj, value, null);
	}

	// Token: 0x06000011 RID: 17 RVA: 0x00002654 File Offset: 0x00000854
	internal static object CallPublicConstructor(this Type type, int constructorindex, params object[] parameters)
	{
		return type.GetConstructors(BindingFlags.Instance | BindingFlags.Public)[constructorindex].Invoke(parameters);
	}

	// Token: 0x06000012 RID: 18 RVA: 0x00002678 File Offset: 0x00000878
	internal static object CallPublicConstructor2(this Type type, params object[] parameters)
	{
		ConstructorInfo constructor = type.GetConstructor(BindingFlags.Instance | BindingFlags.NonPublic, null, new Type[]
		{
			typeof(string)
		}, null);
		return constructor.Invoke(parameters);
	}

	// Token: 0x06000013 RID: 19 RVA: 0x000026B0 File Offset: 0x000008B0
	internal static object CallPublicConstructor3(this Type type, params object[] parameters)
	{
		return Activator.CreateInstance(type, new object[]
		{
			BindingFlags.Instance | BindingFlags.Public,
			null,
			parameters
		});
	}

	// Token: 0x06000014 RID: 20 RVA: 0x000026DC File Offset: 0x000008DC
	internal static object CallPublicMethod(this object internalobj, string name, params object[] parameters)
	{
		return internalobj.GetType().GetMethod(name, BindingFlags.Instance | BindingFlags.Public).Invoke(internalobj, parameters);
	}

	// Token: 0x06000015 RID: 21 RVA: 0x00002704 File Offset: 0x00000904
	internal static object CallPublicMethod(this Type type, string name, params object[] parameters)
	{
		return type.GetMethod(name, BindingFlags.Static | BindingFlags.Public).Invoke(null, parameters);
	}

	// Token: 0x06000016 RID: 22 RVA: 0x00002728 File Offset: 0x00000928
	internal static object CallPublicMethod<T>(this Type type, string name, params object[] parameters)
	{
		return (T)((object)type.GetMethod(name, BindingFlags.Static | BindingFlags.Public).Invoke(null, parameters));
	}
}
