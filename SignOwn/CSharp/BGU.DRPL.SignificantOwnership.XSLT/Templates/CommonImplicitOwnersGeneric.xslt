<?xml version="1.0" encoding="utf-8"?>
<xsl:stylesheet version="1.0" xmlns:xsl="http://www.w3.org/1999/XSL/Transform"
    xmlns:msxsl="urn:schemas-microsoft-com:xslt" exclude-result-prefixes="msxsl"
>
  <!--<xsl:include href="FormatDate.xslt" />
  <xsl:include href="FormatAddressStreetEtc.xslt" />-->
  <xsl:template name="tmplCommonImplicitOwnersGeneric">
    <xsl:param name="commonOwnershipInfos" />
      <table width="100%" class="infoTable">
        <thead>
          <tr>
            <th rowspan="2">Група спільного володіння</th>
            <th rowspan="2">Повне ім’я (для фізичної особи)<br/>Повне найменування (для юридичної особи)
            </th>
            <th colspan="3">Паспортні дані(для фізичної особи)</th>
            <th rowspan="2">Податковий номер</th>
            <th colspan="4">
              Місце проживання (для фізичної особи)<br/>Місцезнаходження (для юридичної особи)</th>
            <th rowspan="2">Тип спільного володіння</th>
            <th rowspan="2">Підстава спільного володіння</th>
            <th rowspan="2">Частка особи у спільному володінні*</th>
          </tr>
          <tr>
            <th>Номер паспорта</th>
            <th>Дата видачі</th>
            <th>Орган видачі</th>
            <th>Країна</th>
            <th>Населений пункт</th>
            <th>Індекс</th>
            <th>Вулиця, номер будинку, приміщення</th>
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
            <th>11</th>
            <th>12</th>
            <th>13</th>
          </tr>
        </thead>
        <tbody>
          <xsl:for-each select="$commonOwnershipInfos/CommonOwnershipInfo/Partners[GenericPersonInfo/CouncilMemberInfo[Member[PersonType='Physical']]">
            <tr>
              <td>
                <xsl:call-template name="formatPhysPersonFullNameUkr">
                  <xsl:with-param name="physicalPerson" select="Member/PhysicalPerson" />
                </xsl:call-template>
                
              </td>
              <td>
                <xsl:value-of select="PositionName"/>
              </td>
              <td>
                <xsl:value-of select="Member/PhysicalPerson/PassportID"/>
              </td>
              <td>
                <xsl:call-template name="formatDate">
                  <xsl:with-param name="dateTime" select="Member/PhysicalPerson/PassIssuedDate" />
                </xsl:call-template>
              </td>
              <td>
                <xsl:value-of select="Member/PhysicalPerson/PassIssueAuthority/RegistrarName"/>
              </td>
              <td>
                <xsl:value-of select="Member/PhysicalPerson/TaxOrSocSecID"/>
              </td>
              <td>
                <xsl:value-of select="Member/PhysicalPerson/Address/Country/CountryNameUkr"/>(<xsl:value-of select="Member/PhysicalPerson/Address/Country/CountryISONr"/>)
              </td>
              <td>
                <xsl:value-of select="Member/PhysicalPerson/Address/City" />
              </td>
              <td>
                <xsl:value-of select="Member/PhysicalPerson/Address/ZipCode" />
              </td>
              <td>
                <xsl:call-template name="formatAddressStreetEtc">
                  <xsl:with-param name="address" select="Member/PhysicalPerson/Address" />
                </xsl:call-template>
              </td>
            </tr>
          </xsl:for-each>
        </tbody>
      </table>
    <br/>
    
    </xsl:template>
</xsl:stylesheet>
