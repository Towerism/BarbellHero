#!/bin/bash

docker build -t barbellhero_client_test ClientApp
docker run barbellhero_client_test ng test --single-run