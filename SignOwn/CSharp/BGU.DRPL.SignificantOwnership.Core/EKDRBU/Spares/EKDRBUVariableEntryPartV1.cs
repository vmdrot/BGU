using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.ComponentModel;
using Evolvex.Utility.Core.ComponentModelEx;
using BGU.DRPL.SignificantOwnership.Core.Spares.Dict;
using BGU.DRPL.SignificantOwnership.Core.Spares;
using BGU.DRPL.SignificantOwnership.Core.Spares.Data;

namespace BGU.DRPL.SignificantOwnership.Core.EKDRBU.Spares
{
    public class EKDRBUVariableEntryPartV1 : NotifyPropertyChangedBase
    {
        public EKDRBUVariableEntryPartV1()
        {
        }

        #region Вид
        
        private bool _IsBranchTypeChanged;
        [Category("Вид")]
        [DisplayName("Вид - змінився?")]
        [Description("Чи змінився вид/тип відділення?")]
        public bool IsBranchTypeChanged { get { return _IsBranchTypeChanged; } set { _IsBranchTypeChanged = value; OnPropertyChanged("IsBranchTypeChanged"); } }
        
        private BankBranchType _BranchTypeNew;
        [Category("Вид")]
        [DisplayName("Вид - новий")]
        [Description("Нове значення поля Вид відокремленого підрозділу")]
        [UIConditionalVisibility("IsBranchTypeChanged")]
        public BankBranchType BranchTypeNew { get { return _BranchTypeNew; } set { _BranchTypeNew = value; OnPropertyChanged("BranchTypeNew"); } }
        
        private BankBranchType _BranchTypeOld;
        [Category("Вид")]
        [DisplayName("Вид - старий")]
        [Description("Старе значення поля Вид відокремленого підрозділу")]
        [UIConditionalVisibility("IsBranchTypeChanged")]
        public BankBranchType BranchTypeOld { get { return _BranchTypeOld; } set { _BranchTypeOld = value; OnPropertyChanged("BranchTypeOld"); } }

        #endregion


        #region Стан

        private bool _IsStatusChanged;
        [Category("Статус")]
        [DisplayName("Стан - змінився?")]
        [Description("Чи змінився стан?")]
        public bool IsStatusChanged { get { return _IsStatusChanged; } set { _IsStatusChanged = value; OnPropertyChanged("IsStatusChanged"); } }

        private BankBranchStatusType _StatusNew;
        [Category("Статус")]
        [DisplayName("Стан - новий")]
        [Description("Нове значення поля Стан")]
        [UIConditionalVisibility("IsStatusChanged")]
        public BankBranchStatusType StatusNew { get { return _StatusNew; } set { _StatusNew = value; OnPropertyChanged("StatusNew"); } }
        
        private BankBranchStatusType _StatusOld;
        [Category("Статус")]
        [DisplayName("Стан - старий")]
        [Description("Старе значення поля Стан")]
        [UIConditionalVisibility("IsStatusChanged")]
        public BankBranchStatusType StatusOld { get { return _StatusOld; } set { _StatusOld = value; OnPropertyChanged("StatusOld"); } }

        #endregion

        #region Ієрархія

        private bool _IsParentIDChanged;
        [Category("Ієрархія (підпорядкованість)")]
        [DisplayName("Батьківський підрозділ міняється?")]
        [Description("Чи міняється значення поля Батьківський підрозділ")]
        public bool IsParentIDChanged { get { return _IsParentIDChanged; } set { _IsParentIDChanged = value; OnPropertyChanged("IsParentIDChanged"); } }

        private string _ParentIDNew;
        /// <summary>
        /// Значення - внутрішній код підрозділу 
        /// Наприклад: 00626804103608000000 для підрозділу 
        /// "Філія - Дніпропетровське обласне управління публічного акціонерного товариства "Державний ощадний банк України"")
        /// </summary>
        [Category("Ієрархія (підпорядкованість)")]
        [DisplayName("Батьківський підрозділ новий")]
        [Description("Батьківський підрозділ - нове значення")]
        [UIConditionalVisibility("IsParentIDChanged")]
        public string ParentIDNew { get { return _ParentIDNew; } set { _ParentIDNew = value; OnPropertyChanged("ParentIDNew"); } }
        
        private string _ParentIDOld;
        [Category("Ієрархія (підпорядкованість)")]
        [DisplayName("Батьківський підрозділ старий")]
        [Description("Батьківський підрозділ - попереднє значення")]
        [UIConditionalVisibility("IsParentIDChanged")]
        public string ParentIDOld { get { return _ParentIDOld; } set { _ParentIDOld = value; OnPropertyChanged("ParentIDOld"); } }

        #endregion

        #region Назви

        private bool _IsNameFullChanged;
        [Category("Назви")]
        [DisplayName("Назва (254 символів) - змінилася?")]
        [Description("Чи змінилася повна назва (254 символів)?")]
        public bool IsNameFullChanged { get { return _IsNameFullChanged; } set { _IsNameFullChanged = value; OnPropertyChanged("IsNameFullChanged"); } }
        
        private string _NameFullNew;
        [Category("Назви")]
        [DisplayName("Назва (254 символів) - нова")]
        [Description("Нове значення поля Повна назва (254 символів)")]
        [UIConditionalVisibility("IsNameFullChanged")]
        public string NameFullNew { get { return _NameFullNew; } set { _NameFullNew = value; OnPropertyChanged("NameFullNew"); } }

        private string _NameFullOld;
        [Category("Назви")]
        [DisplayName("Назва (254 символів) - стара")]
        [Description("Старе значення поля Повна назва (254 символів)")]
        [UIConditionalVisibility("IsNameFullChanged")]
        public string NameFullOld { get { return _NameFullOld; } set { _NameFullOld = value; OnPropertyChanged("NameFullOld"); } }

        private bool _IsNameShortChanged;
        [Category("Назви")]
        [DisplayName("Скорочена назва (80 символів) - змінилася?")]
        [Description("Чи змінилася скорочена назва (80 символів)?")]
        public bool IsNameShortChanged { get { return _IsNameShortChanged; } set { _IsNameShortChanged = value; OnPropertyChanged("IsNameShortChanged"); } }
        
        private string _NameShortNew;
        [Category("Назви")]
        [DisplayName("Скорочена назва (80 символів) - нова")]
        [Description("Нове значення поля скорочена назва (80 символів)")]
        [UIConditionalVisibility("IsNameShortChanged")]
        public string NameShortNew { get { return _NameShortNew; } set { _NameShortNew = value; OnPropertyChanged("NameShortNew"); } }

        private string _NameShortOld;
        [Category("Назви")]
        [DisplayName("Скорочена назва (80 символів) - стара")]
        [Description("Старе значення поля скорочена назва (80 символів)")]
        [UIConditionalVisibility("IsNameShortChanged")]
        public string NameShortOld { get { return _NameShortOld; } set { _NameShortOld = value; OnPropertyChanged("NameShortOld"); } }

