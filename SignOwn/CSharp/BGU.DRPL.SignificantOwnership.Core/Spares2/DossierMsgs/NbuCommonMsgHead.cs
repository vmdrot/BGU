using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Xml.Serialization;

namespace BGU.DRPL.SignificantOwnership.Core.Spares2.DossierMsgs
{
    /*
	<HEAD>
		<FNAME>P70RXX12.301</FNAME>
		<EDRPOU>12345678</EDRPOU>
		<IDBANK>RXX</IDBANK>
		<MFO>300012</MFO>
		<CDTASK>002</CDTASK>
		<CDSUB>00001</CDSUB>
		<CDFORM>NBU_01SV</CDFORM>
		<FILL_DATE>09.12.2013</FILL_DATE>
		<FILL_TIME>0900</FILL_TIME>
		<EI xsi:nil="true"/>
		<KU>24</KU>
	</HEAD>
     */
    public class NbuCommonMsgHead 
    {
        [XmlElement(ElementName = "FNAME")]
        public string FileName { get; set; }
        [XmlElement(ElementName = "EDRPOU")]
        public string TaxID { get; set; }
        [XmlElement(ElementName = "IDBANK")]
        public string BankID { get; set; }
        public int MFO { get; set; }
        [XmlElement(ElementName = "CDTASK")]
        public string TaskCode { get; set; }
        [XmlElement(ElementName = "CDSUB")]
        public string SubCode { get; set; }
        [XmlElement(ElementName = "CDFORM")]
        public string FormCode { get; set; }
        [XmlIgnore]
        public DateTime FillDateTime { get; set; }
        public string EI { get; set; }
        public int KU { get; set; }

        #region ext props
        [XmlElement(ElementName = "FILL_DATE")]
        public string FILL_DATE 
        {
            get
            {
                return FillDateTime.ToString("DD.MM.YYYY");
            }
        }

        [XmlElement(ElementName = "FILL_TIME")]
        public string FILL_TIME 
        {
            get
            {
                return FillDateTime.ToString("HHmm");
            }
        }
        #endregion
    }
}
