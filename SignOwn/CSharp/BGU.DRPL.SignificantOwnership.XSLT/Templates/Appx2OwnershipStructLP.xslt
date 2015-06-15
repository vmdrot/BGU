<?xml version="1.0" encoding="utf-8"?>
<xsl:stylesheet version="1.0" xmlns:xsl="http://www.w3.org/1999/XSL/Transform"
    xmlns:msxsl="urn:schemas-microsoft-com:xslt" exclude-result-prefixes="msxsl"
>
  <xsl:output method="html" indent="yes"/>

  <xsl:include href="Acquiree.xslt" />
  <xsl:include href="FormatDate.xslt" />
  <xsl:include href="CouncilBodyMembersPhys.xslt" />
  <xsl:include href="CouncilBodyMembersLegal.xslt" />
  <xsl:include href="FormatAddressStreetEtc.xslt" />
  <xsl:include href="FormatPhysPersonFullNameUkr.xslt" />
  <xsl:include href="TotalOwnershipDetailsInfo.xslt" />
  <xsl:include href="SignatoryInfo.xslt" />
  



  <xsl:template match="Appx2OwnershipStructLP">
    <html>
      <head>
        <link rel="stylesheet" href="Questionnaire_Files/Questionnaire_print.css" />
        <title>
          Анкета юридичної особи (у тому числі банку) стосовно участі в <xsl:value-of select="BankRef/Name" />
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
                  </td>
                </tr>
              </table>
            </td>
          </tr>
          <tr>
            <td align="center">
              <h1>
                Анкета юридичної особи (у тому числі банку) стосовно участі в <u>
                  <b>
                    <xsl:value-of select="BankRef/Name" />
                  </b>
                </u>
              </h1>
            </td>
          </tr>
          <tr>
            <td align="left">
              <xsl:apply-templates select="Acquiree" mode="viewAcquiree"/>
            </td>
          </tr>
          <tr>
            <td>
              <h3>1.5.	Голова та члени наглядової (спостережної) ради юридичної особи</h3>
            </td>
          </tr>
          <xsl:if test="IsSupervisoryCouncilPresent='true'">
            <tr>
              <td align="left">
                <h4>1.5.1.	Фізичні особи – члени наглядової (спостережної) ради юридичної особи та  фізичні особи, які представляють юридичну особу – члена наглядової ради</h4>
              </td>
            </tr>
            <xsl:if test="SupervisoryCouncil/Members/CouncilMemberInfo/Member[PersonType='Physical']">
              <tr>
                <td>
                  <xsl:call-template name="tmplSupervisoryCouncilPhys">
                    <xsl:with-param name="council" select="SupervisoryCouncil" />
                  </xsl:call-template>
                </td>
              </tr>
            </xsl:if>
            <xsl:if test="not(SupervisoryCouncil/Members/CouncilMemberInfo/Member[PersonType='Physical'])">
              <tr>
                <td>
                  <i>(відсутні)</i>
                </td>
              </tr>
            </xsl:if>
            <tr>
              <td align="left">
                <h4>1.5.2.	Юридичні особи – члени наглядової (спостережної) ради юридичної особи</h4>
              </td>
            </tr>
            <xsl:if test="SupervisoryCouncil/Members/CouncilMemberInfo/Member[PersonType='Legal']">
              <tr>
                <td>
                  <xsl:call-template name="tmplSupervisoryCouncilLegal">
                    <xsl:with-param name="council" select="SupervisoryCouncil" />
                  </xsl:call-template>
                </td>
              </tr>
            </xsl:if>
            <xsl:if test="not(SupervisoryCouncil/Members/CouncilMemberInfo/Member[PersonType='Legal'])">
              <tr>
                <td>
                  <i>(відсутні)</i>
                </td>
              </tr>
            </xsl:if>
          </xsl:if>
            <xsl:if test="IsSupervisoryCouncilPresent!='true'">
            <tr>
              <td>
                <input name="chkSupervisoryCouncilAbsent" type="checkbox" id="chkSupervisoryCouncilAbsent" disabled="disabled" checked="checked"/> Наглядова (спостережна) рада юридичної особи відсутня за статутом
              </td>
            </tr>
          </xsl:if>
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
              <h3>1.7.	Відсоток участі у банку</h3> становить <u><xsl:value-of select="TotalOwneshipPct" /></u> відсотків статутного капіталу банку, в тому числі</td>
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
                <i>(відсутні)</i></td>
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
                </xsl:call-template></u><br />
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
