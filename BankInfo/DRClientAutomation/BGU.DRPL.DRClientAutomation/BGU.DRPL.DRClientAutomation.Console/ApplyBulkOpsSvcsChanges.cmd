SET FNAME=%~1
SET PAUSE_EACH=%~2
SET EMULATE_ONLY=%~3
SET MAX_PROCESS_CNT=%~4
SET PARENT_MFO=%~5

bin\Debug\BGU.DRPL.DRClientAutomation.Console.exe ApplyBulkOpsSvcsChanges "%FNAME%" %2 %3 %4 %5