using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

namespace BGU.DRPL.RandomDataDicts
{
    public abstract class StringNamesDictBase
    {
        private List<string> _names;
        public List<string> Names 
        {
            get
            {
                if (_names == null)
                    _names = GenerateNames();
                return _names;
            }
        }

        protected abstract List<string> GenerateNames();
    }
}
