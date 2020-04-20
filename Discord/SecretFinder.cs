using System;
using System.Reflection;

namespace Discord
{
	// Token: 0x02000010 RID: 16
	public static class SecretFinder
	{
		// Token: 0x0600008B RID: 139 RVA: 0x0000A414 File Offset: 0x00008614
		public static FieldInfo FindSecret<T>(this T classType, string fieldName)
		{
			return typeof(T).GetField(fieldName, BindingFlags.Instance | BindingFlags.Static | BindingFlags.Public | BindingFlags.NonPublic);
		}

		// Token: 0x0600008C RID: 140 RVA: 0x0000A43C File Offset: 0x0000863C
		public static FieldInfo FindFieldInfo<T>(string fieldName)
		{
			return typeof(T).GetField(fieldName, BindingFlags.Instance | BindingFlags.Static | BindingFlags.Public | BindingFlags.NonPublic);
		}

		// Token: 0x0600008D RID: 141 RVA: 0x0000A460 File Offset: 0x00008660
		public static void SetSecret<T>(this FieldInfo target, T value, object targetClass = null)
		{
			target.SetValue(targetClass, value);
		}

		// Token: 0x0600008E RID: 142 RVA: 0x0000A474 File Offset: 0x00008674
		public static T GetSecret<T>(this FieldInfo target, object targetClass = null)
		{
			return (T)((object)target.GetValue(targetClass));
		}

		// Token: 0x0600008F RID: 143 RVA: 0x0000A494 File Offset: 0x00008694
		public static T GetSecret<T>(this object target, string fieldName)
		{
			try
			{
				Type type = target.GetType();
				FieldInfo field = type.GetField(fieldName, BindingFlags.IgnoreCase | BindingFlags.Instance | BindingFlags.Static | BindingFlags.Public | BindingFlags.NonPublic);
				return (T)((object)field.GetValue(target));
			}
			catch
			{
			}
			return default(T);
		}

		// Token: 0x06000090 RID: 144 RVA: 0x0000A4E8 File Offset: 0x000086E8
		public static void SetSecret<T>(this object target, string fieldName, T value)
		{
			target.GetType().GetField(fieldName, BindingFlags.Instance | BindingFlags.Static | BindingFlags.Public | BindingFlags.NonPublic).SetValue(target, value);
		}

		// Token: 0x06000091 RID: 145 RVA: 0x0000A506 File Offset: 0x00008706
		public static void SetSecretProperty(this object target, string propertyName, object[] value)
		{
			target.GetType().GetProperty(propertyName, BindingFlags.Instance | BindingFlags.Static | BindingFlags.Public | BindingFlags.NonPublic).GetSetMethod(false).Invoke(target, value);
		}

		// Token: 0x06000092 RID: 146 RVA: 0x0000A528 File Offset: 0x00008728
		public static T GetSecretProperty<T>(this object target, string propertyName)
		{
			return (T)((object)target.GetType().GetProperty(propertyName, BindingFlags.Instance | BindingFlags.Static | BindingFlags.Public | BindingFlags.NonPublic).GetGetMethod(false).Invoke(target, null));
		}

		// Token: 0x06000093 RID: 147 RVA: 0x0000A55C File Offset: 0x0000875C
		public static retType GetFieldValueToken<retType>(this object classObject, int token)
		{
			return (retType)((object)classObject.GetType().Module.ResolveField(token).GetValue(classObject));
		}
	}
}
