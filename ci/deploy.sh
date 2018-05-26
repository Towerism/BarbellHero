#!/bin/bash

docker login -u "$HEROKU_USER" -p "$HEROKU_TOKEN" registry.heroku.com
docker build -t barbellhero ./BarbellHero
docker tag barbellhero registry.heroku.com/barbellhero/web
docker push registry.heroku.com/barbellhero/web