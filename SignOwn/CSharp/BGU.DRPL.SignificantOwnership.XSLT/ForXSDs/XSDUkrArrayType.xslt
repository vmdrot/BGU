<?xml version="1.0" encoding="utf-8"?>
<xsl:stylesheet version="1.0" xmlns:xsl="http://www.w3.org/1999/XSL/Transform"
    xmlns:msxsl="urn:schemas-microsoft-com:xslt" exclude-result-prefixes="msxsl"
    xmlns:xs="http://www.w3.org/2001/XMLSchema"
>
  <xsl:template name="tmplArrayType">
    <xsl:param name="arrTyp" />
    <H1>
      <a name="{$arrTyp/@name}"></a>
      Детальна специфікація типу <xsl:value-of select="$arrTyp/@name" />
    </H1>

    <xsl:if test="$arrTyp//xs:sequence/xs:element">
      <xsl:for-each select="$arrTyp//xs:sequence/xs:element">
        <p>
          Даний тип є колекцією елементів типу <a href="#{@type}">
            <xsl:value-of select="@type"/>
          </a>.
        </p>
      </xsl:for-each>
    </xsl:if>
    <xsl:if test="not($arrTyp//xs:sequence/xs:element)">
      <i>Цей тип (клас) не містить жодних полів з даними; це є, як правило, ознакою базового типу (класу), котрий має поведінкову цінність та використовується в інших, успадкованих від нього типах (класах).</i>
    </xsl:if>
  </xsl:template>
</xsl:stylesheet>
