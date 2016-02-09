<?xml version="1.0" encoding="utf-8"?>
<xsl:stylesheet version="1.0" xmlns:xsl="http://www.w3.org/1999/XSL/Transform"
    xmlns:msxsl="urn:schemas-microsoft-com:xslt" exclude-result-prefixes="msxsl"
>
  <xsl:import href="ImplicitOwnershipUnwindFormulaRecursive.xslt" />

  <xsl:template name="implicitOwnershipUnwindFormula">
    <xsl:param name="ownerId" />
    <xsl:param name="targetAssetId" />
    <xsl:param name="osHive" />
    <xsl:param name="gpis" />
    <xsl:variable name="firstOSRaw">
      <xsl:copy-of select="$osHive/OwnershipStructure[Owner/CountryISO3Code = $ownerId/CountryISO3Code and Owner/PersonType = $ownerId/PersonType and Owner/PersonCode = $ownerId/PersonCode and not(Asset/CountryISO3Code = $targetAssetId/CountryISO3Code and Asset/PersonType = $targetAssetId/PersonType and Asset/PersonCode = $targetAssetId/PersonCode)][1]/*"/>
    </xsl:variable>
    <!--<xsl:if test="function-available(msxsl:node-set)">
      <xsl:text>function node-set is available</xsl:text>-->
      <xsl:variable name="firstOS" select="msxsl:node-set($firstOSRaw)"></xsl:variable>
    <!--<xsl:value-of select="$firstOS" />-->
    <xsl:for-each select="$osHive/OwnershipStructure[Owner/CountryISO3Code = $ownerId/CountryISO3Code and Owner/PersonType = $ownerId/PersonType and Owner/PersonCode = $ownerId/PersonCode]">
      <xsl:variable name="curr" select="."/>
      <xsl:choose>
        <xsl:when test="$curr/Asset/CountryISO3Code = $targetAssetId/CountryISO3Code and $curr/Asset/PersonType = $targetAssetId/PersonType and $curr/Asset/PersonCode = $targetAssetId/PersonCode">
        </xsl:when>
        <xsl:otherwise>
          <xsl:choose>
            <xsl:when test="$curr/Asset/CountryISO3Code = $firstOS//Asset/CountryISO3Code and $curr/Asset/PersonType = $firstOS//Asset/PersonType and $curr/Asset/PersonCode = $firstOS//Asset/PersonCode"></xsl:when>
            <!--<xsl:when test="$curr/Asset/CountryISO3Code = '455566666'"></xsl:when>-->
            <xsl:otherwise> + </xsl:otherwise>
          </xsl:choose>
          <xsl:value-of select="$curr/SharePct"/>
          <xsl:call-template name="implicitOwnershipUnwindFormulaRecursive">
            <xsl:with-param name="ownerId" select="$curr/Asset" />
            <xsl:with-param name="targetAssetId" select="$targetAssetId" />
            <xsl:with-param name="osHive" select="$osHive" />
            <xsl:with-param name="gpis" select="$gpis" />
            <xsl:with-param name="id" select="$curr/Asset" />
          </xsl:call-template>
        </xsl:otherwise>
      </xsl:choose>
    </xsl:for-each>
    <!--</xsl:if>-->
  </xsl:template>
</xsl:stylesheet>
