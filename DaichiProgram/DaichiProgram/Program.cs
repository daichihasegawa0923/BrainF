using DaichiProgram.BFWord;
using System;
using System.Collections.Generic;
using System.IO;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace DaichiProgram
{
    class Program
    {
        static void Main(string[] args)
        {
            try
            {
                Console.WriteLine("Brain FXXXのインタプリタです。拡張子、\".brainf\"のファイルを選んでください。");
                var filePath = @Console.ReadLine();

                if(!Path.GetExtension(filePath).Equals(".brainf"))
                {
                    Console.WriteLine("ファイルの形式が違います。");
                    throw new ArgumentException();
                }

                using (StreamReader streamReader = new StreamReader(filePath, Encoding.UTF8))
                {                    
                    new CodeExecuter().ExecuteCode(streamReader.ReadToEnd());
                }

                Console.Read();
            }
            catch(Exception exc)
            {
                Console.WriteLine(exc.StackTrace);
                Console.Read();
            }
        }
    }
}
