using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using System.Text;
using System.Security.Cryptography;
using System.Numerics;

namespace EncryptedChatApplication
{
    public class RandomIDGenerator
    {
        public String RandomString { get; set; }

        public String UniqueString { get; set; }

        public String GetRandomString()
        {
            return RandomString;
        }

        public void SetRandomString(String RandomString)
        {
            this.RandomString = RandomString;
        }

        public void SetUniqueString(String UniqueString)
        {
            this.UniqueString = UniqueString;
        }

        public String GetUniqueString()
        {
            GenerateAndSetUniqueString();
            return UniqueString;
        }

        public void GenerateRandomString()
        {
            String RandomAsciiString = "";
            Int64 Loop = 0;
            Int64 RandomNumbers;
            Int64 LoopCount = RandomLoopGenerator();
            StringBuilder stringBuilder = new StringBuilder();
            while (Loop <= LoopCount)
            {
                if (Loop % 3 == 0)
                {
                    RandomNumbers = RandomNumberGenerator(2);
                    stringBuilder.Append((char)RandomNumbers);
                }
                else if (Loop % 2 == 0)
                {
                    RandomNumbers = RandomNumberGenerator(1);
                    stringBuilder.Append((char)RandomNumbers);
                }

                else
                {
                    RandomNumbers = RandomNumberGenerator(3);
                    stringBuilder.Append((char)RandomNumbers);
                }

                Loop += 1;
            }
            RandomAsciiString = stringBuilder.ToString();
            SetRandomString(RandomAsciiString);
        }

        public void GenerateAndSetUniqueString()
        {
            SHA512 MySHA512 = SHA512Managed.Create();
            GenerateRandomString();
            String RandomAsciiString = GetRandomString();
            Byte[] RandomAsciiStringByte;
            Byte[] RandomAsciiUniqueStringByte;
            Int16 Loop = 0;
            StringBuilder stringBuilder = new StringBuilder();
            RandomAsciiStringByte = Encoding.ASCII.GetBytes(RandomAsciiString);
            RandomAsciiUniqueStringByte = MySHA512.ComputeHash(RandomAsciiStringByte);
            while (Loop < RandomAsciiUniqueStringByte.Length)
            {
                if (RandomAsciiUniqueStringByte[Loop] >= 48 && RandomAsciiUniqueStringByte[Loop] <= 57)
                {
                    stringBuilder.Append((char)RandomAsciiUniqueStringByte[Loop]);
                }
                else if (RandomAsciiUniqueStringByte[Loop] >= 65 && RandomAsciiUniqueStringByte[Loop] <= 90)
                {
                    stringBuilder.Append((char)RandomAsciiUniqueStringByte[Loop]);
                }
                else if (RandomAsciiUniqueStringByte[Loop] >= 97 && RandomAsciiUniqueStringByte[Loop] <= 122)
                {
                    stringBuilder.Append((char)RandomAsciiUniqueStringByte[Loop]);
                }
                Loop += 1;
            }
            if (stringBuilder.ToString().CompareTo("") != 0)
            {
                SetUniqueString(stringBuilder.ToString());
            }
        }

        public Int64 RandomNumberGenerator(Int64 Code)
        {
            Random RandomClass = new Random();
            Int64 RandomNumber = 0;
            if (Code == 1)
            {
                RandomNumber = RandomClass.Next(48, 57);
            }
            else if (Code == 2)
            {
                RandomNumber = RandomClass.Next(65, 90);
            }
            else if (Code == 3)
            {
                RandomNumber = RandomClass.Next(97, 122);
            }
            return RandomNumber;
        }

        public Int64 RandomLoopGenerator() 
        {
            Random RandomClass = new Random();
            Int64 RandomNumber = RandomClass.Next(30,150);
            return RandomNumber;
        }
    }
}
