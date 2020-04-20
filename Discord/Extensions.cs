using System;
using System.Reflection;

namespace Discord
{
	// Token: 0x02000018 RID: 24
	public static class Extensions
	{
		// Token: 0x060000C5 RID: 197 RVA: 0x0000B318 File Offset: 0x00009518
		public static void SetPrivateField(this object obj, string name, object value)
		{
			BindingFlags bindingAttr = BindingFlags.Instance | BindingFlags.NonPublic;
			obj.GetType().GetField(name, bindingAttr).SetValue(obj, value);
		}

		// Token: 0x060000C6 RID: 198 RVA: 0x0000B340 File Offset: 0x00009540
		public static object GetPrivateValue(Type type, object instance, string name)
		{
			BindingFlags bindingAttr = BindingFlags.Instance | BindingFlags.Static | BindingFlags.Public | BindingFlags.NonPublic;
			FieldInfo field = type.GetField(name, bindingAttr);
			bool flag = !(field == null);
			object result;
			if (flag)
			{
				result = field.GetValue(instance);
			}
			else
			{
				result = null;
			}
			return result;
		}

		// Token: 0x060000C7 RID: 199 RVA: 0x0000B378 File Offset: 0x00009578
		public static void CallPrivateMethod<T>(this object obj, string name, object[] parameters)
		{
			BindingFlags bindingAttr = BindingFlags.Instance | BindingFlags.NonPublic;
			typeof(T).GetMethod(name, bindingAttr).Invoke(obj, null);
		}

		// Token: 0x060000C8 RID: 200 RVA: 0x0000B3A4 File Offset: 0x000095A4
		public static void InvokePrivateMethod(this object obj, string name, params object[] param)
		{
			BindingFlags bindingAttr = BindingFlags.Instance | BindingFlags.NonPublic;
			obj.GetType().GetMethod(name, bindingAttr).Invoke(obj, param);
		}
	}
}
