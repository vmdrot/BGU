using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using BGU.DRPL.SignificantOwnership.Core.Spares2.DossierMsgs;
using System.Xml.Serialization;

namespace BGU.DRPL.SignificantOwnership.Core.Messages
{
    public abstract class DossierMessageBase
    {
        [XmlElement(ElementName="HEAD")]
        public NbuCommonMsgHead MsgHead { get; set; }
        [XmlElement(ElementName = "BODY")]
        public abstract IDossierMessageBody MsgBody { get; set; }
        [XmlElement(ElementName = "MAN_BANK")]
        public NbuCommonMgsTrail MsgTrail { get; set; }
    }
}
