<?xml version="1.0" encoding="utf-8"?>
<xsl:stylesheet version="1.0" xmlns:xsl="http://www.w3.org/1999/XSL/Transform"
    xmlns:msxsl="urn:schemas-microsoft-com:xslt" exclude-result-prefixes="msxsl"
>
  <xsl:import href="FormatDate.xslt" />
  <xsl:template name="signatoryPlusContactPersonInfo">
    <xsl:param name="signatoryInfo" />
    <xsl:param name="contactPersonInfo" />
    <table width="100%" id="tblSignatory" align="center">
      <tr>
        <td width="10%"></td>
        <td width="24%" class="signTD">
          <b><xsl:value-of select="$signatoryInfo/SignatoryPosition" />
          </b>
        </td>
        <td width="10%"></td>
        <td width="23%" class="signTD">
        </td>
        <td width="10%"></td>
        <td width="23%" class="signTD">
          <b>
            <xsl:value-of select="$signatoryInfo/SurnameInitials" />
          </b>
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
        <td></td>
        <td class="signTD">
          <b>
            <xsl:call-template name="formatDate">
              <xsl:with-param name="dateTime" select="$signatoryInfo/DateSigned" />
            </xsl:call-template>
          </b>
      </td>
        <td></td>
        <td class="signTD">
          <b><xsl:value-of select="$contactPersonInfo/Person/FullName" />
          </b>
        </td>
        <td></td>
        <td class="signTD">
          <b>
            <xsl:value-of select="$contactPersonInfo/Phones/PhoneInfo[1]/PhoneNr" />
          </b>
        </td>
        <td></td>
      </tr>
      <tr>
        <td></td>
        <td class="signTDCaptBelow">(число, місяць, рік)</td>
        <td></td>
        <td class="signTDCaptBelow">(прізвище  та ініціали  виконавця)</td>
        <td></td>
        <td class="signTDCaptBelow">(телефон виконавця)</td>
        <td></td>
      </tr>
    </table>
  </xsl:template>
</xsl:stylesheet>
