using System.Collections;
using System.Collections.Generic;
using LabDataCollector;
using UnityEngine;

public class DemoLogic : MonoBehaviour
{
    // Start is called before the first frame update
    void Start()
    {
        DataCollector.Instance.LabDataCollectInit(()=>"test");
    }

    void OnDisable()
    {
        DataCollector.Instance.LabDataDispose();
    }

    
}
