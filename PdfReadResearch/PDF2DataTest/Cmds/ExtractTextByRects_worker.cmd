@echo off

SET PDF_PATH=%~1
SET RECTS_PATH=%~2

SET LOG_PATH=%PDF_PATH%.xtrects.log

..\bin\Debug\PDF2DataTest.exe "%PDF_PATH%" "%RECTS_PATH%" "%LOG_PATH%.json" 1> %LOG_PATH% 2>&1