        private bool _IsNamePrintChanged;
        [Category("Назви")]
        [DisplayName("Назва для друку (40 символів) - змінилася?")]
        [Description("Чи змінилася назва для друку (40 символів)?")]
        public bool IsNamePrintChanged { get { return _IsNamePrintChanged; } set { _IsNamePrintChanged = value; OnPropertyChanged("IsNamePrintChanged"); } }
        
        private string _NamePrintNew;
        [Category("Назви")]
        [DisplayName("Назва для друку (40 символів) - нова")]
        [Description("Нова значення поля Назва для друку (40 символів)")]
        [UIUsageTextBox(HorizontalAlignment = "Left", IsMultiline = false, MinWidth = "150", MaxWidth = "200")]
        [UIConditionalVisibility("IsNamePrintChanged")]
        public string NamePrintNew { get { return _NamePrintNew; } set { _NamePrintNew = value; OnPropertyChanged("NamePrintNew"); } }
        
        private string _NamePrintOld;
        [Category("Назви")]
        [DisplayName("Назва для друку (40 символів) - стара")]
        [Description("Старе значення поля Назва для друку (40 символів)")]
        [UIUsageTextBox(HorizontalAlignment = "Left", IsMultiline = false, MinWidth = "150", MaxWidth = "200")]
        [UIConditionalVisibility("IsNamePrintChanged")]
        public string NamePrintOld { get { return _NamePrintOld; } set { _NamePrintOld = value; OnPropertyChanged("NamePrintOld"); } }

        private bool _IsNameSEPChanged;
        [Category("Назви")]
        [DisplayName("Назва для СЕП (38 символів) - змінилася?")]
        [Description("Чи змінилася назва для СЕП (38 символів)?")]
        public bool IsNameSEPChanged { get { return _IsNameSEPChanged; } set { _IsNameSEPChanged = value; OnPropertyChanged("IsNameSEPChanged"); } }
        
        private string _NameSEPNew;
        [Category("Назви")]
        [DisplayName("Назва для СЕП (38 символів) - нова")]
        [Description("Нове значення поля Назва для СЕП (38 символів)")]
        [UIConditionalVisibility("IsNameSEPChanged")]
        public string NameSEPNew { get { return _NameSEPNew; } set { _NameSEPNew = value; OnPropertyChanged("NameSEPNew"); } }
        
        private string _NameSEPOld;
        [Category("Назви")]
        [DisplayName("Назва для СЕП (38 символів) - стара")]
        [Description("Старе значення поля Назва для СЕП (38 символів)")]
        [UIConditionalVisibility("IsNameSEPChanged")]
        public string NameSEPOld { get { return _NameSEPOld; } set { _NameSEPOld = value; OnPropertyChanged("NameSEPOld"); } }

        private bool _IsNameStatsChanged;
        [Category("Назви")]
        [DisplayName("Назва для СТАТЗВІТНОСТІ (27 символів) - змінилася?")]
        [Description("Чи змінилася Назва для СТАТЗВІТНОСТІ (27 символів)?")]
        public bool IsNameStatsChanged { get { return _IsNameStatsChanged; } set { _IsNameStatsChanged = value; OnPropertyChanged("IsNameStatsChanged"); } }

        private string _NameStatsNew;
        [Category("Назви")]
        [DisplayName("Назва для СТАТЗВІТНОСТІ (27 символів) - нова")]
        [Description("Нове значення поля Назва для СТАТЗВІТНОСТІ (27 символів)")]
        [UIUsageTextBox(HorizontalAlignment = "Left", IsMultiline = false, MinWidth = "125", MaxWidth = "150")]
        [UIConditionalVisibility("IsNameStatsChanged")]
        public string NameStatsNew { get { return _NameStatsNew; } set { _NameStatsNew = value; OnPropertyChanged("NameStatsNew"); } }

        private string _NameStatsOld;
        [Category("Назви")]
        [DisplayName("Назва для СТАТЗВІТНОСТІ (27 символів) - стара")]
        [Description("Старе значення поля Назва для СТАТЗВІТНОСТІ (27 символів)")]
        [UIUsageTextBox(HorizontalAlignment = "Left", IsMultiline = false, MinWidth = "125", MaxWidth = "150")]
        [UIConditionalVisibility("IsNameStatsChanged")]
        public string NameStatsOld { get { return _NameStatsOld; } set { _NameStatsOld = value; OnPropertyChanged("NameStatsOld"); } }

        #endregion

        #region Номери й коди

        private bool _IsMFOChanged;
        [Category("Номери")]
        [DisplayName("МФО - змінилося?")]
        [Description("Чи змінилося МФО?")]
        public bool IsMFOChanged { get { return _IsMFOChanged; } set { _IsMFOChanged = value; OnPropertyChanged("IsMFOChanged"); } }
        
        private string _MFONew;
        [Category("Номери")]
        [DisplayName("МФО - нове")]
        [Description("Нове значення МФО")]
        [UIUsageTextBox(HorizontalAlignment = "Left", IsMultiline = false, MinWidth = "75", MaxWidth = "100")]
        [UIConditionalVisibility("IsMFOChanged")]
        public string MFONew { get { return _MFONew; } set { _MFONew = value; OnPropertyChanged("MFONew"); } }

        private string _MFOOld;
        [Category("Номери")]
        [DisplayName("МФО - старе")]
        [Description("Старе значення МФО")]
        [UIUsageTextBox(HorizontalAlignment = "Left", IsMultiline = false, MinWidth = "75", MaxWidth = "100")]
        [UIConditionalVisibility("IsMFOChanged")]
        public string MFOOld { get { return _MFOOld; } set { _MFOOld = value; OnPropertyChanged("MFOOld"); } }


        private bool _IsYeDRPOUChanged;
        [Category("Номери")]
        [DisplayName("ЄДРПОУ - змінився?")]
        [Description("Чи змінився ЄДРПОУ?")]
        public bool IsYeDRPOUChanged { get { return _IsYeDRPOUChanged; } set { _IsYeDRPOUChanged = value; OnPropertyChanged("IsYeDRPOUChanged"); } }

        private string _YeDRPOUNew;
        [Category("Номери")]
        [DisplayName("ЄДРПОУ - новий")]
        [Description("Нове значення ЄДРПОУ")]
        [UIUsageTextBox(HorizontalAlignment = "Left", IsMultiline = false, MinWidth = "75", MaxWidth = "100")]
        [UIConditionalVisibility("IsYeDRPOUChanged")]
        public string YeDRPOUNew { get { return _YeDRPOUNew; } set { _YeDRPOUNew = value; OnPropertyChanged("YeDRPOUNew"); } }
        
        private string _YeDRPOUOld;
        [Category("Номери")]
        [DisplayName("ЄДРПОУ - старий")]
        [Description("Старе значення ЄДРПОУ")]
        [UIUsageTextBox(HorizontalAlignment = "Left", IsMultiline = false, MinWidth = "75", MaxWidth = "100")]
        [UIConditionalVisibility("IsYeDRPOUChanged")]
        public string YeDRPOUOld { get { return _YeDRPOUOld; } set { _YeDRPOUOld = value; OnPropertyChanged("YeDRPOUOld"); } }

