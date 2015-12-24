﻿using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using BGU.DRPL.SignificantOwnership.Core.EKDRBU;
using BGU.DRPL.SignificantOwnership.Core.Spares.Data;

namespace BGU.DRPL.SignificantOwnership.EmpiricalData.Examples
{
    public class Oshchad
    {
        private DRPL.SignificantOwnership.Core.EKDRBU.StateBankBranchRegistryChangePackageV1 _zhytomyrOblastBulkChanges;
        private DRPL.SignificantOwnership.Core.EKDRBU.StateBankBranchRegistryChangePackageV1 _dnpPhoneChanges;


        #region prop(s)
        
        public DRPL.SignificantOwnership.Core.EKDRBU.StateBankBranchRegistryChangePackageV1 ZhytomyrOblastBulkChanges
        {
            get 
            {
                if (_zhytomyrOblastBulkChanges == null)
                {
                    _zhytomyrOblastBulkChanges = GenerateZhytomyrBulkChange();
                }
                return _zhytomyrOblastBulkChanges;
            }
        }

        public DRPL.SignificantOwnership.Core.EKDRBU.StateBankBranchRegistryChangePackageV1 DnpPhoneChanges
        {
            get
            {
                if (_dnpPhoneChanges == null)
                {
                    _dnpPhoneChanges = GenerateDnipropetrovskPhoneChange();
                }
                return _dnpPhoneChanges;
            }
        }

        private StateBankBranchRegistryChangePackageV1 GenerateDnipropetrovskPhoneChange()
        {
            StateBankBranchRegistryChangePackageV1 rslt = new StateBankBranchRegistryChangePackageV1();
            rslt.BankRef = BGU.DRPL.SignificantOwnership.Core.Spares.Dict.BankInfo.AllUABanks.Find(b => b.MFO == "300465");
            //rslt.BankRef = BGU.DRPL.SignificantOwnership.Core.Spares.Dict.BankInfo.AllUABanks.Find(b => b.MFO == "328209");
            rslt.PackageID = "11/4-16/3031-10895";
            rslt.PackageDate = DateTime.Parse("2015-10-20T00:00:00");
            rslt.OperationsListingSchemes = new List<Core.EKDRBU.Spares.BankBranchOpsSvcsSchemeInfo>();
            rslt.ChangingBranches = new List<Core.EKDRBU.Spares.StateBankRegistrySingleBranchChangeRecV1>();
            string headBankDecisionID = "40-111/1151-3506";

            #region fill branches
            rslt.ChangingBranches.Add(new Core.EKDRBU.Spares.StateBankRegistrySingleBranchChangeRecV1() { ChangeType = Core.Spares.BankBranchChangeType.Change, BankBranchRegID = "00626804203608030350", ChangeEffectiveDate = DateTime.Parse("2015-12-17T00:00:00"), Changes = new Core.EKDRBU.Spares.EKDRBUVariableEntryPartV1() { IsPhoneChanged = true, PhoneNew = "350315" }, HeadBankDecisionRefs = new List<string>(new string[] { headBankDecisionID }) });
            rslt.ChangingBranches.Add(new Core.EKDRBU.Spares.StateBankRegistrySingleBranchChangeRecV1() { ChangeType = Core.Spares.BankBranchChangeType.Change, BankBranchRegID = "00626804203608030558", ChangeEffectiveDate = DateTime.Parse("2015-12-17T00:00:00"), Changes = new Core.EKDRBU.Spares.EKDRBUVariableEntryPartV1() { IsPhoneChanged = true, PhoneNew = "710177" }, HeadBankDecisionRefs = new List<string>(new string[] { headBankDecisionID }) });
            rslt.ChangingBranches.Add(new Core.EKDRBU.Spares.StateBankRegistrySingleBranchChangeRecV1() { ChangeType = Core.Spares.BankBranchChangeType.Change, BankBranchRegID = "00626804203608030583", ChangeEffectiveDate = DateTime.Parse("2015-12-17T00:00:00"), Changes = new Core.EKDRBU.Spares.EKDRBUVariableEntryPartV1() { IsDialCodeChanged = true, DialCodeNew = "05692", IsPhoneChanged = true, PhoneNew = "63130" }, HeadBankDecisionRefs = new List<string>(new string[] { headBankDecisionID }) });
            rslt.ChangingBranches.Add(new Core.EKDRBU.Spares.StateBankRegistrySingleBranchChangeRecV1() { ChangeType = Core.Spares.BankBranchChangeType.Change, BankBranchRegID = "00626804203608030630", ChangeEffectiveDate = DateTime.Parse("2015-12-17T00:00:00"), Changes = new Core.EKDRBU.Spares.EKDRBUVariableEntryPartV1() { IsDialCodeChanged = true, DialCodeNew = "056", IsPhoneChanged = true, PhoneNew = "7926425" }, HeadBankDecisionRefs = new List<string>(new string[] { headBankDecisionID }) });
            rslt.ChangingBranches.Add(new Core.EKDRBU.Spares.StateBankRegistrySingleBranchChangeRecV1() { ChangeType = Core.Spares.BankBranchChangeType.Change, BankBranchRegID = "00626804203608030428", ChangeEffectiveDate = DateTime.Parse("2015-12-17T00:00:00"), Changes = new Core.EKDRBU.Spares.EKDRBUVariableEntryPartV1() { IsPhoneChanged = true, PhoneNew = "238083" }, HeadBankDecisionRefs = new List<string>(new string[] { headBankDecisionID }) });
            rslt.ChangingBranches.Add(new Core.EKDRBU.Spares.StateBankRegistrySingleBranchChangeRecV1() { ChangeType = Core.Spares.BankBranchChangeType.Change, BankBranchRegID = "00626804203608030465", ChangeEffectiveDate = DateTime.Parse("2015-12-17T00:00:00"), Changes = new Core.EKDRBU.Spares.EKDRBUVariableEntryPartV1() { IsPhoneChanged = true, PhoneNew = "44344" }, HeadBankDecisionRefs = new List<string>(new string[] { headBankDecisionID }) });
            rslt.ChangingBranches.Add(new Core.EKDRBU.Spares.StateBankRegistrySingleBranchChangeRecV1() { ChangeType = Core.Spares.BankBranchChangeType.Change, BankBranchRegID = "00626804203608030380", ChangeEffectiveDate = DateTime.Parse("2015-12-17T00:00:00"), Changes = new Core.EKDRBU.Spares.EKDRBUVariableEntryPartV1() { IsPhoneChanged = true, PhoneNew = "41480" }, HeadBankDecisionRefs = new List<string>(new string[] { headBankDecisionID }) });
            rslt.ChangingBranches.Add(new Core.EKDRBU.Spares.StateBankRegistrySingleBranchChangeRecV1() { ChangeType = Core.Spares.BankBranchChangeType.Change, BankBranchRegID = "00626804203608030517", ChangeEffectiveDate = DateTime.Parse("2015-12-17T00:00:00"), Changes = new Core.EKDRBU.Spares.EKDRBUVariableEntryPartV1() { IsPhoneChanged = true, PhoneNew = "73591" }, HeadBankDecisionRefs = new List<string>(new string[] { headBankDecisionID }) });
            rslt.ChangingBranches.Add(new Core.EKDRBU.Spares.StateBankRegistrySingleBranchChangeRecV1() { ChangeType = Core.Spares.BankBranchChangeType.Change, BankBranchRegID = "00626804203608030518", ChangeEffectiveDate = DateTime.Parse("2015-12-17T00:00:00"), Changes = new Core.EKDRBU.Spares.EKDRBUVariableEntryPartV1() { IsPhoneChanged = true, PhoneNew = "72552" }, HeadBankDecisionRefs = new List<string>(new string[] { headBankDecisionID }) });
            rslt.ChangingBranches.Add(new Core.EKDRBU.Spares.StateBankRegistrySingleBranchChangeRecV1() { ChangeType = Core.Spares.BankBranchChangeType.Change, BankBranchRegID = "00626804203608030606", ChangeEffectiveDate = DateTime.Parse("2015-12-17T00:00:00"), Changes = new Core.EKDRBU.Spares.EKDRBUVariableEntryPartV1() { IsPhoneChanged = true, PhoneNew = "334237" }, HeadBankDecisionRefs = new List<string>(new string[] { headBankDecisionID }) });
            rslt.ChangingBranches.Add(new Core.EKDRBU.Spares.StateBankRegistrySingleBranchChangeRecV1() { ChangeType = Core.Spares.BankBranchChangeType.Change, BankBranchRegID = "00626804203608030608", ChangeEffectiveDate = DateTime.Parse("2015-12-17T00:00:00"), Changes = new Core.EKDRBU.Spares.EKDRBUVariableEntryPartV1() { IsDialCodeChanged = true, DialCodeNew = "0562", IsPhoneChanged = true, PhoneNew = "334237" }, HeadBankDecisionRefs = new List<string>(new string[] { headBankDecisionID }) });
            rslt.ChangingBranches.Add(new Core.EKDRBU.Spares.StateBankRegistrySingleBranchChangeRecV1() { ChangeType = Core.Spares.BankBranchChangeType.Change, BankBranchRegID = "00626804203608030616", ChangeEffectiveDate = DateTime.Parse("2015-12-17T00:00:00"), Changes = new Core.EKDRBU.Spares.EKDRBUVariableEntryPartV1() { IsPhoneChanged = true, PhoneNew = "334237" }, HeadBankDecisionRefs = new List<string>(new string[] { headBankDecisionID }) });
            rslt.ChangingBranches.Add(new Core.EKDRBU.Spares.StateBankRegistrySingleBranchChangeRecV1() { ChangeType = Core.Spares.BankBranchChangeType.Change, BankBranchRegID = "00626804203608030618", ChangeEffectiveDate = DateTime.Parse("2015-12-17T00:00:00"), Changes = new Core.EKDRBU.Spares.EKDRBUVariableEntryPartV1() { IsPhoneChanged = true, PhoneNew = "349555" }, HeadBankDecisionRefs = new List<string>(new string[] { headBankDecisionID }) });
            rslt.ChangingBranches.Add(new Core.EKDRBU.Spares.StateBankRegistrySingleBranchChangeRecV1() { ChangeType = Core.Spares.BankBranchChangeType.Change, BankBranchRegID = "00626804203608030491", ChangeEffectiveDate = DateTime.Parse("2015-12-17T00:00:00"), Changes = new Core.EKDRBU.Spares.EKDRBUVariableEntryPartV1() { IsDialCodeChanged = true, DialCodeNew = "067", IsPhoneChanged = true, PhoneNew = "6118090" }, HeadBankDecisionRefs = new List<string>(new string[] { headBankDecisionID }) });
            #endregion

            rslt.RequirementsKept = true;
            rslt.RequirementsKeptDetails = "";

            rslt.Attachments = new List<Core.Spares.Data.AttachmentInfo>();
            #region fill attachments
            rslt.Attachments.Add(new AttachmentInfo() { AttachmentID = headBankDecisionID, AttachmentType = Core.Spares.TypicalApplicationAttachement.InternalReglementCopiesScans, ContentType = "pdf", FileName = "RishNBU_40-111_1151-3506.pdf" });
            #endregion

            #region Signature etc.
            rslt.Signor = new SignatoryInfo() { SignatoryPosition = "Заступник голови правління", SurnameInitials = "А.О.Тютюн" };
            rslt.PreparedBy = new ContactInfo() { Person = new Core.Spares.Dict.PhysicalPersonInfo() { FullName = "Ткач В.Д." }, Phones = new List<PhoneInfo>(new PhoneInfo[] { new PhoneInfo() { PhoneNr = "249-31-15" } }) };
            #endregion

            return rslt;
        }
        #endregion

