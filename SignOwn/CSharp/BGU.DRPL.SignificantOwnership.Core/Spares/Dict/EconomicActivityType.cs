using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.ComponentModel;
using Evolvex.Utility.Core.ComponentModelEx;

namespace BGU.DRPL.SignificantOwnership.Core.Spares.Dict
{

    [System.ComponentModel.Editor(typeof(BGU.DRPL.SignificantOwnership.Core.TypeEditors.EconomicActivityType_Editor), typeof(System.Drawing.Design.UITypeEditor))]
    public class EconomicActivityType
    {
        /// <summary>
        /// 
        /// </summary>
        /// <seealso cref="http://kved.ukrstat.gov.ua/cgi-bin/kv-vi.exe?r=026492&l=%F4%E0%EA%F2%EE%F0%E8%ED%E3%EE%E2%E8%F5" />
        [DisplayName("Код діяльності за КВЕД")]
        [Required]
        public string KVEDCode { get; set; }
        [DisplayName("Назва діяльності за КВЕД")]
        [Required]
        public string KVEDActivityName { get; set; }
        [DisplayName("Власна фактична назва діяльності")]
        public string ActivitySelfName { get; set; }
    }
}
