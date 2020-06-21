using DataSync;
using System;

namespace LabDataCollector
{
    public interface ILabDataManager
    {
         void LabDataCollectInit(Func<string> userId);
         void SendData(LabDataBase data);
         Action<LabDataBase> GetDataAction { get; set; }
         void LabDataDispose();
         bool IsClientRunning { get;  }
    }
}
