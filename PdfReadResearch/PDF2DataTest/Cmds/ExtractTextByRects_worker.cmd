@echo off

SET PDF_PATH=%~1
SET RECTS_PATH=%~2

SET LOG_PATH=%PDF_PATH%.xtrects_txts.log

..\bin\Debug\PDF2DataTest.exe ExtractTextByRects "%PDF_PATH%" "%RECTS_PATH%" "%LOG_PATH%.json" 1> %LOG_PATH% 2>&1

EXIT /B %ERRORLEVEL%