using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using BGU.DRPL.SignificantOwnership.Core.Spares.Data;
using BGU.DRPL.SignificantOwnership.Utility;
using BGU.DRPL.SignificantOwnership.Core.Spares;

namespace BGU.DRPL.SignificantOwnership.Facade.EKDRBU.Spares
{
    public class BankingActivityServiceUIInfo
    {
        public BankingLicensedActivityInfo Activity { get; set; }
        public String ActivityDisplayName
        {
            get
            {
                return Activity.ActivityDisplayName;
            }
        }

        public List<string> SubActivities { get; set; }


        private static Dictionary<BankingLicensedActivityInfo, string> _SubActivitiesTypes;

        public static Dictionary<BankingLicensedActivityInfo, string> SubActivitiesTypes
        {
            get
            {
                if (_SubActivitiesTypes == null)
                {
                    _SubActivitiesTypes = new Dictionary<BankingLicensedActivityInfo, string>();
                    _SubActivitiesTypes.Add( new BankingLicensedActivityInfo() { BankActivityOrService = LicensedOperationType.BankingActivity, ActivityType = BankingActivityType.DepositsTaking }, new List<string>(new string[] {})));
                }
                return _SubActivitiesTypes;
            }
        }

        public static List<BankingActivityServiceUIInfo> AllBankActivityServices
        {
            get
            {
                List<EnumType> bkacts = EnumType.GetEnumList(typeof(BankingActivityType));
                List<EnumType> finSvcs = EnumType.GetEnumList(typeof(FinancialServicesType));

            }
        }
    }
}
