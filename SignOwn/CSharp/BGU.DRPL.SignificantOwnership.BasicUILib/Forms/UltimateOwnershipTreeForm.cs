using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Windows.Forms;
using BGU.DRPL.SignificantOwnership.Core.Spares.Data;
using BGU.DRPL.SignificantOwnership.Core.Spares;
using BGU.DRPL.SignificantOwnership.Core.Checks;
using BGU.DRPL.SignificantOwnership.Core.Questionnaires;

namespace BGU.DRPL.SignificantOwnership.BasicUILib.Forms
{
    public partial class UltimateOwnershipTreeForm : Form
    {
        public UltimateOwnershipTreeForm()
        {
            InitializeComponent();
            DirectOrReverseBinding = true;
        }

        private List<OwnershipStructure> _dataSource;

        public List<GenericPersonInfo> MentionedEntities { get; set; }
        public GenericPersonID CentralAssetID { get; set; }

        private bool DirectOrReverseBinding { get; set; }

        public List<OwnershipStructure> DataSource
        {
            get
            {
                return _dataSource;
            }
            set
            {
                _dataSource = value;
                ReBindTree();
            }
        }

        public Appx2OwnershipStructLP Questionnaire
        {
            get;
            set;
        }

        private void ReBindTree()
        {
            if (DirectOrReverseBinding)
                ReBindTree_Direct();
            else
                ReBindTree_Reverse();
        }

        private void ReBindTree_Direct()
        {
            if (CentralAssetID == null || MentionedEntities == null || _dataSource == null || _dataSource.Count == 0)
                return;
            treeView.Nodes.Clear();
            TreeNode rootNode = FormatNode(CentralAssetID, 100, string.Empty);
            treeView.Nodes.Add(rootNode);
            UnWindOwnersGraph(CentralAssetID, _dataSource, treeView, rootNode, 100M);
        }


        private void ReBindTree_Reverse()
        {
            if (CentralAssetID == null || MentionedEntities == null || _dataSource == null || _dataSource.Count == 0)
                return;
            treeView.Nodes.Clear();
            Appx2OwnershipStructLPChecker checker = new Appx2OwnershipStructLPChecker();
            checker.Questionnaire = Questionnaire;
            List<TotalOwnershipDetailsInfoEx> ultimateOwners = checker.ListUltimateBeneficiaries(CentralAssetID);
            ultimateOwners.Sort((o1, o2) => o2.TotalCapitalSharePct.CompareTo(o1.TotalCapitalSharePct));
            TreeNode rootNode = FormatNode(ultimateOwners[0].OwnerID, ultimateOwners[0].TotalCapitalSharePct, string.Empty);
            treeView.Nodes.Add(rootNode);
            for (int i = 1; i < ultimateOwners.Count; i++)
            {
                TreeNode currUltimateOwnerNode = FormatNode(ultimateOwners[i].OwnerID, ultimateOwners[i].TotalCapitalSharePct, string.Empty);
                rootNode.Nodes.Add(currUltimateOwnerNode);
                UnWindAssetsGraph(ultimateOwners[i].OwnerID, _dataSource, treeView, currUltimateOwnerNode, ultimateOwners[i].TotalCapitalSharePct);
            }
        }

        private TreeNode FormatNode(GenericPersonID gpid, decimal pct, string pctPath)
        {
            if (gpid == null)
                return null;
            TreeNode rslt = new TreeNode();
            GenericPersonInfo gpi = QuestionnaireCheckUtils.FindPersonByID(MentionedEntities, gpid);
            string dispName = gpid.HashID;
            if (gpi != null)
                dispName = gpi.DisplayName;
            //string pctPathOut = !string.IsNullOrEmpty(pctPath) ? string.Format("( {0} * {1} )", pct, pctPath) : string.Empty;
            //rslt.Text = string.Format("{0}%{1} {2}", pct, pctPathOut, dispName);
            rslt.Text = string.Format("{0}%{1} {2}", pct, pctPath, dispName);
            return rslt;
        }

        private TreeNode FormatNode2(GenericPersonID gpid, decimal pct, string pctPath)
        {
            if (gpid == null)
                return null;
            TreeNode rslt = new TreeNode();
            GenericPersonInfo gpi = QuestionnaireCheckUtils.FindPersonByID(MentionedEntities, gpid);
            string dispName = gpid.HashID;
            if (gpi != null)
                dispName = gpi.DisplayName;
            rslt.Text = string.Format("{0}%{1} {2}", pctPath, pct, dispName);
            return rslt;
        }
        
        private void UnWindOwnersGraph(GenericPersonID forAsset, List<OwnershipStructure> ownershipHaystack, TreeView rslt, TreeNode putUnderNode, decimal inPct)
        {
            foreach (OwnershipStructure os in ownershipHaystack)
            {
                if (os.Asset != forAsset)
                    continue;
                decimal correctedPct = 100 * ((os.SharePct / 100) * (inPct / 100));
                TreeNode currNode = PrintOwnershipLine(os, rslt, putUnderNode, correctedPct);
                if (os.Owner.PersonType == EntityType.Legal)
                    UnWindOwnersGraph(os.Owner, ownershipHaystack, rslt, currNode, correctedPct);
            }
        }

