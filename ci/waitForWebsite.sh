#!/bin/bash

responseCode=""
tries=0
api=http://localhost:$PORT
printf "Connecting to $api"
while [ "$responseCode" != "200" ]; do
  responseCode=$(curl -o /dev/null -s -w "%{http_code}" $api)
  ((tries++))
  printf "."
  sleep 1
  if [ $tries == 30 ]; then
    printf "Failed\n"
    >&2 echo "Could not connect to $api successfully"
    exit 1
  fi
done
printf "Connected!\n"
exit 0
