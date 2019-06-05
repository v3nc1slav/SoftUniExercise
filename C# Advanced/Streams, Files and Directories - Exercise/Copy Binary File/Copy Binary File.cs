using System.IO;


namespace Copy_Binary_File
{
    class CopyBinaryFile
    {
        static void Main(string[] args)
        {
            var inputName = "copyMe.png";
            var outputName = "copy-copyMe.png";
            using (var input = new FileStream(inputName,FileMode.Open))
            {
                using (var output = new FileStream(outputName,FileMode.Create))
                {
                    while (true)
                    {
                        var bufer = new byte[5000];
                        var png = input.Read(bufer, 0, bufer.Length);
                        if (png == 0)
                        {
                            return;
                        }
                        output.Write(bufer, 0, png);
                    }
                }
            }
        }
    }
}
