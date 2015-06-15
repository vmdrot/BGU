<?xml version="1.0" encoding="utf-8"?>
<xsl:stylesheet version="1.0" xmlns:xsl="http://www.w3.org/1999/XSL/Transform"
    xmlns:msxsl="urn:schemas-microsoft-com:xslt" exclude-result-prefixes="msxsl"
>
  <xsl:template name="tmplSupervisoryCouncilLegal">
    <xsl:param name="council" />
    <table width="100%" class="infoTable">
      <thead>
        <tr>
          <th rowspan="2">Повне найменування юридичної особи</th>
          <th rowspan="2">Посада (статус) ***</th>
          <th rowspan="2">Ідентифікаційний номер юридичної особи*</th>
          <th colspan="4">Місцезнаходження</th>
          <th colspan="3">Інформація про фізичну особу (осіб), яка представляє юридичну особу – члена наглядової (спостережної) ради юридичної особи**</th>
        </tr>
        <tr>
          <th>Країна</th>
          <th>Населений пункт</th>
          <th>Індекс</th>
          <th>Вулиця, номер будинку, приміщення</th>
          <th>Повне ім’я фізичної особи</th>
          <th>Паспортні дані</th>
          <th>Адреса</th>
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
          <th>10</th>
        </tr>
      </thead>
      <tbody>
        <xsl:for-each select="$council/Members/CouncilMemberInfo[Member[PersonType='Legal']]">
          <tr>
            <td>
              <xsl:value-of select="Member/LegalPerson/Name"/>
            </td>
            <td>
              <xsl:value-of select="PositionName"/>
            </td>
            <td>
              <xsl:value-of select="Member/LegalPerson/TaxCodeOrHandelsRegNr"/>
            </td>
            <td>
              <xsl:value-of select="Member/LegalPerson/Address/Country/CountryNameUkr"/>(<xsl:value-of select="Member/LegalPerson/Address/Country/CountryISONr"/>)
            </td>
            <td>
              <xsl:value-of select="Member/LegalPerson/Address/City"/>
            </td>
            <td>
              <xsl:value-of select="Member/LegalPerson/Address/ZipCode"/>
            </td>
            <td>
              <xsl:call-template name="formatAddressStreetEtc">
                <xsl:with-param name="address" select="Member/LegalPerson/Address" />
              </xsl:call-template>
            </td>
            <td>
              <xsl:call-template name="formatPhysPersonFullNameUkr">
                <xsl:with-param name="physicalPerson" select="Member/LegalPerson/RepresentedBy" />
              </xsl:call-template>
            </td>
            <td>
              ІПН: <xsl:value-of select="Member/LegalPerson/RepresentedBy/TaxOrSocSecID" /><br/>
              Паспорт: <xsl:value-of select="Member/LegalPerson/RepresentedBy/PassportID" />, виданий <xsl:call-template name="formatDate"><xsl:with-param name="dateTime" select="Member/LegalPerson/RepresentedBy/PassIssuedDate" /></xsl:call-template>
            </td>
            <td>
              <xsl:call-template name="formatAddressStreetEtc">
                <xsl:with-param name="address" select="Member/LegalPerson/RepresentedBy/Address" />
              </xsl:call-template><br/>
              <xsl:value-of select="Member/LegalPerson/RepresentedBy/Address/ZipCode"/> <xsl:value-of select="Member/LegalPerson/RepresentedBy/Address/City"/>,<br/>
              <xsl:value-of select="Member/LegalPerson/RepresentedBy/Address/Country/CountryNameUkr"/>
            </td>
          </tr>
        </xsl:for-each>
      </tbody>
    </table>
    <br/>

  </xsl:template>
</xsl:stylesheet>
