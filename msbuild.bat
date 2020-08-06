echo off
@echo Building with MsBuild

REM Set Path to MSBUILD.exe here

echo Running: "%programfiles(x86)%\MSBuild\14.0\bin\msbuild.exe" build.proj
"%programfiles(x86)%\MSBuild\14.0\bin\msbuild.exe" build.proj

pause
REM net stop "Service Host Manager Watcher"
REM net stop "Service Host Manager"
REM copy .\XCSRFToken.zip "c:\Program Files\Decisions\Decisions Services Manager\CustomModules" /Y
REM net start "Service Host Manager"
pause
