using System;
using System.Collections.Generic;
using System.Text;
using ZPD_Lab_1_5.Alphabets;

namespace ZPD_Lab_1_5
{
    public class ElGamalCipher
    {
        private int _p;
        private int _g;
        private int _x;
        private int _y;
        private int _a;
        private int _ka;
        private int _kb;

        private IAlphabet _alphabet;
        public ElGamalCipher(int p, int x, int ka, int kb, IAlphabet alphabet)
        {
            _p = p;
            _x = x;
            _ka = ka;
            _kb = kb;
            _alphabet = alphabet;
            _calculateInitialRoot();

            _y = (int) Math.Pow(_g, _x) % _p;

            _generateA();
        }

        private void _calculateInitialRoot()
        {
            for (int i = 1; i < _p; i++)
            {
                if (Math.Pow(i, (_p -1)) % _p == 1)
                {
                    _g = i;
                    return;
                }
            }

        }

        public int[] Encode (char[] message)
        {
            int[] encodedValues = new int[message.Length];
            
            for (int i = 0; i < message.Length; i++)
            {
                int charValue = _alphabet[message[i]];
                encodedValues[i] = (int) (Math.Pow(_y, _kb) * charValue) % _p;
            }

            return encodedValues;
        }

        public char[] Decode (int[] message)
        {
            char[] decodedChars = new char[message.Length];

            for (int i = 0; i < message.Length; i++)
            {
                int decodedValue = (int) (message[i] * Math.Pow(_a, _p - 1 - _x)) % _p;
                decodedChars[i] = _alphabet[decodedValue];
            }

            return decodedChars;
        }

        private void _generateA()
        {

            _a = (int) Math.Pow(_g, _ka) % _p;
        }
    }
}
