@echo off
for /f "delims=" %%a in (version) DO ( 
 set /A version=%%a
)
set /A version = %version%+1
echo %version%

echo %version% > version

nuget pack ChileafBleXamarin.nuspec -p Configuration=Debug -p Version=%version%

