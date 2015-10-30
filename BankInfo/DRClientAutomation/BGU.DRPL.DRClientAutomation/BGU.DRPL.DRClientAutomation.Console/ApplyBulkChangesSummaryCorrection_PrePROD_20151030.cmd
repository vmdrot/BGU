SET PAUSE_MS=%~1
SET BEMUL=%~2
SET MAX_CNT=%~3

CALL ApplyBulkChangesSummaryCorrection.cmd D:\home\vmdrot\BGU\Var\DerzhReiestr\OshchadBulkChange\RealPackages\BGU-DRPL_-_OshchadBulkChanges_20151029_PROD.xml "%PAUSE_MS%" "%BEMUL%" "%MAX_CNT%" 311647 > ApplyBulkChangesSummaryCorrection_PrePROD_20151030.cmd.txt 