        private bool _IsRegNrChanged;
        [Category("Номери")]
        [DisplayName("Реєстраційний номер - змінився?")]
        [Description("Чи змінився реєстраційний номер?")]
        public bool IsRegNrChanged { get { return _IsRegNrChanged; } set { _IsRegNrChanged = value; OnPropertyChanged("IsRegNrChanged"); } }
        
        private string _RegNrNew;
        [Category("Номери")]
        [DisplayName("Реєстраційний номер - новий")]
        [Description("Нове значення поля Реєстраційний номер")]
        [UIUsageTextBox(HorizontalAlignment = "Left", IsMultiline = false, MinWidth = "65", MaxWidth = "85")]
        [UIConditionalVisibility("IsRegNrChanged")]
        public string RegNrNew { get { return _RegNrNew; } set { _RegNrNew = value; OnPropertyChanged("RegNrNew"); } }
        
        private string _RegNrOld;
        [Category("Номери")]
        [DisplayName("Реєстраційний номер - новий")]
        [Description("Нове значення поля Реєстраційний номер")]
        [UIUsageTextBox(HorizontalAlignment = "Left", IsMultiline = false, MinWidth = "65", MaxWidth = "85")]
        [UIConditionalVisibility("IsRegNrChanged")]
        public string RegNrOld { get { return _RegNrOld; } set { _RegNrOld = value; OnPropertyChanged("RegNrOld"); } }

        private bool _IsInternalNrChanged;
        [Category("Номери")]
        [DisplayName("Внутрішньобанківський номер - змінився?")]
        [Description("Чи змінився внутрішньобанківський номер?")]
        public bool IsInternalNrChanged { get { return _IsInternalNrChanged; } set { _IsInternalNrChanged = value; OnPropertyChanged("IsInternalNrChanged"); } }
        
        private string _InternalNrNew;
        [Category("Номери")]
        [DisplayName("Внутрішньобанківський номер - новий")]
        [Description("Нове значення поля Внутрішньобанківський номер")]
        [UIUsageTextBox(HorizontalAlignment = "Left", IsMultiline = false, MinWidth = "65", MaxWidth = "85")]
        [UIConditionalVisibility("IsInternalNrChanged")]
        public string InternalNrNew { get { return _InternalNrNew; } set { _InternalNrNew = value; OnPropertyChanged("InternalNrNew"); } }
        
        private string _InternalNrOld;
        [Category("Номери")]
        [DisplayName("Внутрішньобанківський номер - старий")]
        [Description("Старе значення поля Внутрішньобанківський номер")]
        [UIUsageTextBox(HorizontalAlignment = "Left", IsMultiline = false, MinWidth = "65", MaxWidth = "85")]
        [UIConditionalVisibility("IsInternalNrChanged")]
        public string InternalNrOld { get { return _InternalNrOld; } set { _InternalNrOld = value; OnPropertyChanged("InternalNrOld"); } }

        private bool _IsBranchNrInternalChanged;
        [Category("Номери")]
        [DisplayName("Номер підрозділу за внутрішньобанківським номером - змінився?")]
        [Description("Чи змінився номер підрозділу за внутрішньобанківським номером?")]
        public bool IsBranchNrInternalChanged { get { return _IsBranchNrInternalChanged; } set { _IsBranchNrInternalChanged = value; OnPropertyChanged("IsBranchNrInternalChanged"); } }
        
        private string _BranchNrInternalNew;
        [Category("Номери")]
        [DisplayName("Номер підрозділу за внутрішньобанківським номером - новий")]
        [Description("Нове значення поля Номер підрозділу за внутрішньобанківським номером")]
        [UIUsageTextBox(HorizontalAlignment = "Left", IsMultiline = false, MinWidth = "65", MaxWidth = "85")]
        [UIConditionalVisibility("IsBranchNrInternalChanged")]
        public string BranchNrInternalNew { get { return _BranchNrInternalNew; } set { _BranchNrInternalNew = value; OnPropertyChanged("BranchNrInternalNew"); } }

        private string _BranchNrInternalOld;
        [Category("Номери")]
        [DisplayName("Номер підрозділу за внутрішньобанківським номером - старий")]
        [Description("Старе значення поля Номер підрозділу за внутрішньобанківським номером")]
        [UIUsageTextBox(HorizontalAlignment = "Left", IsMultiline = false, MinWidth = "65", MaxWidth = "85")]
        [UIConditionalVisibility("IsBranchNrInternalChanged")]
        public string BranchNrInternalOld { get { return _BranchNrInternalOld; } set { _BranchNrInternalOld = value; OnPropertyChanged("BranchNrInternalOld"); } }
        #endregion

        #region Розташування

        private bool _IsKOATUUChanged;
        [Category("Адреса/розташування")]
        [DisplayName("КОАТУУ змінився?")]
        [Description("Чи змінився код КОАТУУ (Класифікатор об'єктів адміністративно-територіального устрою України)?")]
        public bool IsKOATUUChanged { get { return _IsKOATUUChanged; } set { _IsKOATUUChanged = value; OnPropertyChanged("IsKOATUUChanged"); } }

        private string _KOATUUNew;
        [Category("Адреса/розташування")]
        [DisplayName("КОАТУУ - новий")]
        [Description("Нове значення коду КОАТУУ (Класифікатор об'єктів адміністративно-територіального устрою України)")]
        [UIConditionalVisibility("IsKOATUUChanged")]
        public string KOATUUNew { get { return _KOATUUNew; } set { _KOATUUNew = value; OnPropertyChanged("KOATUUNew"); } }

        private string _KOATUUOld;
        [Category("Адреса/розташування")]
        [DisplayName("КОАТУУ - старий")]
        [Description("Старе значення коду КОАТУУ (Класифікатор об'єктів адміністративно-територіального устрою України)")]
        [UIConditionalVisibility("IsKOATUUChanged")]
        public string KOATUUOld { get { return _KOATUUOld; } set { _KOATUUOld = value; OnPropertyChanged("KOATUUOld"); } }

        private bool _IsGeoCoordinatesChanged;
        [Category("Адреса/розташування")]
        [DisplayName("Координати - змінилися?")]
        [Description("Чи змінилося значення поля Координати (географічні)?")]
        public bool IsGeoCoordinatesChanged { get { return _IsGeoCoordinatesChanged; } set { _IsGeoCoordinatesChanged = value; OnPropertyChanged("IsGeoCoordinatesChanged"); } }

        private string _GeoCoordinatesNew;
        [Category("Адреса/розташування")]
        [DisplayName("Координати - нові")]
        [Description("Нове значення поля Географічні координати")]
        [UIConditionalVisibility("IsGeoCoordinatesChanged")]
        public string GeoCoordinatesNew { get { return _GeoCoordinatesNew; } set { _GeoCoordinatesNew = value; OnPropertyChanged("GeoCoordinatesNew"); } }

