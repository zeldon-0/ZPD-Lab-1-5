using System;
using System.Collections.Generic;
using System.Text;
using Xunit;
using ZPD_Lab_1_5.Alphabets;

namespace ZPD_Lab_1_5.Tests
{
    public class ElGamalCipherTest
    {
        [Theory]
        [InlineData("TOBEKAGAKUNOADAYUUREIHIKOUKIYUKEJIGOKUNOSATASHOUKIWOTAITE")]
        [InlineData("ROUJOUSTUNGUNNODENGEKIGAUTSUGUNSHUUNOKAGEYAIYAITOHITOWAYUKI")]
        public void EncodeDecode_EnglishCharArrayMessage_MessageAndDecodedMessageShouldMatch(string message)
        {
            ElGamalCipher cipher = new ElGamalCipher(37, 13, 16, 18, new EnglishAlphabet());

            int[] encodedMessage = cipher.Encode(message.ToCharArray());
            char[] decodedMessage = cipher.Decode(encodedMessage);


            Assert.Equal(message, new string(decodedMessage));
        }
    }
}
