using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.ComponentModel;
using Evolvex.Utility.Core.ComponentModelEx;

namespace BGU.DRPL.SignificantOwnership.Core.Spares.Data
{
    /// <summary>
    /// Інформація про долучення до анкет
    /// </summary>
    [System.ComponentModel.Editor(typeof(BGU.DRPL.SignificantOwnership.Core.TypeEditors.AttachmentInfo_Editor), typeof(System.Drawing.Design.UITypeEditor))]
    public class AttachmentInfo
    {
        
        /// <summary>
        /// Обов'язкове поле
        /// </summary>
        [DisplayName("ID додатку")]
        [Description("Ідентифікатор додатку (унікальний в межах пакету)")]
        [Required]
        public string AttachmentID { get; set; }
        
        /// <summary>
        /// Обов'язкове поле
        /// </summary>
        [DisplayName("Файл")]
        [Description("Назва файлу")]
        [Required]
        public string FileName { get; set; }
        
        /// <summary>
        /// Обов'язкове поле, за змовчанням - Інше
        /// </summary>
        [DisplayName("Тип (з переліку)")]
        [Description("Тип додатку із переліку типових долучень; якщо \"Інше\" - обов'язково вказати, що саме у полі \"Опис файлу\".")]
        [Required]
        public TypicalApplicationAttachement AttachmentType { get; set; }

        /// <summary>
        /// Необов'язкове поле, якщо в AttachmentType != Інше
        /// </summary>
        [DisplayName("Опис файлу")]
        [Description("Що у файлі?")]
        [Multiline]
        public string Description { get; set; }
        
        /// <summary>
        /// Заповнювати самостійно з розширення FileName
        /// Давати можливість користувачу змінити
        /// </summary>
        [DisplayName("Формат")]
        [Description("Тип MIME, напр. pdf, xls, xlsx, doc, docs, rtf, тощо")]
        [Required]
        public string ContentType { get; set; }

        public override string ToString()
        {
            return FileName;
        }
    }
}
