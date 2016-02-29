SET PAUSE_MS=%~1
SET BEMUL=%~2
SET MAX_CNT=%~3

CALL ApplyBulkOpsSvcsChanges.cmd D:\home\vmdrot\BGU\Var\DerzhReiestr\OshchadBulkChange\RealPackages\BGU-DRPL_-_OshchadBulkChanges_20160225_PROD.xml "%PAUSE_MS%" "%BEMUL%" "%MAX_CNT%" 338545 > ApplyBulkOpsSvcsChanges_PrePROD_20160225.338545.cmd.txt 