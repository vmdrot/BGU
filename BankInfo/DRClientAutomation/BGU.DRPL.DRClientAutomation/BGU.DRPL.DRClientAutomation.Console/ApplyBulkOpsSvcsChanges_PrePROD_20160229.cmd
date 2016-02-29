SET PAUSE_MS=%~1
SET BEMUL=%~2
SET MAX_CNT=%~3

CALL ApplyBulkOpsSvcsChanges.cmd D:\home\vmdrot\BGU\Var\DerzhReiestr\OshchadBulkChange\RealPackages\BGU-DRPL_-_OshchadBulkChanges_20160229_PROD.xml "%PAUSE_MS%" "%BEMUL%" "%MAX_CNT%" 354507 > ApplyBulkOpsSvcsChanges_PrePROD_20160229.354507.cmd.txt 
CALL ApplyBulkOpsSvcsChanges.cmd D:\home\vmdrot\BGU\Var\DerzhReiestr\OshchadBulkChange\RealPackages\BGU-DRPL_-_OshchadBulkChanges_20160229_PROD.xml "%PAUSE_MS%" "%BEMUL%" "%MAX_CNT%" 322669 > ApplyBulkOpsSvcsChanges_PrePROD_20160229.322669.cmd.txt 
