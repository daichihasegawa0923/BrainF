using DaichiProgram.Def;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace DaichiProgram.BFWord
{
    public class CodeExecuter
    {
        /// <summary>
        /// ポインター代わりの配列
        /// </summary>
        private int[] _pointer = new int[1];

        /// <summary>
        /// ポインターの現在位置
        /// </summary>
        private int _pointerPosition = 0;

        /// <summary>
        /// 受け取ったコードを実行します。
        /// </summary>
        /// <param name="code">インタプリタ実行するソースコード</param>
        public void ExecuteCode(string code)
        {
            try
            { 
                // 字句解析
                new WordAnalyst().JudgeIsNotError(code);
            }
            catch
            {
                Console.WriteLine("コンパイルエラー：定義されていない文字列が含まれています。");
                Console.Read();
                throw;
            }

            try
            {
                // 構文解析
                new SyntaxAnalyst(code).Analyse();
            }
            catch
            {
                Console.WriteLine("コンパイルエラー：文法エラー");
                Console.Read();
                throw;
            }

            for (int i = 0; i < code.Length; i++)
            {
                if (code[i].ToString().Equals(WordDefiniton.DEFINITION_WORD["PLUS_POINTER"]))
                {
                    PlusMinusPointerValue(1);
                }

                if (code[i].ToString().Equals(WordDefiniton.DEFINITION_WORD["MINUS_POINTER"]))
                {
                    PlusMinusPointerValue(-1);
                }

                if (code[i].ToString().Equals(WordDefiniton.DEFINITION_WORD["GO_POINTER"]))
                {
                    MovePointer(1);
                }

                if (code[i].ToString().Equals(WordDefiniton.DEFINITION_WORD["BACK_POINTER"]))
                {
                    MovePointer(-1);
                }

                if (code[i].ToString().Equals(WordDefiniton.DEFINITION_WORD["PRINT_POINTER"]))
                {
                    OutputPointer();
                }

                if (code[i].ToString().Equals(WordDefiniton.DEFINITION_WORD["LOOP_START"]))
                {
                    if (IsPointerValueZero())
                    {
                        while (!code[i].ToString().Equals(WordDefiniton.DEFINITION_WORD["LOOP_END"]))
                        {
                            i++;
                        }
                    }
                }

                if (code[i].ToString().Equals(WordDefiniton.DEFINITION_WORD["LOOP_END"]))
                {
                    if (!IsPointerValueZero())
                    {
                        while (!code[i].ToString().Equals(WordDefiniton.DEFINITION_WORD["LOOP_START"]))
                        {
                            i--;
                        }
                    }
                }

                if (code[i].ToString().Equals(WordDefiniton.DEFINITION_WORD["INPUT_POINTER"]))
                {
                    var input = Byte.Parse(Console.ReadLine());
                    _pointer[_pointerPosition] = input;
                }
            }
        }
        
        /// <summary>
        /// ポインターを動かします。
        /// </summary>
        /// <param name="movement">ポインターの動き</param>
        private void MovePointer(int movement)
        {
            _pointerPosition += movement;

            if (_pointerPosition > _pointer.Length - 1)
            {
                var newPointer = new int[_pointerPosition + 1];
                Array.Copy(_pointer, newPointer, _pointer.Length);
                _pointer = newPointer;
            }
            else if(_pointerPosition < 0)
            {
                var newPointer = new int[_pointer.Length - _pointerPosition];
                Array.Copy(_pointer, 0, newPointer, 0, _pointer.Length);
                _pointer = newPointer;
                _pointerPosition = 0;
            }
        }

        /// <summary>
        /// ポインターの値から足すか、引きます。
        /// </summary>
        /// <param name="value">ポインターの値に足すか、引く値</param>
        private void PlusMinusPointerValue(int value)
        {
            _pointer[_pointerPosition] += value;
        }

        /// <summary>
        /// 現在のポインターの値を出力する
        /// </summary>
        private void OutputPointer()
        {
            Console.Write((char)_pointer[_pointerPosition]);
        }

        /// <summary>
        /// 現在のポインターが、ゼロであるかどうかを判定する
        /// </summary>
        /// <returns></returns>
        private bool IsPointerValueZero()
        {
            return _pointer[_pointerPosition] == 0;
        }
    }
}
