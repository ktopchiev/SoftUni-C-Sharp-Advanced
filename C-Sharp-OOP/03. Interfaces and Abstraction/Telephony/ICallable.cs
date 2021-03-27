using System;
using System.Collections.Generic;
using System.Text;

namespace Telephony
{
    public interface ICallable
    {
        public void Dialing(string number);

        public void Calling(string number);

        public bool IsContainLetters(string number);
    }
}
