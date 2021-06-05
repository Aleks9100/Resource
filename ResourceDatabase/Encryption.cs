using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using BCrypt.Net;

namespace ResourceDatabase
{
    public class Encryption
    {
        public string HasPassword(string text) 
        {
            var hash = BCrypt.Net.BCrypt.EnhancedHashPassword(text,HashType.SHA384,workFactor:12);
            return hash;
        }
        public static bool Verify(string password, string hash) => 
            BCrypt.Net.BCrypt.EnhancedVerify(password, hash);
    }
}
