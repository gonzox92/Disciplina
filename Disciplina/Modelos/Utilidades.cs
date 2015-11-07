using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Security.Cryptography;
using System.IO;

namespace Disciplina.Modelos
{
    static class Utilidades
    {
        public static string encriptarPassword(string password)
        {
            MD5 md5 = MD5.Create();
            ASCIIEncoding encoder = new ASCIIEncoding();
            byte[] combined = encoder.GetBytes(password);
            md5.ComputeHash(combined);
            password = Convert.ToBase64String(md5.Hash);

            return password;
        }
    }
}
