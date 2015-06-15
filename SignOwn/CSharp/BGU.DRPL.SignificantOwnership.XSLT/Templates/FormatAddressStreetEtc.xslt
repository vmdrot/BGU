<?xml version="1.0" encoding="utf-8"?>
<xsl:stylesheet version="1.0" xmlns:xsl="http://www.w3.org/1999/XSL/Transform"
    xmlns:msxsl="urn:schemas-microsoft-com:xslt" exclude-result-prefixes="msxsl"
>
  <xsl:template name="formatAddressStreetEtc">
    <xsl:param name="address" />
    <xsl:if test="$address/Street!=''">
      <xsl:value-of select="$address/Street"/>
    </xsl:if>
    <xsl:if test="$address/HouseNr!=''">
      , буд.<xsl:value-of select="$address/HouseNr"/>
    </xsl:if>
    <xsl:if test="$address/ApptOfficeNr!=''">
      , кв./офіс <xsl:value-of select="$address/ApptOfficeNr"/>
    </xsl:if>

  </xsl:template>
</xsl:stylesheet>
