using HarmonyLib;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Reflection;
using System.Reflection.Emit;
using System.Text;
using System.Threading.Tasks;

namespace Extensions.Tests;

[HarmonyPatch(typeof(CrcExtension), "AddCrc")]
public class TranspilerPatchExtension
{
    public static IEnumerable<CodeInstruction> Transpiler(IEnumerable<CodeInstruction> instructions)
    {
        var code = new List<CodeInstruction>(instructions);

        for (int i = 0; i < code.Count; i++)
        {
            // search for Add and remove the line 
            if (code[i].opcode == OpCodes.Callvirt && code[i].operand is MethodInfo methodInfo &&
                methodInfo.Name == "Add" && methodInfo.DeclaringType == typeof(List<byte>))
            {
                code[i].opcode = OpCodes.Nop;
                break; 
            }
        }

        return code;
    }
}
