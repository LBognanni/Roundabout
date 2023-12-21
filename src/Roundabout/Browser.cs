namespace Roundabout;

public record Browser (string Name, string Command, string Icon)
{
    public Image? GetImage()
    {
        var icon = ExtractIcon.FromExecutable(Icon);
        return icon?.ToBitmap();
    }
}
