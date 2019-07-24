using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using DaichiProgram.Def;

namespace DaichiProgram.BFWord
{
    /// <summary>
    /// 字句解析をするクラス
    /// </summary>
    public class WordAnalyst
    {
        /// <summary>
        /// 字句解析
        /// </summary>
        /// <param name="word">解析する文字列</param>
        public void JudgeIsNotError(string word)
        {
            try
            {
                for (int i = 0; i < word.Length; i++)
                {
                    if (!WordDefiniton.IsDefinition(word[i].ToString()))
                    {
                        throw new Exception();
                    }
                }
            }
            catch(Exception e)
            {
                throw e;
            }
        }
    }
}
