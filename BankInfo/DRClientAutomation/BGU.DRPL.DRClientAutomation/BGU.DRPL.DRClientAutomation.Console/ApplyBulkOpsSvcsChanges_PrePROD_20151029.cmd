SET PAUSE_MS=%~1
SET BEMUL=%~2
SET MAX_CNT=%~3

CALL ApplyBulkOpsSvcsChanges.cmd D:\home\vmdrot\BGU\Var\DerzhReiestr\OshchadBulkChange\RealPackages\BGU-DRPL_-_OshchadBulkChanges_20151029_PROD.xml "%PAUSE_MS%" "%BEMUL%" "%MAX_CNT%" 305482 > ApplyBulkOpsSvcsChanges_PrePROD_20151029.305482.cmd.txt
REM CALL ApplyBulkOpsSvcsChanges.cmd D:\home\vmdrot\BGU\Var\DerzhReiestr\OshchadBulkChange\RealPackages\BGU-DRPL_-_OshchadBulkChanges_20151029_PROD.xml "%PAUSE_MS%" "%BEMUL%" "%MAX_CNT%" 311647 D:\home\vmdrot\DEV\BGU\BankInfo\DRClientAutomation\BGU.DRPL.DRClientAutomation\BGU.DRPL.DRClientAutomation.Console\ApplyBulkOpsSvcsChanges_Write.311647.skip.txt > ApplyBulkOpsSvcsChanges_PrePROD_20151029.311647.cmd.txt 
REM CALL ApplyBulkOpsSvcsChanges.cmd D:\home\vmdrot\BGU\Var\DerzhReiestr\OshchadBulkChange\RealPackages\BGU-DRPL_-_OshchadBulkChanges_20151029_PROD.xml "%PAUSE_MS%" "%BEMUL%" "%MAX_CNT%" 351823 > ApplyBulkOpsSvcsChanges_PrePROD_20151029.351823.cmd.txt
REM CALL ApplyBulkOpsSvcsChanges.cmd D:\home\vmdrot\BGU\Var\DerzhReiestr\OshchadBulkChange\RealPackages\BGU-DRPL_-_OshchadBulkChanges_20151029_PROD.xml "%PAUSE_MS%" "%BEMUL%" "%MAX_CNT%" 352457 > ApplyBulkOpsSvcsChanges_PrePROD_20151029.352457.cmd.txt 