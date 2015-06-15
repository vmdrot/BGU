using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Xml.Serialization;

namespace BGU.DRPL.SignificantOwnership.Core.Spares2.DossierMsgs
{
    /*
     * 	<MAN_BANK>
		<MB_NAZVA>
			<FIO_NM1>КОНДРАТЕНКО</FIO_NM1>
			<FIO_NM2>ПРОХОР</FIO_NM2>
			<FIO_NM3>_ВАНОВИЧ</FIO_NM3>
		</MB_NAZVA>
		<MB_POS>ЗАСТУПНИК ГОЛОВИ</MB_POS>
		<MB_DT>01.08.2008</MB_DT>
		<MB_ISP_NAZVA>
			<FIO_NM1>АНТОНЯН</FIO_NM1>
			<FIO_NM2>ВАСИЛ_Й</FIO_NM2>
			<FIO_NM3>ПЕТРОВИЧ</FIO_NM3>
		</MB_ISP_NAZVA>
		<MB_TLF>+380442520000</MB_TLF>
  	   </MAN_BANK>
     */

    //[XmlElement(ElementName = "MAN_BANK")]
    public class NbuCommonMgsTrail
    {
        [XmlElement(ElementName = "MB_NAZVA")]
        public FullName SignedBy { get; set; }
        [XmlElement(ElementName = "MB_POS")]
        public string SignedByPosition { get; set; }
        [XmlElement(ElementName = "MB_DT")]
        public DateTime SignedDate { get; set; }
        [XmlElement(ElementName = "MB_ISP_NAZVA")]
        public FullName MadeBy { get; set; }
        [XmlElement(ElementName = "MB_TLF")]
        public string PhoneNr { get; set; }

        #region inner type(s)
        public class FullName
        {
            [XmlElement(ElementName = "FIO_NM1")]
            public string Surname { get; set; }
            [XmlElement(ElementName = "FIO_NM2")]
            public string Name { get; set; }
            [XmlElement(ElementName = "FIO_NM3")]
            public String Patronymic { get; set; }
        }
        #endregion
    }
}
