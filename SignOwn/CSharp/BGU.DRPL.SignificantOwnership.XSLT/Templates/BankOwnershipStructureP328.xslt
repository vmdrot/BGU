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
  <xsl:import href="SignatoryPlusContactPersonInfo.xslt" />
  <xsl:import href="ArrayOfTotalOwnershipDetailsInfoEx.xslt" />
  <xsl:import href="ArrayOfTotalOwnershipDetailsInfoExFormulas.xslt" />
  <xsl:output method="html" indent="yes"/>

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
        <table id="tblMain" width="100%">
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
              <xsl:call-template name="signatoryPlusContactPersonInfo">
                <xsl:with-param name="signatoryInfo" select="Signatory" />
                <xsl:with-param name="contactPersonInfo" select="ContactPerson" />
              </xsl:call-template>
            </td>
          </tr>
        </table>
      </body>
    </html>
  </xsl:template>


</xsl:stylesheet>
