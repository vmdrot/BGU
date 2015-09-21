<?xml version="1.0" encoding="utf-8"?>
<xsl:stylesheet version="1.0" xmlns:xsl="http://www.w3.org/1999/XSL/Transform"
    xmlns:msxsl="urn:schemas-microsoft-com:xslt" exclude-result-prefixes="msxsl" 
    xmlns:xs="http://www.w3.org/2001/XMLSchema"
>
  <xsl:template name="tmplComplexType">
    <xsl:param name="cmplxTyp" />
    <H1>
      <a name="$cmplxTyp/@name"></a>
      Детальна специфікація типу <xsl:value-of select="$cmplxTyp/@name" />
    </H1>

    <xsl:if test="$cmplxTyp/xs:annotation/xs:documentation">
      <h3>Загальні примітки за цим типом даних:</h3>
    <pre class="annot">
      <xsl:value-of select="$cmplxTyp/xs:annotation/xs:documentation"/>
    </pre>
    </xsl:if>
    <p>
      <b>Поля:</b></p>
    <table class="typTbl">
      <thead>
      <tr>
        <th width="5%" class="typCell tbhd">№ п/п</th>
        <th width="15%" class="typCell tbhd">Назва поля</th>
        <th width="15%" class="typCell tbhd">Назва поля (укр.)</th>
        <th width="7%" class="typCell tbhd">Тип поля</th>
        <th width="3%" class="typCell tbhd">Обов'язковість поля</th>
        <th width="70%" class="typCell tbhd">
          Примітки
        </th>
      </tr>
      </thead>
      <tbody>
      <xsl:for-each select="$cmplxTyp//xs:sequence/xs:element">
          <tr>
            <td class="typCell">
              <xsl:value-of select="@field_order"/>
          </td>
            <td class="typCell">
            <xsl:value-of select="@name"/>
          </td>
            <td class="typCell">
                <xsl:value-of select="@displayName"/>
            </td>
            <td class="typCell">
              <xsl:if test="not(@type_ukr)">
                <a href="#{@type}">
                  <xsl:value-of select="@type"/>
                </a>
              </xsl:if>
              <xsl:if test="@type_ukr">
                <xsl:value-of select="@type_ukr"/>
              </xsl:if>
            </td>
            <td class="typCell">
              <xsl:if test="@minOccurs=1">
                Так
              </xsl:if>
              <xsl:if test="@minOccurs=0">
                Ні
              </xsl:if>
            </td>
            <td class="typCell">
              <pre>
              <xsl:value-of select="xs:annotation/xs:documentation"/>
              </pre>
            </td>
          </tr>
      </xsl:for-each>
      </tbody>
    </table>

  </xsl:template>
</xsl:stylesheet>
