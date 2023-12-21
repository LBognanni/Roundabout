namespace Roundabout;

internal static class ExtractIcon
{
    [DllImport("shell32.dll", CharSet = CharSet.Auto)]
    public static extern uint ExtractIconEx(string lpszFile, int nIconIndex, [Out] IntPtr[] phiconLarge, [Out] IntPtr[] phiconSmall, [In] uint nIcons);

    public static Icon FromExecutable(string fileName)
    {
        var splt = fileName.Split(',');
        int iconId = 0;
        if (splt.Length == 2)
        {
            iconId = int.Parse(splt[1]);
        }

        IntPtr[] phiconLarge = new IntPtr[1];
#pragma warning disable CS8625 // Cannot convert null literal to non-nullable reference type.
        var res = ExtractIconEx(splt[0], iconId, phiconLarge, null, 1);
#pragma warning restore CS8625 // Cannot convert null literal to non-nullable reference type.

        return Icon.FromHandle(phiconLarge[0]);
    }
}
