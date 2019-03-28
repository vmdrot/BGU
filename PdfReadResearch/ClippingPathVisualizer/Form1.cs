using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;
using ClippingPathVisualizer.ViewModels;
using Newtonsoft.Json;
using Pdf2DataLib.Spares;

namespace ClippingPathVisualizer
{
    public partial class Form1 : Form
    {
        #region data field(s)
        protected List<PathInfo> _pathInfos;
        protected List<string> _txts;
        #endregion

        public Form1()
        {
            InitializeComponent();
        }

        private void edJSON_TextChanged(object sender, EventArgs e)
        {
            Rebind2Jsons();
        }

        private void Rebind2Jsons()
        {
            try { _pathInfos = JsonConvert.DeserializeObject<List<PathInfo>>(edJSON.Text); } catch (Exception ex) { _pathInfos = null; }
            try { _txts = JsonConvert.DeserializeObject<List<string>>(edTxtJSON.Text); } catch (Exception ex) { _txts = null; }
            BindCombo();
        }

        private void BindCombo()
        {
            cbxCPIdx.DataSource = null;
            cbxCPIdx.DisplayMember = "DisplayText";
            cbxCPIdx.ValueMember = "DataIndex";
            cbxCPIdx.DataSource = (PathInfoEntryCollection)_pathInfos;
        }

        private void edTxtJSON_TextChanged(object sender, EventArgs e)
        {
            Rebind2Jsons();
        }

        private void cbxCPIdx_SelectedIndexChanged(object sender, EventArgs e)
        {
            RebindChildControls(cbxCPIdx.SelectedItem as PathInfoEntry);
        }

        private void RebindChildControls(PathInfoEntry pie)
        {
            if (pie == null)
                return;
            if (_pathInfos == null || _pathInfos.Count == 0)
            {
                edRelTxtIdx.Clear();
                edRelTxt.Clear();
                edCurrShapeJSON.Clear();
                return;
            }
            edRelTxtIdx.Text = _pathInfos[pie.DataIndex].RelatedTextIndex.ToString();
            if (_txts != null 
                && _pathInfos[pie.DataIndex].RelatedTextIndex < _txts.Count 
                && _pathInfos[pie.DataIndex].RelatedTextIndex >=0)
                edRelTxt.Text = _txts[_pathInfos[pie.DataIndex].RelatedTextIndex];
            else edRelTxt.Clear();
            edCurrShapeJSON.Text = JsonConvert.SerializeObject(_pathInfos[pie.DataIndex].SubPaths, Formatting.None);
            DrawAllSubPaths(_pathInfos[pie.DataIndex].SubPaths);

        }

        private void DrawAllLines(List<LineInfo> segments)
        {
            DrawLines(groupBox1.CreateGraphics(), 5, 5, segments);


        }

        private void DrawAllSubPaths(List<SubPathInfo> subPaths)
        {
            
            if (subPaths != null && subPaths.Count > 0)
                DrawAllLines(subPaths[0].Segments);
        }

        public void DrawLines(System.Drawing.Graphics g, int intMarginLeft, int intMarginTop, List<LineInfo> lines)
        {
            Pen myPen = new Pen(Color.Black);
            myPen.Width = 2;
            // Create array of points that define lines to draw.
            int marginleft = intMarginLeft;
            int marginTop = intMarginTop;
            List<PointF> points = new List<PointF>();
            foreach (LineInfo ln in lines)
            {
                PointF pf1 = new PointF((float)ln.p1.x + (float)marginleft, (float)ln.p1.y + (float)marginTop);
                PointF pf2 = new PointF((float)ln.p2.x + (float)marginleft, (float)ln.p2.y + (float)marginTop);
                points.Add(pf1);
                points.Add(pf2);
            }

            g.DrawLines(myPen, points.ToArray());
        }

        public void DrawLShapeLine(System.Drawing.Graphics g, int intMarginLeft, int intMarginTop, int intWidth, int intHeight)
        {
            Pen myPen = new Pen(Color.Black);
            myPen.Width = 2;
            // Create array of points that define lines to draw.
            int marginleft = intMarginLeft;
            int marginTop = intMarginTop;
            int width = intWidth;
            int height = intHeight;
            int arrowSize = 3;
            Point[] points =
             {
                new Point(marginleft, marginTop),
                new Point(marginleft, height + marginTop),
                new Point(marginleft + width, marginTop + height),
                // Arrow
                new Point(marginleft + width - arrowSize, marginTop + height - arrowSize),
                new Point(marginleft + width - arrowSize, marginTop + height + arrowSize),
                new Point(marginleft + width, marginTop + height)
             };

            g.DrawLines(myPen, points);
        }
    }
}
