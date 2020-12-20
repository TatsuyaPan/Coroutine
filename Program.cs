using System;
using System.Collections;
using System.Threading;

namespace Coroutine
{
    class Program
    {
        static void Main(string[] args)
        {
            var engine = new CoroutineEngine();
            engine.StartCoroutine(TestNull());
            engine.StartCoroutine(TestWaitUntil());
            while (true)
            {
                engine.Update();
                engine.CoroutineUpdate();
                Thread.Sleep(33);
            }
        }

        static bool condition = false;
        static IEnumerator TestNull()
        {
            Debug.Log("Test Null", "1");
            yield return null;
            Debug.Log("Test Null", "2");
            yield return TestWaitForSeconds();

        }
        static IEnumerator TestWaitForSeconds()
        {
            Debug.Log("TestWaitForSeconds", "start WaitForSeconds");
            yield return new WaitForSeconds(5);
            condition = true;
            Debug.Log("TestWaitForSeconds", "stop WaitForSeconds");
            yield return 2;
        }

        static IEnumerator TestWaitUntil()
        {
            Debug.Log("TestWaitUntil", "start WaitUntil");
            yield return new WaitUntil(() => condition);
            Debug.Log("TestWaitUntil", "stop WaitUntil");
        }
    }
}
