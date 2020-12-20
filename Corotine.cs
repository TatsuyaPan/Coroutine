using System;
using System.Collections;
using System.Collections.Generic;
using System.Text;

namespace Coroutine
{
    class Coroutine
    {
        public string Name { get; private set; }
        public Coroutine(IEnumerator enumerator)
        {
            Name = enumerator.GetType().Name;
            enumerators.Push(enumerator);
        }

        public bool IsEnd { get; private set; }

        Stack<IEnumerator> enumerators = new Stack<IEnumerator>();
        public bool MoveNext()
        {
            if (enumerators.Count == 0) return false;
            return MoveNext(enumerators.Peek());
        }

        private bool MoveNext(IEnumerator it)
        {
            if(it.MoveNext())
            {
                if(it.Current is IEnumerator)
                {
                    var next = it.Current as IEnumerator;
                    enumerators.Push(next);
                    MoveNext(next);
                }
                return true;
            }
            else
            {
                enumerators.Pop();
                if (enumerators.Count == 0) return false;
                return false || MoveNext(enumerators.Peek());
            }
        }
    }
}
