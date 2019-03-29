@echo off

SET PDF_PATH=%~1
SET TRIM_OVERLAPS=%~2

SET LOG_PATH=%PDF_PATH%.xtrects.log.json

..\bin\Debug\PDF2DataTest.exe ExtractTableRectangles "%PDF_PATH%" %TRIM_OVERLAPS% 1> %LOG_PATH% 2>&1
