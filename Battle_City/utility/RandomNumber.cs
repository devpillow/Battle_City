using System;
using System.Collections.Generic;
using System.Linq;
using System.Security.Cryptography;
using System.Text;
using System.Threading.Tasks;

namespace Battle_City.utility
{
    public class RandomNumber
    {
        public int GetRandomNumber(int min, int max)
        {
            using (var rng = new RNGCryptoServiceProvider())
            {
                byte[] randomNumber = new byte[4];
                rng.GetBytes(randomNumber);
                int result = BitConverter.ToInt32(randomNumber, 0);
                return Math.Abs(result % (max - min)) + min; // Ensure it falls within the desired range
            }
        }
    }
}
