SET FNAME=%~1
SET PAUSE_EACH=%~2
SET EMULATE_ONLY=%~3
SET MAX_PROCESS_CNT=%~4
SET PARENT_MFO=%~5
SET SKIP_BRANCHES_FIL=%~6

bin\Debug\BGU.DRPL.DRClientAutomation.Console.exe ApplyChangesSummaryCorrectionToSingleBranchTest "%FNAME%" %2 %3 %4 %5 %6  >> ApplyBulkChangesSummaryCorrectionSingle.cmd.txt