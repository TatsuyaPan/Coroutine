﻿using System;
using System.Collections;
using System.Collections.Generic;
using System.Text;

namespace Coroutine
{
    class WaitUntil : IEnumerator
    {
        Func<bool> condition;
        public WaitUntil(Func<bool> condition)
        {
            if (null == condition) throw new ArgumentNullException("WaitUntil condition is null");
            this.condition = condition;
        }
        public object Current => null;

        public bool MoveNext()
        {
            return !condition();
        }

        public void Reset()
        {
            
        }
    }
}
