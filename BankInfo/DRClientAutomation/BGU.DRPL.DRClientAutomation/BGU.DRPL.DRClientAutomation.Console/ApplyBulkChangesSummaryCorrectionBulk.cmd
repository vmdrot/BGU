SET PAUSE_MS=0
SET BEMUL=false
SET MAX_CNT=0
SET INPUT_FIL=%~1
SET MFO=%~2

bin\Debug\BGU.DRPL.DRClientAutomation.Console.exe ApplyChangesSummaryCorrectionBulk "%INPUT_FIL%" "%PAUSE_MS%" "%BEMUL%" "%MAX_CNT%" "%MFO%"  >> ApplyChangesSummaryCorrectionBulk.cmd.txt