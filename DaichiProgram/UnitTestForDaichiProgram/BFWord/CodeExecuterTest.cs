using System;
using DaichiProgram.BFWord;
using Microsoft.VisualStudio.TestTools.UnitTesting;

namespace UnitTestForDaichiProgram.BFWord
{
    [TestClass]
    public class CodeExecuterTest
    {
        [TestMethod]
        public void ExecuteCode_正常系()
        {
            var executer = new CodeExecuter();
            var p = new PrivateObject(executer);
            //現在時点で3回足す
            executer.ExecuteCode("+++");
            var array = (int[])p.GetField("_pointer");
            Assert.AreEqual(3,array[0]);
        }

        [TestMethod]
        public void MovePointer_正常系()
        {
            var executer = new CodeExecuter();
            var p = new PrivateObject(executer);
            var pointerPosition = (int)p.GetField("_pointerPosition");
            var pointerArray = (int[])p.GetField("_pointer");

            //ポインターを動かす
            p.Invoke("MovePointer", new object[] {1});

            pointerPosition = (int)p.GetField("_pointerPosition");
            pointerArray = (int[])p.GetField("_pointer");

            Assert.AreEqual(1, pointerPosition);
            
            pointerPosition = (int)p.GetField("_pointerPosition");
            pointerArray = (int[])p.GetField("_pointer");

            //ポインターを表す配列の数値が変動する
            Assert.AreEqual(2, pointerArray.Length);

            p.Invoke("MovePointer", new object[] { -1});

            pointerPosition = (int)p.GetField("_pointerPosition");
            pointerArray = (int[])p.GetField("_pointer");

            Assert.AreEqual(0, pointerPosition);

            p.Invoke("MovePointer", new object[] { -1});

            pointerPosition = (int)p.GetField("_pointerPosition");
            pointerArray = (int[])p.GetField("_pointer");

            Assert.AreEqual(0, pointerPosition);
            //ポインターを表す配列の数値が変動する
            Assert.AreEqual(3, pointerArray.Length);
        }

        [TestMethod]
        public void PlusMinusPointerValue_正常系()
        {
            var executer = new CodeExecuter();
            var p = new PrivateObject(executer);
            var pointerPosition = (int)p.GetField("_pointerPosition");
            var pointerArray = (int[])p.GetField("_pointer");

            //ポインターの値を変える
            p.Invoke("PlusMinusPointerValue", new object[] { 1 });
            Assert.AreEqual(1, pointerArray[0]);

            p.Invoke("PlusMinusPointerValue", new object[] { -1 });
            Assert.AreEqual(0, pointerArray[0]);
        }

        [TestMethod]
        public void IsPointerValueZero_正常系()
        {
            var executer = new CodeExecuter();
            var p = new PrivateObject(executer);
            
            p.SetField("_pointer",new int[] { 0,1});

            p.SetField("_pointerPosition", 0);
            Assert.AreEqual(true, (bool)p.Invoke("IsPointerValueZero"));
            
            p.SetField("_pointerPosition", 1);
            Assert.AreEqual(false, (bool)p.Invoke("IsPointerValueZero"));
        }
    }
}
