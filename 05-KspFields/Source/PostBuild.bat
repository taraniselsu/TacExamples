set DIR=%1..\GameData\ThunderAerospace\Examples\KspFields\

if not exist %DIR% mkdir %DIR%
copy KspFieldsExample.dll %DIR%

cd %1..
call test.bat
