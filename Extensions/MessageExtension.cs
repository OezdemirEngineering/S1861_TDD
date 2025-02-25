namespace Extensions;

public static class MessageExtensions
{

    public static List<byte> ToMessage(this string message)
    {
        var bytes = message.ToArray().Select(c => (byte)c).ToList().AddCrc();
        return bytes;

    }

}
