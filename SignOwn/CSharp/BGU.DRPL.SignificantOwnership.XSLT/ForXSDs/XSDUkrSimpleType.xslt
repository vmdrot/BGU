<?xml version="1.0" encoding="utf-8"?>
<xsl:stylesheet version="1.0" xmlns:xsl="http://www.w3.org/1999/XSL/Transform"
    xmlns:msxsl="urn:schemas-microsoft-com:xslt" exclude-result-prefixes="msxsl"
    xmlns:xs="http://www.w3.org/2001/XMLSchema"
>
  <xsl:template name="tmplSimpleType">
    <xsl:param name="simpleTyp" />
    <H1>
      <a name="{$simpleTyp/@name}"></a>
      Детальна специфікація перелікового типу (enumeration) <xsl:value-of select="$simpleTyp/@name" />
    </H1>
    <xsl:if test="$simpleTyp/xs:annotation/xs:documentation">
      <h3>Загальні примітки за цим типом даних:</h3>
      <pre class="annot">
        <xsl:value-of select="$simpleTyp/xs:annotation/xs:documentation"/>
      </pre>
    </xsl:if>
    <p>
      <B>Перелік можливих значень:</B>
    </p>
    <table class="typTbl">
      <thead>
        <tr>
          <th class="typCell tbhd">Цифрове значення</th>
          <th class="typCell tbhd">Код (англ.)</th>
          <th class="typCell tbhd">Смислове значення (укр.)</th>
        </tr>
      </thead>
      <tbody>
        <xsl:for-each select="$simpleTyp/xs:restriction/xs:enumeration">
          <tr>
            <td class="typCell">
              <xsl:value-of select="@enum_value"/>
            </td>
            <td class="typCell">
              <xsl:value-of select="@value"/>
            </td>
            <td class="typCell">
              <xsl:value-of select="@description"/>
            </td>
          </tr>
        </xsl:for-each>
      </tbody>
    </table>
  </xsl:template>
</xsl:stylesheet>
