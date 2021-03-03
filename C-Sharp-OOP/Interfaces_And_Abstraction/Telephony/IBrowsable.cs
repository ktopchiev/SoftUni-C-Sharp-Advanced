using System;
using System.Collections.Generic;
using System.Text;

namespace Telephony
{
    public interface IBrowsable
    {
        public void Browsing(string url);

        public bool IsContainDigits(string url);
    }
}
