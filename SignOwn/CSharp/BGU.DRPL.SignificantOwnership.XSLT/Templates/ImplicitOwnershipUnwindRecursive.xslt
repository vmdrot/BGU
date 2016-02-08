<?xml version="1.0" encoding="utf-8"?>
<xsl:stylesheet version="1.0" xmlns:xsl="http://www.w3.org/1999/XSL/Transform"
    xmlns:msxsl="urn:schemas-microsoft-com:xslt" exclude-result-prefixes="msxsl"
>
  <xsl:import href="FullNameByPersonId.xslt" />

  <xsl:template name="implicitOwnershipUnwindRecursive">
    <xsl:param name="ownerId" />
    <xsl:param name="targetAssetId" />
    <xsl:param name="osHive" />
    <xsl:param name="gpis" />
    <xsl:for-each select="$osHive/OwnershipStructure[Owner/CountryISO3Code = $ownerId/CountryISO3Code and Owner/PersonType = $ownerId/PersonType and Owner/PersonCode = $ownerId/PersonCode]">
      <xsl:variable name="curr" select="."/>
            якому належить <xsl:value-of select="$curr/SharePct"/>% у <xsl:call-template name="fullNameByPersonId"><xsl:with-param name="gpis" select="$gpis" /><xsl:with-param name="id" select="$curr/Asset" /></xsl:call-template> <br/>
      <xsl:if test="$curr/Asset/CountryISO3Code = $targetAssetId/CountryISO3Code and $curr/Asset/PersonType = $targetAssetId/PersonType and $curr/Asset/PersonCode = $targetAssetId/PersonCode">
      <xsl:call-template name="implicitOwnershipUnwindRecursive">
        <xsl:with-param name="ownerId" select="$curr/Asset" />
        <xsl:with-param name="targetAssetId" select="$targetAssetId" />
        <xsl:with-param name="osHive" select="$osHive" />
        <xsl:with-param name="gpis" select="$gpis" />
        <xsl:with-param name="id" select="$curr/Asset" />
      </xsl:call-template>
      </xsl:if>
    </xsl:for-each>
  </xsl:template>
</xsl:stylesheet>
