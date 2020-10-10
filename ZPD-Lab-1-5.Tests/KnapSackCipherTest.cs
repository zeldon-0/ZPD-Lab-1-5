using System;
using System.Text;
using System.Numerics;
using Xunit;
using ZPD_Lab_1_5.Alphabets;

namespace ZPD_Lab_1_5.Tests
{
    public class KnapSackCipherTest
    {

        [Theory]
        [InlineData("Rojou StunGun no Dengeki ga Utsu Gunshuu no Kage Yai Yai To Hito wa Yuki Himitsuri ni Koto wa Naru Kikeyo Monokage de Yoki koto no tame to Sasayaku")]
        [InlineData("Tobe Kagaku no ada Yuurei Hikouki Yuke jigoku no sata shouki wo taite Dare mo shiranu ma ni tobitatsu Ari mo senu sora wo KIMI e Gokuhi Shinri no bagu Yuurei Hikouki Hentai yozora ni saku dai karin Dare mo koe kakete chi ni ochi Ari mo senu machi no KIMI")]
        [InlineData("Meta no kumo tooku yuk(u) choo p(u)ranetarium(u) Hiratai kurono no yume Harashoo to miageta sora kaguwashik(u) Hoshi wo shiryo de umi Saa, iki wo haki Saa, jeneshisu wo Saa, me wo samashi Saa, jeneshisu wo")]
        public void EncodeDecode_StringMessage_MessageShouldMatchWithDecoded(string message)
        {
            char[] messageChars = message.ToCharArray();
            KnapSackCipher cipher = new KnapSackCipher(new int[] { 2, 3, 6, 13, 27, 52, 105, 210 },
                31, 420);

            int[] encodedMessage = cipher.Encode(messageChars);
            char[] decodedMessage = cipher.Decode(encodedMessage);

            Assert.Equal(message, new string(decodedMessage));

        }

    }
}
