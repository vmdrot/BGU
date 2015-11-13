using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using Evolvex.Utility.Core.ComponentModelEx;
using System.ComponentModel;

namespace BGU.DRPL.SignificantOwnership.Facade.W32.Dashboards
{
    public class SubjectDashboardBase
    {
        [DisplayName("Ліцензії")]
        [Description("Надані ліцензії")]
        [HasHistory]
        public object LicensesInfo { get; set; }
        [DisplayName("Дозволи та розширення")]
        [Description("Надані дозволи, розширення до ліцензій")]
        [HasHistory]
        public object PermitsInfo { get; set; }
        [DisplayName("Власники")]
        [Description("Структура власності")]
        [HasHistory]
        public object OwnershipStructure { get; set; }
        [DisplayName("Банківські групи")]
        [Description("Належність до банківських груп")]
        [HasHistory]
        public object BankingGroups { get; set; }
        [DisplayName("Мережа")]
        [Description("Філії, відділення, банкомати")]
        [HasHistory]
        public object BranchesNetwork { get; set; }
        [DisplayName("Керівництво")]
        [Description("Відомості про керівництво суб'єкта регуляторного поля")]
        [HasHistory]
        public object Managers { get; set; }
        [DisplayName("Порушення, штрафи, постанови")]
        [Description("Історія виявлених порушень, накладених стягнень, штрафів, постанов про заходи впливу, тощо")]
        public object BreachesFinesPenaltiesEtc { get; set; }
        [DisplayName("Ліцензії")]
        [Description("Надані ліцензії")]
        [HasHistory]
        public object FinancialStatements { get; set; }
        [DisplayName("Рефінансування")]
        [Description("Рефінансування, інші позики чи фінансова підтримка, надана суб'єктові регулятором")]
        [HasHistory]
        public object Refinancing { get; set; }
        [DisplayName("Ризики")]
        [Description("Аналітично-розрахункові відомості, що свідчать про рівень ризиковості діяльності")]
        [HasHistory]
        public object Risks { get; set; }
        [DisplayName("Виконання нормативів")]
        [Description("Відомості про виконання регуляторних нормативів - ліквідності, ризиковості, тощо")]
        [HasHistory]
        public object RegulatoryReqsMet { get; set; }
    }
}