        private void UnWindAssetsGraph(GenericPersonID forOwner, List<OwnershipStructure> ownershipHaystack, TreeView rslt, TreeNode putUnderNode, decimal inPct)
        {
            foreach (OwnershipStructure os in ownershipHaystack)
            {
                if (os.Owner != forOwner)
                    continue;
                decimal correctedPct = 100 * ((os.SharePct / 100) * (inPct / 100));
                TreeNode currNode = PrintOwnershipLineAsset(os, rslt, putUnderNode, correctedPct);
                //if (os.Owner.PersonType == EntityType.Legal)
                    UnWindAssetsGraph(os.Asset, ownershipHaystack, rslt, currNode, correctedPct);
            }
        }

        private TreeNode PrintOwnershipLine(OwnershipStructure os, TreeView rslt, TreeNode putUnderNode, decimal? ultimatePct)
        {
            string pctPath = ultimatePct != null ? string.Format("({0}%)", ((decimal)ultimatePct).ToString()) : string.Empty;
            TreeNode node = FormatNode(os.Owner, os.SharePct, pctPath);
            putUnderNode.Nodes.Add(node);
            return node;
        }

        private TreeNode PrintOwnershipLineAsset(OwnershipStructure os, TreeView rslt, TreeNode putUnderNode, decimal? ultimatePct)
        {
            string pctPath = ultimatePct != null ? string.Format("({0}%)", ((decimal)ultimatePct).ToString()) : string.Empty;
            TreeNode node = FormatNode2(os.Asset, os.SharePct, pctPath);
            putUnderNode.Nodes.Add(node);
            return node;
        }

        private void expandAllToolStripMenuItem_Click(object sender, EventArgs e)
        {
            treeView.ExpandAll();
        }

        private void collapseAllToolStripMenuItem_Click(object sender, EventArgs e)
        {
            treeView.CollapseAll();
        }

        private void btnReverse_Click(object sender, EventArgs e)
        {
            DirectOrReverseBinding = !DirectOrReverseBinding;
            ReBindTree();
        }

        private static string TreeToText(TreeView trvw, string indenter)
        {
            StringBuilder rslt = new StringBuilder();
            Nodes2Text(trvw.Nodes, indenter, rslt, 0);
            return rslt.ToString();
        }

        private static void Nodes2Text(TreeNodeCollection nodes, string indenter, StringBuilder target, int lvl)
        {
            foreach (TreeNode node in nodes)
            {
                target.AppendLine(string.Format("{0}{1}", string.Concat(Enumerable.Repeat(indenter, lvl).ToArray()), node.Text));
                if (node.GetNodeCount(false) > 0)
                    Nodes2Text(node.Nodes, indenter, target, lvl + 1);
            }
        }


        private void btnToTxt_Click(object sender, EventArgs e)
        {
            string txt = TreeToText(this.treeView, "\t");
            Clipboard.SetText(txt);
        }

        private void btnSettings_Click(object sender, EventArgs e)
        {
            SimpleObjectForm<Font> fontDlg = new SimpleObjectForm<System.Drawing.Font>();
            fontDlg.DataSource = treeView.Font;
            if (fontDlg.ShowDialog() != System.Windows.Forms.DialogResult.OK)
                return;
            treeView.Font = fontDlg.DataSource;
        }

        /*
        public string BuildUltimateOwnershipOnlyGraph(bool bWithDisplayNames)
        {

            Dictionary<string, TotalOwnershipDetailsInfo> ultimateOwners = new Dictionary<string, TotalOwnershipDetailsInfo>();
            UnWindUltimateOwners(_questio.BankRef.LegalPerson.GenericID, _questio.BankRef.LegalPerson.GenericID, _questio.BankExistingCommonImplicitOwners, OwnershipType.Direct, 100M, ultimateOwners);
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


        private void UnWindUltimateOwners(GenericPersonID ultimateAsset, GenericPersonID currAsset, List<OwnershipStructure> ownershipHaystack, OwnershipType currDirImpl, decimal currPct, Dictionary<string, TotalOwnershipDetailsInfo> target)
        {
            List<OwnershipStructure> directOwners = QuestionnaireCheckUtils.FilterOutDirectOwners(ownershipHaystack, currAsset);
            if (directOwners.Count == 0)
            {
                IncrementUltimateOwnership(target, currAsset, currDirImpl, 100, currPct);
            }
            foreach (OwnershipStructure os in directOwners)
            {
                if (os.Owner.PersonType == Spares.EntityType.Physical)
                {
                    OwnershipType dirImpl = ((currAsset == ultimateAsset) ? OwnershipType.Direct : OwnershipType.Implicit);
                    IncrementUltimateOwnership(target, os.Owner, dirImpl, os.SharePct, currPct);
                }
                if (os.Owner.PersonType == Spares.EntityType.Legal)
                    UnWindUltimateOwners(ultimateAsset, os.Owner, ownershipHaystack, OwnershipType.Implicit, 100 * ((currPct / 100) * (os.SharePct / 100)), target);
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
         */

    }
}
