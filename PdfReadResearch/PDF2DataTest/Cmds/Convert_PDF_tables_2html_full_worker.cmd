@echo off
SET SRC_PDF=%~1
SET OUT_HTML_PATH=%~2

SET RECTS_PATH=%SRC_PDF%.table_rects.json
SET RECTXTS_PATH=%SRC_PDF%.table_rects_txts.json
SET MATRIX_PATH=%SRC_PDF%.mtrxs.json

IF "%OUT_HTML_PATH%"=="" (SET OUT_HTML_PATH=%SRC_PDF%.tables.html)

CALL ExtractTableRectangles_worker.cmd "%SRC_PDF%" true "%RECTS_PATH%"
IF NOT "%ERRORLEVEL%"=="0" (GOTO ExtractTableRectangles_Error)

CALL ExtractTextByRects_worker.cmd "%SRC_PDF%" "%RECTS_PATH%" "%RECTXTS_PATH%"
IF NOT "%ERRORLEVEL%"=="0" (GOTO ExtractTextByRects_Error)

..\bin\Debug\PDF2DataTest.exe BuildCellsMatrix "%RECTXTS_PATH%" "%SRC_PDF%" "%MATRIX_PATH%"
IF NOT "%ERRORLEVEL%"=="0" (GOTO BuildCellsMatrix_Error)

..\bin\Debug\PDF2DataTest.exe CellMatrices2Html "%MATRIX_PATH%" "%OUT_HTML_PATH%"
IF NOT "%ERRORLEVEL%"=="0" (GOTO CellMatrices2Html_Error) ELSE (GOTO Success)

:ExtractTableRectangles_Error
ECHO Error extracting tables rectangles (step 1)
GOTO Exit

:ExtractTextByRects_Error
ECHO Error extracting tables rectangles texts (step 2)
GOTO Exit

:BuildCellsMatrix_Error
ECHO Error building the tables cells matrix (step 3)
GOTO Exit

:CellMatrices2Html_Error
ECHO Error converting the tables cells matrices to HTML (step 4)
GOTO Exit

:Success
ECHO Extraction and conversion completed successfully!

:Exit
ECHO Exit code - %ERRORLEVEL%
EXIT /B %ERRORLEVEL%