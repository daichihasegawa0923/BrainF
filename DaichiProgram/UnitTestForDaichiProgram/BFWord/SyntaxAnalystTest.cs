using System;
using DaichiProgram.BFWord;
using Microsoft.VisualStudio.TestTools.UnitTesting;

namespace UnitTestForDaichiProgram.BFWord
{
    [TestClass]
    public class SyntaxAnalystTest
    {
        [TestMethod]
        public void Analyze_正常系()
        {
            new SyntaxAnalyst("++[+]").Analyse();
        }

        [TestMethod]
        [ExpectedException(typeof(Exception))]
        public void Analyze_異常系()
        {
            new SyntaxAnalyst("][").Analyse();
        }
    }
}