        private string _GeoCoordinatesOld;
        [Category("Адреса/розташування")]
        [DisplayName("Координати - старі")]
        [Description("Старе значення поля Географічні координати")]
        [UIConditionalVisibility("IsGeoCoordinatesChanged")]
        public string GeoCoordinatesOld { get { return _GeoCoordinatesOld; } set { _GeoCoordinatesOld = value; OnPropertyChanged("GeoCoordinatesOld"); } }

        private bool _IsOblastChanged;
        [Category("Адреса/розташування")]
        [DisplayName("Область змінилася?")]
        [Description("Чи змінилося значення області?")]
        public bool IsOblastChanged { get { return _IsOblastChanged; } set { _IsOblastChanged = value; OnPropertyChanged("IsOblastChanged"); } }
        
        private string _OblastNew;
        [Category("Адреса/розташування")]
        [DisplayName("Область (нова)")]
        [Description("Область - нове значення")]
        [UIUsageTextBox(HorizontalAlignment = "Left", IsMultiline = false, MaxWidth = "400", MinWidth = "350")]
        [UIConditionalVisibility("IsOblastChanged")]
        public string OblastNew { get { return _OblastNew; } set { _OblastNew = value; OnPropertyChanged("OblastNew"); } }
        
        private string _OblastOld;
        [Category("Адреса/розташування")]
        [DisplayName("Область (стара)")]
        [Description("Область - старе значення")]
        [UIUsageTextBox(HorizontalAlignment = "Left", IsMultiline = false, MaxWidth = "400", MinWidth = "350")]
        [UIConditionalVisibility("IsOblastChanged")]
        public string OblastOld { get { return _OblastOld; } set { _OblastOld = value; OnPropertyChanged("OblastOld"); } }

        private bool _IsRaionChanged;
        [Category("Адреса/розташування")]
        [DisplayName("Змінився район?")]
        [Description("Чи змінилося значення району")]
        public bool IsRaionChanged { get { return _IsRaionChanged; } set { _IsRaionChanged = value; OnPropertyChanged("IsRaionChanged"); } }
        
        private string _RaionNew;
        [Category("Адреса/розташування")]
        [DisplayName("Район (новий)")]
        [Description("Нове значення поля район")]
        [UIConditionalVisibility("IsRaionChanged")]
        public string RaionNew { get { return _RaionNew; } set { _RaionNew = value; OnPropertyChanged("RaionNew"); } }
        
        private string _RaionOld;
        [Category("Адреса/розташування")]
        [DisplayName("Район (старий)")]
        [Description("Старе значення поля район")]
        [UIConditionalVisibility("IsRaionChanged")]
        public string RaionOld { get { return _RaionOld; } set { _RaionOld = value; OnPropertyChanged("RaionOld"); } }


        private bool _IsZipCodeChanged;
        [Category("Адреса/розташування")]
        [DisplayName("Поштовий індекс змінився?")]
        [Description("Чи змінився поштовий індекс?")]
        public bool IsZipCodeChanged { get { return _IsZipCodeChanged; } set { _IsZipCodeChanged = value; OnPropertyChanged("IsZipCodeChanged"); } }

        private string _ZipCodeNew;
        [Category("Адреса/розташування")]
        [DisplayName("Поштовий індекс - новий")]
        [Description("Нове значення поштового індексу")]
        [UIUsageTextBox(HorizontalAlignment = "Left", IsMultiline = false, MaxWidth = "150", MinWidth = "100")]
        [UIConditionalVisibility("IsZipCodeChanged")]
        public string ZipCodeNew { get { return _ZipCodeNew; } set { _ZipCodeNew = value; OnPropertyChanged("ZipCodeNew"); } }

        private string _ZipCodeOld;
        [Category("Адреса/розташування")]
        [DisplayName("Поштовий індекс")]
        [Description("Поштовий індекс")]
        [UIUsageTextBox(HorizontalAlignment = "Left", IsMultiline = false, MaxWidth = "150", MinWidth = "100")]
        [UIConditionalVisibility("IsZipCodeChanged")]
        public string ZipCodeOld { get { return _ZipCodeOld; } set { _ZipCodeOld = value; OnPropertyChanged("ZipCodeOld"); } }

        private bool _IsCityChanged;
        [Category("Адреса/розташування")]
        [DisplayName("Населений пункт змінився?")]
        [Description("Чи змінилося значення населеного пункту")]
        public bool IsCityChanged { get { return _IsCityChanged; } set { _IsCityChanged = value; OnPropertyChanged("IsCityChanged"); } }
        
        private string _CityNew;
        [Category("Адреса/розташування")]
        [DisplayName("Населений пункт - новий")]
        [Description("Нове значення населеного пункту")]
        [UIUsageTextBox(HorizontalAlignment = "Left", IsMultiline = false, MaxWidth = "300", MinWidth = "150")]
        [UIConditionalVisibility("IsCityChanged")]
        public string CityNew { get { return _CityNew; } set { _CityNew = value; OnPropertyChanged("CityNew"); } }
        
        private string _CityOld;
        [Category("Адреса/розташування")]
        [DisplayName("Населений пункт - старий")]
        [Description("Старе значення населеного пункту")]
        [UIUsageTextBox(HorizontalAlignment = "Left", IsMultiline = false, MaxWidth = "300", MinWidth = "150")]
        [UIConditionalVisibility("IsCityChanged")]
        public string CityOld { get { return _CityOld; } set { _CityOld = value; OnPropertyChanged("CityOld"); } }

        private bool _IsStreetChanged;
        [Category("Адреса/розташування")]
        [DisplayName("Вулиця/площа/тощо - змінилася?")]
        [Description("Чи змінилося значення вулиці/площі/тощо?")]
        public bool IsStreetChanged { get { return _IsStreetChanged; } set { _IsStreetChanged = value; OnPropertyChanged("IsStreetChanged"); } }

        private string _StreetNew;
        [Category("Адреса/розташування")]
        [DisplayName("Вулиця/площа/тощо - нова")]
        [Description("Нове значення вулиці/площі/тощо")]
        [UIUsageTextBox(HorizontalAlignment = "Left", IsMultiline = false, MaxWidth = "300", MinWidth = "150")]
        [UIConditionalVisibility("IsStreetChanged")]
        public string StreetNew { get { return _StreetNew; } set { _StreetNew = value; OnPropertyChanged("StreetNew"); } }
        
        private string _StreetOld;
        [Category("Адреса/розташування")]
        [DisplayName("Вулиця/площа/тощо - нова")]
        [Description("Нове значення вулиці/площі/тощо")]
        [UIUsageTextBox(HorizontalAlignment = "Left", IsMultiline = false, MaxWidth = "300", MinWidth = "150")]
        [UIConditionalVisibility("IsStreetChanged")]
        public string StreetOld { get { return _StreetOld; } set { _StreetOld = value; OnPropertyChanged("StreetOld"); } }

