using System;
using System.Numerics;
using Xunit;
using ZPD_Lab_1_5.Alphabets;

namespace ZPD_Lab_1_5.Tests
{
    public class RSACipherTest
    {
        [Theory]
        [InlineData("TOBEKAGAKUNOADAYUUREIHIKOUKIYUKEJIGOKUNOSATASHOUKIWOTAITE")]
        [InlineData("ROUJOUSTUNGUNNODENGEKIGAUTSUGUNSHUUNOKAGEYAIYAITOHITOWAYUKI")]
        public void EncodeDecode_CharArray_OriginalMessageInEnglishAndDecodedMessageShouldMatch(string message)
        {
            RSACipher cipher = new RSACipher(new EnglishAlphabet());

            BigInteger[] encdodedMessage = cipher.Encode(message.ToCharArray());

            char[] decodedMessage = cipher.Decode(encdodedMessage);

            Assert.Equal(message, new string(decodedMessage));
        }

        [Theory]
        [InlineData(new int[] { 100, 65, 23, 14})]
        public void EncodeDecode_IntArray_OriginalMessageInEnglishAndDecodedMessageShouldMatch(int[] message)
        {
            RSACipher cipher = new RSACipher(new EnglishAlphabet());

            int[] encdodedMessage = cipher.Encode(message);

            int[] decodedMessage = cipher.Decode(encdodedMessage);

            Assert.Equal(message, decodedMessage);
        }

        [Theory]
        [InlineData("АБРАМОВ")]
        public void EncodeDecode_CharArray_OriginalMessageInUkrainianAndDecodedMessageShouldMatch(string message)
        {
            RSACipher cipher = new RSACipher(new UkrainianAlphabet());

            BigInteger[] encdodedMessage = cipher.Encode(message.ToCharArray());

            char[] decodedMessage = cipher.Decode(encdodedMessage);

            Assert.Equal(message, new string(decodedMessage));
        }
    }
}
