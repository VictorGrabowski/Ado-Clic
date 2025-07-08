
# Ado-Clic

Bienvenue sur **Ado-Clic** !  
Ce projet est une application C# utilisant .NET et PostgreSQL.

## 🚀 Installation

### Prérequis

- [.NET 9 SDK](https://dotnet.microsoft.com/download)
- [Make](https://gnuwin32.sourceforge.net/packages/make.htm) (pour Windows, optionnel)

### 1. Cloner le dépôt

```bash
git clone https://github.com/VictorGrabowski/Ado-Clic.git
cd Ado-Clic
```

### 2. Configurer la base de données

- Crée une base PostgreSQL (ex: `myapp`).
- Mets à jour la chaîne de connexion dans `appsettings.json` :

```json
"ConnectionStrings": {
  "DefaultConnection": "Host=localhost;Port=5432;Database=myapp;Username=postgres;Password=postgres"
}
```

### 3. Installer les dépendances, build l’application

```bash
make build
```

### 4. Appliquer les migrations

```bash
make migrate
```

### 5. Lancer l’application

```bash
make
```

## 🛠️ Commandes utiles

| Commande                | Description                        |
|-------------------------|------------------------------------|
| `make build`            | Compile le projet                  |
| `make test`             | Lance les tests                    |
| `make new-migration`    | Crée une migration (Windows)       |
| `make clean`            | Nettoie les fichiers générés       |

## 🔄 Maintenance

- **Migrations** :  
  Pour ajouter une migration (Windows) :
  ```bash
  make new-migration
  ```
- **Mise à jour des dépendances** :
  ```bash
  dotnet restore
  ```

- **Tests** :
  ```bash
  dotnet test
  ```

## 🤝 Contribuer

1. Fork le projet
2. Crée une branche (`git checkout -b feature/ma-feature`)
3. Commit tes modifications
4. Push et crée une Pull Request

---

**Ado-Clic** © VictorGrabowski  
Licence MIT
```
Ce fichier explique l’installation, la configuration, les commandes utiles et la maintenance du projet.
