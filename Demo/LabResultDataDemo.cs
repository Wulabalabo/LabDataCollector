using System.Collections;
using UnityEngine;


namespace LabDataCollector.Demo
{
    public class LabResultDataDemo : MonoBehaviour
    {

        void Start()
        {
            StartCoroutine(DataCollectTest());
        }

        IEnumerator DataCollectTest()
        {
            yield return new WaitForSeconds(1f);
            DataCollector.Instance.SendData(new LabResultDemoData1("testResultTest04", "testResultTest03"));
        }


    }
}

