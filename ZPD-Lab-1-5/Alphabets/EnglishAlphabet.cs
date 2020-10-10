using System;
using System.Collections.Generic;
using System.Text;

namespace ZPD_Lab_1_5.Alphabets
{
    public class EnglishAlphabet : IAlphabet
    {
        private List<char> _symbols;

        public EnglishAlphabet()
        {
            _symbols = new List<char>();

            for (int i = 65; i <= 90; i++)
                _symbols.Add((char)i);
        }

        public char this[int index]
        {
            get
            {
                if (Size < index + 1)
                    return '_';

                return _symbols[index];
            }
        }

        public int this[char symbol]
        {
            get
            {
                return _symbols.IndexOf(symbol);
            }
        }

        public int Size
        {
            get
            {
                return _symbols.Count;
            }
        }
    }
}
