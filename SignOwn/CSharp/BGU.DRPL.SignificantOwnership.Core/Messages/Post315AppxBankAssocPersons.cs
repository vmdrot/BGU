using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using BGU.DRPL.SignificantOwnership.Core.Spares2;
using System.Xml.Serialization;

namespace BGU.DRPL.SignificantOwnership.Core.Messages
{
    /// <summary>
    /// Перелік пов’язаних із банком осіб станом на _________20____року
    /// ---------------
    /// Додаток
    /// до постанови Правління
    /// Національного банку України
    /// 12 травня 2015 року № 315
    /// </summary>
    public class Post315AppxBankAssocPersons : DossierMessageBase
    {

        #region inner type(s)
        public class Post315AppxBankAssocPersonsMsgBody : IDossierMessageBody
        {
            public DateTime InfoAsOf { get; set; }
            public List<Post315AppxBankAssocPerson> Persons { get; set; }
        }
        #endregion


        private Post315AppxBankAssocPersonsMsgBody _msgBody;
        public override IDossierMessageBody MsgBody
        {
            get
            {
                return (IDossierMessageBody)_msgBody;
            }
            set
            {
                _msgBody = (Post315AppxBankAssocPersonsMsgBody)value;
            }
        }
    }
}
