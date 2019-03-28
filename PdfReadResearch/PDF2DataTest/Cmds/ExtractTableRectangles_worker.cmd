@echo off

SET PDF_PATH=%~1

SET LOG_PATH=%PDF_PATH%.xtrects.log.json

..\bin\Debug\PDF2DataTest.exe ExtractTableRectangles "%PDF_PATH%" 1> %LOG_PATH% 2>&1
