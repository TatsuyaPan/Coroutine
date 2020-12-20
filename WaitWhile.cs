using System;
using System.Collections;
using System.Collections.Generic;
using System.Text;

namespace Coroutine
{
    class WaitWhile : IEnumerator
    {
        Func<bool> condition;
        public WaitWhile(Func<bool> condition)
        {
            if (null == condition) throw new ArgumentNullException("WaitWhile condition is null");
            this.condition = condition;
        }
        public object Current => null;

        public bool MoveNext()
        {
            return condition();
        }

        public void Reset()
        {
        }
    }
}
