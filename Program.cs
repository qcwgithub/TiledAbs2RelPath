using System;
using System.IO;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace TiledAbs2RelPath
{
    class Program
    {
        static void Pause()
        {
            Console.ReadLine();
        }

        static string Calc(string tmxPath)
        {
            string p = tmxPath;
            string rel = "";
            bool suc = false;
            while (true)
            {
                int i = p.LastIndexOf('/');
                if (i < 0)
                    break;
                p = p.Substring(0, i);
                if (Directory.Exists(p + "/Textures"))
                {
                    suc = true;
                    break;
                }
                rel += "../";
            }
            return suc ? rel : null;
        }

        static void Main(string[] args)
        {
            if (args.Length < 1)
            {
                Console.WriteLine("请指定文件名！");
                Pause();
                return;
            }

            string filePath = args[0];
            filePath = filePath.Replace('\\', '/');
            if (!File.Exists(filePath))
            {
                Console.WriteLine("文件不存在！");
                Pause();
                return;
            }

            string rel2Textures = Calc(filePath);
            if (rel2Textures == null)
            {
                Console.WriteLine("文件向上找不到Textures文件夹！");
                Pause();
                return;
            }

            string text = File.ReadAllText(filePath);
            int startIndex = 0;
            StringBuilder sb = new StringBuilder();
            int replaceCount = 0;
            while (true)
            {
                int i_source = text.IndexOf("source=\"", startIndex);
                if (i_source < 0)
                    break;

                i_source += "source=\"".Length;
                sb.Append(text.Substring(startIndex, i_source - startIndex));

                int i_png = text.IndexOf(".png\"", i_source);
                if (i_png < 0)
                {
                    Console.WriteLine("没找到.png\"");
                    Pause();
                    return;
                }
                i_png += ".png".Length;

                string pngPath = text.Substring(i_source, i_png - i_source);
                string newPngPath;

                int iOfTextures = pngPath.IndexOf("Textures");

                if (iOfTextures == 0)
                {
                    newPngPath = pngPath;
                }
                else if (iOfTextures < 0)
                {
                    Console.WriteLine("png路径不包含Textures");
                    Pause();
                    return;
                }
                else
                {
                    newPngPath = rel2Textures + pngPath.Substring(iOfTextures);
                }
                sb.Append(newPngPath);

                Console.WriteLine(pngPath + " ->");
                Console.WriteLine(newPngPath);
                Console.WriteLine();

                startIndex = i_png;

                replaceCount++;
            }
            sb.Append(text.Substring(startIndex));
            File.WriteAllText(
                Path.Combine(Path.GetDirectoryName(filePath), Path.GetFileNameWithoutExtension(filePath)+"_r.tmx"), 
                sb.ToString());
            Console.WriteLine("替换成功，共替换 " + replaceCount + " 处");
            Pause();
        }
    }
}
