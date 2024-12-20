FROM node:22.12.0 As builder

WORKDIR /usr/src/app

COPY package.json package-lock.json ./

RUN npm install

COPY . .

RUN npm run build --prod

FROM nginx:1.27.3

COPY --from=builder /usr/src/app/dist/client/browser/* /usr/share/nginx/html/