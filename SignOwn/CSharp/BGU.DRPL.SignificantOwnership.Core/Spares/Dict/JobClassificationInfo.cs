using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.ComponentModel;

namespace BGU.DRPL.SignificantOwnership.Core.Spares.Dict
{
    /// <summary>
    /// Професія за версією українського класифікатора професій
    /// Джерело: КЛАСИФІКАТОР ПРОФЕСІЙ
    /// ДК 003:2010 
    /// ЗАТВЕРДЖЕНО ТА НАДАНО ЧИННОСТІ
    /// Наказ Держспоживстандарту України
    /// 28.07.2010 N 327 
    /// Чинний від 01.11.2010 р.
    /// </summary>
    /// <seealso cref="http://hrliga.com/docs/327_KP.htm"/>
    public class JobClassificationInfo : NotifyPropertyChangedBase
    {
        private string _Code; 
        [DisplayName("")]
        [Description("")]
        public string Code { get { return _Code; } set { _Code = value; OnPropertyChanged("Code"); } }

        private string _Name; 
        public string Name { get { return _Name; } set { _Name = value; OnPropertyChanged("Name"); } }


    }
}
