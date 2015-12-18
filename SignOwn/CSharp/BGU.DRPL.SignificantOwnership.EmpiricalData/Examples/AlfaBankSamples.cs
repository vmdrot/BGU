using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using BGU.DRPL.SignificantOwnership.Core.EKDRBU.Spares;
using BGU.DRPL.SignificantOwnership.Core.Spares.Data;
using BGU.DRPL.SignificantOwnership.Core.Spares;
using BGU.DRPL.SignificantOwnership.Core.EKDRBU.Spares.TextualFinBankOpsSvc;

namespace BGU.DRPL.SignificantOwnership.EmpiricalData.Examples
{
    public class AlfaBankSamples
    {
        private Dictionary<int, BankBranchOpsFinSvcCompleteInfo> _bankBranchOpsFinServices;
        public Dictionary<int, BankBranchOpsFinSvcCompleteInfo> BankBranchOpsFinServices
        {
            get 
            {
                if (_bankBranchOpsFinServices == null)
                {
                    _bankBranchOpsFinServices = GenerateBankBranchOpsFinServices();
                }
                return _bankBranchOpsFinServices;
            }
        }

        private Dictionary<int, BankBranchOpsFinSvcCompleteInfo> GenerateBankBranchOpsFinServices()
        {
            Dictionary<int, BankBranchOpsFinSvcCompleteInfo> rslt = new Dictionary<int, BankBranchOpsFinSvcCompleteInfo>();
            
            List<CurrencyType> nationalCCYOnly = new List<CurrencyType>(new CurrencyType[] { CurrencyType.NationalCurrency });
            List<CurrencyType> nationalCCYPlusMetals = new List<CurrencyType>(new CurrencyType[] { CurrencyType.NationalCurrency, CurrencyType.BankingMetals });
            List<CurrencyType> foreignCCYOnly = new List<CurrencyType>(new CurrencyType[] { CurrencyType.ForeignCurrency });
            List<CurrencyType> foreignCCYplusMetalsOnly = new List<CurrencyType>(new CurrencyType[] { CurrencyType.ForeignCurrency, CurrencyType.BankingMetals });

            #region #1
            
            BankBranchOpsFinSvcCompleteInfo bbpfs01 = new BankBranchOpsFinSvcCompleteInfo();
            bbpfs01.SchemeNameCode = "1";
            bbpfs01.SchemeDescriptionNotes = "Типовий перелік для обласної філії";

            #region Textuals
            bbpfs01.Textuals.Add(new FinBankOpSvcTextualInfo("1.", "Залучення у вклади (депозити) коштів та банківських металів від необмеженого кола юридичних і фізичних осіб, окрім міжбанківських депозитів, окрім банківських металів з фізичною поставкою"));
            bbpfs01.Textuals.Add(new FinBankOpSvcTextualInfo("2.", "Відкриття та ведення поточних (кореспондентських) рахунків клієнтів, у тому числі у банківських металах, в частині відкриття та ведення поточних рахунків клієнтів, у тому числі у банківських металах, окрім зарахування на ці рахунки банківських металів, унесених клієнтами з фізичною поставкою."));


            #endregion
            #region #1 1.

            //1. Залучення у вклади (депозити) коштів та банківських металів від необмеженого кола юридичних і фізичних осіб, окрім міжбанківських депозитів, окрім банківських металів з фізичною поставкою.
            BankBranchOperationInfo bbpfs0101 = new BankBranchOperationInfo();
            bbpfs0101.LawActivityOrService = BankingLicensedActivityInfo.DepositsTaking;
            bbpfs0101.NrLtrBullet = "1.";
            bbpfs01.AllowedOpsSvcs.Add(bbpfs0101);
            BankBranchOperationInfo bbpfs0101exc01 = new BankBranchOperationInfo() { NrLtrBullet = "1.", LawActivityOrService = bbpfs0101.LawActivityOrService, Instrument = Core.Messages.BankInfo.FinActivitySvcInstrumentType.InterbankDeposit};
            BankBranchOperationInfo bbpfs0101exc02 = new BankBranchOperationInfo() { NrLtrBullet = "1.", LawActivityOrService = bbpfs0101.LawActivityOrService, Instrument = Core.Messages.BankInfo.FinActivitySvcInstrumentType.PreciousMetalWithPhysDelivery };
            bbpfs01.ExceptOpsSvcs.Add(bbpfs0101exc01);
            bbpfs01.ExceptOpsSvcs.Add(bbpfs0101exc02);
            #endregion
            
            #region #1 2.

            //2.  Відкриття та ведення поточних (кореспондентських) рахунків клієнтів, у тому числі у банківських металах, в частині відкриття та ведення поточних рахунків клієнтів, у тому числі у банківських металах, 
            // окрім зарахування на ці рахунки банківських металів, унесених клієнтами з фізичною поставкою.
            BankBranchOperationInfo bbpfs0102 = new BankBranchOperationInfo();
            bbpfs0102.LawActivityOrService = new Core.Spares.Data.BankingLicensedActivityInfo() { BankActivityOrService = Core.Spares.LicensedOperationType.BankingActivity, ActivityType = Core.Spares.BankingActivityType.AccountsMgmt };
            bbpfs0102.NrLtrBullet = "2.";
            bbpfs01.AllowedOpsSvcs.Add(bbpfs0101);
            BankBranchOperationInfo bbpfs0102exc01 = new BankBranchOperationInfo() { NrLtrBullet = "2.", LawActivityOrService = bbpfs0101.LawActivityOrService, Instrument = Core.Messages.BankInfo.FinActivitySvcInstrumentType.PreciousMetalWithPhysDelivery, Action = Core.Messages.BankInfo.FinActivitySvcInstrumentActionType.Installment};
            bbpfs01.ExceptOpsSvcs.Add(bbpfs0102exc01);
            #endregion

            rslt.Add(1, bbpfs01);
            #endregion

            #region #2
            BankBranchOpsFinSvcCompleteInfo bbpfs02 = new BankBranchOpsFinSvcCompleteInfo();
            bbpfs02.SchemeNameCode = "2";
            bbpfs02.SchemeDescriptionNotes = "Типовий перелік для районного відділення";

            #region Textuals
            bbpfs02.Textuals.Add(new FinBankOpSvcTextualInfo("1.", "Залучення у вклади (депозити) коштів та банківських металів від необмеженого кола юридичних і фізичних осіб, окрім міжбанківських депозитів, окрім банківських металів"));
            bbpfs02.Textuals.Add(new FinBankOpSvcTextualInfo("2.", "Відкриття та ведення поточних (кореспондентських) рахунків клієнтів, у тому числі у банківських металах, в частині відкриття та ведення поточних рахунків клієнтів"));
            bbpfs02.Textuals.Add(new FinBankOpSvcTextualInfo("3.", "Розміщення залучених у вклади (депозити), у тому числі на поточні рахунки, коштів та банківських металів від свого імені, на власних умовах та на власний ризик, в частині розміщення залучених у вклади (депозити), у тому числі на поточні рахунки, коштів від імені банку, на умовах, встановлених банком, та на ризик банку, окрім міжбанківських кредитів"));
            #endregion

            #region #2 1.
            // 1. Залучення у вклади (депозити) коштів та банківських металів від необмеженого кола юридичних і фізичних осіб, окрім міжбанківських депозитів, окрім банківських металів.
            BankBranchOperationInfo bbpfs0201 = new BankBranchOperationInfo();
            bbpfs0201.LawActivityOrService = BankingLicensedActivityInfo.DepositsTaking;
            bbpfs0201.NrLtrBullet = "1.";
            bbpfs02.AllowedOpsSvcs.Add(bbpfs0201);
            BankBranchOperationInfo bbpfs0201exc01 = new BankBranchOperationInfo() { NrLtrBullet = "1.", LawActivityOrService = bbpfs0201.LawActivityOrService, Instrument = Core.Messages.BankInfo.FinActivitySvcInstrumentType.InterbankDeposit };
            BankBranchOperationInfo bbpfs0201exc02 = new BankBranchOperationInfo() { NrLtrBullet = "1.", LawActivityOrService = bbpfs0201.LawActivityOrService, Instrument = Core.Messages.BankInfo.FinActivitySvcInstrumentType.PreciousMetalWithPhysDelivery };
            bbpfs01.ExceptOpsSvcs.Add(bbpfs0201exc01);
            bbpfs01.ExceptOpsSvcs.Add(bbpfs0201exc02);
            #endregion

            #region #2 2.
            // 2.  Відкриття та ведення поточних (кореспондентських) рахунків клієнтів, у тому числі у банківських металах, в частині відкриття та ведення поточних рахунків клієнтів.
            
            //відкриття
            bbpfs02.AllowedOpsSvcs.Add(new BankBranchOperationInfo() { NrLtrBullet = "2.", LawActivityOrService = BankingLicensedActivityInfo.AccountsMgmt, Instrument = Core.Messages.BankInfo.FinActivitySvcInstrumentType.CurrentAccount, Action = Core.Messages.BankInfo.FinActivitySvcInstrumentActionType.Opening });

            //ведення
            bbpfs02.AllowedOpsSvcs.Add(new BankBranchOperationInfo() { NrLtrBullet = "2.", LawActivityOrService = BankingLicensedActivityInfo.AccountsMgmt, Instrument = Core.Messages.BankInfo.FinActivitySvcInstrumentType.CurrentAccount, Action = Core.Messages.BankInfo.FinActivitySvcInstrumentActionType.Servicing });
            #endregion

            #region #2 3.
            // 3.  Розміщення залучених у вклади (депозити), у тому числі на поточні рахунки, коштів та банківських металів від свого імені, на власних умовах та на власний ризик, в 
            // частині розміщення залучених у вклади (депозити), у тому числі на поточні рахунки, коштів від імені банку, на умовах, встановлених банком, та на ризик банку, окрім міжбанківських кредитів.
            bbpfs02.AllowedOpsSvcs.Add(new BankBranchOperationInfo() { NrLtrBullet = "3.", LawActivityOrService = BankingLicensedActivityInfo.DepositedFundsPlacement });
            bbpfs02.ExceptOpsSvcs.Add(new BankBranchOperationInfo() { NrLtrBullet = "3.", LawActivityOrService = BankingLicensedActivityInfo.DepositedFundsPlacement, Instrument = Core.Messages.BankInfo.FinActivitySvcInstrumentType.InterbankLoans });

            #endregion

            rslt.Add(2, bbpfs02);
            #endregion

            #region # 3

            BankBranchOpsFinSvcCompleteInfo bbpfs03 = new BankBranchOpsFinSvcCompleteInfo();
            bbpfs03.SchemeNameCode = "3";
            bbpfs03.SchemeDescriptionNotes = "Типовий перелік для ТВБВ";

            #region Textuals
            bbpfs03.Textuals.Add(new FinBankOpSvcTextualInfo("1.", "Залучення у вклади (депозити) коштів та банківських металів від необмеженого кола юридичних і фізичних осіб, окрім міжбанківських депозитів, окрім банківських металів"));
            bbpfs03.Textuals.Add(new FinBankOpSvcTextualInfo("1)", "Залучення у вклади (депозити) коштів від необмеженого кола юридичних і фізичних осіб"));
            bbpfs03.Textuals.Add(new FinBankOpSvcTextualInfo("2)", "Відкриття та ведення поточних (кореспондентських) рахунків клієнтів, у частині відкриття та ведення поточних рахунків клієнтів"));
            bbpfs03.Textuals.Add(new FinBankOpSvcTextualInfo("3)", "Переказ коштів"));
            bbpfs03.Textuals.Add(new FinBankOpSvcTextualInfo("4)", "Обслуговування платіжних карток"));
            bbpfs03.Textuals.Add(new FinBankOpSvcTextualInfo("5)", "Надання консультаційних та інформаційних послуг щодо банківських послуг"));
            bbpfs03.Textuals.Add(new FinBankOpSvcTextualInfo("6)", "Надання в оренду сейфів для зберігання цінностей та документів"));
            #endregion

            #region # 3 1)
            //1)   Залучення у вклади (депозити) коштів від необмеженого кола юридичних і фізичних осіб.
            bbpfs03.AllowedOpsSvcs.Add(new BankBranchOperationInfo() { NrLtrBullet = "1)", LawActivityOrService = BankingLicensedActivityInfo.DepositsTaking });
            #endregion

            #region # 3 2)
            //2)   Відкриття та ведення поточних (кореспондентських) рахунків клієнтів, у частині відкриття та ведення поточних рахунків клієнтів.
            bbpfs03.AllowedOpsSvcs.Add(new BankBranchOperationInfo() { NrLtrBullet = "2)", LawActivityOrService = BankingLicensedActivityInfo.AccountsMgmt, Instrument = Core.Messages.BankInfo.FinActivitySvcInstrumentType.CurrentAccount, Action = Core.Messages.BankInfo.FinActivitySvcInstrumentActionType.Opening });
            bbpfs03.AllowedOpsSvcs.Add(new BankBranchOperationInfo() { NrLtrBullet = "2)", LawActivityOrService = BankingLicensedActivityInfo.AccountsMgmt, Instrument = Core.Messages.BankInfo.FinActivitySvcInstrumentType.CurrentAccount, Action = Core.Messages.BankInfo.FinActivitySvcInstrumentActionType.Servicing });
            #endregion

            #region # 3 3)
            //3)   Переказ коштів.
            bbpfs03.AllowedOpsSvcs.Add(new BankBranchOperationInfo() { NrLtrBullet = "3)", LawActivityOrService = BankingLicensedActivityInfo.FundsTransfer });
            #endregion

            #region # 3 4)
            //4)   Обслуговування          платіжних карток.
            bbpfs03.AllowedOpsSvcs.Add(new BankBranchOperationInfo() { NrLtrBullet = "4)", LawActivityOrService = BankingLicensedActivityInfo.PayDocsIssuance, Instrument = Core.Messages.BankInfo.FinActivitySvcInstrumentType.DebitCard, Action = Core.Messages.BankInfo.FinActivitySvcInstrumentActionType.Servicing });
            bbpfs03.AllowedOpsSvcs.Add(new BankBranchOperationInfo() { NrLtrBullet = "4)", LawActivityOrService = BankingLicensedActivityInfo.PayDocsIssuance, Instrument = Core.Messages.BankInfo.FinActivitySvcInstrumentType.CreditCard, Action = Core.Messages.BankInfo.FinActivitySvcInstrumentActionType.Servicing });
            #endregion

            #region # 3 5)
            //5)   Надання консультаційних та інформаційних послуг щодо банківських послуг.
            bbpfs03.AllowedOpsSvcs.Add(new BankBranchOperationInfo() { NrLtrBullet = "5)", LawActivityOrService = BankingLicensedActivityInfo.ConsultancyOnBankFinServices });
            #endregion

            #region # 3 6)
            //6)   Надання в оренду сейфів для зберігання цінностей та документів.
            bbpfs03.AllowedOpsSvcs.Add(new BankBranchOperationInfo() { NrLtrBullet = "6)", LawActivityOrService = BankingLicensedActivityInfo.SafeCustody, Instrument = Core.Messages.BankInfo.FinActivitySvcInstrumentType.BankSafe, Action = Core.Messages.BankInfo.FinActivitySvcInstrumentActionType.Rental });
            #endregion

            rslt.Add(3, bbpfs03);
            #endregion

            #region # 4
            BankBranchOpsFinSvcCompleteInfo bbpfs04 = new BankBranchOpsFinSvcCompleteInfo();
            bbpfs04.SchemeNameCode = "4";
            bbpfs04.SchemeDescriptionNotes = "";

            #region Textuals
            bbpfs04.Textuals.Add(new FinBankOpSvcTextualInfo("1)", "Залучення у вклади (депозити) коштів від необмеженого кола фізичних осіб"));
            bbpfs04.Textuals.Add(new FinBankOpSvcTextualInfo("2)", "Відкриття та ведення поточних (кореспондентських) рахунків клієнтів, у частині відкриття та ведення поточних рахунків клієнтів"));
            bbpfs04.Textuals.Add(new FinBankOpSvcTextualInfo("3)", "Переказ коштів"));
            bbpfs04.Textuals.Add(new FinBankOpSvcTextualInfo("4)", "Обслуговування платіжних карток"));
            bbpfs04.Textuals.Add(new FinBankOpSvcTextualInfo("5)", "Надання консультаційних та інформаційних послуг щодо банківських послуг"));
            #endregion

            #region #4 1)
            //1)   Залучення у вклади (депозити) коштів від необмеженого кола фізичних осіб.
            bbpfs04.AllowedOpsSvcs.Add(new BankBranchOperationInfo() { NrLtrBullet = "1)", LawActivityOrService = BankingLicensedActivityInfo.DepositsTaking});
            #endregion
            
            #region #4 2)
            //2)   Відкриття та ведення поточних (кореспондентських) рахунків клієнтів, у частині відкриття та ведення поточних рахунків клієнтів.
            bbpfs04.AllowedOpsSvcs.Add(new BankBranchOperationInfo() { NrLtrBullet = "2)", LawActivityOrService = BankingLicensedActivityInfo.AccountsMgmt, Instrument = Core.Messages.BankInfo.FinActivitySvcInstrumentType.CurrentAccount, Action = Core.Messages.BankInfo.FinActivitySvcInstrumentActionType.Opening });
            bbpfs04.AllowedOpsSvcs.Add(new BankBranchOperationInfo() { NrLtrBullet = "2)", LawActivityOrService = BankingLicensedActivityInfo.AccountsMgmt, Instrument = Core.Messages.BankInfo.FinActivitySvcInstrumentType.CurrentAccount, Action = Core.Messages.BankInfo.FinActivitySvcInstrumentActionType.Servicing });
            #endregion
            
            #region #4 3)
            //3)   Переказ коштів.
            bbpfs04.AllowedOpsSvcs.Add(new BankBranchOperationInfo() { NrLtrBullet = "3)", LawActivityOrService = BankingLicensedActivityInfo.FundsTransfer });
            #endregion
            
            #region #4 4)
            //4)   Обслуговування          платіжних карток.
            bbpfs04.AllowedOpsSvcs.Add(new BankBranchOperationInfo() { NrLtrBullet = "4)", LawActivityOrService = BankingLicensedActivityInfo.PayDocsIssuance, Instrument = Core.Messages.BankInfo.FinActivitySvcInstrumentType.DebitCard, Action = Core.Messages.BankInfo.FinActivitySvcInstrumentActionType.Servicing });
            bbpfs04.AllowedOpsSvcs.Add(new BankBranchOperationInfo() { NrLtrBullet = "4)", LawActivityOrService = BankingLicensedActivityInfo.PayDocsIssuance, Instrument = Core.Messages.BankInfo.FinActivitySvcInstrumentType.CreditCard, Action = Core.Messages.BankInfo.FinActivitySvcInstrumentActionType.Servicing });
            #endregion

            #region #4 5)
            //5)   Надання консультаційних та інформаційних послуг щодо банківських послуг.
            bbpfs04.AllowedOpsSvcs.Add(new BankBranchOperationInfo() { NrLtrBullet = "5)", LawActivityOrService = BankingLicensedActivityInfo.ConsultancyOnBankFinServices });
            #endregion

            rslt.Add(4, bbpfs04);
            #endregion

            #region # 5
            BankBranchOpsFinSvcCompleteInfo bbpfs05 = new BankBranchOpsFinSvcCompleteInfo();
            bbpfs05.SchemeNameCode = "5";
            bbpfs05.SchemeDescriptionNotes = "Перелік операцій ПАТ \"АЛЬФА-БАНК\", (тільки каса)";

            #region Textuals
            bbpfs05.Textuals.Add(new FinBankOpSvcTextualInfo("1).", "переказ коштів"));
            bbpfs05.Textuals.Add(new FinBankOpSvcTextualInfo("2).", "приймання готівки в національній валюті для здійснення платежів і зарахування їх на рахунки юридичних та фізичних осіб або на відповідний рахунок у банку"));
            bbpfs05.Textuals.Add(new FinBankOpSvcTextualInfo("3).", "видача готівки з карткових рахунків фізичним особам - власникам платіжних карток, емітірованних ПАТ \"Альфа-Банк\", за допомогою POS-терміналу"));
            bbpfs05.Textuals.Add(new FinBankOpSvcTextualInfo("4).", "видача готівки з карткових рахунків фізичним особам - власникам платіжних карток, емітірованних іншими банками, за допомогою POS-терміналу"));
            bbpfs05.Textuals.Add(new FinBankOpSvcTextualInfo("5).", "надання консультаційних та інформаційних послуг щодо банківських та інших фінансових послуг"));
            #endregion

            #region #5 1)
            //1). переказ коштів; 
            bbpfs05.AllowedOpsSvcs.Add(new BankBranchOperationInfo() { NrLtrBullet = "1).", LawActivityOrService = BankingLicensedActivityInfo.FundsTransfer });
            #endregion

            #region #5 2)
            //2). приймання готівки в національній валюті для здійснення платежів і зарахування їх на рахунки юридичних та фізичних осіб або на відповідний рахунок у банку; 
            bbpfs05.AllowedOpsSvcs.Add(new BankBranchOperationInfo() { NrLtrBullet = "2).", LawActivityOrService = BankingLicensedActivityInfo.OtherFinBankServices }); //todo???!
            #endregion

            #region #5 3)
            //3). видача готівки з карткових рахунків фізичним особам - власникам платіжних карток, емітірованних ПАТ "Альфа-Банк", за допомогою POS-терміналу; 
            bbpfs05.AllowedOpsSvcs.Add(new BankBranchOperationInfo() { NrLtrBullet = "3).", LawActivityOrService = BankingLicensedActivityInfo.PayDocsIssuance, Instrument = Core.Messages.BankInfo.FinActivitySvcInstrumentType.DebitCard, Action = Core.Messages.BankInfo.FinActivitySvcInstrumentActionType.CashAdvancePOS, OtherDimensions = new List<OtherBankOpsSvcDimension>(new OtherBankOpsSvcDimension[] { OtherBankOpsSvcDimension.OwnClients }) });
            bbpfs05.AllowedOpsSvcs.Add(new BankBranchOperationInfo() { NrLtrBullet = "3).", LawActivityOrService = BankingLicensedActivityInfo.PayDocsIssuance, Instrument = Core.Messages.BankInfo.FinActivitySvcInstrumentType.CreditCard, Action = Core.Messages.BankInfo.FinActivitySvcInstrumentActionType.CashAdvancePOS, OtherDimensions = new List<OtherBankOpsSvcDimension>(new OtherBankOpsSvcDimension[] { OtherBankOpsSvcDimension.OwnClients }) });
            #endregion

            #region #5 4)
            //4). видача готівки з карткових рахунків фізичним особам - власникам платіжних карток, емітірованних іншими банками, за допомогою POS-терміналу; 
            bbpfs05.AllowedOpsSvcs.Add(new BankBranchOperationInfo() { NrLtrBullet = "4).", LawActivityOrService = BankingLicensedActivityInfo.PayDocsIssuance, Instrument = Core.Messages.BankInfo.FinActivitySvcInstrumentType.DebitCard, Action = Core.Messages.BankInfo.FinActivitySvcInstrumentActionType.CashAdvancePOS, OtherDimensions = new List<OtherBankOpsSvcDimension>(new OtherBankOpsSvcDimension[] { OtherBankOpsSvcDimension.OtherBanksClients }) });
            bbpfs05.AllowedOpsSvcs.Add(new BankBranchOperationInfo() { NrLtrBullet = "4).", LawActivityOrService = BankingLicensedActivityInfo.PayDocsIssuance, Instrument = Core.Messages.BankInfo.FinActivitySvcInstrumentType.CreditCard, Action = Core.Messages.BankInfo.FinActivitySvcInstrumentActionType.CashAdvancePOS, OtherDimensions = new List<OtherBankOpsSvcDimension>(new OtherBankOpsSvcDimension[] { OtherBankOpsSvcDimension.OtherBanksClients }) });
            #endregion

            #region #5 5)
            //5). - надання консультаційних та інформаційних послуг щодо банківських та інших фінансових послуг.
            bbpfs05.AllowedOpsSvcs.Add(new BankBranchOperationInfo() { NrLtrBullet = "5).", LawActivityOrService = BankingLicensedActivityInfo.ConsultancyOnBankFinServices });
            #endregion

            rslt.Add(5, bbpfs05);
            #endregion

            #region #6
            
            BankBranchOpsFinSvcCompleteInfo bbpfs06 = new BankBranchOpsFinSvcCompleteInfo();
            bbpfs06.SchemeNameCode = "6";
            bbpfs06.SchemeDescriptionNotes = "Перелік операцій ПАТ \"АЛЬФА-БАНК\", (відділення)";

            #region Textuals
            bbpfs06.Textuals.Add(new FinBankOpSvcTextualInfo("1).", "залучення у вклади (депозити) коштів та банківських металів від необмеженого кола юридичних і фізичних осіб"));
            bbpfs06.Textuals.Add(new FinBankOpSvcTextualInfo("2).", "відкриття та ведення поточних рахунків клієнтів, у тому числі у банківських металах"));
            bbpfs06.Textuals.Add(new FinBankOpSvcTextualInfo("3).", "розміщення залучених у вклади (депозити) у тому числі на поточні рахунки, коштів та банківських металів від свого імені, на власних умовах та на власний ризик, у частині розміщення залучених коштів від імені Банку, на умовах, визначених Банком, та на ризик Банку (крім міжбанківських кредитів)"));
            
            bbpfs06.Textuals.Add(new FinBankOpSvcTextualInfo("а1).", "випуск платіжних документів, платіжних карток, дорожніх чеків та/або їх обслуговування, кліринг, інші форми забезпечення розрахунків"));
            bbpfs06.Textuals.Add(new FinBankOpSvcTextualInfo("а2).", "довірче управління фінансовими активами"));
            bbpfs06.Textuals.Add(new FinBankOpSvcTextualInfo("а3).", "діяльність з обміну валют"));
            bbpfs06.Textuals.Add(new FinBankOpSvcTextualInfo("а4).", "фінансовий лізинг"));
            bbpfs06.Textuals.Add(new FinBankOpSvcTextualInfo("а5).", "надання гарантій та поручительств"));
            bbpfs06.Textuals.Add(new FinBankOpSvcTextualInfo("а6).", "переказ коштів"));
            bbpfs06.Textuals.Add(new FinBankOpSvcTextualInfo("а7).", "факторинг"));
            
            bbpfs06.Textuals.Add(new FinBankOpSvcTextualInfo("б1).", "інвестицій"));
            bbpfs06.Textuals.Add(new FinBankOpSvcTextualInfo("б2).", "випуску власних цінних паперів"));
            bbpfs06.Textuals.Add(new FinBankOpSvcTextualInfo("б3).", "випуску, розповсюдження та проведення лотерей"));
            bbpfs06.Textuals.Add(new FinBankOpSvcTextualInfo("б4).", "зберігання цінностей або надання в майновий найм (оренду) індивідуального банківського сейфа"));
            bbpfs06.Textuals.Add(new FinBankOpSvcTextualInfo("б5).", "інкасації коштів та перевезення валютних цінностей"));
            bbpfs06.Textuals.Add(new FinBankOpSvcTextualInfo("б6).", "надання консультаційних та інформаційних послуг щодо банківських та інших фінансових послуг"));

            bbpfs06.Textuals.Add(new FinBankOpSvcTextualInfo("в1).", "неторговельні операції з валютними цінностями"));
            bbpfs06.Textuals.Add(new FinBankOpSvcTextualInfo("в2).", "операції з готівковою іноземною валютою та чеками (купівля, продаж, обмін, прийняття на інкасо), що здійснюються в касах відділення"));
            bbpfs06.Textuals.Add(new FinBankOpSvcTextualInfo("в3).", "ведення рахунків клієнтів (резидентів і нерезидентів) в іноземній валюті та клієнтів-нерезидентів у грошовій одиниці України"));
            bbpfs06.Textuals.Add(new FinBankOpSvcTextualInfo("в4).", "залучення та розміщення іноземної валюти на валютному ринку України"));
            bbpfs06.Textuals.Add(new FinBankOpSvcTextualInfo("5).", "торгівля іноземною валютою на валютному ринку України [за винятком операцій з готівковою іноземною валютою та чеками (купівля, продаж, обмін), що здійснюється в касах відділення]"));
            bbpfs06.Textuals.Add(new FinBankOpSvcTextualInfo("в6).", "залучення та розміщення банківських металів на валютному ринку України"));
            bbpfs06.Textuals.Add(new FinBankOpSvcTextualInfo("7).", "валютні операції на валютному ринку України, які належать до фінансових послуг згідно зі статтею 4 Закону України «Про фінансові послуги та державне регулювання ринків фінансових послуг» та не зазначені в абзацах другому-сімнадцятому розділу другого Положення про порядок надання банкам і філіям іноземних банків генеральних ліцензій на здійснення валютних операцій, затвердженого постановою Правління Національного банку України від 15.08.2011 №281"));
            #endregion
            //Відділення має право від імені Банку надавати, в тому числі, наступні банківські та інші фінансові послуги:
            #region #6 BkOps 1)
            //1). залучення у вклади (депозити) коштів та банківських металів від необмеженого кола юридичних і фізичних осіб; 
            bbpfs06.AllowedOpsSvcs.Add(new BankBranchOperationInfo() { NrLtrBullet = "1)", LawActivityOrService = BankingLicensedActivityInfo.DepositsTaking, CCYDimensions = nationalCCYOnly });
            #endregion
            #region #6 BkOps 2)
            //2). відкриття та ведення поточних рахунків клієнтів, у тому числі у банківських металах; 
            bbpfs06.AllowedOpsSvcs.Add(new BankBranchOperationInfo() { NrLtrBullet = "2)", LawActivityOrService = BankingLicensedActivityInfo.AccountsMgmt, Action = Core.Messages.BankInfo.FinActivitySvcInstrumentActionType.Opening, CCYDimensions = nationalCCYOnly });
            bbpfs06.AllowedOpsSvcs.Add(new BankBranchOperationInfo() { NrLtrBullet = "2)", LawActivityOrService = BankingLicensedActivityInfo.AccountsMgmt, Action = Core.Messages.BankInfo.FinActivitySvcInstrumentActionType.Servicing, CCYDimensions = nationalCCYOnly });
            #endregion

            #region #6 BkOps 3)
            //3). розміщення залучених у вклади (депозити) у тому числі на поточні рахунки, коштів та банківських металів від свого імені, 
            // на власних умовах та на власний ризик, у частині розміщення залучених коштів від імені Банку, на умовах, визначених Банком, 
            // та на ризик Банку (крім міжбанківських кредитів). 
            bbpfs06.AllowedOpsSvcs.Add(new BankBranchOperationInfo() { NrLtrBullet = "3)", LawActivityOrService = BankingLicensedActivityInfo.DepositedFundsPlacement, CCYDimensions = nationalCCYOnly });
            bbpfs06.ExceptOpsSvcs.Add(new BankBranchOperationInfo() { NrLtrBullet = "3)", LawActivityOrService = BankingLicensedActivityInfo.DepositedFundsPlacement, Instrument = Core.Messages.BankInfo.FinActivitySvcInstrumentType.InterbankLoans, CCYDimensions = nationalCCYOnly });
            #endregion

            //Відділення має право від імені Банку надавати своїм клієнтам (крім банків) фінансові послуги, перелік яких встановлюється 
            // Національним банком України, та які визначені Законом України «Про фінансові послуги та державне регулювання ринків фінансових послуг», а саме: 

            #region #6 FinSvc 1)
            //1). випуск платіжних документів, платіжних карток, дорожніх чеків та/або їх обслуговування, кліринг, інші форми забезпечення розрахунків; 
            bbpfs06.AllowedOpsSvcs.Add(new BankBranchOperationInfo() { NrLtrBullet = "а1)", LawActivityOrService = BankingLicensedActivityInfo.PayDocsIssuance, CCYDimensions = nationalCCYOnly });
            #endregion
            #region #6 FinSvc 2)
            //2). довірче управління фінансовими активами; 
            bbpfs06.AllowedOpsSvcs.Add(new BankBranchOperationInfo() { NrLtrBullet = "а2)", LawActivityOrService = BankingLicensedActivityInfo.Trust, CCYDimensions = nationalCCYOnly });
            #endregion
            #region #6 FinSvc 3)
            //3). діяльність з обміну валют; 
            bbpfs06.AllowedOpsSvcs.Add(new BankBranchOperationInfo() { NrLtrBullet = "а3)", LawActivityOrService = BankingLicensedActivityInfo.CurrencyExchange });
            #endregion
            #region #6 FinSvc 4)
            //4). фінансовий лізинг; 
            bbpfs06.AllowedOpsSvcs.Add(new BankBranchOperationInfo() { NrLtrBullet = "а4)", LawActivityOrService = BankingLicensedActivityInfo.FinancialLeasing, CCYDimensions = nationalCCYOnly });
            #endregion
            #region #6 FinSvc 5)
            //5). надання гарантій та поручительств; 
            bbpfs06.AllowedOpsSvcs.Add(new BankBranchOperationInfo() { NrLtrBullet = "а5)", LawActivityOrService = BankingLicensedActivityInfo.Guarantees, CCYDimensions = nationalCCYOnly });
            #endregion
            #region #6 FinSvc 6)
            //6). переказ коштів;
            bbpfs06.AllowedOpsSvcs.Add(new BankBranchOperationInfo() { NrLtrBullet = "а6)", LawActivityOrService = BankingLicensedActivityInfo.FundsTransfer, CCYDimensions = nationalCCYOnly });
            #endregion
            #region #6 FinSvc 7)
            //7). факторинг. 
            bbpfs06.AllowedOpsSvcs.Add(new BankBranchOperationInfo() { NrLtrBullet = "а7)", LawActivityOrService = BankingLicensedActivityInfo.Factoring, CCYDimensions = nationalCCYOnly });
            #endregion

            //Відділення також має право від імені Банку, крім надання фінансових послуг,  здійснювати діяльність щодо: 

            #region #6 Actvty 1)
            //1). інвестицій; 
            bbpfs06.AllowedOpsSvcs.Add(new BankBranchOperationInfo() { NrLtrBullet = "б1)", LawActivityOrService = BankingLicensedActivityInfo.Investments, CCYDimensions = nationalCCYOnly });
            #endregion
            #region #6 Actvty 2)
            //2). випуску власних цінних паперів; 
            bbpfs06.AllowedOpsSvcs.Add(new BankBranchOperationInfo() { NrLtrBullet = "б2)", LawActivityOrService = BankingLicensedActivityInfo.ProprietarySecuritiesIssue, CCYDimensions = nationalCCYOnly });
            #endregion
            #region #6 Actvty 3)
            //3). випуску, розповсюдження та проведення лотерей;
            bbpfs06.AllowedOpsSvcs.Add(new BankBranchOperationInfo() { NrLtrBullet = "б3)", LawActivityOrService = BankingLicensedActivityInfo.Lotteries, CCYDimensions = nationalCCYOnly });
            #endregion
            #region #6 Actvty 4)
            //4). зберігання цінностей або надання в майновий найм (оренду) індивідуального банківського сейфа;
            bbpfs06.AllowedOpsSvcs.Add(new BankBranchOperationInfo() { NrLtrBullet = "б4)", LawActivityOrService = BankingLicensedActivityInfo.SafeCustody });
            #endregion
            #region #6 Actvty 5)
            //5). інкасації коштів та перевезення валютних цінностей;
            bbpfs06.AllowedOpsSvcs.Add(new BankBranchOperationInfo() { NrLtrBullet = "б5)", LawActivityOrService = BankingLicensedActivityInfo.CashCollectionTransportation }); //todo - на інкасацію й транспортування валюти треба ген.ліцензія? - UPD. Не треба!
            #endregion
            #region #6 Actvty 6)
            //6). надання консультаційних та інформаційних послуг щодо банківських та інших фінансових послуг.
            bbpfs06.AllowedOpsSvcs.Add(new BankBranchOperationInfo() { NrLtrBullet = "б6)", LawActivityOrService = BankingLicensedActivityInfo.ConsultancyOnBankFinServices });
            #endregion

            //Відділення також має право здійснювати діяльність, надання банківських та інших фінансових послуг в 
            // іноземній валюті, які є валютними операціями, перелік яких зазначений в Генеральній ліцензії та додатку 
            // до Генеральної ліцензії на здійснення валютних операцій, отриманих Банком від Національного банку України.
            //Перелік валютних операцій, які (в тому числі) має право здійснювати Відділення:

            #region #6 FX 1)
            //1). неторговельні операції з валютними цінностями;
            bbpfs06.AllowedOpsSvcs.Add(new BankBranchOperationInfo() { NrLtrBullet = "в1)", LawActivityOrService = BankingLicensedActivityInfo.GFX_NonTrade, CCYDimensions = foreignCCYplusMetalsOnly });
            #endregion
            #region #6 FX 2)
            //2). операції з готівковою іноземною валютою та чеками (купівля, продаж, обмін, прийняття на інкасо), що здійснюються в касах відділення; 
            bbpfs06.AllowedOpsSvcs.Add(new BankBranchOperationInfo() { NrLtrBullet = "в2)", LawActivityOrService = BankingLicensedActivityInfo.GFX_CashBankOps, CCYDimensions = foreignCCYplusMetalsOnly });
            #endregion

            #region #6 FX 3)
            //3). ведення рахунків клієнтів (резидентів і нерезидентів) в іноземній валюті та клієнтів-нерезидентів у грошовій одиниці України;
            bbpfs06.AllowedOpsSvcs.Add(new BankBranchOperationInfo() { NrLtrBullet = "в3)", LawActivityOrService = BankingLicensedActivityInfo.GFX_AcctMgmt, CCYDimensions = foreignCCYplusMetalsOnly, ResidenceDimensions = new List<ResidenceType>(new ResidenceType[] { ResidenceType.Resident, ResidenceType.NonResident }) });
            bbpfs06.AllowedOpsSvcs.Add(new BankBranchOperationInfo() { NrLtrBullet = "в3)", LawActivityOrService = BankingLicensedActivityInfo.GFX_AcctMgmt, CCYDimensions = nationalCCYOnly, ResidenceDimensions = new List<ResidenceType>(new ResidenceType[] { ResidenceType.NonResident }) });
            #endregion
            #region #6 FX 4)
            //4). залучення та розміщення іноземної валюти на валютному ринку України;
            bbpfs06.AllowedOpsSvcs.Add(new BankBranchOperationInfo() { NrLtrBullet = "в4)", LawActivityOrService = BankingLicensedActivityInfo.GFX_FCCYBorrNPlaceLocalMarket });
            #endregion
            #region #6 FX 5)
            //5). торгівля іноземною валютою на валютному ринку України [за винятком операцій з готівковою іноземною валютою та чеками (купівля, продаж, обмін), що здійснюється в касах відділення];
            bbpfs06.AllowedOpsSvcs.Add(new BankBranchOperationInfo() { NrLtrBullet = "в5)", LawActivityOrService = BankingLicensedActivityInfo.GFX_FCCYTradingNonCashLocalMarket });
            #endregion
            #region #6 FX 6)
            //6). залучення та розміщення банківських металів на валютному ринку України;
            bbpfs06.AllowedOpsSvcs.Add(new BankBranchOperationInfo() { NrLtrBullet = "в6)", LawActivityOrService = BankingLicensedActivityInfo.GFX_BkMetalBorrNPlaceLocalMarket });
            #endregion
            #region #6 FX 7)
            //7). валютні операції на валютному ринку України, які належать до фінансових послуг згідно зі статтею 4 Закону 
            //    України «Про фінансові послуги та державне регулювання ринків фінансових послуг» та не зазначені в 
            //    абзацах другому-сімнадцятому розділу другого Положення про порядок надання банкам і філіям іноземних банків 
            //    генеральних ліцензій на здійснення валютних операцій, затвердженого постановою Правління Національного банку України від 15.08.2011 №281.
            bbpfs06.AllowedOpsSvcs.Add(new BankBranchOperationInfo() { NrLtrBullet = "в7)", LawActivityOrService = BankingLicensedActivityInfo.GFX_FinSvcLocalMarket });
            #endregion

            rslt.Add(6, bbpfs06);

            #endregion

            return rslt;
        }
    }
}
