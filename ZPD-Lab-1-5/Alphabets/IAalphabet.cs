using System;
using System.Collections.Generic;
using System.Text;

namespace ZPD_Lab_1_5.Alphabets
{
    public interface IAlphabet
    {
            char this[int index]
            {
                get;
            }

            int this[char symbol]
            {
                get;
            }

            int Size
            {
                get;
            }

    }
}
