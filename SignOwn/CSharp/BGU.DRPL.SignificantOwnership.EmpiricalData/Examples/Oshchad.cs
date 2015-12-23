using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using BGU.DRPL.SignificantOwnership.Core.EKDRBU;

namespace BGU.DRPL.SignificantOwnership.EmpiricalData.Examples
{
    public class Oshchad
    {
        public DRPL.SignificantOwnership.Core.EKDRBU.StateBankBranchRegistryChangePackageV1 _zhytomyrOblastBulkChanges;

        public DRPL.SignificantOwnership.Core.EKDRBU.StateBankBranchRegistryChangePackageV1 ZhytomyrOblastBulkChanges
        {
            get 
            {
                if (_zhytomyrOblastBulkChanges == null)
                {
                    _zhytomyrOblastBulkChanges = GenerateZhytomyrBulkChange();
                }
                return _zhytomyrOblastBulkChanges;
            }
        }

        private StateBankBranchRegistryChangePackageV1 GenerateZhytomyrBulkChange()
        {
            StateBankBranchRegistryChangePackageV1 rslt = new StateBankBranchRegistryChangePackageV1();
            rslt.BankRef = BGU.DRPL.SignificantOwnership.Core.Spares.Dict.BankInfo.AllUABanks.Find(b => b.MFO == "300465");
            rslt.PackageID = "11/4-16/3031-10895";
            rslt.PackageDate = DateTime.Parse("2015-10-20T00:00:00");
            rslt.OperationsListingSchemes = new List<Core.EKDRBU.Spares.BankBranchOpsSvcsSchemeInfo>();
            #region fill schemes
            
            #endregion
            
            rslt.ChangingBranches = new List<Core.EKDRBU.Spares.StateBankRegistrySingleBranchChangeRecV1>();
            
            #region fill branches
            
            #endregion

            rslt.RequirementsKept = true;
            rslt.RequirementsKeptDetails = "";
            rslt.Attachments = new List<Core.Spares.Data.AttachmentInfo>();
            return rslt;
        }


    }
}
