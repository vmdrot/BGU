SET IN_FILE=%1
..\3dPartyLibraries\Microsoft\MSXsl\msxsl.exe %IN_FILE% ..\BGU.DRPL.SignificantOwnership.XSLT\ForXSDs\BGU.XSDRenderingTemplate.xslt -o %IN_FILE%.html > %IN_FILE%.txt