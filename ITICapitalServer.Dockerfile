FROM mcr.microsoft.com/windows:1809 AS app

RUN powershell Invoke-WebRequest -UseBasicParsing -Uri "https://iticapital.ru/downloads/software/SmartCOM-x64/4.0.14444" -OutFile C:\SmartCOM_x64.msi
RUN powershell Start-Process -FilePath "C:\\Windows\\System32\\msiexec.exe" -ArgumentList "/i", "C:\\SmartCOM_x64.msi", "/qn", "/NoRestart" -NoNewWindow -Wait
RUN powershell Remove-Item C:\SmartCOM_x64.msi -Force

WORKDIR /app
COPY ITICapitalServer/bin/Release/Current .

EXPOSE ${GRPC_PORT}

ENTRYPOINT ["ITICapitalServer.exe"]

#FROM mcr.microsoft.com/dotnet/framework/sdk:4.8 AS build
#WORKDIR /app
#
#COPY *.sln .
#COPY ITICapitalServer/. ./ITICapitalServer/
#
#WORKDIR /app/ITICapitalServer
#
#RUN msbuild /t:restore
#RUN msbuild /p:Configuration=Release
#
#FROM mcr.microsoft.com/dotnet/framework/aspnet:4.8 AS runtime
#WORKDIR /inetpub/wwwroot
#COPY --from=build /app/ITICapitalServer/. ./