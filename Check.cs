using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace ASM2Final
{
    public class Check
    {
        public int CheckID(string ID)
        {
            if (ID.StartsWith("GT") || ID.StartsWith("GX"))
            {
                return 0;
            }
            return -1;
        }
        public int CheckGmail(string Gmail)
        {
            string EmailFormat = "@gmail.com";
            if (Gmail.Contains(EmailFormat))
            {
                return 0;
            }
            return -1;
        }
        public bool CheckInputValidation(string input)
        {
            if ((CheckLength(input) == false) || (IsNumber(input) == false))
                return false;
            return true;
        }
        private bool CheckLength(string input)
        {
            if (input.Length != 1)
                return false;
            return true;
        }

        private bool IsNumber(string input)
        {
            foreach (Char c in input)
            {
                if (!Char.IsDigit(c))
                    return false;
            }
            return true;
        }

    }
}
