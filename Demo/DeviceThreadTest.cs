using System;
using System.Collections;
using System.Collections.Generic;
using System.Threading;
using DataSync;
using LabDataCollector;
using UnityEngine;


namespace LabDataCollector.Demo
{
    public class DeviceThreadTest
    {


        public void StartTest()
        {
            Thread t = new Thread(test);
            t.Start();
        }

        private void test()
        {
            Thread.Sleep(1000);
            float _i = 0, _o = 0, _u = 0;
            while (_i < 500)
            {
                _i++;
                _o--;
                _u += 2;
                Thread.Sleep(2);
            }
        }

    }
}

