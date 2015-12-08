﻿using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using BGU.DRPL.SignificantOwnership.Core.Spares.Data;
using BGU.DRPL.SignificantOwnership.Core.Spares;
using BGU.DRPL.SignificantOwnership.Core.Messages.BankInfo;

namespace BGU.DRPL.SignificantOwnership.Core.EKDRBU.Spares
{
    public class BankBranchOperationInfo
    {
        public BankingLicensedActivityInfo LawActivityOrService { get; set; }
        public FinActivitySvcInstrumentType Instrument { get; set; }
        public FinActivitySvcInstrumentActionType Action { get; set; }
        public List<ResidenceType> ResidenceDimensions { get; set; }
        public List<CurrencyType> CCYDimensions { get; set; }
        public List<BankClientType> ClientTypeDimensions { get; set; }
        public List<OperationsLimitInfo> LimitsDimensions { get; set; }
    }
}
