@ECHO OFF
SET MYSQL_EXE="C:\Program Files\MySQL\MySQL Server 5.5\bin\mysql.exe"
SET BATCH_FILES="C:\ProgramData\21Batch\EIS\"
SET HOST=localhost
SET DB_USER=user21-batch
SET DB_PWD=21express*
SET CURR_YEAR=%date:~10,4%

CD %BATCH_FILES%

slave stop;
slave start;