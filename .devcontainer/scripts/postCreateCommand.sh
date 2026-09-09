#!/bin/bash
set -euo pipefail

SApassword=$1
dacpath=$2
sqlpath=$3

ready="false"
for _ in {1..60};
do
    if /opt/mssql-tools/bin/sqlcmd -S localhost -U sa -P "$SApassword" -d master -Q "SELECT 1" > /dev/null 2>&1
    then
        ready="true"
        echo "SQL server ready"
        break
    else
        echo "Not ready yet..."
        sleep 1
    fi
done

if [ "$ready" != "true" ]
then
    echo "SQL server failed to start" >&2
    exit 1
fi

shopt -s nullglob

for f in "$sqlpath"/*.sql
do
    echo "Executing $f"
    /opt/mssql-tools/bin/sqlcmd -S localhost -U sa -P "$SApassword" -d master -i "$f"
done

dacpacs=("$dacpath"/*.dacpac)
if [ ${#dacpacs[@]} -eq 0 ]
then
    echo "No dacpac files found in $dacpath" >&2
    exit 1
fi

for f in "${dacpacs[@]}"
do
    dbname=$(basename "$f" ".dacpac")
    echo "Deploying dacpac $f"
    /opt/sqlpackage/sqlpackage /Action:Publish /SourceFile:"$f" /TargetServerName:localhost /TargetDatabaseName:"$dbname" /TargetUser:sa /TargetPassword:"$SApassword" /TargetEncryptConnection:False
done
