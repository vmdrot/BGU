using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using BGU.DRPL.SignificantOwnership.Core.Spares.Data;
using System.ComponentModel;
using Evolvex.Utility.Core.ComponentModelEx;

namespace BGU.DRPL.SignificantOwnership.Core.Messages
{
    /// <summary>
    /// Тип-обгортка для повідомлення про структуру власності (участі) банку,
    /// зг. з Постановою № 328 НБУ
    /// Відомості про остаточних ключових учасників у структурі власності банку 
    /// </summary>
    public class BankOwnershipStructureP328MessageBody : IDossierMessageBody
    {

        [DisplayName("Ідентифікація банку")]
        [Description("Однозначна ідентифікація банку-подавача")]
        [Required]
        public BGU.DRPL.SignificantOwnership.Core.Spares.Dict.BankInfo BankRef { get; set; }


        [DisplayName("Станом на ...")]
        [Description("(дата, станом на яку подаються відомості про структуру власності)")]
        [Required]
        public DateTime DateAsOf { get; set; }

        [DisplayName("Перелік кінцевих учасників банку")]
        [Description("Перелік кінцевих учасників (як прямих, так і опосередкованих) у банку")]
        [Required]
        public List<TotalOwnershipDetailsInfoEx> UltimateOwners { get; set; }

        [DisplayName("Відомості про участь осіб в банку")]
        [Description("Розшифровка ланцюжків опосередкованої участі та пряма участь осіб у банку")]
        [Browsable(true)]
        [Required]
        [UIUsageDataGridParams(IsOneColumn = true, OneDataColumnHeader = "Розшифровка чинної власності осіб-фігурантів анкети")]
        public List<OwnershipStructure> OwnershipsHive { get; set; }


        [DisplayName("Зв'язки між особами-фігурантами анкети")]
        [Description("Опис зв'язків між фізичними та юридичними особами, що згадуються у розшифровці ланцюжків участі")]
        [Required]
        [UIUsageDataGridParams(IsOneColumn = true, OneDataColumnHeader = "Опис зв'язку")]
        public List<PersonsAssociation> PersonsLinks { get; set; }

        [DisplayName("Реквізити осіб-фігурантів анкети")]
        [Description("Повна інформація про осіб, що згадуються в анкеті")]
        [Required]
        public List<GenericPersonInfo> MentionedIdentities { get; set; }

        /// <summary>
        /// Як мінімум, має долучатися діаграма власності (участі)
        /// - поки що її надаватиме банк, доки НБУ не розробить 
        /// програмне забезпечення для автоматичної генерації цих діаграм на підставі заповненої інформації
        /// </summary>
        [DisplayName("Додатки")]
        [Description("Додатки")]
        [Required]
        public List<AttachmentInfo> Attachments { get; set; }

        [DisplayName("Підтверджую правдивість інформації?")]
        [Description("Стверджую, що інформація, зазначена в анкеті, є правдивою і повною, та не заперечую проти перевірки Національним банком України її достовірності та повноти.")]
        [Editor(typeof(BGU.DRPL.SignificantOwnership.Core.TypeEditors.BooleanEditor), typeof(System.Drawing.Design.UITypeEditor))]
        [Required]
        public bool IsApplicationInfoAccurateAndTrue { get; set; }

        [DisplayName("Підписант")]
        [Description("Відомості про особу, що підписала анкету")]
        [Required]
        public SignatoryInfo Signatory { get; set; }

        /// <summary>
        /// У цьому полі та його під-об'єктах не 
        /// вимагається заповнювати ідентифікаційні поля (ІПН, паспортні дані, тощо)
        /// </summary>
        [DisplayName("Контакти")]
        [Description("Контактні дані відправника анкети")]
        [Required]
        public ContactInfo ContactPerson { get; set; }

    }
}
