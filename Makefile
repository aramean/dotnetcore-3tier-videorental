SHELL := /bin/bash # Use bash syntax

default:
	docker-compose build

up: default
	docker-compose up -d

install:
	@dotnet tool install -g dotnet-ef && echo "[Success]" || echo "[Failure]"
	@dotnet add package Microsoft.EntityFrameworkCore.SqlServer --version 3.0.0 && echo "[Success]" || echo "[Failure]"
	@dotnet add package Microsoft.EntityFrameworkCore.Design && echo "[Success]" || echo "[Failure]"
	@dotnet add package Microsoft.DotNet.Watcher.Tools && echo "[Success]" || echo "[Failure]"
	@dotnet add package Microsoft.AspNetCore.Mvc.NewtonsoftJson --version 3.0.0 && echo "[Success]" || echo "[Failure]"

run:
	@dotnet run

rebuild: ef%rebuild watch

watch:
	@cd UI & dotnet watch run

ef%rebuild:
	cd DAL
	rm -fr Migrations/*
	dotnet ef database drop -f -v
	dotnet ef migrations add InitialCreate
	dotnet ef database update -v

ef%rebuild-win:
	@if exist DAL/Migrations rmdir /s /q "DAL/Migrations"
	@cd DAL & dotnet ef database drop -f -v
	@cd DAL & dotnet ef migrations add InitialCreate
	@cd DAL & dotnet ef database update -v

ssl%create:
	dotnet dev-certs https --clean
	dotnet dev-certs https --trust

mssql%start:
	docker-compose run -d db

ide%reset:
	rm -fr ~/Library/Preferences/VisualStudio