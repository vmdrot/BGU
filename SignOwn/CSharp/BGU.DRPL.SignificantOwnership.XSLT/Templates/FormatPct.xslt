<?xml version="1.0" encoding="utf-8"?>
<xsl:stylesheet version="1.0" xmlns:xsl="http://www.w3.org/1999/XSL/Transform"
    xmlns:msxsl="urn:schemas-microsoft-com:xslt" exclude-result-prefixes="msxsl"
>
  <xsl:template name="formatPct">
    <xsl:param name="pct" />
    <xsl:choose>
      <xsl:when test="null != $pct or $pct != 0">
        <!--<xsl:value-of select='format-number(round(100 * $pct) div 100, "##0.0000")' />-->
        <xsl:value-of select='format-number($pct, "##0.000000")' />
      </xsl:when>
      <xsl:otherwise>0.000000</xsl:otherwise>
    </xsl:choose>
  </xsl:template>
</xsl:stylesheet>