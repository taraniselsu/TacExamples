set DIR=%1..\GameData\ThunderAerospace\Examples\SimplePartModule\

if not exist %DIR% mkdir %DIR%
copy SimplePartModule.dll %DIR%

cd %1..
call test.bat
