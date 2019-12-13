using System.Security.Cryptography;
using System.Text;

namespace ComicEngine.Common {
    public class HashUtilities {

        /// <summary>
        /// Takes an md5hash, and string anc creates a new string out of the new computed hash.
        /// </summary>
        /// <param name="md5Hash"></param>
        /// <param name="input"></param>
        /// <returns></returns>
        public static string GetMd5Hash (MD5 md5Hash, string input) {

            // Convert the input string to a byte array and compute the hash.
            byte[] data = md5Hash.ComputeHash (Encoding.UTF8.GetBytes (input));

            // Create a new Stringbuilder to collect the bytes
            // and create a string.
            StringBuilder sBuilder = new StringBuilder ();

            // Loop through each byte of the hashed data 
            // and format each one as a hexadecimal string.
            for (int i = 0; i < data.Length; i++) {
                sBuilder.Append (data[i].ToString ("x2"));
            }

            // Return the hexadecimal string.
            return sBuilder.ToString ();
        }
    }
}