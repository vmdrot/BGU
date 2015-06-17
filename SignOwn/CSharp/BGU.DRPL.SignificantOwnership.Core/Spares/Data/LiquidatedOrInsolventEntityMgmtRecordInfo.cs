﻿using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.ComponentModel;

namespace BGU.DRPL.SignificantOwnership.Core.Spares.Data
{

    [System.ComponentModel.Editor(typeof(BGU.DRPL.SignificantOwnership.Core.TypeEditors.LiquidatedOrInsolventEntityMgmtRecordInfo_Editor), typeof(System.Drawing.Design.UITypeEditor))]
    public class LiquidatedOrInsolventEntityMgmtRecordInfo : LiquidatedOrInsolventEntityInfoBase
    {
        
        /// <summary>
        /// ... займану Вами в цій юридичний особі посаду
        /// </summary>
        [DisplayName("Посада")]
        public ManagementPosition Position { get; set; }
    }
}
