using System;
using System.Reflection;
using System.Runtime.CompilerServices;
using System.Runtime.InteropServices;

namespace Discord
{
	// Token: 0x0200000B RID: 11
	public class DumbHook
	{
		// Token: 0x17000006 RID: 6
		// (get) Token: 0x06000060 RID: 96 RVA: 0x00009742 File Offset: 0x00007942
		// (set) Token: 0x06000061 RID: 97 RVA: 0x0000974A File Offset: 0x0000794A
		public MethodInfo OriginalMethod { get; private set; }

		// Token: 0x17000007 RID: 7
		// (get) Token: 0x06000062 RID: 98 RVA: 0x00009753 File Offset: 0x00007953
		// (set) Token: 0x06000063 RID: 99 RVA: 0x0000975B File Offset: 0x0000795B
		public MethodInfo HookMethod { get; private set; }

		// Token: 0x06000064 RID: 100 RVA: 0x00009764 File Offset: 0x00007964
		public DumbHook()
		{
			this.original = null;
			this.OriginalMethod = (this.HookMethod = null);
		}

		// Token: 0x06000065 RID: 101 RVA: 0x00009792 File Offset: 0x00007992
		public DumbHook(MethodInfo orig, MethodInfo hook)
		{
			this.original = null;
			this.Init(orig, hook);
		}

		// Token: 0x06000066 RID: 102 RVA: 0x000097AC File Offset: 0x000079AC
		public MethodInfo GetMethodByName(Type typeOrig, string nameOrig)
		{
			return typeOrig.GetMethod(nameOrig);
		}

		// Token: 0x06000067 RID: 103 RVA: 0x000097C5 File Offset: 0x000079C5
		public DumbHook(Type typeOrig, string nameOrig, Type typeHook, string nameHook)
		{
			this.original = null;
			this.Init(this.GetMethodByName(typeOrig, nameOrig), this.GetMethodByName(typeHook, nameHook));
		}

		// Token: 0x06000068 RID: 104 RVA: 0x000097F0 File Offset: 0x000079F0
		public void Init(MethodInfo orig, MethodInfo hook)
		{
			bool flag = orig == null || hook == null;
			if (flag)
			{
				throw new ArgumentException("Both original and hook need to be valid methods");
			}
			RuntimeHelpers.PrepareMethod(orig.MethodHandle);
			RuntimeHelpers.PrepareMethod(hook.MethodHandle);
			this.OriginalMethod = orig;
			this.HookMethod = hook;
		}

		// Token: 0x06000069 RID: 105 RVA: 0x00009848 File Offset: 0x00007A48
		public unsafe void Hook()
		{
			bool flag = null == this.OriginalMethod || null == this.HookMethod;
			if (flag)
			{
				throw new ArgumentException("Hook has to be properly Init'd before use");
			}
			bool flag2 = this.original != null;
			if (!flag2)
			{
				IntPtr functionPointer = this.OriginalMethod.MethodHandle.GetFunctionPointer();
				IntPtr functionPointer2 = this.HookMethod.MethodHandle.GetFunctionPointer();
				bool flag3 = IntPtr.Size == 8;
				if (flag3)
				{
					this.original = new byte[12];
					uint newProtect;
					DumbHook.Import.VirtualProtect(functionPointer, 12U, 64U, out newProtect);
					byte* ptr = (byte*)((void*)functionPointer);
					int num = 0;
					while ((long)num < 12L)
					{
						this.original[num] = ptr[num];
						num++;
					}
					*ptr = 72;
					ptr[1] = 184;
					*(IntPtr*)(ptr + 2) = functionPointer2;
					ptr[10] = byte.MaxValue;
					ptr[11] = 224;
					DumbHook.Import.VirtualProtect(functionPointer, 12U, newProtect, out newProtect);
				}
				else
				{
					this.original = new byte[7];
					uint newProtect;
					DumbHook.Import.VirtualProtect(functionPointer, 7U, 64U, out newProtect);
					byte* ptr2 = (byte*)((void*)functionPointer);
					int num2 = 0;
					while ((long)num2 < 7L)
					{
						this.original[num2] = ptr2[num2];
						num2++;
					}
					*ptr2 = 184;
					*(IntPtr*)(ptr2 + 1) = functionPointer2;
					ptr2[5] = byte.MaxValue;
					ptr2[6] = 224;
					DumbHook.Import.VirtualProtect(functionPointer, 7U, newProtect, out newProtect);
				}
			}
		}

		// Token: 0x0600006A RID: 106 RVA: 0x000099D4 File Offset: 0x00007BD4
		public unsafe void Unhook()
		{
			bool flag = this.original == null;
			if (!flag)
			{
				uint num = (uint)this.original.Length;
				IntPtr functionPointer = this.OriginalMethod.MethodHandle.GetFunctionPointer();
				uint num2;
				DumbHook.Import.VirtualProtect(functionPointer, num, 64U, out num2);
				byte* ptr = (byte*)((void*)functionPointer);
				int num3 = 0;
				while ((long)num3 < (long)((ulong)num))
				{
					ptr[num3] = this.original[num3];
					num3++;
				}
				DumbHook.Import.VirtualProtect(functionPointer, num, 64U, out num2);
				this.original = null;
			}
		}

		// Token: 0x04000053 RID: 83
		private const uint HOOK_SIZE_X64 = 12U;

		// Token: 0x04000054 RID: 84
		private const uint HOOK_SIZE_X86 = 7U;

		// Token: 0x04000055 RID: 85
		private byte[] original;

		// Token: 0x02000024 RID: 36
		internal class Import
		{
			// Token: 0x0600011A RID: 282
			[DllImport("kernel32.dll", SetLastError = true)]
			internal static extern bool VirtualProtect(IntPtr address, uint size, uint newProtect, out uint oldProtect);
		}
	}
}
