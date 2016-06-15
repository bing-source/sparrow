@echo off
color 1e
title Initialize...
%~d0
cd %~dp0

if exist "data" (
	echo If you need to initialize MySQL again, please delet the directory ¡°%cd%\data¡±.
	echo.
	pause
	exit
)

echo Waiting..., It will take about 30 seconds...
echo.
bin\mysqld  --initialize-insecure
echo MySQL system database initialized success.

start /HIGH bin\mysqld
echo Start the temporary database serve.
echo.

rem modify password as root
ping 127.0.0.1 >nul
bin\mysql -uroot --execute="set password=password('root');flush privileges;" 2>nul

bin\mysql -uroot -proot --execute="drop database if exists fmc_webhost;create database fmc_webhost;" 2>nul
echo Create a new database

bin\mysql -uroot -proot fmc_webhost <table_structure.sql 2>nul
echo Load database sturcture success.

bin\mysqladmin -uroot -proot shutdown 2>nul
echo Stop the temporary database serve.

echo.