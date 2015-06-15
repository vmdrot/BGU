<?xml version="1.0" encoding="utf-8"?>
<xsl:stylesheet version="1.0" xmlns:xsl="http://www.w3.org/1999/XSL/Transform"
    xmlns:msxsl="urn:schemas-microsoft-com:xslt" exclude-result-prefixes="msxsl"
>
  <xsl:template name="tmplSignatoryInfo">
    <xsl:param name="signatoryInfo" />
    <table width="100%" id="tblSignatory" align="center">
      <tr>
        <td width="10%"></td>
        <td width="24%" class="signTD">
            <xsl:value-of select="$signatoryInfo/SignatoryPosition" />
        </td>
        <td width="10%"></td>
        <td width="23%" class="signTD">
        </td>
        <td width="10%"></td>
        <td width="23%" class="signTD">
            <xsl:value-of select="$signatoryInfo/SurnameInitials" />
        </td>
        <td width="10%"></td>
      </tr>
      <tr>
        <td></td>
        <td class="signTDCaptBelow">
          (посада керівника юридичної<br/>
          особи-заявника, який підписав анкету)
        </td>
        <td></td>
        <td class="signTDCaptBelow">
          (підпис керівника)<br/>
          М. П.
        </td>
        <td></td>
        <td class="signTDCaptBelow">
          (ініціали та прізвище керівника<br/>
          друкованими літерами)
        </td>
        <td></td>
      </tr>
      <tr>
        <td>Підписано</td>
        <td class="signTD"><xsl:call-template name="formatDate"><xsl:with-param name="dateTime" select="$signatoryInfo/DateSigned" /></xsl:call-template>
      </td>
        <td></td>
        <td></td>
        <td></td>
        <td></td>
        <td></td>
      </tr>
      <tr>
        <td></td>
        <td class="signTDCaptBelow">(число, місяць, рік)</td>
        <td></td>
        <td></td>
        <td></td>
        <td></td>
        <td></td>
      </tr>
    </table>
  </xsl:template>
</xsl:stylesheet>
