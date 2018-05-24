FROM node:latest AS deps
ENV HOME=/home/app
WORKDIR $HOME
COPY package.json yarn.lock ./
RUN yarn
EXPOSE 4200
