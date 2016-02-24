SET PAUSE_EACH=%~1
SET EMULATE_ONLY=%~2
SET MAX_PROCESS_CNT=%~3

CALL bin\Debug\BGU.DRPL.DRClientAutomation.Console.exe RollbackAllChangesForToday %PAUSE_EACH% %EMULATE_ONLY% %MAX_PROCESS_CNT% >> RollbackAllChangesForToday.cmd.txt