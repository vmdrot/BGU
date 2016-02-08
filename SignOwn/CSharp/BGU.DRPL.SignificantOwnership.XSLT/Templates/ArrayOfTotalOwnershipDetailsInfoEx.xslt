<?xml version="1.0" encoding="utf-8"?>
<xsl:stylesheet version="1.0" xmlns:xsl="http://www.w3.org/1999/XSL/Transform"
    xmlns:msxsl="urn:schemas-microsoft-com:xslt" exclude-result-prefixes="msxsl"
>
  <!--<xsl:include href="FormatAddressZipCityStreetEtc.xslt" />-->
  <xsl:import href="FormatDate.xslt" />
  <xsl:import href="FormatPct.xslt" />
  <xsl:import href="FormatAddressStreetEtc.xslt" />
  <xsl:import href="FormatAddressZipCityStreetEtc.xslt" />
  <xsl:import href="FormatAddressZipCityStreetEtcEx.xslt" />
  <xsl:import href="ImplicitOwnershipUnwind.xslt" />
  

  <xsl:template name="arrayOfTotalOwnershipDetailsInfoEx">
    <xsl:param name="theArr" />
    <xsl:param name="gpis" />
    <xsl:param name="osHive" />
    <xsl:param name="targetAssetId" />
    <table width="100%" style="border: 1pt solid black;">
      <thead>
        <tr>
          <th rowspan="2">№ з/п</th>
          <th rowspan="2">Прізвище,  ім'я та по батькові фізичної  особи або повне найменування юридичної особи</th>
          <th rowspan="2">Тип особи</th>
          <th rowspan="2">Чи є особа власни- ком істотної участі  в банку</th>
          <th rowspan="2">Інформація  про особу</th>
          <th colspan="3">Участь особи в банку,  %</th>
          <th rowspan="2">Опис взаємозв'язку особи з банком</th>
        </tr>
        <tr>
          <th>Пряма</th>
          <th>Опосеред-кована</th>
          <th>Сукупна</th>
        </tr>
        <tr>
          <th>1</th>
          <th>2</th>
          <th>3</th>
          <th>4</th>
          <th>5</th>
          <th>6</th>
          <th>7</th>
          <th>8</th>
          <th>9</th>
        </tr>
      </thead>
      <tbody>
        <xsl:for-each select="$theArr/TotalOwnershipDetailsInfoEx">
          <xsl:variable name="curr" select="."/>
          <xsl:if test="$curr/OwnerID/PersonType != 'None'">
          <xsl:variable name="currGPI" select="$gpis/GenericPersonInfo[PersonType=$curr/OwnerID/PersonType and ((PersonType='Legal' and LegalPerson/TaxCodeOrHandelsRegNr=$curr/OwnerID/PersonCode and LegalPerson/ResidenceCountry/CountryISONr=$curr/OwnerID/CountryISO3Code) or (PersonType='Physical' and PhysicalPerson/TaxOrSocSecID=$curr/OwnerID/PersonCode and PhysicalPerson/CitizenshipCountry/CountryISONr=$curr/OwnerID/CountryISO3Code))][1]"></xsl:variable>
            <!--<xsl:variable name="currGPICountry" select="$currGPI//PhysicalPerson/CitizenshipCountry"></xsl:variable>-->
            <!--<xsl:if test="$currGPI/PersonType = 'Physical'">
              <xsl:variable name="currGPICountry" select="$currGPI/PhysicalPerson/CitizenshipCountry" />
            </xsl:if>
            <xsl:if test="$currGPI/PersonType = 'Legal'">
              <xsl:variable name="currGPICountry" select="$currGPI/LegalPerson/ResidenceCountry" />
            </xsl:if>-->

            <!--<xsl:variable name="currGPICountry" select="$currGPI/PhysicalPerson/CitizenshipCountry">-->
            <xsl:variable name="currGPICountry">
              <xsl:choose>
                <xsl:when test="$currGPI/PersonType = 'Physical'">
                  <xsl:copy-of select ="$currGPI/PhysicalPerson/CitizenshipCountry/*"/>
                </xsl:when>
                <xsl:when test="$currGPI/PersonType = 'Legal'">
                  <xsl:copy-of select="$currGPI/LegalPerson/ResidenceCountry/*"/>
                </xsl:when>
                <xsl:otherwise>
                  <!--<xsl:element name="defaultCountry">
                    <ResidenceCountry>
                      <CountryISO2Code>UA</CountryISO2Code>
                      <CountryISO3Code>UKR</CountryISO3Code>
                      <CountryISONr>804</CountryISONr>
                      <CountryNameEng>UKRAINE</CountryNameEng>
                      <CountryNameUkr>Україна</CountryNameUkr>
                    </ResidenceCountry>
                  </xsl:element>-->
                  <xsl:if test="null != $curr//CitizenshipCountry">
                    <xsl:copy-of select="$curr//CitizenshipCountry/*"/>
                  </xsl:if>
                  <xsl:if test="null != $curr//ResidenceCountry">
                    <xsl:copy-of select="$curr//ResidenceCountry/*"/>
                  </xsl:if>
                </xsl:otherwise>
              </xsl:choose>
            </xsl:variable>
            <tr>
          <td valign="top">
            <xsl:value-of select="1 + count(preceding-sibling::*)"/>
          </td>
              <td valign="top">
            <xsl:if test="$currGPI/PersonType='Legal'">
              <xsl:value-of select="$currGPI/LegalPerson/Name"/>
            </xsl:if>
            <xsl:if test="$currGPI/PersonType='Physical'">
              <xsl:value-of select="$currGPI/PhysicalPerson/FullName"/>
            </xsl:if>
          </td>
          <td align="center" valign="top">
            <xsl:if test="$currGPI/PersonType='Legal'">
              ЮО
            </xsl:if>
            <xsl:if test="$currGPI/PersonType='Physical'">
              ФО
            </xsl:if>
          </td>
          <td align="center" valign="top">
            <xsl:if test="$curr/TotalCapitalSharePct &gt;= 10">Так</xsl:if>
            <xsl:if test="$curr/TotalCapitalSharePct &lt; 10">Ні</xsl:if>
          </td>
          <td align="left" valign="top">
            <xsl:if test="null != $currGPICountry">
            <xsl:value-of select="$currGPICountry/CountryNameUkr"/>
            </xsl:if>
            <xsl:if test="$currGPI/PersonType = 'Legal'">
            <xsl:call-template name="formatAddressZipCityStreetEtcEx">
              <xsl:with-param name="address" select="$currGPI/LegalPerson/Address" />
              <xsl:with-param name="gpiCountry" select="$currGPICountry" />
            </xsl:call-template>
            </xsl:if>
            <xsl:if test="$currGPI/PersonType = 'Physical'">
              <xsl:call-template name="formatAddressZipCityStreetEtcEx">
                <xsl:with-param name="address" select="$currGPI/PhysicalPerson/Address" />
                <xsl:with-param name="gpiCountry" select="$currGPICountry" />
              </xsl:call-template>
            </xsl:if>
          </td>
          <td align="right" valign="top">
            <xsl:call-template name="formatPct">
              <xsl:with-param name="pct" select="$curr/DirectOwnership/Pct" />
            </xsl:call-template>
          </td>
          <td align="right" valign="top">
            <xsl:call-template name="formatPct">
              <xsl:with-param name="pct" select="$curr/ImplicitOwnership/Pct" />
            </xsl:call-template>
          </td>
          <td align="right" valign="top">
            <xsl:call-template name="formatPct">
              <xsl:with-param name="pct" select="$curr/TotalCapitalSharePct" />
            </xsl:call-template>
          </td>
              <td valign="top">
            <xsl:call-template name="implicitOwnershipUnwind">
              <xsl:with-param name="ownerId" select="$curr/OwnerID" />
              <xsl:with-param name="targetAssetId" select="$targetAssetId" />
              <xsl:with-param name="osHive" select="$osHive" />
              <xsl:with-param name="gpis" select="$gpis" />
            </xsl:call-template>
          </td>
        </tr>
          </xsl:if>
        </xsl:for-each>
      </tbody>
    </table>
  </xsl:template>
</xsl:stylesheet>
