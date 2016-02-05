<?xml version="1.0" encoding="utf-8"?>
<xsl:stylesheet version="1.0" xmlns:xsl="http://www.w3.org/1999/XSL/Transform"
    xmlns:msxsl="urn:schemas-microsoft-com:xslt" exclude-result-prefixes="msxsl"
>
<xsl:template name="formatAddressZipCityStreetEtc"><xsl:param name="address" /><xsl:if test="$address/ZipCode!=''"><xsl:value-of select="normalize-space($address/ZipCode)"/></xsl:if><xsl:if test="$address/City!=''">, <xsl:value-of select="normalize-space($address/City)"/></xsl:if><xsl:if test="$address/Street!=''">, <xsl:value-of select="normalize-space($address/Street)"/></xsl:if><xsl:if test="$address/HouseNr!=''">, <xsl:value-of select="normalize-space($address/HouseNr)"/></xsl:if><xsl:if test="$address/ApptOfficeNr!=''">, <xsl:value-of select="normalize-space($address/ApptOfficeNr)"/></xsl:if></xsl:template></xsl:stylesheet>
