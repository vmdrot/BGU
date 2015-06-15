using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using BGU.DRPL.SignificantOwnership.Core.Spares.Data;
using BGU.DRPL.SignificantOwnership.Core.Spares;
using BGU.DRPL.SignificantOwnership.Core.Misc;

namespace BGU.DRPL.SignificantOwnership.Core.Checks
{
    public class QuestionnaireCheckUtils
    {
        public static List<GenericPersonID> ExtractPhysicsOnly(List<OwnershipStructure> haystack)
        {
            return ExtractPersons(haystack, EntityType.Physical);
        }

        public static List<GenericPersonID> ExtractLegalsOnly(List<OwnershipStructure> haystack)
        {
            return ExtractPersons(haystack, EntityType.Legal);
        }
        
        public static List<GenericPersonID> ExtractPersons(List<OwnershipStructure> haystack, EntityType filterByType)
        {
            List<GenericPersonID> rslt = new List<GenericPersonID>();
            List<string> hashes = new List<string>();
            foreach (OwnershipStructure o in haystack)
            {
                if (filterByType != EntityType.None)
                {
                    if (((int)o.Owner.PersonType & (int)filterByType) == 0)
                        continue;
                }
                if (hashes.Contains(o.Owner.HashID))
                    continue;
                rslt.Add(o.Owner);
                hashes.Add(o.Owner.HashID);
            }
            return rslt;
        }

        public static GenericPersonInfo FindPersonByID(List<GenericPersonInfo> lst, GenericPersonID id)
        {
            foreach (GenericPersonInfo gpi in lst)
            {
                if (gpi.ID == id)
                    return gpi;
            }

            return null;
        }

        public static GenericPersonInfo FindPersonByHashID(List<GenericPersonInfo> lst, string hashId)
        {
            foreach (GenericPersonInfo gpi in lst)
            {
                if (Utils.AreStringsEqual(gpi.ID.HashID, hashId))
                    return gpi;
            }

            return null;
        }

        public static List<OwnershipStructure> FilterOutDirectOwners(List<OwnershipStructure> ownershipHive, GenericPersonID asset)
        {
            if (asset.PersonType == EntityType.Physical || asset.PersonType == EntityType.None)
                throw new ArgumentException("Owners are supported only for legal entities");
            List<OwnershipStructure> rslt = new List<OwnershipStructure>();
            foreach (OwnershipStructure o in ownershipHive)
            {
                if (o.Asset == asset)
                    rslt.Add(o);
            }
            return rslt;
        }


        public static void FinalizeOwners(GenericPersonID forEntity, Dictionary<string, List<Appx2OwnershipStructLPChecker.UltimateOwnershipStruct>> structs, Dictionary<string, bool> finalizedOwnership)
        {
        }

        public static void FinalizeOwners(List<OwnershipStructure> ownershipHive, GenericPersonID forEntity, Dictionary<string, List<Appx2OwnershipStructLPChecker.UltimateOwnershipStruct>> structs, Dictionary<string, bool> finalizedOwnership)
        {
            List<OwnershipStructure> directOwners = FilterOutDirectOwners(ownershipHive, forEntity);
            foreach (OwnershipStructure o in directOwners)
            {
                if (o.Owner.PersonType == EntityType.Physical)
                    ;//structs.Add
            }
        }
    }
}
