<?xml version="1.0" encoding="utf-8"?>
<xsl:stylesheet version="1.0" xmlns:xsl="http://www.w3.org/1999/XSL/Transform"
    xmlns:msxsl="urn:schemas-microsoft-com:xslt" exclude-result-prefixes="msxsl"
>
  <!--<xsl:include href="FormatAddressZipCityStreetEtc.xslt" />-->

  <xsl:template name="arrayOfTotalOwnershipDetailsInfoEx">
    <xsl:param name="theArr" />
    <xsl:param name="gpis" />
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
        <!--<xsl:variable name="arrIdx">
          <xsl:number/>
        </xsl:variable>-->
        <xsl:for-each select="$theArr/TotalOwnershipDetailsInfoEx">
          <!--<xsl: name="arrIdx" select="$arrIdx+1"/>-->
          <xsl:variable name="curr" select="."/>
          <xsl:variable name="currGPI" select="$gpis/GenericPersonInfo[PersonType=$curr/OwnerID/PersonType and ((PersonType='Legal' and LegalPerson/TaxCodeOrHandelsRegNr=$curr/OwnerID/PersonCode and LegalPerson/ResidenceCountry/CountryISONr=$curr/OwnerID/CountryISO3Code) or (PersonType='Physical' and PhysicalPerson/TaxOrSocSecID=$curr/OwnerID/PersonCode and PhysicalPerson/CitizenshipCountry/CountryISONr=$curr/OwnerID/CountryISO3Code))][1]"></xsl:variable> <!--doesn't work-->
          <!--<xsl:variable name="currGPI" select="$gpis/GenericPersonInfo[PersonType=$curr/OwnerID/PersonType][1]"></xsl:variable>-->
        <tr>
          <td>
            <!--<xsl:value-of select="generate-id()"/> / <xsl:value-of select="$arrIdx"/> / <xsl:value-of select="1+ count(preceding-sibling::record)"/> /--> <!--didn't work-->
            <xsl:value-of select="1 + count(preceding-sibling::*)"/>
          </td>
          <td>
            <xsl:value-of select="$currGPI/PersonType"/> / 
            <xsl:if test="$currGPI/PersonType='Legal'">
              <xsl:value-of select="$currGPI/LegalPerson/Name"/>
            </xsl:if>
            <xsl:if test="$currGPI/PersonType='Physical'">
              <xsl:value-of select="$currGPI/PhysicalPerson/FullName"/>
            </xsl:if>
          </td>
          <td>
            <xsl:if test="$currGPI/PersonType='Legal'">
              ЮО
            </xsl:if>
            <xsl:if test="$currGPI/PersonType='Physical'">
              ФО
            </xsl:if>
          </td>
          <td>
            <xsl:if test="$curr/TotalCapitalSharePct &gt;= 10">Так</xsl:if>
            <xsl:if test="$curr/TotalCapitalSharePct &lt; 10">Ні</xsl:if>
          </td>
          <td>
            <xsl:if test="$currGPI/PersonType = 'Legal'">
              <xsl:value-of select="$currGPI/LegalPerson/ResidenceCountry/CountryNameUkr"/>,
            <xsl:call-template name="formatAddressZipCityStreetEtc">
              <xsl:with-param name="address" select="$currGPI/LegalPerson/Address" />
            </xsl:call-template>
            </xsl:if>
            <xsl:if test="$currGPI/PersonType = 'Physical'">
              <xsl:value-of select="$currGPI/LegalPerson/CitizenshipCountry/CountryNameUkr"/>,
              <xsl:call-template name="formatAddressZipCityStreetEtc">
                <xsl:with-param name="address" select="$currGPI/PhysicalPerson/Address" />
              </xsl:call-template>
            </xsl:if>
          </td>
          <td align="right">
            <!--<xsl:value-of select='format-number( round(100*$curr/DirectOwnership/Pct) div 100 ,"##0.00" )' />-->
            <xsl:call-template name="formatPct">
              <xsl:with-param name="pct" select="$curr/DirectOwnership/Pct" />
            </xsl:call-template>
          </td>
          <td align="right">
            <!--<xsl:value-of select="$curr/ImplicitOwnership/Pct" />-->
            <xsl:call-template name="formatPct">
              <xsl:with-param name="pct" select="$curr/ImplicitOwnership/Pct" />
            </xsl:call-template>
          </td>
          <td align="right">
            <xsl:call-template name="formatPct">
              <xsl:with-param name="pct" select="$curr/TotalCapitalSharePct" />
            </xsl:call-template>
            <!--<xsl:value-of select="$curr/TotalCapitalSharePct" />-->
          </td>
          <td>9</td>
        </tr>
        </xsl:for-each>
      </tbody>
    </table>
  </xsl:template>
</xsl:stylesheet>
