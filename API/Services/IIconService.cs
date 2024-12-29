using System.Text.Json;

interface IIconService
{
    Task<byte[]?> GetIconBytesAsync(string name);
}

public class IconService : IIconService
{
    public async Task<byte[]?> GetIconBytesAsync(string name)
    {
        byte[]? imageArray = null;

        DirectoryInfo info = new DirectoryInfo("./Data/Icons");
        var files = info.GetFiles();

        var targetFile = files.FirstOrDefault(x => x.Name == $"{ name}.png");

        if (targetFile != null)
        {
            using (var fs = targetFile.OpenRead())
            {
                imageArray = new byte[fs.Length];
                await fs.ReadExactlyAsync(imageArray);
            }
        }

        return imageArray;
    }
}
