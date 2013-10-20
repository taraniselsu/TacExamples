set DIR=%1..\GameData\ThunderAerospace\Examples\PartRightClick\

if not exist %DIR% mkdir %DIR%
copy PartRightClick.dll %DIR%

cd %1..
call test.bat
