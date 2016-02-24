SET PAUSE_MS=%~1
SET BEMUL=%~2
SET MAX_CNT=%~3

CALL ApplyBulkOpsSvcsChanges.cmd D:\home\vmdrot\BGU\Var\DerzhReiestr\OshchadBulkChange\RealPackages\BGU-DRPL_-_OshchadBulkChanges_20160224_PROD.xml "%PAUSE_MS%" "%BEMUL%" "%MAX_CNT%" 322669 > ApplyBulkOpsSvcsChanges_PrePROD_20160224.322669.cmd.txt 