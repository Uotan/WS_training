using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Med.APIs
{
    class CaptchaAPI
    {
        public string GenerateCode()
        {
            Random random = new Random();
            string code = null;
            for (int i = 0; i < 4; i++)
                code += (char)random.Next(33, 123);
            return code;
        }
    }
}
