<?xml version="1.0" encoding="utf-8"?>
<xsl:stylesheet version="1.0" xmlns:xsl="http://www.w3.org/1999/XSL/Transform"
    xmlns:msxsl="urn:schemas-microsoft-com:xslt" exclude-result-prefixes="msxsl"
>
  <xsl:template name="formatPhysPersonFullNameUkr">
    <xsl:param name="physicalPerson" />
    <xsl:if test="$physicalPerson/FullNameUkr!=''">
      <xsl:value-of select="$physicalPerson/FullNameUkr"/>
    </xsl:if>
    <xsl:if test="not($physicalPerson/FullNameUkr!='')">
      <xsl:value-of select="$physicalPerson/FullName"/>
    </xsl:if>
  </xsl:template>
</xsl:stylesheet>
