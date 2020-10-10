using System;
using System.Collections.Generic;
using System.Text;
using ZPD_Lab_1_5.Alphabets;
using System.Numerics;

namespace ZPD_Lab_1_5
{
    public class RSACipher
    {
        
        private const int _p = 13;
        private const int _q = 19;
        private const int _e = 59;
       

        private int _n;
        private int _euler;
        private int _d;
        private IAlphabet _alphabet;
        public RSACipher(IAlphabet alphabet)
        {
            _alphabet = alphabet;

            _n = _p * _q;
            _euler = (_p - 1) * (_q - 1);
            _d = _modInverse(_e, _euler);
        }
        public BigInteger[] Encode(char[] message)
        {
            BigInteger[] encodedMessage = new BigInteger[message.Length];
            for (int i = 0; i < message.Length; i++)
            {
                //encodedMessage[i] = (BigInteger) (Math.Pow(message[i], _e) % _n);

                int charValue = _alphabet[message[i]];
                encodedMessage[i] = (int) (BigInteger.Pow(charValue, _e) % _n); 
            }
            return encodedMessage;
        }
        public char[] Decode(BigInteger[] message)
        {
            char[] decodedMessage = new char[message.Length];
            for (int i = 0; i < message.Length; i++)
            {
                //decodedMessage[i] = (char)(BigInteger.Pow(message[i], _d) % _n);


                BigInteger charValue = message[i];
                decodedMessage[i] = _alphabet[(int)(BigInteger.Pow(charValue, _d) % _n) % _alphabet.Size];
            }
            return decodedMessage;
        }



        public int[] Encode(int[] message)
        {
            int[] encodedMessage = new int[message.Length];
            for (int i = 0; i < message.Length; i++)
            {
                encodedMessage[i] = (int) (BigInteger.Pow(message[i], _e) % _n);

            }
            return encodedMessage;
        }
        public int[] Decode(int[] message)
        {
            int[] decodedMessage = new int[message.Length];
            for (int i = 0; i < message.Length; i++)
            {
                decodedMessage[i] = (int) (BigInteger.Pow(message[i], _d) % _n);

            }
            return decodedMessage;
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

    }
}
