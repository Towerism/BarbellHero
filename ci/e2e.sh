#!/bin/bash

docker-compose up -d && sleep 10
docker run --net host barbellhero_client_test ng e2e --serve false --host 0.0.0.0 --port 5000
docker-compose down