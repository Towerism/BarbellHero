#!/bin/bash

set -x

if [ $E2E -eq 0 ]; then
  docker build -t barbellhero_client_test ClientApp
  docker run barbellhero_client_test ng test --single-run
  testResult=$?
else
  export PORT=3000
  docker-compose up -d
  ci/waitForWebsite.sh
  testResult=$?
  if [ $testResult -eq 0 ]; then 
    docker run --net host barbellhero_client_test ng e2e --serve false --host 0.0.0.0 --port $PORT
  fi
  docker-compose down
fi
exit $testResult