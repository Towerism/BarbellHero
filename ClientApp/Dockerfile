FROM mhart/alpine-node:latest AS deps
WORKDIR /src
RUN apk add --no-cache make gcc g++ python2

FROM deps AS dev
COPY ./package*.json ./
RUN npm install
EXPOSE 4200
