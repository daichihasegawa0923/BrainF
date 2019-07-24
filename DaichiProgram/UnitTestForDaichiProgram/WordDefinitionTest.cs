using System;
using Microsoft.VisualStudio.TestTools.UnitTesting;
using DaichiProgram.Def;

namespace UnitTestForDaichiProgram
{
    [TestClass]
    public class WordDefinitionTest
    {
        [TestMethod]
        public void IsDefinition_正常系_定義されている文字列を引数に渡す()
        {
            Assert.AreEqual( true,WordDefiniton.IsDefinition("."));
        }

        [TestMethod]
        public void IsDefinition_正常系_定義されていない文字列を引数に渡す()
        {
            Assert.AreEqual(false, WordDefiniton.IsDefinition("未定義の文字列"));
        }
    }
}