        private bool _IsHouseNrChanged;
        [Category("Адреса/розташування")]
        [DisplayName("№ / назва будинку - змінився?")]
        [Description("Чи змінився № / назва будинку?")]
        public bool IsHouseNrChanged { get { return _IsHouseNrChanged; } set { _IsHouseNrChanged = value; OnPropertyChanged("IsHouseNrChanged"); } }

        private string _HouseNrNew;
        [Category("Адреса/розташування")]
        [DisplayName("№ / назва будинку - нова")]
        [Description("Нове значення № / назва будинку")]
        [UIUsageTextBox(HorizontalAlignment = "Left", IsMultiline = false, MaxWidth = "300", MinWidth = "75")]
        [UIConditionalVisibility("IsHouseNrChanged")]
        public string HouseNrNew { get { return _HouseNrNew; } set { _HouseNrNew = value; OnPropertyChanged("HouseNrNew"); } }

        private string _HouseNrOld;
        [Category("Адреса/розташування")]
        [DisplayName("№ / назва будинку - старий")]
        [Description("Старе значення № / назва будинку")]
        [UIUsageTextBox(HorizontalAlignment = "Left", IsMultiline = false, MaxWidth = "300", MinWidth = "75")]
        [UIConditionalVisibility("IsHouseNrChanged")]
        public string HouseNrOld { get { return _HouseNrOld; } set { _HouseNrOld = value; OnPropertyChanged("HouseNrOld"); } }

        private bool _IsApptOfficeNrChanged;
        [Category("Адреса/розташування")]
        [DisplayName("№ кв./офісу, тощо - змінився?")]
        [Description("Чи змінився № кв./офісу, тощо?")]
        public bool IsApptOfficeNrChanged { get { return _IsApptOfficeNrChanged; } set { _IsApptOfficeNrChanged = value; OnPropertyChanged("IsApptOfficeNrChanged"); } }
        
        private string _ApptOfficeNrNew;
        [Category("Адреса/розташування")]
        [DisplayName("№ кв./офісу, тощо - новий")]
        [Description("Нове значення № кв./офісу, тощо")]
        [UIUsageTextBox(HorizontalAlignment = "Left", IsMultiline = false, MaxWidth = "300", MinWidth = "75")]
        [UIConditionalVisibility("IsApptOfficeNrChanged")]
        public string ApptOfficeNrNew { get { return _ApptOfficeNrNew; } set { _ApptOfficeNrNew = value; OnPropertyChanged("ApptOfficeNrNew"); } }
        
        private string _ApptOfficeNrOld;
        [Category("Адреса/розташування")]
        [DisplayName("№ кв./офісу, тощо - старий")]
        [Description("Старе значення № кв./офісу, тощо")]
        [UIUsageTextBox(HorizontalAlignment = "Left", IsMultiline = false, MaxWidth = "300", MinWidth = "75")]
        [UIConditionalVisibility("IsApptOfficeNrChanged")]
        public string ApptOfficeNrOld { get { return _ApptOfficeNrOld; } set { _ApptOfficeNrOld = value; OnPropertyChanged("ApptOfficeNrOld"); } }
        #endregion

        #region Перелік операцій

        private bool _IsOperationsListingChanged;
        [Category("Діяльність")]
        [DisplayName("Перелік операцій - змінився?")]
        [Description("Чи змінилося поле Перелік і обсяг операцій відокремленого підрозділу?")]
        public bool IsOperationsListingChanged { get { return _IsOperationsListingChanged; } set { _IsOperationsListingChanged = value; OnPropertyChanged("IsOperationsListingChanged"); } }

        private string _OperationsListingNew;
        /// <summary>
        /// Буквальне значення поля перелік та обсяги операцій
        /// (текст як є зараз у 15-му додатку)
        /// </summary>
        [Category("Діяльність")]
        [DisplayName("Перелік операцій - новий")]
        [Description("Нове значення поля Перелік і обсяг операцій відокремленого підрозділу?")]
        [UIUsageTextBox(HorizontalAlignment = "Left", IsMultiline = true, MinWidth = "450", MaxWidth = "650")]
        [UIConditionalVisibility("IsOperationsListingChanged")]
        public string OperationsListingNew { get { return _OperationsListingNew; } set { _OperationsListingNew = value; OnPropertyChanged("OperationsListingNew"); } }

        private string _OperationsListingOld;
        /// <summary>
        /// Буквальне значення поля перелік та обсяги операцій
        /// (текст як є зараз у 15-му додатку)
        /// </summary>
        [Category("Діяльність")]
        [DisplayName("Перелік операцій - старий")]
        [Description("Старе значення поля Перелік і обсяг операцій відокремленого підрозділу?")]
        [UIUsageTextBox(HorizontalAlignment = "Left", IsMultiline = true, MinWidth = "450", MaxWidth = "650")]
        [UIConditionalVisibility("IsOperationsListingChanged")]
        public string OperationsListingOld { get { return _OperationsListingOld; } set { _OperationsListingOld = value; OnPropertyChanged("OperationsListingOld"); } }

        private bool _IsOperationsListingRefChanged;
        [Category("Діяльність")]
        [DisplayName("Перелік операцій (код схеми)- змінився?")]
        [Description("Чи змінилося поле Код схеми переліку і обсягу операцій відокремленого підрозділу?")]
        public bool IsOperationsListingRefChanged { get { return _IsOperationsListingRefChanged; } set { _IsOperationsListingRefChanged = value; OnPropertyChanged("IsOperationsListingRefChanged"); } }

        private string _OperationsListingRefNew;
        /// <summary>
        /// Значення з полів SchemeID 
        /// колекції OperationsListingSchemes
        /// </summary>
        /// <seealso cref="#BankBranchOpsSvcsSchemeInfo"/>
        [Category("Діяльність")]
        [DisplayName("Код схеми переліку операцій - новий")]
        [Description("Нове значення поля Код схеми переліку і обсягу операцій відокремленого підрозділу")]
        [UIUsageTextBox(HorizontalAlignment = "Left", IsMultiline = true, MinWidth = "450", MaxWidth = "650")]
        [UIConditionalVisibility("IsOperationsListingRefChanged")]
        public string OperationsListingRefNew { get { return _OperationsListingRefNew; } set { _OperationsListingRefNew = value; OnPropertyChanged("OperationsListingRefNew"); } }

        private string _OperationsListingRefOld;
        /// <summary>
        /// Значення з полів SchemeID 
        /// колекції OperationsListingSchemes
        /// </summary>
        /// <seealso cref="#BankBranchOpsSvcsSchemeInfo"/>
        [Category("Діяльність")]
        [DisplayName("Код схеми переліку операцій - старий")]
        [Description("Старе значення поля Код схеми переліку і обсягу операцій відокремленого підрозділу")]
        [UIUsageTextBox(HorizontalAlignment = "Left", IsMultiline = true, MinWidth = "450", MaxWidth = "650")]
        [UIConditionalVisibility("IsOperationsListingRefChanged")]
        public string OperationsListingRefOld { get { return _OperationsListingRefOld; } set { _OperationsListingRefOld = value; OnPropertyChanged("OperationsListingRefOld"); } }

        #endregion

        #region Контакти

