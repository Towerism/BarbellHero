#!/bin/bash

set -ex

docker build -t barbellhero_client_test ClientApp
docker run barbellhero_client_test ng test --single-run
export PORT=3000

docker-compose up -d \
  && ci/waitForWebsite.sh \
  && docker run --net host barbellhero_client_test ng e2e --serve false --host 0.0.0.0 --port $PORT \
  && docker-compose down \
  || (docker-compose down && exit 1)