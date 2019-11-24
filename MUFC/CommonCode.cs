using System;
using System.Collections.Generic;
using System.Text;
//MD5
using System.Security.Cryptography;

namespace CommonCode
{
    class MD5Hash
    {
       
        static string GetMd5Hash(MD5 md5Hash, string input)
        {

           
            byte[] data = md5Hash.ComputeHash(Encoding.Default.GetBytes(input));

          
            StringBuilder sBuilder = new StringBuilder();

            
            for (int i = 0; i < data.Length; i++)
            {
                sBuilder.Append(data[i].ToString("x2"));
            }

            // Return the hexadecimal string.
            return sBuilder.ToString();
        }

        // Verify a hash against a string.
        public static bool VerifyMd5Hash(MD5 md5Hash, string input, string hash)
        {
            // Hash the input.
            string hashOfInput = GetMd5Hash(md5Hash, input);

            // Create a StringComparer an compare the hashes.
            StringComparer comparer = StringComparer.OrdinalIgnoreCase;
            

            if (0 == comparer.Compare(hashOfInput, hash))
            {
                return true;
            }
            else
            {
                return false;
            }
        }

    }
}