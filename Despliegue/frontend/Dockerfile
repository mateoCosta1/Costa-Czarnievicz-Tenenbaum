#FROM node:latest as node
FROM node:14.2.0-alpine3.11 as build
WORKDIR /app
COPY . .

#FROM nginx:alpine
FROM nginx as runtime
#COPY --from=node /app /usr/share/nginx/html
COPY --from=build /app /usr/share/nginx/html
#docker build -t front-image ./
#docker run -p 8081:80 front-image