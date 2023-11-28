#uporabi ASP.NET Core runtime kot osnovno sliko
FROM mcr.microsoft.com/dotnet/aspnet:7.0 AS base
WORKDIR /app
EXPOSE 80
EXPOSE 443

#uporabi SDK sliko za gradnjo kode
FROM mcr.microsoft.com/dotnet/sdk:7.0 AS build
WORKDIR /src

#kopira csproj in obnovite odvisnosti
COPY ["Fitness/Fitness.csproj", "./"]
RUN dotnet restore "./Fitness.csproj"

#kopira celoten source code in zgradite projekt
COPY ["Fitness/", "./"]
RUN dotnet build "Fitness.csproj" -c Release -o /app/build

#objavi aplikacijo
FROM build AS publish
RUN dotnet publish "Fitness.csproj" -c Release -o /app/publish /p:UseAppHost=false

#končna slika, ki bo zagnala aplikacijo
FROM base AS final
WORKDIR /app
COPY --from=publish /app/publish .
ENTRYPOINT ["dotnet", "Fitness.dll"]
