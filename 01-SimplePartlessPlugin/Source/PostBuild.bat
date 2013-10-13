set DIR=%1..\GameData\ThunderAerospace\Examples\SimplePartlessPlugin\

if not exist %DIR% mkdir %DIR%
copy SimplePartlessPlugin.dll %DIR%

cd %1..
call test.bat
