#!/bin/bash

# put any commands to run at startup for all environments here

set -e

>&2 echo "Migrating database"
until dotnet ef database update; do
    sleep 1
done

>&2 echo "DONE Migrating database"

exec "$@"