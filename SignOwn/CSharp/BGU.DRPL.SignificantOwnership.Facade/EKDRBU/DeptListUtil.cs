﻿using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Data;
using BGU.DRPL.SignificantOwnership.Core.EKDRBU;
using BGU.DRPL.SignificantOwnership.Core.EKDRBU.Legacy;

namespace BGU.DRPL.SignificantOwnership.Facade.EKDRBU
{
    public class DeptListUtil
    {
        public static void BuildHierarchy(List<DeptListEntry> depts)
        {
            var topBanks = depts.Where(dle => dle.TP == "0");
            var midBranches = depts.Where(dle => dle.TP == "1");
            var lowBranches = depts.Where(dle => dle.TP == "2");
            foreach (DeptListEntry dept in depts)
            {
                dept.HierarchySource = depts;
                switch (dept.TP)
                {
                    case "0":
                        dept.ParentCode = string.Empty;
                        break;
                    case "1": 
                        dept.ParentCode = topBanks.First(dle => dle.NKB == dept.NKB).DEPCODE;
                        {
                            if (topBanks.Any(dle => dle.NKB == dept.NKB))
                                dept.ParentCode = topBanks.First(dle => dle.NKB == dept.NKB).DEPCODE;
                        }
                        break;
                    case "2":
                        {
                            if(midBranches.Any(dle => dle.NKB == dept.NKB && dle.KOB == dept.KOB && dle.NF == dept.NF))
                                dept.ParentCode = midBranches.First(dle => dle.NKB == dept.NKB && dle.KOB == dept.KOB && dle.NF == dept.NF).DEPCODE;
                        }
                        break;
                    case "3": break;
                    case "4": break;
                    case "5": break;
                    case "6": break;
                    case "7": break;
                    default: break;
                }
            }
        }

        public static List<DeptListEntry> BuildHierarchy(List<DeptListEntry> filteredDepts, List<DeptListEntry> allDepts)
        {
            BuildHierarchy(allDepts);
            List<DeptListEntry> toPreserve = new List<DeptListEntry>();
            foreach (DeptListEntry dle in allDepts)
            {
                if (filteredDepts.Any(e => e.DEPCODE == dle.DEPCODE))
                {
                    CheckAddDepListEntry(dle, toPreserve);
                    if (!string.IsNullOrEmpty(dle.ParentCode))
                    {
                        string currParentID = dle.ParentCode;
                        do
                        {
                            DeptListEntry currParent = allDepts.First(e => e.DEPCODE == currParentID);
                            CheckAddDepListEntry(currParent, toPreserve);
                            currParentID = currParent.ParentCode;
                        } while (!string.IsNullOrEmpty(currParentID));
                    }
                }

            }
            foreach (DeptListEntry dle in toPreserve)
            {
                dle.HierarchySource = toPreserve;
            }
            return toPreserve;
        }

        private static void CheckAddDepListEntry(DeptListEntry dle, List<DeptListEntry> target)
        {
            if (!target.Any(e => e.DEPCODE == dle.DEPCODE))
                target.Add(dle);
        }
    }
}
