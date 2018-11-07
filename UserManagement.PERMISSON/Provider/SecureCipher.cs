using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace UserManagement.PERMISSON.Provider
{
    public class SecureCipher
    {
        public String Encrypt(String Password)
        {
            //Admin must change default password to more secure
            String defaultPassword = "abc@123";
            String encrypt = new StringCipher().Encrypt(Password, defaultPassword);
            return encrypt;
        }

        public String Decrypt(String Password)
        {
            //Admin must change default password to more secure
            String defaultPassword = "abc@123";
            String decrypt = new StringCipher().Decrypt(Password, defaultPassword);
            return decrypt;
        }

    }
}