        #region method(s)

        private StateBankBranchRegistryChangePackageV1 GenerateZhytomyrBulkChange()
        {
            StateBankBranchRegistryChangePackageV1 rslt = new StateBankBranchRegistryChangePackageV1();
            rslt.BankRef = BGU.DRPL.SignificantOwnership.Core.Spares.Dict.BankInfo.AllUABanks.Find(b => b.MFO == "300465");
            //rslt.BankRef = BGU.DRPL.SignificantOwnership.Core.Spares.Dict.BankInfo.AllUABanks.Find(b => b.MFO == "328209");
            rslt.PackageID = "11/4-16/3031-10895";
            rslt.PackageDate = DateTime.Parse("2015-10-20T00:00:00");
            rslt.OperationsListingSchemes = new List<Core.EKDRBU.Spares.BankBranchOpsSvcsSchemeInfo>();
            
            #region fill schemes
rslt.OperationsListingSchemes.Add(new Core.EKDRBU.Spares.BankBranchOpsSvcsSchemeInfo() {SchemeID = "A" , OperationsListingText = @"Залучення у вклади (депозити) коштів та банківських металів від необмеженого кола юридичних і фізичних осіб.
У частині: залучення (відкриття та ведення рахунків) у вклади (депозити) коштів  від юридичних (крім банків) і необмеженого кола фізичних осіб.
Відкриття та ведення поточних (кореспондентських) рахунків клієнтів, у тому числі у банківських металах.
У частині: відкриття  та ведення поточних рахунків клієнтів - юридичних та фізичних осіб.
Розміщення залучених у вклади (депозити), у тому числі на поточні рахунки, коштів та банківських металів від свого імені, на власних умовах та на власний ризик.
У частині: розміщення серед юридичних осіб (крім банків), фізичних осіб-підприємців та фізичних осіб залучених у вклади (депозити), у тому числі на поточні рахунки, коштів від імені Банку, на умовах, встановлених Банком, та на ризик Банку, крім прийняття рішення про: надання кредиту та умови такого кредитування, зміну умов кредитування, визнання заборгованості за кредитною операцією проблемною, списання безнадійної заборгованості за кредитною операцією.
Переказ коштів.
У частині: переказ коштів в грошовій одиниці України.
Випуск платіжних документів, платіжних карток, дорожніх чеків та/або їх обслуговування, кліринг, інші форми забезпечення розрахунків.
У частині: відкриття та ведення карткових рахунків юридичним (крім банків) та фізичним особам, видача та обслуговування банківських платіжних карток.
Послуги у сфері страхування та у системі накопичувального пенсійного забезпечення.
У частині: виконання функції страхового посередника.
Випуск власних цінних паперів.
У частині: розміщення та обслуговування цінних паперів, емітованих банком.
Випуск, розповсюдження та проведення лотерей.
У частині: розповсюдження та проведення державної грошової лотереї.
Надання консультаційних та інформаційних послуг щодо банківських та інших фінансових послуг.
Неторговельні операції з валютними цінностями.
Операції з готівковою іноземною валютою та чеками (купівля, продаж, обмін, прийняття на інкасо), що здійснюються в касах і пунктах обміну іноземної валюти банків.
У частині: операції з готівковою іноземною валютою та чеками (купівля, продаж, обмін, прийняття на інкасо), що здійснюються в касі установи Банку.
Ведення рахунків клієнтів (резидентів та нерезидентів) в іноземній валюті та клієнтів-нерезидентів у грошовій одиниці України.
У частині: відкриття та ведення рахунків клієнтів (крім банків - резидентів та нерезидентів) в іноземній валюті та клієнтів-нерезидентів (крім банків) у грошовій одиниці України.
Залучення та розміщення іноземної валюти на валютному ринку України.
У частині: залучення (відкриття та ведення вкладів (депозитів) клієнтів - юридичних (крім банків) та фізичних осіб) іноземної валюти на валютному ринку України.
У частині: розміщення іноземної валюти серед юридичних осіб (крім банків) та фізичних осіб-підприємців на валютному ринку України від імені Банку, на умовах, встановлених Банком, та на ризик Банку, крім прийняття рішення про: надання кредиту та умови такого кредитування, зміну умов кредитування, визнання заборгованості за кредитною операцією проблемною, списання безнадійної заборгованості за кредитною операцією.
Торгівля банківськими металами на валютному ринку України.
У частині: 
- продаж банківських металів за гривні;
- купівля банківських металів за гривні, операції з якими здійснювались раніше в установі Банку без вилучення їх клієнтом із каси (сховища) установи Банку.
Відповідальне зберігання банківських металів у власному сховищі.
У частині: відповідальне зберігання банківських металів у власному сховищі, операції з якими здійснювались раніше в установі банку без вилучення їх клієнтом з каси (сховища) установи Банку.
Залучення та розміщення банківських металів на валютному ринку України.
У частині: залучення (відкриття та ведення поточних рахунків і вкладів (депозитів) клієнтів-юридичних (крім банків) та фізичних осіб) банківських металів на валютному ринку України.
" });
rslt.OperationsListingSchemes.Add(new Core.EKDRBU.Spares.BankBranchOpsSvcsSchemeInfo() {SchemeID = "B" , OperationsListingText = @"Залучення у вклади (депозити) коштів та банківських металів від необмеженого кола юридичних і фізичних осіб.
У частині: залучення (відкриття та ведення рахунків) у вклади (депозити) коштів  від юридичних (крім банків) і необмеженого кола фізичних осіб.
Відкриття та ведення поточних (кореспондентських) рахунків клієнтів, у тому числі у банківських металах.
У частині: відкриття  та ведення поточних рахунків клієнтів - юридичних та фізичних осіб.
Розміщення залучених у вклади (депозити), у тому числі на поточні рахунки, коштів та банківських металів від свого імені, на власних умовах та на власний ризик.
У частині: розміщення серед юридичних осіб (крім банків), фізичних осіб-підприємців та фізичних осіб залучених у вклади (депозити), у тому числі на поточні рахунки, коштів від імені Банку, на умовах, встановлених Банком, та на ризик Банку, крім прийняття рішення про: надання кредиту та умови такого кредитування, зміну умов кредитування, визнання заборгованості за кредитною операцією проблемною, списання безнадійної заборгованості за кредитною операцією.
Переказ коштів.
У частині: переказ коштів в грошовій одиниці України.
Випуск платіжних документів, платіжних карток, дорожніх чеків та/або їх обслуговування, кліринг, інші форми забезпечення розрахунків.
У частині: відкриття та ведення карткових рахунків юридичним (крім банків) та фізичним особам, видача та обслуговування банківських платіжних карток.
Послуги у сфері страхування та у системі накопичувального пенсійного забезпечення.
У частині: виконання функції страхового посередника.
Випуск власних цінних паперів.
У частині: розміщення та обслуговування цінних паперів, емітованих банком.
Випуск, розповсюдження та проведення лотерей.
У частині: розповсюдження та проведення державної грошової лотереї.
Зберігання цінностей або надання в майновий найм (оренду) індивідуального банківського сейфа.
У частині: зберігання цінностей у власному сховищі. 
Надання консультаційних та інформаційних послуг щодо банківських та інших фінансових послуг.
Неторговельні операції з валютними цінностями.
Операції з готівковою іноземною валютою та чеками (купівля, продаж, обмін, прийняття на інкасо), що здійснюються в касах і пунктах обміну іноземної валюти банків.
У частині: операції з готівковою іноземною валютою та чеками (купівля, продаж, обмін, прийняття на інкасо), що здійснюються в касі установи Банку.
Ведення рахунків клієнтів (резидентів та нерезидентів) в іноземній валюті та клієнтів-нерезидентів у грошовій одиниці України.
У частині: відкриття та ведення рахунків клієнтів (крім банків - резидентів та нерезидентів) в іноземній валюті та клієнтів-нерезидентів (крім банків) у грошовій одиниці України.
Залучення та розміщення іноземної валюти на валютному ринку України.
У частині: залучення (відкриття та ведення вкладів (депозитів) клієнтів - юридичних (крім банків) та фізичних осіб) іноземної валюти на валютному ринку України.
У частині: розміщення іноземної валюти серед юридичних осіб (крім банків) та фізичних осіб-підприємців на валютному ринку України від імені Банку, на умовах, встановлених Банком, та на ризик Банку, крім прийняття рішення про: надання кредиту та умови такого кредитування, зміну умов кредитування, визнання заборгованості за кредитною операцією проблемною, списання безнадійної заборгованості за кредитною операцією.
Торгівля банківськими металами на валютному ринку України.
У частині: 
- продаж банківських металів за гривні;
- купівля банківських металів за гривні, операції з якими здійснювались раніше в установі Банку без вилучення їх клієнтом із каси (сховища) установи Банку.
Відповідальне зберігання банківських металів у власному сховищі.
У частині: відповідальне зберігання банківських металів у власному сховищі, операції з якими здійснювались раніше в установі банку без вилучення їх клієнтом з каси (сховища) установи Банку.
Залучення та розміщення банківських металів на валютному ринку України.
У частині: залучення (відкриття та ведення поточних рахунків і вкладів (депозитів) клієнтів-юридичних (крім банків) та фізичних осіб) банківських металів на валютному ринку України.

" });
rslt.OperationsListingSchemes.Add(new Core.EKDRBU.Spares.BankBranchOpsSvcsSchemeInfo() {SchemeID = "C" , OperationsListingText = @"Залучення у вклади (депозити) коштів та банківських металів від необмеженого кола юридичних і фізичних осіб.
У частині: залучення (відкриття та ведення рахунків) у вклади (депозити) коштів від необмеженого кола фізичних осіб.
Відкриття та ведення поточних (кореспондентських) рахунків клієнтів, у тому числі у банківських металах.
У частині: відкриття та ведення поточних рахунків клієнтів - фізичних осіб.
Розміщення залучених у вклади (депозити), у тому числі на поточні рахунки, коштів та банківських металів від свого імені, на власних умовах та на власний ризик.
У частині: розміщення серед фізичних осіб залучених у вклади (депозити), у тому числі на поточні рахунки, коштів від імені Банку, на умовах встановлених Банком та на ризик Банку, крім прийняття рішення про: надання кредиту та умови такого кредитування, зміну умов кредитування, визнання заборгованості за кредитною операцією проблемною, списання безнадійної заборгованості за кредитною операцією.
Переказ коштів.
У частині: переказ коштів в грошовій одиниці України.
Випуск платіжних документів, платіжних карток, дорожніх чеків та/або їх обслуговування, кліринг, інші форми забезпечення розрахунків.
У частині: відкриття та ведення карткових рахунків фізичним особам, видача та обслуговування банківських платіжних карток.
Послуги у сфері страхування та у системі накопичувального пенсійного забезпечення.
У частині: виконання функції страхового посередника.
Випуск власних цінних паперів.
У частині: розміщення та обслуговування цінних паперів, емітованих банком.
Випуск, розповсюдження та проведення лотерей.
У частині: розповсюдження та проведення державної грошової лотереї.
Надання консультаційних та інформаційних послуг щодо банківських та інших фінансових послуг.
Неторговельні операції з валютними цінностями.
У частині: неторговельні операції з валютними цінностями фізичних осіб.
Операції з готівковою іноземною валютою та чеками (купівля, продаж, обмін, прийняття на інкасо), що здійснюються в касах і пунктах обміну іноземної валюти банків.
У частині: операції з готівковою іноземною валютою та чеками (купівля, продаж, обмін, прийняття на інкасо), що здійснюються в касі установи Банку.
Ведення рахунків клієнтів (резидентів та нерезидентів) в іноземній валюті та клієнтів-нерезидентів у грошовій одиниці України.
У частині: відкриття та ведення рахунків клієнтів (резидентів та нерезидентів) фізичних осіб в іноземній валюті та клієнтів-нерезидентів фізичних осіб у грошовій одиниці України. 
Залучення та розміщення іноземної валюти на валютному ринку України.
У частині: залучення (відкриття та ведення вкладів (депозитів) клієнтів - фізичних осіб) іноземної валюти на валютному ринку України.
Торгівля банківськими металами на валютному ринку України.
У частині: 
 продаж банківських металів за гривні;
 купівля банківських металів за гривні, операції з якими здійснювались раніше в установі Банку без вилучення їх клієнтом із каси (сховища) установи Банку.
Залучення та розміщення банківських металів на валютному ринку України.
У частині: залучення (відкриття та ведення поточних рахунків і вкладів (депозитів)  клієнтів-фізичних осіб) банківських металів на валютному ринку України.

" });
rslt.OperationsListingSchemes.Add(new Core.EKDRBU.Spares.BankBranchOpsSvcsSchemeInfo() {SchemeID = "D" , OperationsListingText = @"Залучення у вклади (депозити) коштів та банківських металів від необмеженого кола юридичних і фізичних осіб.
У частині: залучення (відкриття та ведення рахунків) у вклади (депозити) коштів від необмеженого кола фізичних осіб.
Відкриття та ведення поточних (кореспондентських) рахунків клієнтів, у тому числі у банківських металах.
У частині: відкриття та ведення поточних рахунків клієнтів - фізичних осіб.
Розміщення залучених у вклади (депозити), у тому числі на поточні рахунки, коштів та банківських металів від свого імені, на власних умовах та на власний ризик.
У частині: розміщення серед фізичних осіб залучених у вклади (депозити), у тому числі на поточні рахунки, коштів від імені Банку, на умовах встановлених Банком та на ризик Банку, крім прийняття рішення про: надання кредиту та умови такого кредитування, зміну умов кредитування, визнання заборгованості за кредитною операцією проблемною, списання безнадійної заборгованості за кредитною операцією.
Переказ коштів.
У частині: переказ коштів в грошовій одиниці України.
Випуск платіжних документів, платіжних карток, дорожніх чеків та/або їх обслуговування, кліринг, інші форми забезпечення розрахунків.
У частині: відкриття та ведення карткових рахунків фізичним особам, видача та обслуговування банківських платіжних карток.
Послуги у сфері страхування та у системі накопичувального пенсійного забезпечення.
У частині: виконання функції страхового посередника.
Випуск, розповсюдження та проведення лотерей.
У частині: розповсюдження та проведення державної грошової лотереї.
Надання консультаційних та інформаційних послуг щодо банківських та інших фінансових послуг.
Неторговельні операції з валютними цінностями.
У частині: неторговельні операції з валютними цінностями фізичних осіб.
Операції з готівковою іноземною валютою та чеками (купівля, продаж, обмін, прийняття на інкасо), що здійснюються в касах і пунктах обміну іноземної валюти банків.
У частині: операції з готівковою іноземною валютою (купівля, продаж, обмін, прийняття на інкасо), що здійснюються в касі установи Банку.
Ведення рахунків клієнтів (резидентів та нерезидентів) в іноземній валюті та клієнтів-нерезидентів у грошовій одиниці України.
У частині: відкриття та ведення рахунків клієнтів (резидентів та нерезидентів) фізичних осіб в іноземній валюті та клієнтів-нерезидентів фізичних осіб у грошовій одиниці України. 
Залучення та розміщення іноземної валюти на валютному ринку України.
У частині: залучення (відкриття та ведення вкладів (депозитів) клієнтів - фізичних осіб) іноземної валюти на валютному ринку України.
Торгівля банківськими металами на валютному ринку України.
У частині: 
- продаж банківських металів за гривні.
" });
            #endregion
            
            rslt.ChangingBranches = new List<Core.EKDRBU.Spares.StateBankRegistrySingleBranchChangeRecV1>();
            string headBankDecisionID = "PP910d20151007";
            #region fill branches
            rslt.ChangingBranches.Add(new Core.EKDRBU.Spares.StateBankRegistrySingleBranchChangeRecV1() { ChangeType = Core.Spares.BankBranchChangeType.Change, BankBranchRegID = "00626804205603050001", ChangeEffectiveDate = DateTime.Parse("2015-11-19T00:00:00"), Changes = new Core.EKDRBU.Spares.EKDRBUVariableEntryPartV1() { IsOperationsListingRefChanged = true, OperationsListingRefNew = "B" }, HeadBankDecisionRefs = new List<string>(new string[] { headBankDecisionID }) });
            rslt.ChangingBranches.Add(new Core.EKDRBU.Spares.StateBankRegistrySingleBranchChangeRecV1() { ChangeType = Core.Spares.BankBranchChangeType.Change, BankBranchRegID = "00626804205603050002", ChangeEffectiveDate = DateTime.Parse("2015-11-19T00:00:00"), Changes = new Core.EKDRBU.Spares.EKDRBUVariableEntryPartV1() { IsOperationsListingRefChanged = true, OperationsListingRefNew = "C" }, HeadBankDecisionRefs = new List<string>(new string[] { headBankDecisionID }) });
            rslt.ChangingBranches.Add(new Core.EKDRBU.Spares.StateBankRegistrySingleBranchChangeRecV1() { ChangeType = Core.Spares.BankBranchChangeType.Change, BankBranchRegID = "00626804205603050003", ChangeEffectiveDate = DateTime.Parse("2015-11-19T00:00:00"), Changes = new Core.EKDRBU.Spares.EKDRBUVariableEntryPartV1() { IsOperationsListingRefChanged = true, OperationsListingRefNew = "B" }, HeadBankDecisionRefs = new List<string>(new string[] { headBankDecisionID }) });
            rslt.ChangingBranches.Add(new Core.EKDRBU.Spares.StateBankRegistrySingleBranchChangeRecV1() { ChangeType = Core.Spares.BankBranchChangeType.Change, BankBranchRegID = "00626804205603050004", ChangeEffectiveDate = DateTime.Parse("2015-11-19T00:00:00"), Changes = new Core.EKDRBU.Spares.EKDRBUVariableEntryPartV1() { IsOperationsListingRefChanged = true, OperationsListingRefNew = "C" }, HeadBankDecisionRefs = new List<string>(new string[] { headBankDecisionID }) });
            rslt.ChangingBranches.Add(new Core.EKDRBU.Spares.StateBankRegistrySingleBranchChangeRecV1() { ChangeType = Core.Spares.BankBranchChangeType.Change, BankBranchRegID = "00626804205603050005", ChangeEffectiveDate = DateTime.Parse("2015-11-19T00:00:00"), Changes = new Core.EKDRBU.Spares.EKDRBUVariableEntryPartV1() { IsOperationsListingRefChanged = true, OperationsListingRefNew = "C" }, HeadBankDecisionRefs = new List<string>(new string[] { headBankDecisionID }) });
            rslt.ChangingBranches.Add(new Core.EKDRBU.Spares.StateBankRegistrySingleBranchChangeRecV1() { ChangeType = Core.Spares.BankBranchChangeType.Change, BankBranchRegID = "00626804205603050006", ChangeEffectiveDate = DateTime.Parse("2015-11-19T00:00:00"), Changes = new Core.EKDRBU.Spares.EKDRBUVariableEntryPartV1() { IsOperationsListingRefChanged = true, OperationsListingRefNew = "D" }, HeadBankDecisionRefs = new List<string>(new string[] { headBankDecisionID }) });
            rslt.ChangingBranches.Add(new Core.EKDRBU.Spares.StateBankRegistrySingleBranchChangeRecV1() { ChangeType = Core.Spares.BankBranchChangeType.Change, BankBranchRegID = "00626804205603050007", ChangeEffectiveDate = DateTime.Parse("2015-10-22T00:00:00"), Changes = new Core.EKDRBU.Spares.EKDRBUVariableEntryPartV1() { IsOperationsListingRefChanged = true, OperationsListingRefNew = "A" }, HeadBankDecisionRefs = new List<string>(new string[] { headBankDecisionID }) });
            rslt.ChangingBranches.Add(new Core.EKDRBU.Spares.StateBankRegistrySingleBranchChangeRecV1() { ChangeType = Core.Spares.BankBranchChangeType.Change, BankBranchRegID = "00626804205603050008", ChangeEffectiveDate = DateTime.Parse("2015-11-19T00:00:00"), Changes = new Core.EKDRBU.Spares.EKDRBUVariableEntryPartV1() { IsOperationsListingRefChanged = true, OperationsListingRefNew = "C" }, HeadBankDecisionRefs = new List<string>(new string[] { headBankDecisionID }) });
            rslt.ChangingBranches.Add(new Core.EKDRBU.Spares.StateBankRegistrySingleBranchChangeRecV1() { ChangeType = Core.Spares.BankBranchChangeType.Change, BankBranchRegID = "00626804205603050009", ChangeEffectiveDate = DateTime.Parse("2015-11-19T00:00:00"), Changes = new Core.EKDRBU.Spares.EKDRBUVariableEntryPartV1() { IsOperationsListingRefChanged = true, OperationsListingRefNew = "C" }, HeadBankDecisionRefs = new List<string>(new string[] { headBankDecisionID }) });
            rslt.ChangingBranches.Add(new Core.EKDRBU.Spares.StateBankRegistrySingleBranchChangeRecV1() { ChangeType = Core.Spares.BankBranchChangeType.Change, BankBranchRegID = "00626804205603050010", ChangeEffectiveDate = DateTime.Parse("2015-10-22T00:00:00"), Changes = new Core.EKDRBU.Spares.EKDRBUVariableEntryPartV1() { IsOperationsListingRefChanged = true, OperationsListingRefNew = "A" }, HeadBankDecisionRefs = new List<string>(new string[] { headBankDecisionID }) });
            rslt.ChangingBranches.Add(new Core.EKDRBU.Spares.StateBankRegistrySingleBranchChangeRecV1() { ChangeType = Core.Spares.BankBranchChangeType.Change, BankBranchRegID = "00626804205603050011", ChangeEffectiveDate = DateTime.Parse("2015-11-03T00:00:00"), Changes = new Core.EKDRBU.Spares.EKDRBUVariableEntryPartV1() { IsOperationsListingRefChanged = true, OperationsListingRefNew = "B" }, HeadBankDecisionRefs = new List<string>(new string[] { headBankDecisionID }) });
            rslt.ChangingBranches.Add(new Core.EKDRBU.Spares.StateBankRegistrySingleBranchChangeRecV1() { ChangeType = Core.Spares.BankBranchChangeType.Change, BankBranchRegID = "00626804205603050012", ChangeEffectiveDate = DateTime.Parse("2015-11-03T00:00:00"), Changes = new Core.EKDRBU.Spares.EKDRBUVariableEntryPartV1() { IsOperationsListingRefChanged = true, OperationsListingRefNew = "A" }, HeadBankDecisionRefs = new List<string>(new string[] { headBankDecisionID }) });
            rslt.ChangingBranches.Add(new Core.EKDRBU.Spares.StateBankRegistrySingleBranchChangeRecV1() { ChangeType = Core.Spares.BankBranchChangeType.Change, BankBranchRegID = "00626804205603050013", ChangeEffectiveDate = DateTime.Parse("2015-11-19T00:00:00"), Changes = new Core.EKDRBU.Spares.EKDRBUVariableEntryPartV1() { IsOperationsListingRefChanged = true, OperationsListingRefNew = "C" }, HeadBankDecisionRefs = new List<string>(new string[] { headBankDecisionID }) });
            rslt.ChangingBranches.Add(new Core.EKDRBU.Spares.StateBankRegistrySingleBranchChangeRecV1() { ChangeType = Core.Spares.BankBranchChangeType.Change, BankBranchRegID = "00626804205603050014", ChangeEffectiveDate = DateTime.Parse("2015-11-03T00:00:00"), Changes = new Core.EKDRBU.Spares.EKDRBUVariableEntryPartV1() { IsOperationsListingRefChanged = true, OperationsListingRefNew = "A" }, HeadBankDecisionRefs = new List<string>(new string[] { headBankDecisionID }) });
            rslt.ChangingBranches.Add(new Core.EKDRBU.Spares.StateBankRegistrySingleBranchChangeRecV1() { ChangeType = Core.Spares.BankBranchChangeType.Change, BankBranchRegID = "00626804205603050015", ChangeEffectiveDate = DateTime.Parse("2015-11-19T00:00:00"), Changes = new Core.EKDRBU.Spares.EKDRBUVariableEntryPartV1() { IsOperationsListingRefChanged = true, OperationsListingRefNew = "C" }, HeadBankDecisionRefs = new List<string>(new string[] { headBankDecisionID }) });
            rslt.ChangingBranches.Add(new Core.EKDRBU.Spares.StateBankRegistrySingleBranchChangeRecV1() { ChangeType = Core.Spares.BankBranchChangeType.Change, BankBranchRegID = "00626804205603050016", ChangeEffectiveDate = DateTime.Parse("2015-11-03T00:00:00"), Changes = new Core.EKDRBU.Spares.EKDRBUVariableEntryPartV1() { IsOperationsListingRefChanged = true, OperationsListingRefNew = "A" }, HeadBankDecisionRefs = new List<string>(new string[] { headBankDecisionID }) });
            rslt.ChangingBranches.Add(new Core.EKDRBU.Spares.StateBankRegistrySingleBranchChangeRecV1() { ChangeType = Core.Spares.BankBranchChangeType.Change, BankBranchRegID = "00626804205603050017", ChangeEffectiveDate = DateTime.Parse("2015-10-27T00:00:00"), Changes = new Core.EKDRBU.Spares.EKDRBUVariableEntryPartV1() { IsOperationsListingRefChanged = true, OperationsListingRefNew = "A" }, HeadBankDecisionRefs = new List<string>(new string[] { headBankDecisionID }) });
            rslt.ChangingBranches.Add(new Core.EKDRBU.Spares.StateBankRegistrySingleBranchChangeRecV1() { ChangeType = Core.Spares.BankBranchChangeType.Change, BankBranchRegID = "00626804205603050018", ChangeEffectiveDate = DateTime.Parse("2015-11-19T00:00:00"), Changes = new Core.EKDRBU.Spares.EKDRBUVariableEntryPartV1() { IsOperationsListingRefChanged = true, OperationsListingRefNew = "C" }, HeadBankDecisionRefs = new List<string>(new string[] { headBankDecisionID }) });
            rslt.ChangingBranches.Add(new Core.EKDRBU.Spares.StateBankRegistrySingleBranchChangeRecV1() { ChangeType = Core.Spares.BankBranchChangeType.Change, BankBranchRegID = "00626804205603050019", ChangeEffectiveDate = DateTime.Parse("2015-11-19T00:00:00"), Changes = new Core.EKDRBU.Spares.EKDRBUVariableEntryPartV1() { IsOperationsListingRefChanged = true, OperationsListingRefNew = "A" }, HeadBankDecisionRefs = new List<string>(new string[] { headBankDecisionID }) });
            rslt.ChangingBranches.Add(new Core.EKDRBU.Spares.StateBankRegistrySingleBranchChangeRecV1() { ChangeType = Core.Spares.BankBranchChangeType.Change, BankBranchRegID = "00626804205603050020", ChangeEffectiveDate = DateTime.Parse("2015-10-27T00:00:00"), Changes = new Core.EKDRBU.Spares.EKDRBUVariableEntryPartV1() { IsOperationsListingRefChanged = true, OperationsListingRefNew = "A" }, HeadBankDecisionRefs = new List<string>(new string[] { headBankDecisionID }) });
            rslt.ChangingBranches.Add(new Core.EKDRBU.Spares.StateBankRegistrySingleBranchChangeRecV1() { ChangeType = Core.Spares.BankBranchChangeType.Change, BankBranchRegID = "00626804205603050021", ChangeEffectiveDate = DateTime.Parse("2015-11-19T00:00:00"), Changes = new Core.EKDRBU.Spares.EKDRBUVariableEntryPartV1() { IsOperationsListingRefChanged = true, OperationsListingRefNew = "C" }, HeadBankDecisionRefs = new List<string>(new string[] { headBankDecisionID }) });
            rslt.ChangingBranches.Add(new Core.EKDRBU.Spares.StateBankRegistrySingleBranchChangeRecV1() { ChangeType = Core.Spares.BankBranchChangeType.Change, BankBranchRegID = "00626804205603050022", ChangeEffectiveDate = DateTime.Parse("2015-10-27T00:00:00"), Changes = new Core.EKDRBU.Spares.EKDRBUVariableEntryPartV1() { IsOperationsListingRefChanged = true, OperationsListingRefNew = "B" }, HeadBankDecisionRefs = new List<string>(new string[] { headBankDecisionID }) });
            rslt.ChangingBranches.Add(new Core.EKDRBU.Spares.StateBankRegistrySingleBranchChangeRecV1() { ChangeType = Core.Spares.BankBranchChangeType.Change, BankBranchRegID = "00626804205603050023", ChangeEffectiveDate = DateTime.Parse("2015-11-05T00:00:00"), Changes = new Core.EKDRBU.Spares.EKDRBUVariableEntryPartV1() { IsOperationsListingRefChanged = true, OperationsListingRefNew = "B" }, HeadBankDecisionRefs = new List<string>(new string[] { headBankDecisionID }) });
            rslt.ChangingBranches.Add(new Core.EKDRBU.Spares.StateBankRegistrySingleBranchChangeRecV1() { ChangeType = Core.Spares.BankBranchChangeType.Change, BankBranchRegID = "00626804205603050024", ChangeEffectiveDate = DateTime.Parse("2015-11-19T00:00:00"), Changes = new Core.EKDRBU.Spares.EKDRBUVariableEntryPartV1() { IsOperationsListingRefChanged = true, OperationsListingRefNew = "C" }, HeadBankDecisionRefs = new List<string>(new string[] { headBankDecisionID }) });
            rslt.ChangingBranches.Add(new Core.EKDRBU.Spares.StateBankRegistrySingleBranchChangeRecV1() { ChangeType = Core.Spares.BankBranchChangeType.Change, BankBranchRegID = "00626804205603050025", ChangeEffectiveDate = DateTime.Parse("2015-11-19T00:00:00"), Changes = new Core.EKDRBU.Spares.EKDRBUVariableEntryPartV1() { IsOperationsListingRefChanged = true, OperationsListingRefNew = "D" }, HeadBankDecisionRefs = new List<string>(new string[] { headBankDecisionID }) });
            rslt.ChangingBranches.Add(new Core.EKDRBU.Spares.StateBankRegistrySingleBranchChangeRecV1() { ChangeType = Core.Spares.BankBranchChangeType.Change, BankBranchRegID = "00626804205603050026", ChangeEffectiveDate = DateTime.Parse("2015-11-19T00:00:00"), Changes = new Core.EKDRBU.Spares.EKDRBUVariableEntryPartV1() { IsOperationsListingRefChanged = true, OperationsListingRefNew = "D" }, HeadBankDecisionRefs = new List<string>(new string[] { headBankDecisionID }) });
            rslt.ChangingBranches.Add(new Core.EKDRBU.Spares.StateBankRegistrySingleBranchChangeRecV1() { ChangeType = Core.Spares.BankBranchChangeType.Change, BankBranchRegID = "00626804205603050027", ChangeEffectiveDate = DateTime.Parse("2015-11-19T00:00:00"), Changes = new Core.EKDRBU.Spares.EKDRBUVariableEntryPartV1() { IsOperationsListingRefChanged = true, OperationsListingRefNew = "C" }, HeadBankDecisionRefs = new List<string>(new string[] { headBankDecisionID }) });
            rslt.ChangingBranches.Add(new Core.EKDRBU.Spares.StateBankRegistrySingleBranchChangeRecV1() { ChangeType = Core.Spares.BankBranchChangeType.Change, BankBranchRegID = "00626804205603050028", ChangeEffectiveDate = DateTime.Parse("2015-11-05T00:00:00"), Changes = new Core.EKDRBU.Spares.EKDRBUVariableEntryPartV1() { IsOperationsListingRefChanged = true, OperationsListingRefNew = "A" }, HeadBankDecisionRefs = new List<string>(new string[] { headBankDecisionID }) });
            rslt.ChangingBranches.Add(new Core.EKDRBU.Spares.StateBankRegistrySingleBranchChangeRecV1() { ChangeType = Core.Spares.BankBranchChangeType.Change, BankBranchRegID = "00626804205603050029", ChangeEffectiveDate = DateTime.Parse("2015-11-19T00:00:00"), Changes = new Core.EKDRBU.Spares.EKDRBUVariableEntryPartV1() { IsOperationsListingRefChanged = true, OperationsListingRefNew = "B" }, HeadBankDecisionRefs = new List<string>(new string[] { headBankDecisionID }) });
            rslt.ChangingBranches.Add(new Core.EKDRBU.Spares.StateBankRegistrySingleBranchChangeRecV1() { ChangeType = Core.Spares.BankBranchChangeType.Change, BankBranchRegID = "00626804205603050030", ChangeEffectiveDate = DateTime.Parse("2015-11-02T00:00:00"), Changes = new Core.EKDRBU.Spares.EKDRBUVariableEntryPartV1() { IsOperationsListingRefChanged = true, OperationsListingRefNew = "D" }, HeadBankDecisionRefs = new List<string>(new string[] { headBankDecisionID }) });
            rslt.ChangingBranches.Add(new Core.EKDRBU.Spares.StateBankRegistrySingleBranchChangeRecV1() { ChangeType = Core.Spares.BankBranchChangeType.Change, BankBranchRegID = "00626804205603050031", ChangeEffectiveDate = DateTime.Parse("2015-11-19T00:00:00"), Changes = new Core.EKDRBU.Spares.EKDRBUVariableEntryPartV1() { IsOperationsListingRefChanged = true, OperationsListingRefNew = "C" }, HeadBankDecisionRefs = new List<string>(new string[] { headBankDecisionID }) });
            rslt.ChangingBranches.Add(new Core.EKDRBU.Spares.StateBankRegistrySingleBranchChangeRecV1() { ChangeType = Core.Spares.BankBranchChangeType.Change, BankBranchRegID = "00626804205603050032", ChangeEffectiveDate = DateTime.Parse("2015-11-19T00:00:00"), Changes = new Core.EKDRBU.Spares.EKDRBUVariableEntryPartV1() { IsOperationsListingRefChanged = true, OperationsListingRefNew = "C" }, HeadBankDecisionRefs = new List<string>(new string[] { headBankDecisionID }) });
            rslt.ChangingBranches.Add(new Core.EKDRBU.Spares.StateBankRegistrySingleBranchChangeRecV1() { ChangeType = Core.Spares.BankBranchChangeType.Change, BankBranchRegID = "00626804205603050033", ChangeEffectiveDate = DateTime.Parse("2015-10-29T00:00:00"), Changes = new Core.EKDRBU.Spares.EKDRBUVariableEntryPartV1() { IsOperationsListingRefChanged = true, OperationsListingRefNew = "A" }, HeadBankDecisionRefs = new List<string>(new string[] { headBankDecisionID }) });
            rslt.ChangingBranches.Add(new Core.EKDRBU.Spares.StateBankRegistrySingleBranchChangeRecV1() { ChangeType = Core.Spares.BankBranchChangeType.Change, BankBranchRegID = "00626804205603050034", ChangeEffectiveDate = DateTime.Parse("2015-11-19T00:00:00"), Changes = new Core.EKDRBU.Spares.EKDRBUVariableEntryPartV1() { IsOperationsListingRefChanged = true, OperationsListingRefNew = "D" }, HeadBankDecisionRefs = new List<string>(new string[] { headBankDecisionID }) });
            rslt.ChangingBranches.Add(new Core.EKDRBU.Spares.StateBankRegistrySingleBranchChangeRecV1() { ChangeType = Core.Spares.BankBranchChangeType.Change, BankBranchRegID = "00626804205603050035", ChangeEffectiveDate = DateTime.Parse("2015-10-29T00:00:00"), Changes = new Core.EKDRBU.Spares.EKDRBUVariableEntryPartV1() { IsOperationsListingRefChanged = true, OperationsListingRefNew = "A" }, HeadBankDecisionRefs = new List<string>(new string[] { headBankDecisionID }) });
            rslt.ChangingBranches.Add(new Core.EKDRBU.Spares.StateBankRegistrySingleBranchChangeRecV1() { ChangeType = Core.Spares.BankBranchChangeType.Change, BankBranchRegID = "00626804205603050036", ChangeEffectiveDate = DateTime.Parse("2015-10-29T00:00:00"), Changes = new Core.EKDRBU.Spares.EKDRBUVariableEntryPartV1() { IsOperationsListingRefChanged = true, OperationsListingRefNew = "B" }, HeadBankDecisionRefs = new List<string>(new string[] { headBankDecisionID }) });
            rslt.ChangingBranches.Add(new Core.EKDRBU.Spares.StateBankRegistrySingleBranchChangeRecV1() { ChangeType = Core.Spares.BankBranchChangeType.Change, BankBranchRegID = "00626804205603050037", ChangeEffectiveDate = DateTime.Parse("2015-10-29T00:00:00"), Changes = new Core.EKDRBU.Spares.EKDRBUVariableEntryPartV1() { IsOperationsListingRefChanged = true, OperationsListingRefNew = "D" }, HeadBankDecisionRefs = new List<string>(new string[] { headBankDecisionID }) });
            rslt.ChangingBranches.Add(new Core.EKDRBU.Spares.StateBankRegistrySingleBranchChangeRecV1() { ChangeType = Core.Spares.BankBranchChangeType.Change, BankBranchRegID = "00626804205603050038", ChangeEffectiveDate = DateTime.Parse("2015-11-19T00:00:00"), Changes = new Core.EKDRBU.Spares.EKDRBUVariableEntryPartV1() { IsOperationsListingRefChanged = true, OperationsListingRefNew = "B" }, HeadBankDecisionRefs = new List<string>(new string[] { headBankDecisionID }) });
            rslt.ChangingBranches.Add(new Core.EKDRBU.Spares.StateBankRegistrySingleBranchChangeRecV1() { ChangeType = Core.Spares.BankBranchChangeType.Change, BankBranchRegID = "00626804205603050039", ChangeEffectiveDate = DateTime.Parse("2015-11-19T00:00:00"), Changes = new Core.EKDRBU.Spares.EKDRBUVariableEntryPartV1() { IsOperationsListingRefChanged = true, OperationsListingRefNew = "D" }, HeadBankDecisionRefs = new List<string>(new string[] { headBankDecisionID }) });
            rslt.ChangingBranches.Add(new Core.EKDRBU.Spares.StateBankRegistrySingleBranchChangeRecV1() { ChangeType = Core.Spares.BankBranchChangeType.Change, BankBranchRegID = "00626804205603050040", ChangeEffectiveDate = DateTime.Parse("2015-11-19T00:00:00"), Changes = new Core.EKDRBU.Spares.EKDRBUVariableEntryPartV1() { IsOperationsListingRefChanged = true, OperationsListingRefNew = "D" }, HeadBankDecisionRefs = new List<string>(new string[] { headBankDecisionID }) });
            rslt.ChangingBranches.Add(new Core.EKDRBU.Spares.StateBankRegistrySingleBranchChangeRecV1() { ChangeType = Core.Spares.BankBranchChangeType.Change, BankBranchRegID = "00626804205603050041", ChangeEffectiveDate = DateTime.Parse("2015-11-19T00:00:00"), Changes = new Core.EKDRBU.Spares.EKDRBUVariableEntryPartV1() { IsOperationsListingRefChanged = true, OperationsListingRefNew = "D" }, HeadBankDecisionRefs = new List<string>(new string[] { headBankDecisionID }) });
            rslt.ChangingBranches.Add(new Core.EKDRBU.Spares.StateBankRegistrySingleBranchChangeRecV1() { ChangeType = Core.Spares.BankBranchChangeType.Change, BankBranchRegID = "00626804205603050042", ChangeEffectiveDate = DateTime.Parse("2015-11-19T00:00:00"), Changes = new Core.EKDRBU.Spares.EKDRBUVariableEntryPartV1() { IsOperationsListingRefChanged = true, OperationsListingRefNew = "D" }, HeadBankDecisionRefs = new List<string>(new string[] { headBankDecisionID }) });
            rslt.ChangingBranches.Add(new Core.EKDRBU.Spares.StateBankRegistrySingleBranchChangeRecV1() { ChangeType = Core.Spares.BankBranchChangeType.Change, BankBranchRegID = "00626804205603050043", ChangeEffectiveDate = DateTime.Parse("2015-11-19T00:00:00"), Changes = new Core.EKDRBU.Spares.EKDRBUVariableEntryPartV1() { IsOperationsListingRefChanged = true, OperationsListingRefNew = "B" }, HeadBankDecisionRefs = new List<string>(new string[] { headBankDecisionID }) });
            rslt.ChangingBranches.Add(new Core.EKDRBU.Spares.StateBankRegistrySingleBranchChangeRecV1() { ChangeType = Core.Spares.BankBranchChangeType.Change, BankBranchRegID = "00626804205603050044", ChangeEffectiveDate = DateTime.Parse("2015-11-19T00:00:00"), Changes = new Core.EKDRBU.Spares.EKDRBUVariableEntryPartV1() { IsOperationsListingRefChanged = true, OperationsListingRefNew = "C" }, HeadBankDecisionRefs = new List<string>(new string[] { headBankDecisionID }) });
            rslt.ChangingBranches.Add(new Core.EKDRBU.Spares.StateBankRegistrySingleBranchChangeRecV1() { ChangeType = Core.Spares.BankBranchChangeType.Change, BankBranchRegID = "00626804205603050045", ChangeEffectiveDate = DateTime.Parse("2015-11-04T00:00:00"), Changes = new Core.EKDRBU.Spares.EKDRBUVariableEntryPartV1() { IsOperationsListingRefChanged = true, OperationsListingRefNew = "A" }, HeadBankDecisionRefs = new List<string>(new string[] { headBankDecisionID }) });
            rslt.ChangingBranches.Add(new Core.EKDRBU.Spares.StateBankRegistrySingleBranchChangeRecV1() { ChangeType = Core.Spares.BankBranchChangeType.Change, BankBranchRegID = "00626804205603050046", ChangeEffectiveDate = DateTime.Parse("2015-11-19T00:00:00"), Changes = new Core.EKDRBU.Spares.EKDRBUVariableEntryPartV1() { IsOperationsListingRefChanged = true, OperationsListingRefNew = "C" }, HeadBankDecisionRefs = new List<string>(new string[] { headBankDecisionID }) });
            rslt.ChangingBranches.Add(new Core.EKDRBU.Spares.StateBankRegistrySingleBranchChangeRecV1() { ChangeType = Core.Spares.BankBranchChangeType.Change, BankBranchRegID = "00626804205603050047", ChangeEffectiveDate = DateTime.Parse("2015-11-19T00:00:00"), Changes = new Core.EKDRBU.Spares.EKDRBUVariableEntryPartV1() { IsOperationsListingRefChanged = true, OperationsListingRefNew = "C" }, HeadBankDecisionRefs = new List<string>(new string[] { headBankDecisionID }) });
            rslt.ChangingBranches.Add(new Core.EKDRBU.Spares.StateBankRegistrySingleBranchChangeRecV1() { ChangeType = Core.Spares.BankBranchChangeType.Change, BankBranchRegID = "00626804205603050048", ChangeEffectiveDate = DateTime.Parse("2015-11-04T00:00:00"), Changes = new Core.EKDRBU.Spares.EKDRBUVariableEntryPartV1() { IsOperationsListingRefChanged = true, OperationsListingRefNew = "A" }, HeadBankDecisionRefs = new List<string>(new string[] { headBankDecisionID }) });
            rslt.ChangingBranches.Add(new Core.EKDRBU.Spares.StateBankRegistrySingleBranchChangeRecV1() { ChangeType = Core.Spares.BankBranchChangeType.Change, BankBranchRegID = "00626804205603050049", ChangeEffectiveDate = DateTime.Parse("2015-11-04T00:00:00"), Changes = new Core.EKDRBU.Spares.EKDRBUVariableEntryPartV1() { IsOperationsListingRefChanged = true, OperationsListingRefNew = "B" }, HeadBankDecisionRefs = new List<string>(new string[] { headBankDecisionID }) });
            rslt.ChangingBranches.Add(new Core.EKDRBU.Spares.StateBankRegistrySingleBranchChangeRecV1() { ChangeType = Core.Spares.BankBranchChangeType.Change, BankBranchRegID = "00626804205603050050", ChangeEffectiveDate = DateTime.Parse("2015-11-04T00:00:00"), Changes = new Core.EKDRBU.Spares.EKDRBUVariableEntryPartV1() { IsOperationsListingRefChanged = true, OperationsListingRefNew = "A" }, HeadBankDecisionRefs = new List<string>(new string[] { headBankDecisionID }) });
            rslt.ChangingBranches.Add(new Core.EKDRBU.Spares.StateBankRegistrySingleBranchChangeRecV1() { ChangeType = Core.Spares.BankBranchChangeType.Change, BankBranchRegID = "00626804205603050051", ChangeEffectiveDate = DateTime.Parse("2015-10-28T00:00:00"), Changes = new Core.EKDRBU.Spares.EKDRBUVariableEntryPartV1() { IsOperationsListingRefChanged = true, OperationsListingRefNew = "B" }, HeadBankDecisionRefs = new List<string>(new string[] { headBankDecisionID }) });
            rslt.ChangingBranches.Add(new Core.EKDRBU.Spares.StateBankRegistrySingleBranchChangeRecV1() { ChangeType = Core.Spares.BankBranchChangeType.Change, BankBranchRegID = "00626804205603050052", ChangeEffectiveDate = DateTime.Parse("2015-10-28T00:00:00"), Changes = new Core.EKDRBU.Spares.EKDRBUVariableEntryPartV1() { IsOperationsListingRefChanged = true, OperationsListingRefNew = "A" }, HeadBankDecisionRefs = new List<string>(new string[] { headBankDecisionID }) });
            rslt.ChangingBranches.Add(new Core.EKDRBU.Spares.StateBankRegistrySingleBranchChangeRecV1() { ChangeType = Core.Spares.BankBranchChangeType.Change, BankBranchRegID = "00626804205603050053", ChangeEffectiveDate = DateTime.Parse("2015-10-28T00:00:00"), Changes = new Core.EKDRBU.Spares.EKDRBUVariableEntryPartV1() { IsOperationsListingRefChanged = true, OperationsListingRefNew = "B" }, HeadBankDecisionRefs = new List<string>(new string[] { headBankDecisionID }) });
            rslt.ChangingBranches.Add(new Core.EKDRBU.Spares.StateBankRegistrySingleBranchChangeRecV1() { ChangeType = Core.Spares.BankBranchChangeType.Change, BankBranchRegID = "00626804205603050054", ChangeEffectiveDate = DateTime.Parse("2015-10-28T00:00:00"), Changes = new Core.EKDRBU.Spares.EKDRBUVariableEntryPartV1() { IsOperationsListingRefChanged = true, OperationsListingRefNew = "D" }, HeadBankDecisionRefs = new List<string>(new string[] { headBankDecisionID }) });
            rslt.ChangingBranches.Add(new Core.EKDRBU.Spares.StateBankRegistrySingleBranchChangeRecV1() { ChangeType = Core.Spares.BankBranchChangeType.Change, BankBranchRegID = "00626804205603050055", ChangeEffectiveDate = DateTime.Parse("2015-10-28T00:00:00"), Changes = new Core.EKDRBU.Spares.EKDRBUVariableEntryPartV1() { IsOperationsListingRefChanged = true, OperationsListingRefNew = "D" }, HeadBankDecisionRefs = new List<string>(new string[] { headBankDecisionID }) });
            rslt.ChangingBranches.Add(new Core.EKDRBU.Spares.StateBankRegistrySingleBranchChangeRecV1() { ChangeType = Core.Spares.BankBranchChangeType.Change, BankBranchRegID = "00626804205603050056", ChangeEffectiveDate = DateTime.Parse("2015-11-19T00:00:00"), Changes = new Core.EKDRBU.Spares.EKDRBUVariableEntryPartV1() { IsOperationsListingRefChanged = true, OperationsListingRefNew = "D" }, HeadBankDecisionRefs = new List<string>(new string[] { headBankDecisionID }) });
            rslt.ChangingBranches.Add(new Core.EKDRBU.Spares.StateBankRegistrySingleBranchChangeRecV1() { ChangeType = Core.Spares.BankBranchChangeType.Change, BankBranchRegID = "00626804205603050057", ChangeEffectiveDate = DateTime.Parse("2015-11-19T00:00:00"), Changes = new Core.EKDRBU.Spares.EKDRBUVariableEntryPartV1() { IsOperationsListingRefChanged = true, OperationsListingRefNew = "B" }, HeadBankDecisionRefs = new List<string>(new string[] { headBankDecisionID }) });
            rslt.ChangingBranches.Add(new Core.EKDRBU.Spares.StateBankRegistrySingleBranchChangeRecV1() { ChangeType = Core.Spares.BankBranchChangeType.Change, BankBranchRegID = "00626804205603050058", ChangeEffectiveDate = DateTime.Parse("2015-11-19T00:00:00"), Changes = new Core.EKDRBU.Spares.EKDRBUVariableEntryPartV1() { IsOperationsListingRefChanged = true, OperationsListingRefNew = "C" }, HeadBankDecisionRefs = new List<string>(new string[] { headBankDecisionID }) });
            rslt.ChangingBranches.Add(new Core.EKDRBU.Spares.StateBankRegistrySingleBranchChangeRecV1() { ChangeType = Core.Spares.BankBranchChangeType.Change, BankBranchRegID = "00626804205603050059", ChangeEffectiveDate = DateTime.Parse("2015-11-19T00:00:00"), Changes = new Core.EKDRBU.Spares.EKDRBUVariableEntryPartV1() { IsOperationsListingRefChanged = true, OperationsListingRefNew = "C" }, HeadBankDecisionRefs = new List<string>(new string[] { headBankDecisionID }) });
            rslt.ChangingBranches.Add(new Core.EKDRBU.Spares.StateBankRegistrySingleBranchChangeRecV1() { ChangeType = Core.Spares.BankBranchChangeType.Change, BankBranchRegID = "00626804205603050060", ChangeEffectiveDate = DateTime.Parse("2015-11-19T00:00:00"), Changes = new Core.EKDRBU.Spares.EKDRBUVariableEntryPartV1() { IsOperationsListingRefChanged = true, OperationsListingRefNew = "C" }, HeadBankDecisionRefs = new List<string>(new string[] { headBankDecisionID }) });
            rslt.ChangingBranches.Add(new Core.EKDRBU.Spares.StateBankRegistrySingleBranchChangeRecV1() { ChangeType = Core.Spares.BankBranchChangeType.Change, BankBranchRegID = "00626804205603050061", ChangeEffectiveDate = DateTime.Parse("2015-10-23T00:00:00"), Changes = new Core.EKDRBU.Spares.EKDRBUVariableEntryPartV1() { IsOperationsListingRefChanged = true, OperationsListingRefNew = "B" }, HeadBankDecisionRefs = new List<string>(new string[] { headBankDecisionID }) });
            rslt.ChangingBranches.Add(new Core.EKDRBU.Spares.StateBankRegistrySingleBranchChangeRecV1() { ChangeType = Core.Spares.BankBranchChangeType.Change, BankBranchRegID = "00626804205603050062", ChangeEffectiveDate = DateTime.Parse("2015-10-23T00:00:00"), Changes = new Core.EKDRBU.Spares.EKDRBUVariableEntryPartV1() { IsOperationsListingRefChanged = true, OperationsListingRefNew = "B" }, HeadBankDecisionRefs = new List<string>(new string[] { headBankDecisionID }) });
            rslt.ChangingBranches.Add(new Core.EKDRBU.Spares.StateBankRegistrySingleBranchChangeRecV1() { ChangeType = Core.Spares.BankBranchChangeType.Change, BankBranchRegID = "00626804205603050063", ChangeEffectiveDate = DateTime.Parse("2015-10-23T00:00:00"), Changes = new Core.EKDRBU.Spares.EKDRBUVariableEntryPartV1() { IsOperationsListingRefChanged = true, OperationsListingRefNew = "A" }, HeadBankDecisionRefs = new List<string>(new string[] { headBankDecisionID }) });
            rslt.ChangingBranches.Add(new Core.EKDRBU.Spares.StateBankRegistrySingleBranchChangeRecV1() { ChangeType = Core.Spares.BankBranchChangeType.Change, BankBranchRegID = "00626804205603050064", ChangeEffectiveDate = DateTime.Parse("2015-11-19T00:00:00"), Changes = new Core.EKDRBU.Spares.EKDRBUVariableEntryPartV1() { IsOperationsListingRefChanged = true, OperationsListingRefNew = "D" }, HeadBankDecisionRefs = new List<string>(new string[] { headBankDecisionID }) });
            rslt.ChangingBranches.Add(new Core.EKDRBU.Spares.StateBankRegistrySingleBranchChangeRecV1() { ChangeType = Core.Spares.BankBranchChangeType.Change, BankBranchRegID = "00626804205603050065", ChangeEffectiveDate = DateTime.Parse("2015-10-23T00:00:00"), Changes = new Core.EKDRBU.Spares.EKDRBUVariableEntryPartV1() { IsOperationsListingRefChanged = true, OperationsListingRefNew = "C" }, HeadBankDecisionRefs = new List<string>(new string[] { headBankDecisionID }) });
            rslt.ChangingBranches.Add(new Core.EKDRBU.Spares.StateBankRegistrySingleBranchChangeRecV1() { ChangeType = Core.Spares.BankBranchChangeType.Change, BankBranchRegID = "00626804205603050066", ChangeEffectiveDate = DateTime.Parse("2015-11-19T00:00:00"), Changes = new Core.EKDRBU.Spares.EKDRBUVariableEntryPartV1() { IsOperationsListingRefChanged = true, OperationsListingRefNew = "B" }, HeadBankDecisionRefs = new List<string>(new string[] { headBankDecisionID }) });
            rslt.ChangingBranches.Add(new Core.EKDRBU.Spares.StateBankRegistrySingleBranchChangeRecV1() { ChangeType = Core.Spares.BankBranchChangeType.Change, BankBranchRegID = "00626804205603050067", ChangeEffectiveDate = DateTime.Parse("2015-11-05T00:00:00"), Changes = new Core.EKDRBU.Spares.EKDRBUVariableEntryPartV1() { IsOperationsListingRefChanged = true, OperationsListingRefNew = "A" }, HeadBankDecisionRefs = new List<string>(new string[] { headBankDecisionID }) });
            rslt.ChangingBranches.Add(new Core.EKDRBU.Spares.StateBankRegistrySingleBranchChangeRecV1() { ChangeType = Core.Spares.BankBranchChangeType.Change, BankBranchRegID = "00626804205603050068", ChangeEffectiveDate = DateTime.Parse("2015-11-05T00:00:00"), Changes = new Core.EKDRBU.Spares.EKDRBUVariableEntryPartV1() { IsOperationsListingRefChanged = true, OperationsListingRefNew = "A" }, HeadBankDecisionRefs = new List<string>(new string[] { headBankDecisionID }) });
            rslt.ChangingBranches.Add(new Core.EKDRBU.Spares.StateBankRegistrySingleBranchChangeRecV1() { ChangeType = Core.Spares.BankBranchChangeType.Change, BankBranchRegID = "00626804205603050069", ChangeEffectiveDate = DateTime.Parse("2015-11-06T00:00:00"), Changes = new Core.EKDRBU.Spares.EKDRBUVariableEntryPartV1() { IsOperationsListingRefChanged = true, OperationsListingRefNew = "B" }, HeadBankDecisionRefs = new List<string>(new string[] { headBankDecisionID }) });
            rslt.ChangingBranches.Add(new Core.EKDRBU.Spares.StateBankRegistrySingleBranchChangeRecV1() { ChangeType = Core.Spares.BankBranchChangeType.Change, BankBranchRegID = "00626804205603050070", ChangeEffectiveDate = DateTime.Parse("2015-11-19T00:00:00"), Changes = new Core.EKDRBU.Spares.EKDRBUVariableEntryPartV1() { IsOperationsListingRefChanged = true, OperationsListingRefNew = "C" }, HeadBankDecisionRefs = new List<string>(new string[] { headBankDecisionID }) });
            rslt.ChangingBranches.Add(new Core.EKDRBU.Spares.StateBankRegistrySingleBranchChangeRecV1() { ChangeType = Core.Spares.BankBranchChangeType.Change, BankBranchRegID = "00626804205603050071", ChangeEffectiveDate = DateTime.Parse("2015-11-19T00:00:00"), Changes = new Core.EKDRBU.Spares.EKDRBUVariableEntryPartV1() { IsOperationsListingRefChanged = true, OperationsListingRefNew = "C" }, HeadBankDecisionRefs = new List<string>(new string[] { headBankDecisionID }) });
            rslt.ChangingBranches.Add(new Core.EKDRBU.Spares.StateBankRegistrySingleBranchChangeRecV1() { ChangeType = Core.Spares.BankBranchChangeType.Change, BankBranchRegID = "00626804205603050072", ChangeEffectiveDate = DateTime.Parse("2015-11-06T00:00:00"), Changes = new Core.EKDRBU.Spares.EKDRBUVariableEntryPartV1() { IsOperationsListingRefChanged = true, OperationsListingRefNew = "A" }, HeadBankDecisionRefs = new List<string>(new string[] { headBankDecisionID }) });
            rslt.ChangingBranches.Add(new Core.EKDRBU.Spares.StateBankRegistrySingleBranchChangeRecV1() { ChangeType = Core.Spares.BankBranchChangeType.Change, BankBranchRegID = "00626804205603050073", ChangeEffectiveDate = DateTime.Parse("2015-11-19T00:00:00"), Changes = new Core.EKDRBU.Spares.EKDRBUVariableEntryPartV1() { IsOperationsListingRefChanged = true, OperationsListingRefNew = "D" }, HeadBankDecisionRefs = new List<string>(new string[] { headBankDecisionID }) });
            rslt.ChangingBranches.Add(new Core.EKDRBU.Spares.StateBankRegistrySingleBranchChangeRecV1() { ChangeType = Core.Spares.BankBranchChangeType.Change, BankBranchRegID = "00626804205603050074", ChangeEffectiveDate = DateTime.Parse("2015-11-06T00:00:00"), Changes = new Core.EKDRBU.Spares.EKDRBUVariableEntryPartV1() { IsOperationsListingRefChanged = true, OperationsListingRefNew = "B" }, HeadBankDecisionRefs = new List<string>(new string[] { headBankDecisionID }) });
            rslt.ChangingBranches.Add(new Core.EKDRBU.Spares.StateBankRegistrySingleBranchChangeRecV1() { ChangeType = Core.Spares.BankBranchChangeType.Change, BankBranchRegID = "00626804205603050075", ChangeEffectiveDate = DateTime.Parse("2015-11-06T00:00:00"), Changes = new Core.EKDRBU.Spares.EKDRBUVariableEntryPartV1() { IsOperationsListingRefChanged = true, OperationsListingRefNew = "B" }, HeadBankDecisionRefs = new List<string>(new string[] { headBankDecisionID }) });
            rslt.ChangingBranches.Add(new Core.EKDRBU.Spares.StateBankRegistrySingleBranchChangeRecV1() { ChangeType = Core.Spares.BankBranchChangeType.Change, BankBranchRegID = "00626804205603050076", ChangeEffectiveDate = DateTime.Parse("2015-11-06T00:00:00"), Changes = new Core.EKDRBU.Spares.EKDRBUVariableEntryPartV1() { IsOperationsListingRefChanged = true, OperationsListingRefNew = "D" }, HeadBankDecisionRefs = new List<string>(new string[] { headBankDecisionID }) });
            rslt.ChangingBranches.Add(new Core.EKDRBU.Spares.StateBankRegistrySingleBranchChangeRecV1() { ChangeType = Core.Spares.BankBranchChangeType.Change, BankBranchRegID = "00626804205603050077", ChangeEffectiveDate = DateTime.Parse("2015-11-06T00:00:00"), Changes = new Core.EKDRBU.Spares.EKDRBUVariableEntryPartV1() { IsOperationsListingRefChanged = true, OperationsListingRefNew = "D" }, HeadBankDecisionRefs = new List<string>(new string[] { headBankDecisionID }) });
            rslt.ChangingBranches.Add(new Core.EKDRBU.Spares.StateBankRegistrySingleBranchChangeRecV1() { ChangeType = Core.Spares.BankBranchChangeType.Change, BankBranchRegID = "00626804205603050078", ChangeEffectiveDate = DateTime.Parse("2015-11-06T00:00:00"), Changes = new Core.EKDRBU.Spares.EKDRBUVariableEntryPartV1() { IsOperationsListingRefChanged = true, OperationsListingRefNew = "B" }, HeadBankDecisionRefs = new List<string>(new string[] { headBankDecisionID }) });
            rslt.ChangingBranches.Add(new Core.EKDRBU.Spares.StateBankRegistrySingleBranchChangeRecV1() { ChangeType = Core.Spares.BankBranchChangeType.Change, BankBranchRegID = "00626804205603050079", ChangeEffectiveDate = DateTime.Parse("2015-11-06T00:00:00"), Changes = new Core.EKDRBU.Spares.EKDRBUVariableEntryPartV1() { IsOperationsListingRefChanged = true, OperationsListingRefNew = "A" }, HeadBankDecisionRefs = new List<string>(new string[] { headBankDecisionID }) });
            rslt.ChangingBranches.Add(new Core.EKDRBU.Spares.StateBankRegistrySingleBranchChangeRecV1() { ChangeType = Core.Spares.BankBranchChangeType.Change, BankBranchRegID = "00626804205603050080", ChangeEffectiveDate = DateTime.Parse("2015-10-22T00:00:00"), Changes = new Core.EKDRBU.Spares.EKDRBUVariableEntryPartV1() { IsOperationsListingRefChanged = true, OperationsListingRefNew = "A" }, HeadBankDecisionRefs = new List<string>(new string[] { headBankDecisionID }) });
            rslt.ChangingBranches.Add(new Core.EKDRBU.Spares.StateBankRegistrySingleBranchChangeRecV1() { ChangeType = Core.Spares.BankBranchChangeType.Change, BankBranchRegID = "00626804205603050081", ChangeEffectiveDate = DateTime.Parse("2015-11-19T00:00:00"), Changes = new Core.EKDRBU.Spares.EKDRBUVariableEntryPartV1() { IsOperationsListingRefChanged = true, OperationsListingRefNew = "D" }, HeadBankDecisionRefs = new List<string>(new string[] { headBankDecisionID }) });
            rslt.ChangingBranches.Add(new Core.EKDRBU.Spares.StateBankRegistrySingleBranchChangeRecV1() { ChangeType = Core.Spares.BankBranchChangeType.Change, BankBranchRegID = "00626804205603050082", ChangeEffectiveDate = DateTime.Parse("2015-10-28T00:00:00"), Changes = new Core.EKDRBU.Spares.EKDRBUVariableEntryPartV1() { IsOperationsListingRefChanged = true, OperationsListingRefNew = "D" }, HeadBankDecisionRefs = new List<string>(new string[] { headBankDecisionID }) });
            rslt.ChangingBranches.Add(new Core.EKDRBU.Spares.StateBankRegistrySingleBranchChangeRecV1() { ChangeType = Core.Spares.BankBranchChangeType.Change, BankBranchRegID = "00626804205603050083", ChangeEffectiveDate = DateTime.Parse("2015-10-28T00:00:00"), Changes = new Core.EKDRBU.Spares.EKDRBUVariableEntryPartV1() { IsOperationsListingRefChanged = true, OperationsListingRefNew = "A" }, HeadBankDecisionRefs = new List<string>(new string[] { headBankDecisionID }) });
            #endregion

            rslt.RequirementsKept = true;
            rslt.RequirementsKeptDetails = "";
            
            rslt.Attachments = new List<Core.Spares.Data.AttachmentInfo>();
            #region fill attachments
            rslt.Attachments.Add(new AttachmentInfo() { AttachmentID = headBankDecisionID, AttachmentType = Core.Spares.TypicalApplicationAttachement.InternalReglementCopiesScans, ContentType = "pdf", FileName = "PostPravlN910_07102015.pdf" });
            #endregion

            #region Signature etc.
            rslt.Signor = new SignatoryInfo() { SignatoryPosition = "Заступник голови правління", SurnameInitials = "А.О.Тютюн" };
            rslt.PreparedBy = new ContactInfo() { Person = new Core.Spares.Dict.PhysicalPersonInfo() { FullName = "Кравець Н.М." }, Phones = new List<PhoneInfo>(new PhoneInfo[] { new PhoneInfo() {PhoneNr = "(044) 247-86-52" }}) };
            #endregion
            return rslt;
        }
        
        #endregion

    }
}
