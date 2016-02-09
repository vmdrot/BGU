SET IN_XML_FILE=%~1
SET IN_XSL_FILE=%~2

DEL "%IN_XML_FILE%.html"
..\3dPartyLibraries\Microsoft\MSXsl\msxsl.exe "%IN_XML_FILE%" "%IN_XSL_FILE%" -o "%IN_XML_FILE%.html"  >"%IN_XML_FILE%.txt"
