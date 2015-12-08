using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

namespace BGU.DRPL.SignificantOwnership.Core.EKDRBU.Spares.TextualFinBankOpsSvc.Parsers
{
    public enum BankParserType
    { 
        None = 0,
        // <unknown>
        Unknown,
        // АБ "УКРГАЗБАНК"
        UkrGasBank,
        // АТ "НК БАНК"
        NKBank,
        // АТ "ОТП Банк"
        OTP,
        // АТ "Ощадбанк"
        Oshchad,
        // АТ "Райффайзен Банк Аваль"
        RaiffAval,
        // АТ "УКРСИББАНК"
        UkrSib,
        // АТ ˮПІРЕУС БАНК МКБˮ
        Piraeus,
        // ПАТ "АЛЬФА-БАНК"
        AlfaBank,
        // ПАТ "БАНК ВОСТОК"
        Vostok,
        // ПАТ "ДІАМАНТБАНК"
        Diamant,
        // ПАТ "КРЕДІ АГРІКОЛЬ БАНК"
        CreditAgricole,
        // ПАТ "ПЕРШИЙ ІНВЕСТИЦІЙНИЙ БАНК"
        PershInv,
        // ПАТ "Промінвестбанк"
        Prominvest,
        // ПАТ "УКРСОЦБАНК"
        UkrSoc,
        // ПАТ ˮАБ ˮРАДАБАНКˮ
        Radabank,
        // ПАТ ˮБАНК ˮГРАНТˮ
        Grant,
        // ПАТ ˮБАНК ˮЮНІСОНˮ
        Unison,
        // ПАТ КБ "ПРИВАТБАНК"
        Privat,
        // ПАТ ˮКБ ˮЗЕМЕЛЬНИЙ КАПІТАЛˮ
        ZemKapital,
        // ПАТ КБ ˮЦентрˮ
        Centr,
        // ПАТ ˮМЕГАБАНКˮ
        Megabank,
        // ПАТ ˮРАДИКАЛ БАНКˮ
        RadikalBank,
        // ПАТˮБАНК ˮФОРВАРДˮ
        Forward,
        // ПАТˮУКРІНБАНКˮ
        Ukrinbank,
        // ПУАТ "ФІДОБАНК"
        Fidobank
    }
}