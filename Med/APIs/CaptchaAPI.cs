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
            for (int i = 0; i < 6; i++)
                code += random.Next(0, 10).ToString();
            return code;
        }
    }
}
