#!/bin/bash

code=-1
tries=0
api=http://localhost:$PORT
printf "Connecting to $api"
while [[ "$code" -ne "0" ]]; do
  code=$(curl -so /dev/null --fail $api && echo 0 || echo 1)
  ((tries++))
  printf "."
  if [[ "$tries" -eq "60" ]]; then
    printf "Failed\n"
    >&2 echo "Could not connect to $api successfully"
    exit 1
  fi
  sleep 1
done
printf "Connected!\n"
exit 0
