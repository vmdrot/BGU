<?xml version="1.0" encoding="utf-8"?>
<xsl:stylesheet version="1.0" xmlns:xsl="http://www.w3.org/1999/XSL/Transform"
    xmlns:msxsl="urn:schemas-microsoft-com:xslt" exclude-result-prefixes="msxsl"
    xmlns:xs="http://www.w3.org/2001/XMLSchema"
>
  <xsl:output method="html" indent="yes"/>

  <xsl:include href="XSDUkrComplexType.xslt" />
  <xsl:include href="XSDUkrSimpleType.xslt" />
  <xsl:include href="XSDUkrArrayType.xslt" />

  <xsl:template match="xs:schema">
    <html>
      <head>
        <style>
          <!-- insert css here -->
        </style>
      </head>
      <body>

      </body>
      <!-- insert markup here-->
    </html>
  </xsl:template>
</xsl:stylesheet>
