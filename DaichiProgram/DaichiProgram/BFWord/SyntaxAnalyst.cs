using DaichiProgram.Def;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace DaichiProgram.BFWord
{
    public class SyntaxAnalyst
    {
        public string AllProgram { set; get; }

        public SyntaxAnalyst(string program)
        {
           this.AllProgram = program;
        }

        /// <summary>
        /// プログラムの構文ミスがないかを判断します。
        /// </summary>
        public void Analyse()
        {
            int index = 0;

            for (int i = 0; i < AllProgram.Length; i++)
            {
                if (AllProgram[i].ToString().Equals( WordDefiniton.DEFINITION_WORD["LOOP_START"]))
                {
                    index++;
                }
                else if (AllProgram[i].ToString().Equals(WordDefiniton.DEFINITION_WORD["LOOP_END"]))
                {
                    index--;
                }

                if (index < 0)
                {
                    throw new Exception();
                }
            }

            if (index != 0)
            {
                throw new Exception();
            }
        }
    }
}
