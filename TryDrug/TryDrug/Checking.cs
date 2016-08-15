using System;
using System.IO;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace TryDrug
{
    class Checking
    {
        public static bool CheckFormat(string path)
        {
            bool isNeedFormat = false;
            if (
                string.Equals(Path.GetExtension(path), ".doc") ||
                string.Equals(Path.GetExtension(path), ".docx")||
                string.Equals(Path.GetExtension(path), ".xls")
                )
            {
                isNeedFormat = true;
            }
            return isNeedFormat;
        }
    }
}
