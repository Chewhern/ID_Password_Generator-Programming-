﻿using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using System.Security.Cryptography;
using System.Text;
using Sodium;

namespace SecureRandomByteArrayDataGenerator
{
    public class CryptographicSecureIDGenerator
    {
        public String GenerateUniqueString()
        {
            Byte[] CryptographicSecureData = new Byte[240];
            RNGCryptoServiceProvider rngCsp = new RNGCryptoServiceProvider();
            rngCsp.GetBytes(CryptographicSecureData);
            Byte[] HashedBytes = GenericHash.Hash(CryptographicSecureData, null,64);
            HashedBytes = GenericHash.Hash(HashedBytes, null, 64);
            HashedBytes = GenericHash.Hash(HashedBytes, null, 64);
            HashedBytes = GenericHash.Hash(HashedBytes, null, 64);
            int Loop = 0;
            StringBuilder stringBuilder = new StringBuilder();
            while (Loop < HashedBytes.Length)
            {
                if (HashedBytes[Loop] >= 48 && HashedBytes[Loop] <= 57)
                {
                    stringBuilder.Append((char)HashedBytes[Loop]);
                }
                else if (HashedBytes[Loop] >= 65 && HashedBytes[Loop] <= 90)
                {
                    stringBuilder.Append((char)HashedBytes[Loop]);
                }
                else if (HashedBytes[Loop] >= 97 && HashedBytes[Loop] <= 122)
                {
                    stringBuilder.Append((char)HashedBytes[Loop]);
                }
                Loop += 1;
            }
            if (stringBuilder.ToString().CompareTo("") != 0)
            {
                return stringBuilder.ToString();
            }
            else
            {
                return "";
            }
        }

        public String GenerateMinimumAmountOfUniqueString(int Amount)
        {
            String TestString = GenerateUniqueString();
            while (TestString.Length < Amount)
            {
                TestString += GenerateUniqueString();
            }
            return TestString;
        }
    }
}
