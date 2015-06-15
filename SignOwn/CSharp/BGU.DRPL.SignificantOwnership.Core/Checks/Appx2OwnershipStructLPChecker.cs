using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using BGU.DRPL.SignificantOwnership.Core.Questionnaires;
using BGU.DRPL.SignificantOwnership.Core.Spares.Data;
using BGU.DRPL.SignificantOwnership.Core.Spares.Dict;
using BGU.DRPL.SignificantOwnership.Core.Spares;
using System.Data;

namespace BGU.DRPL.SignificantOwnership.Core.Checks
{
    public class Appx2OwnershipStructLPChecker : IQuestionnaireChecker
    {
        #region field(s)
        public static readonly string DEFAULT_INDENT_STRING = "    ";
        private string _indentString = DEFAULT_INDENT_STRING;
        private decimal _unknownOwnersTolerancePct = 3M;
        private bool _unknownOwnersTolerancePctSet = false;
        private Appx2OwnershipStructLP _questio;
        private Dictionary<GenericPersonID, decimal> _detectedUltimateBeneficiaries;
        private Dictionary<GenericPersonID, Dictionary<BGU.DRPL.SignificantOwnership.Core.Spares.EntityType, decimal>> _ownerAggrByEntityType;
        #endregion


        #region IQuestionnaireChecker members

        public string IndentString
        {
            get { return _indentString; }
            set { _indentString = value; }
        }

        public IQuestionnaire Questionnaire 
        {
            get { if (_questio == null) return null; return (IQuestionnaire)_questio; }
            set
            {
                if (_questio != null)
                    throw new ArgumentException("You can set the questionnaire only once");
                if(!(value is Appx2OwnershipStructLP))
                    throw new ArgumentException("Not supported questionnaire format");
                _questio = (Appx2OwnershipStructLP)value;
            } 
        }

        public decimal UnkownOwnersTolerancePct 
        {
            get { return _unknownOwnersTolerancePct; }
            set
            {
                if (_unknownOwnersTolerancePctSet)
                    throw new ArgumentException("Unknown owners tolerance % can be set only once.");
                _unknownOwnersTolerancePct = value;
                _unknownOwnersTolerancePctSet = true;
            }
        }

        public bool CheckOwnershipCompleteness()
        {
            return false;
        }

        public bool CheckMissingPersons()
        {
            throw new NotImplementedException();
        }

        public bool CheckMissingPersonsLinks()
        {
            throw new NotImplementedException();
        }

        public List<Spares.Data.OwnershipStructure> ListUltimateBeneficiaries()
        {
            List<GenericPersonID> physPersons = QuestionnaireCheckUtils.ExtractPhysicsOnly(_questio.BankExistingCommonImplicitOwners);
            Dictionary<GenericPersonID, TotalOwnershipDetailsInfo> aggrOwners = new Dictionary<GenericPersonID, TotalOwnershipDetailsInfo>();

            //UnWindOwners(_questio.BankRef.LegalPerson.GenericID, _questio.BankExistingCommonImplicitOwners, physPersons, aggrOwners); //todo
            return null; //todo
        }


        #region inner type(s)
        public class UltimateOwnershipStruct
        {
            public GenericPersonID Owner { get; set; }
            public BGU.DRPL.SignificantOwnership.Core.Spares.OwnershipType OwnershipType { get; set; }
            public decimal SharePct { get; set; }
        }
        #endregion

