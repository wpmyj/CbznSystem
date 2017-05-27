using System;
using System.Collections.Generic;
using System.Text;
using System.Windows.Forms;

namespace Bll
{
    public class LimitInput
    {
        public static bool InputNumber(char keychar)
        {
            if (keychar >= 48 && keychar <= 57 || keychar == (char)Keys.Back)
                return false;
            return true;
        }

        public static bool InputNumberAndLetter(char keychar)
        {
            if (keychar >= 48 && keychar <= 57 || keychar == (char)Keys.Back || keychar >= 65 && keychar <= 90 || keychar >= 97 && keychar <= 122)
                return false;
            return true;
        }
    }
}
