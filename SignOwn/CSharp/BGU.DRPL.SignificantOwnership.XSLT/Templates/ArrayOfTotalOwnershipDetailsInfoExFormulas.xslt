<?xml version="1.0" encoding="utf-8"?>
<xsl:stylesheet version="1.0" xmlns:xsl="http://www.w3.org/1999/XSL/Transform"
    xmlns:msxsl="urn:schemas-microsoft-com:xslt" exclude-result-prefixes="msxsl"
>
  <!--<xsl:include href="FormatAddressZipCityStreetEtc.xslt" />-->
  <xsl:import href="FormatDate.xslt" />
  <xsl:import href="FormatPct.xslt" />
  <xsl:import href="ImplicitOwnershipUnwindFormula.xslt" />

  <xsl:template name="arrayOfTotalOwnershipDetailsInfoExFormulas">
    <xsl:param name="theArr" />
    <xsl:param name="gpis" />
    <xsl:param name="osHive" />
    <xsl:param name="targetAssetId" />
    <table width="100%" style="border: 1pt solid;">
      <thead>
        <tr>
          <th width="3%">
            №<br/>з/п
          </th>
          <th width="27%">
            Прізвище, ім'я  та по батькові фізичної  особи
            або повне найменування юридичної особи
          </th>
          <th width="70%">Розрахунок</th>
        </tr>
        <tr>
          <th>1</th>
          <th>2</th>
          <th>3</th>
        </tr>
      </thead>
      <tbody>
        <xsl:for-each select="$theArr/TotalOwnershipDetailsInfoEx">
          <xsl:variable name="curr" select="."/>
          <xsl:if test="$curr/OwnerID/PersonType != 'None'">
            <xsl:variable name="currGPI" select="$gpis/GenericPersonInfo[PersonType=$curr/OwnerID/PersonType and ((PersonType='Legal' and LegalPerson/TaxCodeOrHandelsRegNr=$curr/OwnerID/PersonCode and LegalPerson/ResidenceCountry/CountryISONr=$curr/OwnerID/CountryISO3Code) or (PersonType='Physical' and PhysicalPerson/TaxOrSocSecID=$curr/OwnerID/PersonCode and PhysicalPerson/CitizenshipCountry/CountryISONr=$curr/OwnerID/CountryISO3Code))][1]"></xsl:variable>
            <xsl:if test="$curr/ImplicitOwnership/Pct > 0">
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
                <td valign="top" align="left">
                  <xsl:call-template name="implicitOwnershipUnwindFormula">
                    <xsl:with-param name="ownerId" select="$curr/OwnerID" />
                    <xsl:with-param name="targetAssetId" select="$targetAssetId" />
                    <xsl:with-param name="osHive" select="$osHive" />
                    <xsl:with-param name="gpis" select="$gpis" />
                  </xsl:call-template> = <xsl:value-of select="$curr/ImplicitOwnership/Pct" />
                </td>
              </tr>
            </xsl:if>
          </xsl:if>
        </xsl:for-each>
      </tbody>
    </table>
  </xsl:template>
</xsl:stylesheet>
