using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using BGU.DRPL.SignificantOwnership.Core.EKDRBU.Spares;

namespace BGU.DRPL.SignificantOwnership.EmpiricalData.Examples
{
    public class AlfaBankSamples
    {
        private Dictionary<int, BankBranchOpsFinSvcCompleteInfo> _bankBranchOpsFinServices;
        public Dictionary<int, BankBranchOpsFinSvcCompleteInfo> BankBranchOpsFinServices
        {
            get 
            {
                if (_bankBranchOpsFinServices == null)
                {
                    _bankBranchOpsFinServices = GenerateBankBranchOpsFinServices();
                }
                return _bankBranchOpsFinServices;
            }
        }

        private Dictionary<int, BankBranchOpsFinSvcCompleteInfo> GenerateBankBranchOpsFinServices()
        {
            Dictionary<int, BankBranchOpsFinSvcCompleteInfo> rslt = new Dictionary<int, BankBranchOpsFinSvcCompleteInfo>();
            #region #1
            
            BankBranchOpsFinSvcCompleteInfo bbpfs01 = new BankBranchOpsFinSvcCompleteInfo();
            bbpfs01.AllowedOpsSvcs = new List<BankBranchOperationInfo>();
            bbpfs01.ExceptOpsSvcs = new List<BankBranchOperationInfo>();
            bbpfs01.OptionalOpsSvcs = new List<BankBranchOperationInfo>();

            #region #1.1.
            
            //1. Залучення у вклади (депозити) коштів та банківських металів від необмеженого кола юридичних і фізичних осіб, окрім міжбанківських депозитів, окрім банківських металів з фізичною поставкою.
            BankBranchOperationInfo bbpfs0101 = new BankBranchOperationInfo();
            bbpfs0101.LawActivityOrService = new Core.Spares.Data.BankingLicensedActivityInfo() { BankActivityOrService = Core.Spares.LicensedOperationType.BankingActivity, ActivityType = Core.Spares.BankingActivityType.DepositsTaking };
            bbpfs01.AllowedOpsSvcs.Add(bbpfs0101);
            BankBranchOperationInfo bbpfs0101exc01 = new BankBranchOperationInfo() { LawActivityOrService = bbpfs0101.LawActivityOrService, Instrument = Core.Messages.BankInfo.FinActivitySvcInstrumentType.InterbankDeposit };
            BankBranchOperationInfo bbpfs0101exc02 = new BankBranchOperationInfo() { LawActivityOrService = bbpfs0101.LawActivityOrService, Instrument = Core.Messages.BankInfo.FinActivitySvcInstrumentType.PreciousMetalWithPhysDelivery };
            bbpfs01.ExceptOpsSvcs.Add(bbpfs0101exc01);
            bbpfs01.ExceptOpsSvcs.Add(bbpfs0101exc02);
            #endregion
            
            #region #1.2.

            //2.  Відкриття та ведення поточних (кореспондентських) рахунків клієнтів, у тому числі у банківських металах, в частині відкриття та ведення поточних рахунків клієнтів, у тому числі у банківських металах, окрім зарахування на ці рахунки банківських металів, унесених клієнтами з фізичною поставкою.
            //todo - ???!
            BankBranchOperationInfo bbpfs0102 = new BankBranchOperationInfo();
            bbpfs0102.LawActivityOrService = new Core.Spares.Data.BankingLicensedActivityInfo() { BankActivityOrService = Core.Spares.LicensedOperationType.BankingActivity, ActivityType = Core.Spares.BankingActivityType.DepositsTaking };
            bbpfs01.AllowedOpsSvcs.Add(bbpfs0101);

            BankBranchOperationInfo bbpfs0101exc01 = new BankBranchOperationInfo() { LawActivityOrService = bbpfs0101.LawActivityOrService, Instrument = Core.Messages.BankInfo.FinActivitySvcInstrumentType.InterbankDeposit };
            BankBranchOperationInfo bbpfs0101exc02 = new BankBranchOperationInfo() { LawActivityOrService = bbpfs0101.LawActivityOrService, Instrument = Core.Messages.BankInfo.FinActivitySvcInstrumentType.PreciousMetalWithPhysDelivery };
            bbpfs01.ExceptOpsSvcs.Add(bbpfs0101exc01);
            bbpfs01.ExceptOpsSvcs.Add(bbpfs0101exc02);
            #endregion

            rslt.Add(1, bbpfs01);
            #endregion
            return rslt;
        }
    }
}
