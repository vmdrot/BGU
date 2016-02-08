<?xml version="1.0" encoding="utf-8"?>
<xsl:stylesheet version="1.0" xmlns:xsl="http://www.w3.org/1999/XSL/Transform"
    xmlns:msxsl="urn:schemas-microsoft-com:xslt" exclude-result-prefixes="msxsl"
>
  <xsl:template name="fullNameByPersonId">
    <xsl:param name="id" />
    <xsl:param name="gpis" />
    <xsl:choose>
      <xsl:when test ="$id/PersonType = 'Physical'">
        <xsl:value-of select="$gpis/GenericPersonInfo[PersonType = 'Physical' and PhysicalPerson/CitizenshipCountry/CountryISONr = $id/CountryISO3Code and PhysicalPerson/TaxOrSocSecID = $id/PersonCode]/PhysicalPerson/FullName"/>
      </xsl:when>
      <xsl:when test ="$id/PersonType = 'Legal'">
        <xsl:value-of select="$gpis/GenericPersonInfo[PersonType = 'Legal' and LegalPerson/ResidenceCountry/CountryISONr = $id/CountryISO3Code and LegalPerson/TaxCodeOrHandelsRegNr = $id/PersonCode]/LegalPerson/Name"/>
      </xsl:when>
    </xsl:choose>
  </xsl:template>
</xsl:stylesheet>
