using DataSync;

namespace LabDataCollector.Demo
{
    internal class LabResultDemoData1 : LabDataBase
    {
        public string v1 { get; set; }
        public string v2 { get; set; }

        public LabResultDemoData1(string v1, string v2)
        {
            this.v1 = v1;
            this.v2 = v2;
        }
    }
}