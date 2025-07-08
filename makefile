# Utilise dotnet CLI pour les commandes .NET
SOLUTION = $(wildcard *.sln)

.PHONY: all restore build test clean

all: run

restore:
	dotnet restore $(SOLUTION)

build: restore
	dotnet build $(SOLUTION) --no-restore --configuration Release

test: build
	dotnet test $(SOLUTION) --no-build --configuration Release

clean:
	dotnet clean $(SOLUTION)
	
run: build
	docker compose up --build
	
migrate: run
	dotnet ef database update --project Ado-Clic
	
new-migration:
	@cmd /C "set /p name=Nom de la migration : & dotnet ef migrations add %name% --project Infrastructure --startup-project Ado-Clic"
	
undo-migration:
	dotnet ef migrations remove --project Infrastructure --startup-project Ado-Clic"