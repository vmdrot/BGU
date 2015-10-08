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

        public object LastDebugInfo { get; private set; }

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

        public static void MergeIdentifiedGroups(List<OwnershipStructure> ownershipsHiveSrc, List<GenericPersonInfo> identitiesHiveSrc, List<OwnershipStructure> groupedOwnerships, List<GenericPersonInfo> groupedMentionedIdentities, List<OwnershipStructure> toBeDelOwnerships)
        {
            if (groupedOwnerships.Count > 0)
            {
                List<int> idxs2Del = new List<int>();
                for (int i = 0; i < ownershipsHiveSrc.Count; i++)
                {
                    OwnershipStructure curr = ownershipsHiveSrc[i];
                    OwnershipStructure found = toBeDelOwnerships.Find(o => o.Owner == curr.Owner && o.Asset == curr.Asset && o.SharePct == curr.SharePct);
                    if (found != null)
                        idxs2Del.Add(i);
                }
                for (int j = idxs2Del.Count - 1; j >= 0; j--)
                    ownershipsHiveSrc.RemoveAt(idxs2Del[j]);
                ownershipsHiveSrc.AddRange(groupedOwnerships);
                identitiesHiveSrc.AddRange(groupedMentionedIdentities);
            }

        }


        public List<TotalOwnershipDetailsInfoEx> ListUltimateBeneficiaries(Spares.Data.GenericPersonID forEntity)
        {
            return ListUltimateBeneficiaries(forEntity, false);
        }
        public List<TotalOwnershipDetailsInfoEx> ListUltimateBeneficiaries(Spares.Data.GenericPersonID forEntity, bool bIdentifyGroups)
        {
            List<TotalOwnershipDetailsInfoEx> rslt = new List<TotalOwnershipDetailsInfoEx>();

            Dictionary<string, TotalOwnershipDetailsInfo> ultimateOwners = new Dictionary<string, TotalOwnershipDetailsInfo>();
            List<OwnershipStructure> ownershipsHive;
            List<GenericPersonInfo> identitiesHive;
            //UnWindUltimateOwners(_questio.BankRef.LegalPerson, _questio.BankRef.LegalPerson, _questio.BankExistingCommonImplicitOwners, OwnershipType.Direct, 100M, ultimateOwners);
            if (bIdentifyGroups)
            {
                ownershipsHive = new List<OwnershipStructure>();
                ownershipsHive.AddRange(_questio.BankExistingCommonImplicitOwners);
                identitiesHive = new List<GenericPersonInfo>();
                identitiesHive.AddRange(_questio.MentionedIdentities);
                List<OwnershipStructure> groupedOwnerships;
                List<OwnershipStructure> toBeDelOwnerships;
                List<GenericPersonInfo> groupedMentionedIdentities;
                IdentifyAssociatedPersonsGroups(ownershipsHive, identitiesHive, out groupedOwnerships, out groupedMentionedIdentities, out toBeDelOwnerships);
                MergeIdentifiedGroups(ownershipsHive, identitiesHive, groupedOwnerships, groupedMentionedIdentities, toBeDelOwnerships);
            }
            else
            {
                ownershipsHive = _questio.BankExistingCommonImplicitOwners;
                identitiesHive = _questio.MentionedIdentities;
            }

            UnWindUltimateOwners(forEntity, forEntity, ownershipsHive, OwnershipType.Direct, 100M, ultimateOwners);
            TotalOwnershipDetailsInfo grandTotals = new TotalOwnershipDetailsInfo();
            foreach (string key in ultimateOwners.Keys)
            {
                TotalOwnershipDetailsInfo curr = ultimateOwners[key];
                decimal dirPct = curr.DirectOwnership != null ? curr.DirectOwnership.Pct : 0;
                decimal implPct = curr.ImplicitOwnership != null ? curr.ImplicitOwnership.Pct : 0;
                curr.TotalCapitalSharePct = dirPct + implPct;
                string currDispName = key;
                GenericPersonInfo gpi = QuestionnaireCheckUtils.FindPersonByHashID(identitiesHive, key);
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

        public void IdentifyAssociatedPersonsGroups(List<OwnershipStructure> ownerships, List<GenericPersonInfo> identities, out List<OwnershipStructure> groupedOwnerships, out List<GenericPersonInfo> groupedMentionedIdentities, out List<OwnershipStructure> insteadOSes)
        {
            #region 0. Init all outs and aux vars
            groupedOwnerships = new List<OwnershipStructure>();
            groupedMentionedIdentities = new List<GenericPersonInfo>();
            insteadOSes = new List<OwnershipStructure>();
            Dictionary<string, GenericPersonID> assets = new Dictionary<string,GenericPersonID>();
            Dictionary<string, GenericPersonID> allHashes2IDs = new Dictionary<string,GenericPersonID>();
            Dictionary<string, GenericPersonID> members2Groups = new Dictionary<string,GenericPersonID>();
            Dictionary<string, GenericPersonInfo> groupGPIs = new Dictionary<string,GenericPersonInfo>();
            Dictionary<GenericPersonID, List<OwnershipStructure>> grouppedOwnerships = new Dictionary<GenericPersonID,List<OwnershipStructure>>();
            Dictionary<string, object> debugInfo = new Dictionary<string, object>();
            #endregion
            #region 1. List assets distinctively
            foreach (OwnershipStructure os in ownerships)
            {
                if (!assets.ContainsKey(os.Asset.HashID))
                    assets.Add(os.Asset.HashID, os.Asset);
            }
            #endregion

            #region 2. Cycle through distinct assets list and detect groups
            foreach (GenericPersonID asset in assets.Values)
            {
                var currControllers = from o in ownerships
                                      where o.Asset == asset && o.SharePct == 100.00M
                                      select o.Owner;
                decimal currTotalPct = ownerships.Where(o => o.Asset == asset).Sum(o => o.SharePct);

                if (currControllers.Count() < 2 && currTotalPct <= 100.00M || (currControllers.Count() == 1 && currControllers.First().PersonType == EntityType.Legal))
                    continue;

                var currCtrlOSes = from o in ownerships
                               where o.Asset == asset && o.SharePct == 100.00M
                               select o;

                var currNonCtrlOSes = from o in ownerships
                                   where o.Asset == asset && o.SharePct < 100.00M
                                   select o;
                if (currControllers.Count() == 1)
                {
                    insteadOSes.AddRange(currNonCtrlOSes);
                }
                if (currNonCtrlOSes.Count() > 0)
                {
                    Console.WriteLine("currNonCtrlOSes.Count() > 0:");
                    foreach (OwnershipStructure os in currNonCtrlOSes)
                        Console.WriteLine(os.ToString());
                    Console.WriteLine("-------------------------------------------------------");
                }

                insteadOSes.AddRange(currCtrlOSes);


                var existingGroups = from m2g in members2Groups
                                     join cc in currControllers on m2g.Key equals cc.HashID
                                     select m2g.Value;
                GenericPersonID currGrp = null;
                if (existingGroups.Count() > 0)
                {
                    currGrp = existingGroups.First();
                    
                    List<string> ctrllerNames = new List<string>();
                    foreach (GenericPersonID ctrller in currControllers)
                    {
                        if (members2Groups.ContainsKey(ctrller.HashID))
                            continue;
                        members2Groups.Add(ctrller.HashID, currGrp);
                        ctrllerNames.Add(identities.Find(gpi => gpi.ID == ctrller).DisplayName);
                    }
                    groupGPIs[currGrp.HashID].LegalPerson.Name = AppendToName(groupGPIs[currGrp.HashID].LegalPerson.Name, ctrllerNames);
                    groupedOwnerships.Add(new OwnershipStructure() {  Asset = asset, Owner = currGrp, SharePct = 100.00M, OwnershipKind = OwnershipType.Direct });
                }
                else
                {
                    GenericPersonInfo gpiGrp = new GenericPersonInfo();
                    var currCtrlNames = from ids in currControllers
                                        join gpis in identities on ids.HashID equals gpis.ID.HashID
                                        select gpis.DisplayName;
                    string grpDispName = AppendToName(string.Empty, currCtrlNames);

                    int currGroupsCnt = groupGPIs.Count;
                    currGroupsCnt++;
                    string grpID = string.Format("TMP_CTRLLR_GROUP_{0}", currGroupsCnt);

                    gpiGrp.PersonType = EntityType.Legal;
                    gpiGrp.LegalPerson = new LegalPersonInfo() { TaxCodeOrHandelsRegNr = grpID, ResidenceCountry = CountryInfo.UKRAINE, Name = grpDispName };
                    groupGPIs.Add(gpiGrp.ID.HashID, gpiGrp);
                    currGrp = gpiGrp.ID;
                    foreach (GenericPersonID ctrller in currControllers)
                    {
                        if (members2Groups.ContainsKey(ctrller.HashID))
                            continue;
                        members2Groups.Add(ctrller.HashID, gpiGrp.ID);
                    }
                    groupedOwnerships.Add(new OwnershipStructure() { Asset = asset, Owner = gpiGrp.ID, SharePct = 100.00M, OwnershipKind = OwnershipType.Direct });
                    groupedMentionedIdentities.Add(gpiGrp);
                }
                if(!grouppedOwnerships.ContainsKey(currGrp))
                    grouppedOwnerships.Add(currGrp, new List<OwnershipStructure>());
                grouppedOwnerships[currGrp].AddRange(currCtrlOSes);
                grouppedOwnerships[currGrp].AddRange(currNonCtrlOSes);
            }
            #endregion

            #region 3. Back-check previous for groups belonging
            foreach (OwnershipStructure os in ownerships)
            {
                if ((members2Groups.ContainsKey(os.Owner.HashID) || members2Groups.ContainsKey(os.Asset.HashID)) && !insteadOSes.Contains(os))
                {
                    GenericPersonID correctedAsset = members2Groups.ContainsKey(os.Asset.HashID) ? members2Groups[os.Asset.HashID] : os.Asset;
                    GenericPersonID correctedOwner = members2Groups.ContainsKey(os.Owner.HashID) ? members2Groups[os.Owner.HashID] : os.Owner;
                    groupedOwnerships.Add(new OwnershipStructure() { Asset = correctedAsset, Owner = correctedOwner, SharePct = os.SharePct, OwnershipKind = OwnershipType.Direct });
                    insteadOSes.Add(os);
                    if (members2Groups.ContainsKey(os.Owner.HashID))
                        grouppedOwnerships[members2Groups[os.Owner.HashID]].Add(os);
                    else
                        grouppedOwnerships[members2Groups[os.Asset.HashID]].Add(os);
                }
            }
            #endregion

            #region debug-related
            debugInfo.Add("assets", (object)assets);
            debugInfo.Add("allHashes2IDs", (object)allHashes2IDs);
            debugInfo.Add("members2Groups", (object)members2Groups);
            debugInfo.Add("groupGPIs", (object)groupGPIs);
            debugInfo.Add("groupedOwnerships", (object)groupedOwnerships);
            debugInfo.Add("groupedMentionedIdentities", (object)groupedMentionedIdentities);
            debugInfo.Add("insteadOSes", (object)insteadOSes);
            debugInfo.Add("grouppedOwnerships", (object)grouppedOwnerships);
            LastDebugInfo = (object)debugInfo;
            #endregion
        }

        private static string AppendToName(string oldName, IEnumerable<string> names)
        {
            StringBuilder rslt = new StringBuilder(oldName);
            if (names != null && names.Count() > 0)
            {
                int i = 0;
                if (string.IsNullOrEmpty(oldName))
                    rslt.Append("Група: ");
                foreach (string name in names)
                {
                    if((i == 0 && !string.IsNullOrEmpty(oldName)) || i > 0)
                        rslt.Append(" + ");
                    rslt.Append(name);
                    i++;
                }
            }
            return rslt.ToString();
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
            if(os.Share!= null && os.Share.Amt > 0)
                sb.AppendFormat(", {0}", os.Share);
            if(os.SharePct > 0)
                sb.AppendFormat(", {0}%", os.SharePct);
            if(os.Votes > 0)
                sb.AppendFormat(", {0} votes", os.Votes);
            rslt.AppendLine(sb.ToString());
        }
    }
}
