using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace DaichiProgram.Def
{
    /// <summary>
    /// 定義された最小単位の言語を定義します。
    /// </summary>
    public class WordDefiniton
    {
        /// <summary>
        /// 定義された言葉と、その役割
        /// </summary>
        public static readonly Dictionary<string, string> DEFINITION_WORD = new Dictionary<string, string>()
        {
            {"GO_POINTER",">"},
            {"BACK_POINTER","<"},
            {"PRINT_POINTER","."},
            {"PLUS_POINTER","+"},
            {"MINUS_POINTER","-"},
            {"INPUT_POINTER",","},
            {"LOOP_START","["},
            {"LOOP_END","]"}
        };

        /// <summary>
        /// 指定したワードが指定されているかどうかを返す
        /// </summary>
        /// <param name="word">判定するワード</param>
        /// <returns>ワードが指定されている：true、ワードが指定されていない：false</returns>
        public static bool IsDefinition(string word)
        {
            foreach (KeyValuePair<string,string> wordSet in DEFINITION_WORD)
            {
                if (wordSet.Value.Equals(word))
                {
                    return true;
                }
            }
            return false;
        }
    }
}
