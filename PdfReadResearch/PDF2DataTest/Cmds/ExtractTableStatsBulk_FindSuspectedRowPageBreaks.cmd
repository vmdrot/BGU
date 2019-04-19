SET STATS_JSON=F:\home\vmdrot\Testing\OpenData\Output\BGU\328\stats.log.json
SET RSLT_JSON=F:\home\vmdrot\Testing\OpenData\Output\BGU\328\stats.suspectedRowBreaks.log.json

..\bin\Debug\PDF2DataTest.exe ExtractTableStatsBulk F:\home\vmdrot\Testing\OpenData\Output\BGU\328\??????_????????.pdf.xttbl_txts.log.json > %STATS_JSON%
..\bin\Debug\PDF2DataTest.exe GetSuspectedRowBreaksFromTableStats "%STATS_JSON%" > %RSLT_JSON%