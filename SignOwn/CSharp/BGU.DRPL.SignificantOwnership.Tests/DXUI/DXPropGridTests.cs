using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using NUnit.Framework;
using BGU.DRPL.SignificantOwnership.DXUILib.Forms;
using BGU.DRPL.SignificantOwnership.EmpiricalData.Examples;
using System.Windows.Forms;

namespace BGU.DRPL.SignificantOwnership.Tests.DXUI
{
    [TestFixture]
    public class DXPropGridTests
    {
        [Test]
        public void Discover()
        {
            SimpleObjectFormDX frm = new SimpleObjectFormDX();
            frm.DataSource = (new GrantBank()).Appx2Questionnaire;
            ((Form)(DevExpress.XtraEditors.XtraForm)frm).ShowDialog();
        }
    }
}
