using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

namespace BGU.DRPL.SignificantOwnership.Utility.WPFGen
{
    public class XAMLGeneratorFactory
    {
        private static XAMLGeneratorFactory _instance;

        private XAMLGeneratorFactory(){}

        public static XAMLGeneratorFactory Instance
        {
            get
            {
                if(_instance == null)
                    _instance = new XAMLGeneratorFactory();
                return _instance;
            }
        }

        public IXAMLGenerator SpawnInstance()
        {
            //return new XAMLGenerator();
            //return new XAMLGeneratorPureXml();
            return new XAMLGeneratorPureXmlStackPanel();
        }
    }
}
