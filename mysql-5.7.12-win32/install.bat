@echo off
color 1e
title Install mysqld...
%~d0
cd %~dp0

if not exist data (
	call initialize.bat
)

bin\mysqld --install MySQL3306 --defaults-file=%cd%\my.ini >nul 2>nul
echo MySQL service installed success, It will start automaticall after system bootup
echo.
ping 127.0.0.1 >nul
net start MySQL3306 2>nul
echo.
echo Install End. Please press any key to shutdown this windows.
pause >nul