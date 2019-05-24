@echo off

SET PDF_PATH=%~1
SET RECTS_PATH=%~2
SET OUT_FILE_PATH=%~3

IF "%OUT_FILE_PATH%"=="" (SET LOG_PATH=%PDF_PATH%.xttbl_txts.log) ELSE (SET LOG_PATH=%OUT_FILE_PATH%.log)
IF "%OUT_FILE_PATH%"=="" (SET OUT_FILE_PATH=%LOG_PATH%.json)

..\bin\Debug\PDF2DataTest.exe ExtractTableTexts "%PDF_PATH%" "%RECTS_PATH%" "%OUT_FILE_PATH%" 1> %LOG_PATH% 2>&1

EXIT /B %ERRORLEVEL%