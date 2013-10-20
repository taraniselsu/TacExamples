set DIR=%1..\GameData\ThunderAerospace\Examples\ActionGroups\

if not exist %DIR% mkdir %DIR%
copy ActionGroups.dll %DIR%

cd %1..
call test.bat
