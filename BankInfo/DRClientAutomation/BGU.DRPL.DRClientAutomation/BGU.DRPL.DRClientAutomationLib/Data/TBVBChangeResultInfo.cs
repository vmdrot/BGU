using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

namespace BGU.DRPL.DRClientAutomationLib.Data
{
    public class TBVBChangeResultInfo
    {
        public TBVBChangeResultInfo()
        {
            this.Succeeded = false;
            this.ErrorsCount = 0;
            this.ErrorsInfo = new List<string>();
        }

        public string BranchID { get; set; }
        public string ParentMFO { get; set; }
        public string BranchName { get; set; }
        public bool Succeeded { get; set; }
        public int ErrorsCount { get; set; }
        public List<string> ErrorsInfo { get; set; }
    }
}
