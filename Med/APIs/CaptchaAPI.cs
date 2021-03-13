using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Med.Models;
using Med.Windows;

namespace Med.APIs
{
    class CaptchaAPI
    {
        CaptchaWindow _captchaWindow;
        public CaptchaAPI(CaptchaWindow captchaWindow)
        {
            _captchaWindow = captchaWindow;
        }
    }
}
