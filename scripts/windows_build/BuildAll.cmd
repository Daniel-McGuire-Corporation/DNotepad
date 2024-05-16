@echo off
cd %~dp0
set App=DNotepad
title %App% Compiler 
echo DMC C# Universal Compiling Script for %App%
echo.
echo Compiling %App%
echo.
cd ..\..\src\
dotnet build DNotepad.csproj --nologo -c Release --verbosity detailed
cd ..\InsPathComp\
echo.
echo Compiling Installer Path Component
echo.
dotnet build PathEd.csproj --nologo -c Release -o ..\bin\Release\net6.0-windows7.0\Path\ --verbosity detailed
echo.
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