        private bool _IsDialCodeChanged;
        [Category("Контактні дані")]
        [DisplayName("Код телефонного зв’язку - змінився?")]
        [Description("Чи змінилося значення поля Код телефонного зв’язку?")]
        public bool IsDialCodeChanged { get { return _IsDialCodeChanged; } set { _IsDialCodeChanged = value; OnPropertyChanged("IsDialCodeChanged"); } }

        private string _DialCodeNew;
        [Category("Контактні дані")]
        [DisplayName("Код телефонного зв’язку - новий")]
        [Description("Нове значення поля Код телефонного зв’язку")]
        [UIUsageTextBox(HorizontalAlignment = "Left", IsMultiline = false, MinWidth = "50", MaxWidth = "75")]
        [UIConditionalVisibility("IsDialCodeChanged")]
        public string DialCodeNew { get { return _DialCodeNew; } set { _DialCodeNew = value; OnPropertyChanged("DialCodeNew"); } }
        
        private string _DialCodeOld;
        [Category("Контактні дані")]
        [DisplayName("Код телефонного зв’язку - старий")]
        [Description("Старе значення поля Код телефонного зв’язку")]
        [UIUsageTextBox(HorizontalAlignment = "Left", IsMultiline = false, MinWidth = "50", MaxWidth = "75")]
        [UIConditionalVisibility("IsDialCodeChanged")]
        public string DialCodeOld { get { return _DialCodeOld; } set { _DialCodeOld = value; OnPropertyChanged("DialCodeOld"); } }

        private bool _IsPhoneChanged;
        [Category("Контактні дані")]
        [DisplayName("Телефон(-и) - змінив(-ли)ся?")]
        [Description("Чи змінив(-ли)ся телефон(-и)?")]
        public bool IsPhoneChanged { get { return _IsPhoneChanged; } set { _IsPhoneChanged = value; OnPropertyChanged("IsPhoneChanged"); } }

        private string _PhoneNew;
        [Category("Контактні дані")]
        [DisplayName("Телефон(-и) - новий(-і)")]
        [Description("Нове значення поля Телефон(-и)")]
        [UIUsageTextBox(HorizontalAlignment = "Left", IsMultiline = false, MinWidth = "75", MaxWidth = "150")]
        [UIConditionalVisibility("IsPhoneChanged")]
        public string PhoneNew { get { return _PhoneNew; } set { _PhoneNew = value; OnPropertyChanged("PhoneNew"); } }

        private string _PhoneOld;
        [Category("Контактні дані")]
        [DisplayName("Телефон(-и) - старий(-і)")]
        [Description("Старе значення поля Телефон(-и)")]
        [UIUsageTextBox(HorizontalAlignment = "Left", IsMultiline = false, MinWidth = "75", MaxWidth = "150")]
        [UIConditionalVisibility("IsPhoneChanged")]
        public string PhoneOld { get { return _PhoneOld; } set { _PhoneOld = value; OnPropertyChanged("PhoneOld"); } }

        private bool _IsFaxChanged;
        [Category("Контактні дані")]
        [DisplayName("факс(-и) - змінив(-ли)ся?")]
        [Description("Чи змінив(-ли)ся факс(-и)?")]
        public bool IsFaxChanged { get { return _IsFaxChanged; } set { _IsFaxChanged = value; OnPropertyChanged("IsFaxChanged"); } }

        private string _FaxNew;
        [Category("Контактні дані")]
        [DisplayName("факс(-и) - новий(-і)")]
        [Description("Нове значення поля факс(-и)")]
        [UIUsageTextBox(HorizontalAlignment = "Left", IsMultiline = false, MinWidth = "75", MaxWidth = "150")]
        [UIConditionalVisibility("IsFaxChanged")]
        public string FaxNew { get { return _FaxNew; } set { _FaxNew = value; OnPropertyChanged("FaxNew"); } }

        private string _FaxOld;
        [Category("Контактні дані")]
        [DisplayName("факс(-и) - старий(-і)")]
        [Description("Старе значення поля факс(-и)")]
        [UIUsageTextBox(HorizontalAlignment = "Left", IsMultiline = false, MinWidth = "75", MaxWidth = "150")]
        [UIConditionalVisibility("IsFaxChanged")]
        public string FaxOld { get { return _FaxOld; } set { _FaxOld = value; OnPropertyChanged("FaxOld"); } }

        private bool _IsEmailChanged;
        [Category("Контактні дані")]
        [DisplayName("e-mail(-и) - змінив(-ли)ся?")]
        [Description("Чи змінив(-ли)ся e-mail(-и)?")]
        public bool IsEmailChanged { get { return _IsEmailChanged; } set { _IsEmailChanged = value; OnPropertyChanged("IsEmailChanged"); } }
        
        private string _EmailNew;
        [Category("Контактні дані")]
        [DisplayName("e-mail(-и) - новий(-і)")]
        [Description("Нове значення поля e-mail(-и)")]
        [UIUsageTextBox(HorizontalAlignment = "Left", IsMultiline = false, MinWidth = "100", MaxWidth = "250")]
        [UIConditionalVisibility("IsEmailChanged")]
        public string EmailNew { get { return _EmailNew; } set { _EmailNew = value; OnPropertyChanged("EmailNew"); } }
        
        private string _EmailOld;
        [Category("Контактні дані")]
        [DisplayName("e-mail(-и) - старий(-і)")]
        [Description("Старе значення поля e-mail(-и)")]
        [UIUsageTextBox(HorizontalAlignment = "Left", IsMultiline = false, MinWidth = "100", MaxWidth = "250")]
        [UIConditionalVisibility("IsEmailChanged")]
        public string EmailOld { get { return _EmailOld; } set { _EmailOld = value; OnPropertyChanged("EmailOld"); } }

        private bool _IswwwChanged;
        [Category("Контактні дані")]
        [DisplayName("веб-сайт - змінився?")]
        [Description("Чи змінився веб-сайт?")]
        public bool IswwwChanged { get { return _IswwwChanged; } set { _IswwwChanged = value; OnPropertyChanged("IswwwChanged"); } }

        private string _wwwNew;
        [Category("Контактні дані")]
        [DisplayName("веб-сайт - новий(-і)")]
        [Description("Нове значення поля веб-сайт")]
        [UIUsageTextBox(HorizontalAlignment = "Left", IsMultiline = false, MinWidth = "150", MaxWidth = "250")]
        [UIConditionalVisibility("IswwwChanged")]
        public string wwwNew { get { return _wwwNew; } set { _wwwNew = value; OnPropertyChanged("wwwNew"); } }
        
        private string _wwwOld;
        [Category("Контактні дані")]
        [DisplayName("веб-сайт - старий(-і)")]
        [Description("Старе значення поля веб-сайт")]
        [UIUsageTextBox(HorizontalAlignment = "Left", IsMultiline = false, MinWidth = "150", MaxWidth = "250")]
        [UIConditionalVisibility("IswwwChanged")]
        public string wwwOld { get { return _wwwOld; } set { _wwwOld = value; OnPropertyChanged("wwwOld"); } }
        #endregion

