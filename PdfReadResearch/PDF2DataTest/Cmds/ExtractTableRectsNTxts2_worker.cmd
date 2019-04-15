@echo off

SET PDF_PATH=%~1

SET LOG_PATH1=%PDF_PATH%.xtrects.log.json

..\bin\Debug\PDF2DataTest.exe ExtractTableRectangles "%PDF_PATH%" true 1> %LOG_PATH1% 2>&1

IF NOT "%ERRORLEVEL%"=="0" GOTO Exit

CALL ExtractTableTexts_worker.cmd "%PDF_PATH%" "%LOG_PATH1%"

:Exit
EXIT /B %ERRORLEVEL%

