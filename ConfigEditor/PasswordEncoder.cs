using System;
using System.Collections.Generic;
using System.Configuration;
using System.IO;
using System.Linq;
using System.Security.Cryptography;
using System.Text;
using System.Threading.Tasks;

namespace ConfigEditor
{
    class PasswordEncoder
    {
        string mEncryptedPassword = ConfigurationManager.AppSettings["password"];
        string mByteArray = "#%232%$#>s$!@l)UR+as#a0";
        byte[] mInitializationVector = { 0xAB, 0xE0, 0xBE, 0xEF, 0x11, 0x10, 0x19, 0x85 };

        public PasswordEncoder()
        {
        }

        public PasswordEncoder(string inPassword)
        {
            mEncryptedPassword = EncryptWithByteArray(inPassword, mByteArray);
        }

        public string EncryptWithByteArray(string inPassword)
        {
            mEncryptedPassword = EncryptWithByteArray(inPassword, mByteArray);
            return mEncryptedPassword;
        }

        private string EncryptWithByteArray(string inPassword, string inByteArray)
        {
            try
            {
                byte[] tmpKey = new byte[20];
                tmpKey = System.Text.Encoding.UTF8.GetBytes(inByteArray.Substring(0, 8));
                DESCryptoServiceProvider des = new DESCryptoServiceProvider();
                byte[] inputArray = System.Text.Encoding.UTF8.GetBytes(inPassword);
                MemoryStream ms = new MemoryStream();
                CryptoStream cs = new CryptoStream(ms, des.CreateEncryptor(tmpKey, mInitializationVector), CryptoStreamMode.Write);
                cs.Write(inputArray, 0, inputArray.Length);
                cs.FlushFinalBlock();
                return Convert.ToBase64String(ms.ToArray());
            }
            catch (Exception ex)
            {
                throw ex;
            }
        }

        public string DecryptWithByteArray()
        {
            return DecryptWithByteArray(mEncryptedPassword, mByteArray);
        }

        private string DecryptWithByteArray(string strText, string strEncrypt)
        {
            try
            {
                byte[] tmpKey = new byte[20];
                tmpKey = System.Text.Encoding.UTF8.GetBytes(strEncrypt.Substring(0, 8));
                DESCryptoServiceProvider des = new DESCryptoServiceProvider();
                Byte[] inputByteArray = inputByteArray = Convert.FromBase64String(strText);
                MemoryStream ms = new MemoryStream();
                CryptoStream cs = new CryptoStream(ms, des.CreateDecryptor(tmpKey, mInitializationVector), CryptoStreamMode.Write);
                cs.Write(inputByteArray, 0, inputByteArray.Length);
                cs.FlushFinalBlock();
                System.Text.Encoding encoding = System.Text.Encoding.UTF8;
                return encoding.GetString(ms.ToArray());
            }
            catch (Exception ex)
            {
                throw ex;
            }
        }

        public string EncryptedPassword
        {
            get { return mEncryptedPassword; }
            set { mEncryptedPassword = value; }
        }

        public string ByteArray
        {
            get { return mByteArray; }
            set { mByteArray = value; }
        }
    }
}

