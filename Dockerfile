FROM mcr.microsoft.com/dotnet/sdk:5.0-alpine as dev
ARG PORT=5000
ENV PORT $PORT
EXPOSE $PORT
WORKDIR /app/api