        #region Керівник(-и)

        private bool _IsMgrPositionChanged;
        [Category("Керівники/персонал")]
        [DisplayName("Посада - змінилася?")]
        [Description("Чи змінилася посада керівника?")]
        public bool IsMgrPositionChanged { get { return _IsMgrPositionChanged; } set { _IsMgrPositionChanged = value; OnPropertyChanged("IsMgrPositionChanged"); } }
        
        private string _MgrPositionNew;
        [Category("Керівники/персонал")]
        [DisplayName("Посада - нова")]
        [Description("Нова посада керівника")]
        [UIConditionalVisibility("IsMgrPositionChanged")]
        public string MgrPositionNew { get { return _MgrPositionNew; } set { _MgrPositionNew = value; OnPropertyChanged("MgrPositionNew"); } }

        private string _MgrPositionOld;
        [Category("Керівники/персонал")]
        [DisplayName("Посада - стара")]
        [Description("Стара посада керівника")]
        [UIConditionalVisibility("IsMgrPositionChanged")]
        public string MgrPositionOld { get { return _MgrPositionOld; } set { _MgrPositionOld = value; OnPropertyChanged("MgrPositionOld"); } }

        private bool _IsMgrCountryISO3CodeChanged;
        [Category("Керівники/персонал")]
        [DisplayName("Код країни громадянства - змінився?")]
        [Description("Чи змінився код країни громадянства керівника?")]
        public bool IsMgrCountryISO3CodeChanged { get { return _IsMgrCountryISO3CodeChanged; } set { _IsMgrCountryISO3CodeChanged = value; OnPropertyChanged("IsMgrCountryISO3CodeChanged"); } }

        private string _MgrCountryISO3CodeNew;
        [Category("Керівники/персонал")]
        [DisplayName("Код країни громадянства - новий")]
        [Description("Нове значення поля Код країни громадянства керівника")]
        [UIConditionalVisibility("IsMgrCountryISO3CodeChanged")]
        public string MgrCountryISO3CodeNew { get { return _MgrCountryISO3CodeNew; } set { _MgrCountryISO3CodeNew = value; OnPropertyChanged("MgrCountryISO3CodeNew"); } }

        private string _MgrCountryISO3CodeOld;
        [Category("Керівники/персонал")]
        [DisplayName("Код країни громадянства - старий")]
        [Description("Старе значення поля Код країни громадянства керівника")]
        [UIConditionalVisibility("IsMgrCountryISO3CodeChanged")]
        public string MgrCountryISO3CodeOld { get { return _MgrCountryISO3CodeOld; } set { _MgrCountryISO3CodeOld = value; OnPropertyChanged("MgrCountryISO3CodeOld"); } }

        private bool _IsMgrCountryNameUkrChanged;
        [Category("Керівники/персонал")]
        [DisplayName("Країна громадянства - змінився?")]
        [Description("Чи змінилася назва країни громадянства керівника?")]
        public bool IsMgrCountryNameUkrChanged { get { return _IsMgrCountryNameUkrChanged; } set { _IsMgrCountryNameUkrChanged = value; OnPropertyChanged("IsMgrCountryNameUkrChanged"); } }

        private string _MgrCountryNameUkrNew;
        [Category("Керівники/персонал")]
        [DisplayName("Країна громадянства - нова")]
        [Description("Нове значення поля Країна громадянства керівника")]
        [UIConditionalVisibility("IsMgrCountryNameUkrChanged")]
        public string MgrCountryNameUkrNew { get { return _MgrCountryNameUkrNew; } set { _MgrCountryNameUkrNew = value; OnPropertyChanged("MgrCountryNameUkrNew"); } }

        private string _MgrCountryNameUkrOld;
        [Category("Керівники/персонал")]
        [DisplayName("Країна громадянства - стара")]
        [Description("Старе значення поля Країна громадянства керівника")]
        [UIConditionalVisibility("IsMgrCountryNameUkrChanged")]
        public string MgrCountryNameUkrOld { get { return _MgrCountryNameUkrOld; } set { _MgrCountryNameUkrOld = value; OnPropertyChanged("MgrCountryNameUkrOld"); } }

        private bool _IsMgrSurnameChanged;
        [Category("Керівники/персонал")]
        [DisplayName("Прізвище керівника - змінилося?")]
        [Description("Чи змінилося прізвище керівника?")]
        public bool IsMgrSurnameChanged { get { return _IsMgrSurnameChanged; } set { _IsMgrSurnameChanged = value; OnPropertyChanged("IsMgrSurnameChanged"); } }
        
        private string _MgrSurnameNew;
        [Category("Керівники/персонал")]
        [DisplayName("Прізвище керівника - нове")]
        [Description("Нове значення поля Прізвище керівника")]
        [UIConditionalVisibility("IsMgrSurnameChanged")]
        public string MgrSurnameNew { get { return _MgrSurnameNew; } set { _MgrSurnameNew = value; OnPropertyChanged("MgrSurnameNew"); } }
        
        private string _MgrSurnameOld;
        [Category("Керівники/персонал")]
        [DisplayName("Прізвище керівника - старе")]
        [Description("Старе значення поля Прізвище керівника")]
        [UIConditionalVisibility("IsMgrSurnameChanged")]
        public string MgrSurnameOld { get { return _MgrSurnameOld; } set { _MgrSurnameOld = value; OnPropertyChanged("MgrSurnameOld"); } }

        private bool _IsMgrNameChanged;
        [Category("Керівники/персонал")]
        [DisplayName("Ім'я керівника - змінилося?")]
        [Description("Чи змінилося ім'я керівника?")]
        public bool IsMgrNameChanged { get { return _IsMgrNameChanged; } set { _IsMgrNameChanged = value; OnPropertyChanged("IsMgrNameChanged"); } }

        private string _MgrNameNew;
        [Category("Керівники/персонал")]
        [DisplayName("Ім'я керівника - нове")]
        [Description("Нове значення поля Ім'я керівника")]
        [UIConditionalVisibility("IsMgrNameChanged")]
        public string MgrNameNew { get { return _MgrNameNew; } set { _MgrNameNew = value; OnPropertyChanged("MgrNameNew"); } }

        private string _MgrNameOld;
        [Category("Керівники/персонал")]
        [DisplayName("Ім'я керівника - старе")]
        [Description("Старе значення поля Ім'я керівника")]
        [UIConditionalVisibility("IsMgrNameChanged")]
        public string MgrNameOld { get { return _MgrNameOld; } set { _MgrNameOld = value; OnPropertyChanged("MgrNameOld"); } }

        private bool _IsMgrMiddleNameChanged;
        [Category("Керівники/персонал")]
        [DisplayName("Ім'я по батькові керівника - змінилося?")]
        [Description("Чи змінилося Ім'я по батькові керівника?")]
        public bool IsMgrMiddleNameChanged { get { return _IsMgrMiddleNameChanged; } set { _IsMgrMiddleNameChanged = value; OnPropertyChanged("IsMgrMiddleNameChanged"); } }

