@echo off
cd %~dp0
set App=DNotepad
title %App% Compiler 
echo DMC C# Universal Compiling Script for %App%
echo.
echo Compiling %App%
echo.
cd ..\..\src\
dotnet build DNotepad.csproj --nologo -c Release 
echo.
echo Application Compiled!
echo.
echo Compiling %App% Installer
echo.
cd /d "C:\Program Files (x86)\NSIS\"
makensis.exe %~dp0\main.nsi
echo.
echo Installer Compiled!
pause
exit