SET ASM_PATH=%~1
SET TYP_FQN=%~2
SET OUT_DIR=%~3

CD bin\Debug
BGU.DRPL.SignificantOwnership.Tester.exe UpdateXSDsUniversal "%ASM_PATH%" "%TYP_FQN%" "%OUT_DIR%"
cd ..\..\