        private string _MgrMiddleNameNew;
        [Category("Керівники/персонал")]
        [DisplayName("Ім'я по батькові керівника - нове")]
        [Description("Нове значення поля Ім'я по батькові керівника")]
        [UIConditionalVisibility("IsMgrMiddleNameChanged")]
        public string MgrMiddleNameNew { get { return _MgrMiddleNameNew; } set { _MgrMiddleNameNew = value; OnPropertyChanged("MgrMiddleNameNew"); } }
        
        private string _MgrMiddleNameOld;
        [Category("Керівники/персонал")]
        [DisplayName("Ім'я по батькові керівника - старе")]
        [Description("Старе значення поля Ім'я по батькові керівника")]
        [UIConditionalVisibility("IsMgrMiddleNameChanged")]
        public string MgrMiddleNameOld { get { return _MgrMiddleNameOld; } set { _MgrMiddleNameOld = value; OnPropertyChanged("MgrMiddleNameOld"); } }

        private bool _IsMgrSurnameAtBirthChanged;
        [Category("Керівники/персонал")]
        [DisplayName("Дівоче прізвище керівника - змінилося?")]
        [Description("Чи змінилося Дівоче прізвище керівника?")]
        public bool IsMgrSurnameAtBirthChanged { get { return _IsMgrSurnameAtBirthChanged; } set { _IsMgrSurnameAtBirthChanged = value; OnPropertyChanged("IsMgrSurnameAtBirthChanged"); } }
        
        private string _MgrSurnameAtBirthNew;
        [Category("Керівники/персонал")]
        [DisplayName("Дівоче прізвище керівника - нове")]
        [Description("Нове значення поля Дівоче прізвище керівника")]
        [UIConditionalVisibility("IsMgrSurnameAtBirthChanged")]
        public string MgrSurnameAtBirthNew { get { return _MgrSurnameAtBirthNew; } set { _MgrSurnameAtBirthNew = value; OnPropertyChanged("MgrSurnameAtBirthNew"); } }
        
        private string _MgrSurnameAtBirthOld;
        [Category("Керівники/персонал")]
        [DisplayName("Дівоче прізвище керівника - старе")]
        [Description("Старе значення поля Дівоче прізвище керівника")]
        [UIConditionalVisibility("IsMgrSurnameAtBirthChanged")]
        public string MgrSurnameAtBirthOld { get { return _MgrSurnameAtBirthOld; } set { _MgrSurnameAtBirthOld = value; OnPropertyChanged("MgrSurnameAtBirthOld"); } }

        private bool _IsMgrTaxOrSocSecIDChanged;
        [Category("Керівники/персонал")]
        [DisplayName("ІПН керівника - змінився?")]
        [Description("Чи змінився ІПН керівника?")]
        public bool IsMgrTaxOrSocSecIDChanged { get { return _IsMgrTaxOrSocSecIDChanged; } set { _IsMgrTaxOrSocSecIDChanged = value; OnPropertyChanged("IsMgrTaxOrSocSecIDChanged"); } }
        
        private string _MgrTaxOrSocSecIDNew;
        [Category("Керівники/персонал")]
        [DisplayName("ІПН керівника - новий")]
        [Description("Нове значення поля ІПН керівника")]
        [UIConditionalVisibility("IsMgrTaxOrSocSecIDChanged")]
        public string MgrTaxOrSocSecIDNew { get { return _MgrTaxOrSocSecIDNew; } set { _MgrTaxOrSocSecIDNew = value; OnPropertyChanged("MgrTaxOrSocSecIDNew"); } }
        
        private string _MgrTaxOrSocSecIDOld;
        [Category("Керівники/персонал")]
        [DisplayName("ІПН керівника - старий")]
        [Description("Старе значення поля ІПН керівника")]
        [UIConditionalVisibility("IsMgrTaxOrSocSecIDChanged")]
        public string MgrTaxOrSocSecIDOld { get { return _MgrTaxOrSocSecIDOld; } set { _MgrTaxOrSocSecIDOld = value; OnPropertyChanged("MgrTaxOrSocSecIDOld"); } }

        private bool _IsMgrPassportIDChanged;
        [Category("Керівники/персонал")]
        [DisplayName("Серія № паспорта керівника - змінилися?")]
        [Description("Чи змінилися Серія № паспорта керівника?")]
        public bool IsMgrPassportIDChanged { get { return _IsMgrPassportIDChanged; } set { _IsMgrPassportIDChanged = value; OnPropertyChanged("IsMgrPassportIDChanged"); } }
        
        private string _MgrPassportIDNew;
        [Category("Керівники/персонал")]
        [DisplayName("Серія № паспорта керівника - нові")]
        [Description("Нове значення поля Серія № паспорта керівника")]
        [UIConditionalVisibility("IsMgrPassportIDChanged")]
        public string MgrPassportIDNew { get { return _MgrPassportIDNew; } set { _MgrPassportIDNew = value; OnPropertyChanged("MgrPassportIDNew"); } }
        
        private string _MgrPassportIDOld;
        [Category("Керівники/персонал")]
        [DisplayName("Серія № паспорта керівника - старі")]
        [Description("Старе значення поля Серія № паспорта керівника")]
        [UIConditionalVisibility("IsMgrPassportIDChanged")]
        public string MgrPassportIDOld { get { return _MgrPassportIDOld; } set { _MgrPassportIDOld = value; OnPropertyChanged("MgrPassportIDOld"); } }

        private bool _IsMgrPassIssuedDateChanged;
        [Category("Керівники/персонал")]
        [DisplayName("Дата видачі паспорта керівника - змінилася?")]
        [Description("Чи змінилася Дата видачі паспорта керівника?")]
        public bool IsMgrPassIssuedDateChanged { get { return _IsMgrPassIssuedDateChanged; } set { _IsMgrPassIssuedDateChanged = value; OnPropertyChanged("IsMgrPassIssuedDateChanged"); } }
        
        private DateTime? _MgrPassIssuedDateNew;
        [Category("Керівники/персонал")]
        [DisplayName("Дата видачі паспорта керівника - нова")]
        [Description("Нове значення поля Дата видачі паспорта керівника")]
        [UIConditionalVisibility("IsMgrPassIssuedDateChanged")]
        public DateTime? MgrPassIssuedDateNew { get { return _MgrPassIssuedDateNew; } set { _MgrPassIssuedDateNew = value; OnPropertyChanged("MgrPassIssuedDateNew"); } }
        
        private DateTime? _MgrPassIssuedDateOld;
        [Category("Керівники/персонал")]
        [DisplayName("Дата видачі паспорта керівника - стара")]
        [Description("Старе значення поля Дата видачі паспорта керівника")]
        [UIConditionalVisibility("IsMgrPassIssuedDateChanged")]
        public DateTime? MgrPassIssuedDateOld { get { return _MgrPassIssuedDateOld; } set { _MgrPassIssuedDateOld = value; OnPropertyChanged("MgrPassIssuedDateOld"); } }
       
        #endregion

    }
}
