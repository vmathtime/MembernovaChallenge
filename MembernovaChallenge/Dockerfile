FROM mcr.microsoft.com/dotnet/aspnet:6.0 AS base
WORKDIR /app
EXPOSE 80
EXPOSE 443

FROM mcr.microsoft.com/dotnet/sdk:6.0 AS build
WORKDIR /src
COPY ["MembernovaChallenge/MembernovaChallenge.csproj", "MembernovaChallenge/"]
COPY ["MembernovaChallenge.Application/MembernovaChallenge.Application.csproj", "MembernovaChallenge.Application/"]
COPY ["MembernovaChallenge.Contracts/MembernovaChallenge.Contracts.csproj", "MembernovaChallenge.Contracts/"]
COPY ["MembernovaChallenge.CountriesApi/MembernovaChallenge.CountriesApi.csproj", "MembernovaChallenge.CountriesApi/"]
COPY ["MembernovaChallenge.Domain/MembernovaChallenge.Domain.csproj", "MembernovaChallenge.Domain/"]
RUN dotnet restore "MembernovaChallenge/MembernovaChallenge.csproj"
COPY . .
WORKDIR "/src/MembernovaChallenge"
RUN dotnet build "MembernovaChallenge.csproj" -c Release -o /app/build

FROM build AS publish
RUN dotnet publish "MembernovaChallenge.csproj" -c Release -o /app/publish

FROM base AS final
WORKDIR /app
COPY --from=publish /app/publish .
ENTRYPOINT ["dotnet", "MembernovaChallenge.dll"]