using Extensions.Utils;
using HarmonyLib;
using System.Reflection;

namespace Extensions.Tests;


public class MessageExtensionsTests
{

    [Fact]
    public void ToMessage_String_ExpectedByteArray()
    {
        //arrange
        var originalMethod = typeof(CrcExtension).GetMethod("AddCrc", BindingFlags.Static | BindingFlags.Public);
        var fakeMethod = typeof(FakeExtensions).GetMethod("AddCrc", BindingFlags.Static | BindingFlags.Public);

        originalMethod.ReplaceExtensionMethod(fakeMethod);


        var bytes = "0000".ToMessage();
    }

    [Fact]
    public void ToMessage_StringWithPrefixPatch_ExpectedByteArray()
    {
        // Arrange
        var harmony = new Harmony("com.test.mockcrc");

        var original = typeof(CrcExtension).GetMethod(nameof(CrcExtension.AddCrc));

        var patch = typeof(PrefixPatchedExtensions).GetMethod(nameof(PrefixPatchedExtensions.Prefix));

        harmony.Patch(original, prefix: new HarmonyMethod(patch));

        string testMessage = "0000";
        var expectedBytes = testMessage.Select(c => (byte)c).ToList(); // Original-Daten ohne CRC

        // Act
        var result = testMessage.ToMessage();

        // Assert
        Assert.NotNull(result);
        Assert.Equal(expectedBytes, result);
    }

    [Fact]
    public void ToMessage_StringWithTranspilerChange_ExpectedByteArray()
    {
        // Arrange
        var harmony = new Harmony("com.test.mockcrc");
        var original = typeof(CrcExtension).GetMethod(nameof(CrcExtension.AddCrc));
        var transpiler = typeof(TranspilerPatchExtension).GetMethod(nameof(TranspilerPatchExtension.Transpiler));

        // Wende den Transpiler-Patch an
        harmony.Patch(original, transpiler: new HarmonyMethod(transpiler));

        string testMessage = "0000";
        var expectedBytes = testMessage.Select(c => (byte)c).ToList(); // Original-Daten ohne CRC

        // Act
        var result = testMessage.ToMessage();

        // Assert
        Assert.NotNull(result);
        Assert.Equal(expectedBytes, result);
    }


}
