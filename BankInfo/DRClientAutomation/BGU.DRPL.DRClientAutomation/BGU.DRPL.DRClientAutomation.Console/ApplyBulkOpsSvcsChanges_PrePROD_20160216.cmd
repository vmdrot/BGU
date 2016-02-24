SET PAUSE_MS=%~1
SET BEMUL=%~2
SET MAX_CNT=%~3

REM CALL ApplyBulkOpsSvcsChanges.cmd D:\home\vmdrot\BGU\Var\DerzhReiestr\OshchadBulkChange\RealPackages\BGU-DRPL_-_OshchadBulkChanges_20160216_PROD.xml "%PAUSE_MS%" "%BEMUL%" "%MAX_CNT%" 303398 > ApplyBulkOpsSvcsChanges_PrePROD_20160216.303398.cmd.txt 
CALL ApplyBulkOpsSvcsChanges.cmd D:\home\vmdrot\BGU\Var\DerzhReiestr\OshchadBulkChange\RealPackages\BGU-DRPL_-_OshchadBulkChanges_20160216_PROD.xml "%PAUSE_MS%" "%BEMUL%" "%MAX_CNT%" 335106 > ApplyBulkOpsSvcsChanges_PrePROD_20160216.335106.cmd.txt 