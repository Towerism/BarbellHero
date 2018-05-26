FROM node:latest AS deps
ENV HOME=/home/app
WORKDIR $HOME
COPY package.json yarn.lock ./
RUN yarn
EXPOSE 4200

FROM trion/ng-cli-karma:1.7.4 AS test
ENV HOME=/home/app
WORKDIR $HOME
COPY . .
COPY --from=deps /home/app .
