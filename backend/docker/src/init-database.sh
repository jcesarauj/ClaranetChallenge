# Wait to be sure that SQL Server came up
sleep 90s
/opt/mssql-tools/bin/sqlcmd -S sqlserver -U sa -P @cl4r4n3t! -d master -i /tmp/create-database.sql
/opt/mssql-tools/bin/sqlcmd -S sqlserver -U sa -P @cl4r4n3t! -d master -i /tmp/create-database-tests.sql