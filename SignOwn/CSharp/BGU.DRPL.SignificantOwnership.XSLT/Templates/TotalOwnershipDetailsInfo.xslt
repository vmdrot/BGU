<?xml version="1.0" encoding="utf-8"?>
<xsl:stylesheet version="1.0" xmlns:xsl="http://www.w3.org/1999/XSL/Transform"
    xmlns:msxsl="urn:schemas-microsoft-com:xslt" exclude-result-prefixes="msxsl"
>
  <xsl:template name="tmpTotalOwnershipDetails">
    <xsl:param name="totalOwnershipDetailsInfo" />
    <table width="100%" class="infoTable">
      <thead>
        <tr>
          <th colspan="3">Пряма участь</th>
          <th colspan="5">Опосередкована участь</th>
          <th rowspan="3">Загальний % участі у статному капіталі банку</th>
          <th rowspan="3">Загальна кількість голосів у банку</th>
        </tr>
        <tr>
          <th rowspan="2">%</th>
          <th rowspan="2">Грн.</th>
          <th rowspan="2">Кількість голосів</th>
          <th colspan="3">Сукупна опосередкована участь</th>
          <th colspan="2">В тому числі набуте право голосу</th>
        </tr>
        <tr>
          <th>%</th>
          <th>Грн.</th>
          <th>Кількість голосів</th>
          <th>%</th>
          <th>Кількість голосів</th>
        </tr>
        <tr>
          <th width="5%">1</th>
          <th width="10%">2</th>
          <th width="10%">3</th>
          <th width="5%">4</th>
          <th width="10%">5</th>
          <th width="10%">6</th>
          <th width="5%">7</th>
          <th width="10%">8</th>
          <th width="10%">9</th>
          <th width="10%">10</th>
        </tr>
      </thead>
      <tbody>
        <tr>
          <td align="right">
            <xsl:value-of select="$totalOwnershipDetailsInfo/DirectOwnership/Pct"/>
          </td>
          <td align="right">
            <xsl:value-of select="$totalOwnershipDetailsInfo/DirectOwnership/Amount"/>
          </td>
          <td align="center">
            <xsl:value-of select="$totalOwnershipDetailsInfo/DirectOwnership/Votes"/>
          </td>
          <td align="right">
            <xsl:value-of select="$totalOwnershipDetailsInfo/ImplicitOwnership/Pct"/>
          </td>
          <td align="right">
            <xsl:value-of select="$totalOwnershipDetailsInfo/ImplicitOwnership/Amount"/>
          </td>
          <td align="right">
            <xsl:value-of select="$totalOwnershipDetailsInfo/ImplicitOwnership/Votes"/>
          </td>
          <td align="right">
            <xsl:value-of select="$totalOwnershipDetailsInfo/AcquiredVotes/Pct"/>
          </td>
          <td align="right">
            <xsl:value-of select="$totalOwnershipDetailsInfo/AcquiredVotes/Votes"/>
          </td>
          <td align="right">
            <xsl:value-of select="$totalOwnershipDetailsInfo/TotalCapitalSharePct"/>
          </td>
          <td align="right">
            <xsl:value-of select="$totalOwnershipDetailsInfo/TotalVotes"/>
          </td>
        </tr>
      </tbody>
    </table>
    <br/>

  </xsl:template>
</xsl:stylesheet>
