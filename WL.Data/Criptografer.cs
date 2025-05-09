using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace WL.Data
{
    public static class Criptografer
    {
        public static string DoubleEncode(string initialString)
        {
            var stringOne = ASCIIEncoding.ASCII.GetBytes(initialString);

            var oneConverted = Convert.ToBase64String(stringOne);

            var stringTwo = ASCIIEncoding.ASCII.GetBytes(oneConverted);

            return Convert.ToBase64String(stringTwo);
        }
        public static string DoubleDecode(string initialString)
        {
            var newString = Convert.FromBase64String(initialString);

            var oneDecoded = ASCIIEncoding.ASCII.GetString(newString);

            var twoDecoded = Convert.FromBase64String(oneDecoded);

            return ASCIIEncoding.ASCII.GetString(twoDecoded);
        }
    }
}
