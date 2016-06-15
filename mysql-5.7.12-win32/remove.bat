@echo off
color 1e
title Remove mysqld...
%~d0
cd %~dp0

net stop MySQL3306 2>nul
bin\mysqld --remove MySQL3306 >nul 2>nul
echo.
echo Remove End. Please press any key to shutdown this windows.
pause >nul