using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using BGU.DRPL.SignificantOwnership.Core.Spares;
using BGU.DRPL.SignificantOwnership.Core.EKDRBU.Spares;
using System.ComponentModel;
using Evolvex.Utility.Core.ComponentModelEx;

namespace BGU.DRPL.SignificantOwnership.Core.EKDRBU
{
    /// <summary>
    /// Повідомлення-квитанція (відповідь) на попередньо 
    /// поданий пакет змін.
    /// Генерується на боці НБУ у відповідь на повідомлення 
    /// типу StateBankBranchRegistryChangePackageV1.
    /// Містить статус обробки попередньо поданого банком 
    /// відповідного пакету змін.
    /// </summary>
    /// <seealso cref="StateBankBranchRegistryChangePackageV1"/>
    public class StateBankBranchRegistryChangePackageResponseV1 : NotifyPropertyChangedBase
    {
        private string _MessageID;
        [DisplayName("№ повідомлення-квитанції")]
        [Description("Вихідний № (присвоюється автоматично)")]
        [Required]
        public string MessageID { get { return _MessageID; } set { _MessageID = value; OnPropertyChanged("MessageID"); } }

        private DateTime _MessageDate;
        [DisplayName("Дата повідомлення-квитанції")]
        [Required]
        public DateTime MessageDate { get { return _MessageDate; } set { _MessageDate = value; OnPropertyChanged("MessageDate"); } }
        
        private string _RelRef;
        [DisplayName("№ основного пакету")]
        [Description("№ основного пакету, на котре дається відповідь-квитанція")]
        [Required]
        public string RelRef { get { return _RelRef; } set { _RelRef = value; OnPropertyChanged("RelRef"); } }
        
        private DateTime _RelDate;
        [DisplayName("Дата основного пакету")]
        [Description("Дата основного пакету, на котре дається відповідь-квитанція")]
        [Required]
        public DateTime RelDate { get { return _RelDate; } set { _RelDate = value; OnPropertyChanged("RelDate"); } }
        
        private EKDRBUChangePackageResponseStatus _ResponseStatus;
        [DisplayName("Статус обробки")]
        [Description("Статус обробки основного пакету, котрого стосується ця відповідь-квитанція")]
        [Required]
        public EKDRBUChangePackageResponseStatus ResponseStatus { get { return _ResponseStatus; } set { _ResponseStatus = value; OnPropertyChanged("ResponseStatus"); } }
        
        private List<StateBankRegistryProcessingErrorInfo> _Errors;
        [DisplayName("Помилки обробки")]
        [Description("Список помилок, що виникли при обробці основного пакету, котрого стосується ця відповідь-квитанція")]
        [Required("ResponseStatus != CompleteSuccess")]
        public List<StateBankRegistryProcessingErrorInfo> Errors { get { return _Errors; } set { _Errors = value; OnPropertyChanged("Errors"); } }

        private ContactInfoSimple _CheckedBy;
        [DisplayName("Виконавець")]
        [Description("Прізвище й ініціали та контактні дані виконавця, що перевірив і прийняв пакет до оброки/відбракував")]
        [Required]
        public ContactInfoSimple CheckedBy { get { return _CheckedBy; } set { _CheckedBy = value; OnPropertyChanged("CheckedBy"); } }

    }
}
