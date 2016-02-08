<?xml version="1.0" encoding="utf-8"?>
<xsl:stylesheet version="1.0" xmlns:xsl="http://www.w3.org/1999/XSL/Transform"
    xmlns:msxsl="urn:schemas-microsoft-com:xslt" exclude-result-prefixes="msxsl"
>
  <xsl:import href="Acquiree.xslt" />
  <xsl:import href="FormatDate.xslt" />
  <xsl:import href="FormatPct.xslt" />
  <xsl:import href="CouncilBodyMembersPhys.xslt" />
  <xsl:import href="CouncilBodyMembersLegal.xslt" />
  <xsl:import href="FormatAddressStreetEtc.xslt" />
  <xsl:import href="FormatAddressZipCityStreetEtc.xslt" />
  <xsl:import href="FormatAddressZipCityStreetEtcEx.xslt" />
  <xsl:import href="FormatPhysPersonFullNameUkr.xslt" />
  <xsl:import href="TotalOwnershipDetailsInfo.xslt" />
  <xsl:import href="SignatoryInfo.xslt" />
  <xsl:import href="ArrayOfTotalOwnershipDetailsInfoEx.xslt" />
  <xsl:import href="ArrayOfTotalOwnershipDetailsInfoExFormulas.xslt" />
  <xsl:output method="html" indent="yes"/>

  <!--<xsl:include href="Acquiree.xslt" />
  <xsl:include href="FormatDate.xslt" />
  <xsl:include href="FormatPct.xslt" />
  <xsl:include href="CouncilBodyMembersPhys.xslt" />
  <xsl:include href="CouncilBodyMembersLegal.xslt" />
  <xsl:include href="FormatAddressStreetEtc.xslt" />
  <xsl:include href="FormatAddressZipCityStreetEtc.xslt" />
  <xsl:include href="FormatAddressZipCityStreetEtcEx.xslt" />
  <xsl:include href="FormatPhysPersonFullNameUkr.xslt" />
  <xsl:include href="TotalOwnershipDetailsInfo.xslt" />
  <xsl:include href="SignatoryInfo.xslt" />
  <xsl:include href="ArrayOfTotalOwnershipDetailsInfoEx.xslt" />-->

  <xsl:template match="BankOwnershipStructureP328">
    <xsl:variable name ="bankRef" select="BankRef" />
    <html>
      <head>
        <link rel="stylesheet" href="Questionnaire_Files/Questionnaire_print.css" />
        <title>
          Відомості про остаточних ключових учасників у структурі власності банку <xsl:value-of select="BankRef/Name" /> станом на <xsl:call-template name="formatDate"><xsl:with-param name="dateTime" select="DateAsOf" /></xsl:call-template>
        </title>
      </head>
      <body>
        <table id="tblMain" width="1200px">
          <tr>
            <td>
              <table width="100%">
                <tr>
                  <td width="50%"></td>
                  <td width="50%" align="left" valign="top">
                    Додаток 2<br/>
                    до Положення про порядок подання<br/>
                    відомостей про структуру власності<br/>
                    банку (пункт 11 розділу ІІ)
                  </td>
                </tr>
              </table>
            </td>
          </tr>
          <tr>
            <td align="center">
              <h1>
                Відомості про остаточних ключових учасників у структурі власності банку станом на <xsl:call-template name="formatDate"><xsl:with-param name="dateTime" select="DateAsOf" /></xsl:call-template><br/>
                <u>
                  <b>
                    <xsl:value-of select="BankRef/Name" />
                  </b>
                </u>
              </h1>
              <br/>
              <!--<xsl:variable name="gpiBank" select="MentionedIdentities/GenericPersonInfo[PersonType='Legal'][1]"></xsl:variable>--> <!--works-->
              <!--<xsl:variable name="gpiBank" select="MentionedIdentities/GenericPersonInfo[PersonType=BankRef/LegalPerson/PersonType][1]"></xsl:variable>--> <!--doesn't work-->
              <xsl:variable name="gpiBank" select="MentionedIdentities/GenericPersonInfo[PersonType=$bankRef/LegalPerson/PersonType and LegalPerson/TaxCodeOrHandelsRegNr=$bankRef/LegalPerson/PersonCode and LegalPerson/ResidenceCountry/CountryISONr=$bankRef/LegalPerson/CountryISO3Code][1]"></xsl:variable> <!--works-->
              <!--<xsl:value-of select="MentionedIdentities/GenericPersonInfo[PersonType=BankRef/PersonType and LegalPerson/TaxCodeOrHandelsRegNr=BankRef/PersonCode and LegalPerson/ResidenceCountry/CountryISONr=BankRef/PersonCode]/Address/Street" />-->
              <!--<xsl:value-of select="$gpiBank/LegalPerson/Address/Street" />--> <!--works-->
              <!--<xsl:call-template name="formatAddressStreetEtc"><xsl:with-param name="address" select="MentionedIdentities/GenericPersonInfo[PersonType=BankRef/PersonType and LegalPerson/TaxCodeOrHandelsRegNr=BankRef/PersonCode and LegalPerson/ResidenceCountry/CountryISONr=BankRef/PersonCode]/Address" /></xsl:call-template>--> <!--doesn't work-->
              <xsl:call-template name="formatAddressZipCityStreetEtc">
                <xsl:with-param name="address" select="$gpiBank/LegalPerson/Address" />
              </xsl:call-template>
              
            </td>
          </tr>
          <tr>
            <td align="left">
              <xsl:call-template name="arrayOfTotalOwnershipDetailsInfoEx">
                <xsl:with-param name="theArr" select="UltimateOwners" />
                <xsl:with-param name="gpis" select="MentionedIdentities" />
                <xsl:with-param name="osHive" select="OwnershipsHive" />
                <xsl:with-param name="targetAssetId" select="$bankRef/LegalPerson" />
              </xsl:call-template>
            </td>
          </tr>
          <tr>
            <td>
              <h3>Примітка. Розрахунок опосередкованої участі ключового учасника в банку (колонка 7 таблиці):</h3>
              <xsl:call-template name="arrayOfTotalOwnershipDetailsInfoExFormulas">
                <xsl:with-param name="theArr" select="UltimateOwners" />
                <xsl:with-param name="gpis" select="MentionedIdentities" />
                <xsl:with-param name="osHive" select="OwnershipsHive" />
                <xsl:with-param name="targetAssetId" select="$bankRef/LegalPerson" />
              </xsl:call-template>
            </td>
          </tr>
          <tr>
            <td>
              <h3>1.6.	Голова та члени виконавчого органу юридичної особи</h3>
            </td>
          </tr>
          <xsl:if test="IsExecutivesPresent='true'">
            <tr>
              <td>
                <h4>1.6.1.	Фізичні особи – члени виконавчого органу юридичної особи та  фізичні особи, які представляють юридичну особу – члена виконавчого органу</h4>
              </td>
            </tr>
            <xsl:if test="Executives/Members/CouncilMemberInfo/Member[PersonType='Physical']">
              <tr>
                <td>
                  <xsl:call-template name="tmplSupervisoryCouncilPhys">
                    <xsl:with-param name="council" select="Executives" />
                  </xsl:call-template>
                </td>
              </tr>
            </xsl:if>
            <xsl:if test="not(Executives/Members/CouncilMemberInfo/Member[PersonType='Physical'])">
              <tr>
                <td>
                  <i>(відсутні)</i>
                </td>
              </tr>
            </xsl:if>
            <tr>
              <td>
                <h4>1.6.2.	Юридичні особи – члени виконавчого органу юридичної особи</h4>
              </td>
            </tr>
            <xsl:if test="Executives/Members/CouncilMemberInfo/Member[PersonType='Legal']">

              <tr>
                <td>
                  <xsl:call-template name="tmplSupervisoryCouncilLegal">
                    <xsl:with-param name="council" select="Executives" />
                  </xsl:call-template>
                </td>
              </tr>
            </xsl:if>
            <xsl:if test="not(Executives/Members/CouncilMemberInfo/Member[PersonType='Legal'])">
              <tr>
                <td>
                  <i>(відсутні)</i>
                </td>
              </tr>
            </xsl:if>
          </xsl:if>
          <xsl:if test="IsExecutivesPresent!='true'">
            <tr>
              <td>
                <input name="chkSupervisoryCouncilAbsent" type="checkbox" id="chkSupervisoryCouncilAbsent" disabled="disabled" checked="checked"/> Виконавчий орган юридичної особи відсутній за статутом
              </td>
            </tr>
          </xsl:if>
          <tr>
            <td>
              <h3>1.7.	Відсоток участі у банку</h3> становить <u>
                <xsl:value-of select="TotalOwneshipPct" />
              </u> відсотків статутного капіталу банку, в тому числі
            </td>
          </tr>
          <tr>
            <td>
              <xsl:call-template name="tmpTotalOwnershipDetails">
                <xsl:with-param name="totalOwnershipDetailsInfo" select="TotalOwneshipDetails" />
              </xsl:call-template>
            </td>
          </tr>
          <tr>
            <td>
              <h3>1.8.	Інформація про спільне володіння</h3>
            </td>
          </tr>
          <tr>
            <td>
              <h4>1.8.1.	Фізичні особи, які мають спільне володіння із юридичною особою</h4>
            </td>
          </tr>
          <xsl:if test="BankExistingCommonImplicitOwners/CommonOwnershipInfo[Partners/GenericPersonInfo/PersonType='Physical' and OwnershipType='Direct']">
            <tr>
              <td>todo</td>
            </tr>
          </xsl:if>
          <xsl:if test="not(BankExistingCommonImplicitOwners/CommonOwnershipInfo[Partners/GenericPersonInfo/PersonType='Physical' and OwnershipType='Direct'])">
            <tr>
              <td>
                <i>(відсутні)</i>
              </td>
            </tr>
          </xsl:if>
          <tr>
            <td>
              <h4>1.8.2.	Юридичні особи, які мають спільне володіння із юридичною особою</h4>
            </td>
          </tr>
          <xsl:if test="BankExistingCommonImplicitOwners/CommonOwnershipInfo[Partners/GenericPersonInfo/PersonType='Legal' and OwnershipType='Direct']">
            <tr>
              <td>todo</td>
            </tr>
          </xsl:if>
          <xsl:if test="not(BankExistingCommonImplicitOwners/CommonOwnershipInfo[Partners/GenericPersonInfo/PersonType='Legal' and OwnershipType='Direct'])">
            <tr>
              <td>
                <i>(відсутні)</i>
              </td>
            </tr>
          </xsl:if>
          <tr>
            <td>
              <h3>1.9.	Наявне володіння опосередкованою участю через:</h3>
            </td>
          </tr>
          <tr>
            <td>
              <h4>1.9.1.	Фізичні особи, через яких юридична особа володіє опосередкованою участю</h4>
            </td>
          </tr>
          <xsl:if test="BankExistingCommonImplicitOwners/CommonOwnershipInfo[Partners/GenericPersonInfo/PersonType='Physical' and OwnershipType='Implicit']">
            <tr>
              <td>todo</td>
            </tr>
          </xsl:if>
          <xsl:if test="not(BankExistingCommonImplicitOwners/CommonOwnershipInfo[Partners/GenericPersonInfo/PersonType='Physical' and OwnershipType='Implicit'])">
            <tr>
              <td>
                <i>(відсутні)</i>
              </td>
            </tr>
          </xsl:if>
          <tr>
            <td>
              <h4>1.9.2.	Юридичні особи, через яких юридична особа володіє опосередкованою участю</h4>
            </td>
          </tr>
          <xsl:if test="BankExistingCommonImplicitOwners/CommonOwnershipInfo[Partners/GenericPersonInfo/PersonType='Legal' and OwnershipType='Implicit']">
            <tr>
              <td>todo</td>
            </tr>
          </xsl:if>
          <xsl:if test="not(BankExistingCommonImplicitOwners/CommonOwnershipInfo[Partners/GenericPersonInfo/PersonType='Legal' and OwnershipType='Implicit'])">
            <tr>
              <td>
                <i>(відсутні)</i>
              </td>
            </tr>
          </xsl:if>
          <tr>
            <td>
              <h3>1.10. Інформація про набуття права голосу</h3>
            </td>
          </tr>
          <tr>
            <td>todo</td>
          </tr>
          <tr>
            <td align="center">
              <h2>2. Інформація про структуру власності</h2>
            </td>
          </tr>
          <tr>
            <td>
              <h3>2.1. Інформація про фізичних осіб, які володіють істотною участю в юридичній особі</h3>
            </td>
          </tr>
          <xsl:if test="BankExistingCommonImplicitOwners/CommonOwnershipInfo[Partners/GenericPersonInfo/PersonType='Legal' and OwnershipType='???!']">
            <tr>
              <td>todo</td>
            </tr>
          </xsl:if>
          <tr>
            <td>
              <h3>2.2. Інформація про юридичних осіб, які володіють істотною участю в юридичній особі</h3>
            </td>
          </tr>
          <tr>
            <td>todo</td>
          </tr>
          <tr>
            <td>
              <h3>2.3. Інформація про спільне володіння</h3>
            </td>
          </tr>
          <tr>
            <td>todo</td>
          </tr>
          <tr>
            <td>
              <h3>2.4. Наявне володіння опосередкованою участю через:</h3>
            </td>
          </tr>
          <tr>
            <td>todo</td>
          </tr>
          <tr>
            <td>
              2.5. <input name="chkInfoIsCorrect" type="checkbox" id="chkInfoIsCorrect" disabled="disabled" checked="checked"/> Стверджую, що інформація, надана в анкеті, є правдивою і повною, та не заперечую проти перевірки банком або Національним банком України достовірності поданих документів і персональних даних, що в них містяться.
              У разі будь-яких змін в інформації, що зазначена в цій анкеті, зобов'язуюся повідомити про них банк у місячний строк з моменту настання відповідних змін.
              Якщо анкета подається для погодження набуття/збільшення істотної участі, то в анкеті зазначається інформація з урахуванням намірів набуття/збільшення істотної участі в банку.
            </td>
          </tr>
          <tr>
            <td>
              <xsl:call-template name="tmplSignatoryInfo">
                <xsl:with-param name="signatoryInfo" select="Signatory" />
              </xsl:call-template>
            </td>
          </tr>
          <tr>
            <td>
              Підписано <u>
                <xsl:call-template name="formatDate">
                  <xsl:with-param name="dateTime" select="Signatory/DateSigned" />
                </xsl:call-template>
              </u><br />
              (число, місяць, рік)
            </td>
          </tr>
          <!--
          <tr>
            <td></td>
          </tr>
-->
        </table>
      </body>
    </html>
  </xsl:template>


</xsl:stylesheet>
