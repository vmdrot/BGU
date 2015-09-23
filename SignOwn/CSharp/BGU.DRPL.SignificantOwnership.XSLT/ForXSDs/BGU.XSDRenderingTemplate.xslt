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
        <!--<link rel="stylesheet" href="Questionnaire_Files/Questionnaire_print.css" />-->
        <title>
          Детальна специфікація типу <xsl:value-of select="/xs:schema/xs:element/@name" />

        </title>
        <style media="screen" type="text/css">
          .typTbl
          {
          border: 2px solid Black ;
          }
          .typCell
          {
          border: 1px dotted Black;
          }
          .tbhd
          {
          background-color: LightGray;
          }
          .annot
          {
          color: DarkGreen;
          background-color: #DCDCDC;
          border: 1px dotted Black;
          width: 75%;
          }
        </style>
      </head>
      <body>
        <table style="width: 100%">
          <xsl:for-each select="/xs:schema/xs:complexType">
            <xsl:choose>
              <xsl:when test="./@hideFromHtml='true'"></xsl:when>
              <xsl:otherwise>
            <tr>
              <td width="100%">
                <br />
                <xsl:choose>
                  <xsl:when test="contains(./@name, 'ArrayOf')">
                    <xsl:call-template name="tmplArrayType">
                      <xsl:with-param name="arrTyp" select="." />
                    </xsl:call-template>
                  </xsl:when>

                  <xsl:otherwise>
                    <xsl:call-template name="tmplComplexType">
                      <xsl:with-param name="cmplxTyp" select="." />
                      <xsl:with-param name ="baseTyp" select="//xs:complexType[@name=.//xs:extension/@base]"/>
                    </xsl:call-template>
                    <!--</xsl:if>-->
                  </xsl:otherwise>
                </xsl:choose>
                <br />
                <br />
                <hr/>
              </td>
            </tr>
              </xsl:otherwise>
            </xsl:choose>
          </xsl:for-each>
          <xsl:for-each select="/xs:schema/xs:simpleType">
            <tr>
              <td width="100%">
                <!--<xsl:if test="xs:simpleType">-->
                <xsl:call-template name="tmplSimpleType">
                  <xsl:with-param name="simpleTyp" select="." />
                </xsl:call-template>
                <!--</xsl:if>-->
                <br />
                <br />
                <hr/>
              </td>
            </tr>
          </xsl:for-each>
        </table>
      </body>
    </html>
  </xsl:template>
</xsl:stylesheet>
