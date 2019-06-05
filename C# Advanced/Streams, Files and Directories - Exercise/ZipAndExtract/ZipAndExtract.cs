using System.IO;
using System.IO.Compression;

namespace ZipAndExtract
{
    class ZipAndExtract
    {
        static void Main(string[] args)
        {
            var file = "copyMe.png";
            var zipFile = "../myZip.zip";
            using (var item = ZipFile.Open(zipFile, ZipArchiveMode.Create))
            {
                item.CreateEntryFromFile(file, Path.GetFileName(file));
            }
        }
    }
}
