using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Web;
using System.Web.Security;

namespace CNSA216_EBC_project {

    // https://www.codingfusion.com/Post/Query-String-Encrypt-Decrypt-in-asp-net

    public static class SecureID {
        public static string Encrypt(string input) {
            byte[] encryptedBytes;
            string encryptedString;
            encryptedBytes = Encoding.UTF8.GetBytes(input);
            encryptedBytes = MachineKey.Protect(encryptedBytes);
            encryptedString = Convert.ToBase64String(encryptedBytes);
            encryptedString = HttpUtility.UrlEncode(encryptedString);

            return encryptedString;
        }

        public static string Decrypt(string input) {
            byte[] decryptedBytes;
            string decryptedString;

            decryptedBytes = Convert.FromBase64String(input);
            decryptedBytes = MachineKey.Unprotect(decryptedBytes);
            decryptedString = Encoding.UTF8.GetString(decryptedBytes);

            return decryptedString;
        }
    }
}