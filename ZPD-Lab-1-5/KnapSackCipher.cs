using System;
using System.Collections;
using System.Collections.Generic;
using System.Linq;
using System.Text;

namespace ZPD_Lab_1_5
{
    public class KnapSackCipher
    {
        private int[] _closedKey;
        private int[] _openKey;
        
        private int _n;
        private int _m;
        private int _nInverse;
        public KnapSackCipher(int[] closedKey, int n, int m)
        {

            _closedKey = closedKey;
            if (_gcd(n, m) != 1)
                throw new ArgumentException("n and m must be relatively prime.");
            
            _n = n;
            _m = m;
            _nInverse = _modInverse(_n, _m);

            _calculateOpenKey();
        }

        public int[] Encode(char[] message)
        {
            int[] encodedValues = new int[message.Length];

            for(int i = 0; i < message.Length; i++)
            {
                encodedValues[i] = _encodeChar(message[i]);
            }
            return encodedValues;
        }

        public char[] Decode(int[] message)
        {
            char[] decodedChars = new char[message.Length];
            for (int i = 0; i < message.Length; i++)
            {
                decodedChars[i] = _convertWeightsToChar(message[i]);
            }
            return decodedChars;
        }

        private void _calculateOpenKey()
        {
            _openKey = new int[_closedKey.Length]; 
            for (int i = 0; i < _closedKey.Length; i++)
            {
                _openKey[i] = (_closedKey[i] * _n) % _m;

            }
        }
        private int _encodeChar(char letter)
        {
            BitArray bitArray = new BitArray(new byte[] { (byte)letter });

            int weightSum = 0;
            for (int i = 0; i < 8; i ++)
            {
                if (bitArray.Get( bitArray.Length - 1 - i))
                {
                    weightSum += _openKey[i];
                }
            }
            return weightSum;
        }

        private int _gcd(int a, int b)
        {
            a = Math.Abs(a);
            b = Math.Abs(b);

            for (; ; )
            {
                int remainder = a % b;
                if (remainder == 0) return b;
                a = b;
                b = remainder;
            };
        }

        private int _modInverse(int a, int m)
        {
            a = a % m;

            if (a < 0)
                a = a + m;
            for (int x = 1; x < m; x++)
                if ((a * x) % m == 1)
                    return x;
            return 1;
        }
        private char _convertWeightsToChar(int weights)
        {
            weights = (weights * _nInverse) % _m;

            BitArray charBits = new BitArray(8);


            for (int i = 7; i >=0; i-- )
            {
                if (weights >= _closedKey[i])
                {
                    charBits[7 - i] = true;
                    weights -= _closedKey[i];
                }
            }
            return (char)_getNumericValueFromBits(charBits);
        }

        private int _getNumericValueFromBits(BitArray bits)
        {
            int value = 0;
            for (int i = 0; i < 8; i++)
            {
                if (bits[i])
                {
                    value += (int)Math.Pow(2, i);
                }
            }

            return value;
        }
    }
}