        public List<TotalOwnershipDetailsInfoEx> ListUltimateBeneficiaries(Spares.Data.GenericPersonID forEntity)
        {
            List<TotalOwnershipDetailsInfoEx> rslt = new List<TotalOwnershipDetailsInfoEx>();

            Dictionary<string, TotalOwnershipDetailsInfo> ultimateOwners = new Dictionary<string, TotalOwnershipDetailsInfo>();

            UnWindUltimateOwners(_questio.BankRef.LegalPerson, _questio.BankRef.LegalPerson, _questio.BankExistingCommonImplicitOwners, OwnershipType.Direct, 100M, ultimateOwners);
            TotalOwnershipDetailsInfo grandTotals = new TotalOwnershipDetailsInfo();
            foreach (string key in ultimateOwners.Keys)
            {
                TotalOwnershipDetailsInfo curr = ultimateOwners[key];
                decimal dirPct = curr.DirectOwnership != null ? curr.DirectOwnership.Pct : 0;
                decimal implPct = curr.ImplicitOwnership != null ? curr.ImplicitOwnership.Pct : 0;
                curr.TotalCapitalSharePct = dirPct + implPct;
                string currDispName = key;
                GenericPersonInfo gpi = QuestionnaireCheckUtils.FindPersonByHashID(this._questio.MentionedIdentities, key);
                if (gpi != null)
                    currDispName = gpi.DisplayName;
                rslt.Add(new TotalOwnershipDetailsInfoEx(curr, gpi.ID, currDispName));
                IncrementUltimateOwnershipSingle(grandTotals, OwnershipType.Direct, dirPct);
                IncrementUltimateOwnershipSingle(grandTotals, OwnershipType.Implicit, implPct);
                grandTotals.TotalCapitalSharePct += curr.TotalCapitalSharePct;
            }
            rslt.Add(new TotalOwnershipDetailsInfoEx(grandTotals, GenericPersonID.Empty, "Всього"));
            return rslt;
        }
        #endregion


        public Dictionary<Spares.EntityType, decimal> AggregateBankOwnersByEntityType()
        {
            throw new NotImplementedException();
        }

        public string BuildOwnershipGraph()
        {
            StringBuilder rslt = new StringBuilder();
            UnWindOwnersGraph(_questio.BankRef.LegalPerson, _questio.BankExistingCommonImplicitOwners, 0, rslt);
            return rslt.ToString();
        }

        public string BuildUltimateOwnershipOnlyGraph(bool bWithDisplayNames)
        {
            
            Dictionary<string, TotalOwnershipDetailsInfo> ultimateOwners = new Dictionary<string, TotalOwnershipDetailsInfo>();
            UnWindUltimateOwners(_questio.BankRef.LegalPerson, _questio.BankRef.LegalPerson, _questio.BankExistingCommonImplicitOwners, OwnershipType.Direct, 100M, ultimateOwners);
            StringBuilder rslt = new StringBuilder();
            rslt.AppendLine("Beneficiary\tDirect\tImplicit\tTotal");
            TotalOwnershipDetailsInfo grandTotals = new TotalOwnershipDetailsInfo();
            foreach (string key in ultimateOwners.Keys)
            {
                TotalOwnershipDetailsInfo curr = ultimateOwners[key];
                decimal dirPct = curr.DirectOwnership != null ? curr.DirectOwnership.Pct : 0;
                decimal implPct = curr.ImplicitOwnership != null ? curr.ImplicitOwnership.Pct : 0;
                curr.TotalCapitalSharePct = dirPct + implPct;
                string currDispName = key;
                if (bWithDisplayNames)
                {
                    GenericPersonInfo gpi = QuestionnaireCheckUtils.FindPersonByHashID(this._questio.MentionedIdentities, key);
                    if (gpi != null)
                        currDispName = gpi.DisplayName;
                }
                rslt.AppendLine(string.Format("{0}\t{1}\t{2}\t{3}", currDispName, dirPct, implPct, curr.TotalCapitalSharePct));
                IncrementUltimateOwnershipSingle(grandTotals, OwnershipType.Direct, dirPct);
                IncrementUltimateOwnershipSingle(grandTotals, OwnershipType.Implicit, implPct);
                grandTotals.TotalCapitalSharePct += curr.TotalCapitalSharePct;
            }
            rslt.AppendLine("-----------------------------------------------------------------------------------------------------------------------------------------");
            rslt.AppendLine(string.Format("{0}\t{1}\t{2}\t{3}", "Grand totals:", grandTotals.DirectOwnership.Pct, grandTotals.ImplicitOwnership.Pct, grandTotals.TotalCapitalSharePct));
            return rslt.ToString();
        }

        
        private void UnWindUltimateOwners(GenericPersonID ultimateAsset, GenericPersonID currAsset, List<OwnershipStructure> ownershipHaystack, OwnershipType currDirImpl, decimal currPct, Dictionary<string,TotalOwnershipDetailsInfo> target)
        {
            List<OwnershipStructure> directOwners = QuestionnaireCheckUtils.FilterOutDirectOwners(ownershipHaystack, currAsset);
            if(directOwners.Count == 0)
            {
                IncrementUltimateOwnership(target, currAsset,currDirImpl, 100, currPct);
            }
            foreach (OwnershipStructure os in directOwners)
            {
                if(os.Owner.PersonType == Spares.EntityType.Physical)
                {
                    OwnershipType dirImpl = ((currAsset == ultimateAsset) ? OwnershipType.Direct : OwnershipType.Implicit );
                    IncrementUltimateOwnership(target, os.Owner, dirImpl, os.SharePct, currPct);
                }
                if (os.Owner.PersonType == Spares.EntityType.Legal)
                    UnWindUltimateOwners(ultimateAsset, os.Owner, ownershipHaystack, OwnershipType.Implicit, 100*((currPct / 100)* (os.SharePct / 100)) , target);
            }
        }

