using System;
using System.Linq;

namespace IECFW.Common.Helper
{
    public static class GenerateRandom
    {
        private static Random random = new Random();
        public static string RandomString(int length)
        {
            const string chars = "ABCÇDEFGĞHIİJKLMNOÖPQRSŞTUÜVYZ";
            return new string(Enumerable.Repeat(chars, length).Select(s => s[random.Next(s.Length)]).ToArray());
        }

        public static string RandomStringWithNumbers(int length)
        {
            const string chars = "ABCÇDEFGĞHIİJKLMNOÖPQRSŞTUÜVYZ0123456789";
            return new string(Enumerable.Repeat(chars, length).Select(s => s[random.Next(s.Length)]).ToArray());
        }
        public static string GenerateNewPassword()
        {
            return RandomStringWithNumbers(6);
        }
    }
}
