using System;
using Microsoft.VisualStudio.TestTools.UnitTesting;
using DaichiProgram.BFWord;

namespace UnitTestForDaichiProgram.BFWord
{
    [TestClass]
    public class WordAnalystTest
    {
        [TestMethod]
        public void JudgeIsNotError_正常系()
        {
            new WordAnalyst().JudgeIsNotError(".");
        }

        [TestMethod]
        [ExpectedException(typeof(Exception))]
        public void JudgeIsNotError_異常系_定義されていない文字列()
        {
            new WordAnalyst().JudgeIsNotError("未定義の文字列");
        }
    }
}