        private void IncrementUltimateOwnership(Dictionary<string, TotalOwnershipDetailsInfo> target, GenericPersonID genericPersonID, OwnershipType dirImpl, decimal sharePct, decimal currPct)
        {
            if (!target.ContainsKey(genericPersonID.HashID))
                target.Add(genericPersonID.HashID, new TotalOwnershipDetailsInfo());
            TotalOwnershipDetailsInfo todi = target[genericPersonID.HashID];
            decimal correctedPct = 100 * ((sharePct / 100) * (currPct / 100));
            IncrementUltimateOwnershipSingle(todi, dirImpl, correctedPct);
        }

        private void IncrementUltimateOwnershipSingle(TotalOwnershipDetailsInfo todi, OwnershipType dirImpl, decimal correctedPct)
        {
            switch (dirImpl)
            {
                case OwnershipType.None:
                    throw new ArgumentException("A not supported ownership type for this particular purpose.");

                case OwnershipType.Direct:
                    {
                        if (todi.DirectOwnership == null)
                        {
                            todi.DirectOwnership = new OwnershipSummaryInfo();
                            todi.DirectOwnership.Pct = correctedPct;
                        }
                        else
                            todi.DirectOwnership.Pct += correctedPct;
                    }
                    break;
                case OwnershipType.Implicit:
                case OwnershipType.Associated:
                case OwnershipType.Agreement:
                case OwnershipType.Attorney:
                default:
                    {
                        if (todi.ImplicitOwnership == null)
                        {
                            todi.ImplicitOwnership = new OwnershipSummaryInfo();
                            todi.ImplicitOwnership.Pct = correctedPct;
                        }
                        else
                            todi.ImplicitOwnership.Pct += correctedPct;
                    }
                    break;
            }
        }

        private void UnWindOwnersGraph(GenericPersonID forAsset, List<OwnershipStructure> ownershipHaystack, int lvl, StringBuilder rslt)
        {
            foreach (OwnershipStructure os in ownershipHaystack)
            {
                if (os.Asset != forAsset)
                    continue;
                PrintOwnershipLine(os, lvl, rslt);
                if (os.Owner.PersonType == Spares.EntityType.Legal)
                    UnWindOwnersGraph(os.Owner, ownershipHaystack, lvl + 1, rslt);
            }
        }

        private void PrintOwnershipLine(OwnershipStructure os, int lvl, StringBuilder rslt)
        {
            StringBuilder sb = new StringBuilder();
            if(lvl>0)
            {
                for(int i = 0; i < lvl; i++)
                    sb.Append(_indentString);
            }
            GenericPersonInfo gpi = QuestionnaireCheckUtils.FindPersonByID(this._questio.MentionedIdentities, os.Owner);
            string ownerTxt = gpi != null ? (gpi.PersonType == Spares.EntityType.Legal ? gpi.LegalPerson.Name : gpi.PhysicalPerson.FullName) : os.Owner.HashID;
            sb.AppendFormat("{0}, {1}", ownerTxt, os.OwnershipKind);
            if(os.Share > 0)
                sb.AppendFormat(", {0}", os.Share);
            if(os.SharePct > 0)
                sb.AppendFormat(", {0}%", os.SharePct);
            if(os.Votes > 0)
                sb.AppendFormat(", {0} votes", os.Votes);
            rslt.AppendLine(sb.ToString());
        }
    }
}
