using System;
using System.Collections;
using System.Collections.Generic;
using System.Text;

namespace Coroutine
{
    class CoroutineEngine
    {
        public CoroutineEngine()
        {
            Debug.Log("CoroutineEngine", "setup");
        }
        List<Coroutine> coroutines = new List<Coroutine>();
        public void Update()
        {
            //Debug.Log("CoroutineEngine", "Update");
        }

        public void CoroutineUpdate()
        {
            for (int i = 0; i < coroutines.Count; i++)
            {
                if (coroutines[i].MoveNext())
                {
                    //Debug.Log("CoroutineEngine", "CoroutineUpdate");
                }
                else
                {
                    Debug.Log("CoroutineEngine", "remove corotine : " + coroutines[i].Name);
                    coroutines.RemoveAt(i);
                    i--;
                }
            }
        }

        public void StartCoroutine(IEnumerator coroutine)
        {
            coroutines.Add(new Coroutine(coroutine));
        }
    }
}
