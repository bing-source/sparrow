@echo off
color 1e
title Backup
%~d0
cd %~dp0

set TODAY=%date:~,4%%date:~5,2%%date:~8,2%
set BACK_FILE=%cd%\backups\%TODAY%.sql

rem delet old files
mkdir backups >nul 2>nul
del /f /q %BACK_FILE% >nul 2>nul
del /f /q %BACK_FILE%.gz >nul 2>nul

bin\mysqldump fmc_webhost >%BACK_FILE% 2>nul

rem check bakup files success or not...
set /p BACK_FILE_firstline=<%BACK_FILE%
if "%BACK_FILE_firstline%"=="" (
	echo ERR: Backup files failed.
	del /f /q %BACK_FILE% >nul 2>nul
	goto END
)

rem Compressed backup files...
gzip %BACK_FILE%

echo Backup file success£º
echo %BACK_FILE%.gz

:END
echo.
echo This window will close automaticaly after 5 seconds...
ping -n 5 127.0.0.0 >nul