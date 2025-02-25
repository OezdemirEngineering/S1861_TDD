
namespace Extensions.Utils;

using System;
using System.Collections.Generic;
using System.Linq;
using System.Reflection;
using System.Runtime.CompilerServices;

public static class TestHelper
{
    public static void ReplaceExtensionMethod(this MethodInfo originalMethod, MethodInfo newMethod)
    {

        RuntimeHelpers.PrepareMethod(originalMethod.MethodHandle);
        RuntimeHelpers.PrepareMethod(newMethod.MethodHandle);

        unsafe
        {
            if (IntPtr.Size == 8) // 64-bit
            {
                long* inj = (long*)originalMethod.MethodHandle.Value.ToPointer() + 1;
                long* tar = (long*)newMethod.MethodHandle.Value.ToPointer() + 1;
                *inj = *tar;
            }
            else // 32-bit
            {
                int* inj = (int*)originalMethod.MethodHandle.Value.ToPointer() + 2;
                int* tar = (int*)newMethod.MethodHandle.Value.ToPointer() + 2;
                *inj = *tar;
            }
        }
    }
}

