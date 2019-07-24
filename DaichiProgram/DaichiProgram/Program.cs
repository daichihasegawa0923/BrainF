using DaichiProgram.BFWord;
using System;
using System.Collections.Generic;
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
                new CodeExecuter().ExecuteCode("+++++++++[>++++++++>+++++++++++>+++++<<<-]>.>++.+++++++..+++.>-.------------.<++++++++.--------.+++.------.--------.>+.");
                Console.Read();
            }
            catch
            {

            }
        }
    }
}
