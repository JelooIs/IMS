# ?? IMS (Inventory Management System)

Un système de gestion d'inventaires simple et moderne construit avec **Blazor Server** et **.NET 8**.

## ?? À propos du Projet

IMS est une application web permettant de :
- ? Gérer des **produits** (création, édition, suppression, consultation)
- ? Gérer des **inventaires** (stock, prix, quantités)
- ? Associer des inventaires aux produits
- ? Valider les prix des produits par rapport aux coûts des inventaires

## ??? Architecture

Ce projet suit l'architecture **Clean Architecture** avec une séparation claire des responsabilités :

```
??? IMS.CoreBusiness/          # Domaine - Entités et validations métier
?   ??? Product.cs
?   ??? Inventory.cs
?   ??? ProductInventory.cs
?   ??? Validations/
?
??? IMS.UseCases/              # Logique métier - Cas d'usage
?   ??? Products/
?   ??? Inventories/
?   ??? PluginInterfaces/
?
??? IMS.Plugins.InMemory/      # Persistance - Repositories en mémoire
?   ??? ProductRepository.cs
?   ??? InventoryRepository.cs
?   ??? InventoryTransactionRepository.cs
?
??? IMS.WebApp/                # Présentation - Interface Blazor
    ??? Components/
    ??? Pages/
    ?   ??? Products/
    ?   ??? Inventories/
    ?   ??? Activities/
    ??? Program.cs
```

## ?? Démarrage Rapide

### Prérequis

- **.NET 8 SDK** ([Télécharger](https://dotnet.microsoft.com/download/dotnet/8.0))
- **Visual Studio 2022** (ou Visual Studio Code avec C# Dev Kit)
- **Git** (optionnel)

### Installation et Lancement

#### Option 1 : Avec Visual Studio 2022

1. **Cloner ou ouvrir le projet** :
   ```bash
   git clone https://github.com/JelooIs/IMS.git
   cd IMS
   ```

2. **Ouvrir la solution** :
   - Double-cliquez sur `IMS.sln`

3. **Restaurer les dépendances** (automatique) :
   - Visual Studio restaure les packages NuGet automatiquement

4. **Définir le projet de démarrage** :
   - Clic droit sur `IMS.WebApp` ? Définir comme projet de démarrage

5. **Lancer l'application** :
   - Appuyez sur `F5` ou cliquez sur le bouton de lecture (??)
   - L'application s'ouvrira par défaut à : `https://localhost:7216`

#### Option 2 : Avec la Ligne de Commande

1. **Cloner le projet** :
   ```bash
   git clone https://github.com/JelooIs/IMS.git
   cd IMS
   ```

2. **Restaurer les dépendances** :
   ```bash
   dotnet restore
   ```

3. **Construire la solution** :
   ```bash
   dotnet build
   ```

4. **Lancer l'application** :
   ```bash
   cd IMS.WebApp
   dotnet run
   ```

5. **Accéder à l'application** :
   - Ouvrez votre navigateur et allez à : `https://localhost:7216`

#### Option 3 : Avec Visual Studio Code

1. **Ouvrir le dossier du projet** :
   ```bash
   code .
   ```

2. **Ouvrir le terminal intégré** (`Ctrl + `)

3. **Lancer le projet** :
   ```bash
   dotnet run --project IMS.WebApp
   ```

## ?? Fonctionnalités

### ?? Gestion des Produits
- **Créer** : Ajouter un nouveau produit avec nom, quantité et prix
- **Éditer** : Modifier les informations d'un produit existant
- **Supprimer** : Retirer un produit du système
- **Consulter** : Voir les détails et l'historique d'un produit
- **Associer des inventaires** : Lier des inventaires à un produit

### ?? Gestion des Inventaires
- **Créer** : Ajouter un nouvel inventaire (stock)
- **Éditer** : Modifier les informations d'un inventaire
- **Supprimer** : Retirer un inventaire
- **Consulter** : Voir les détails d'un inventaire
- **Transactionnel** : Enregistrer les mouvements d'inventaire

### ? Validations Métier
- **Prix du Produit** : Doit être ? au coût total des inventaires associés
- **Quantités** : Doivent être positives
- **Longueur des noms** : Limités à 100 caractères

## ??? Technologies

| Technologie | Version | Utilisation |
|-------------|---------|------------|
| **.NET** | 8.0 | Framework principal |
| **Blazor** | Server | Framework UI |
| **C#** | 12.0 | Langage de programmation |
| **Bootstrap** | 5.x | Styling CSS |

## ?? Structure des Dossiers

```
IMS/
??? IMS.CoreBusiness/          # Entités et validations
?   ??? Product.cs
?   ??? Inventory.cs
?   ??? ProductInventory.cs
?   ??? Validations/
?       ??? Product_EnsurePriceIsGreaterThanInventoriesCost.cs
?
??? IMS.UseCases/              # Logique applicative
?   ??? Products/
?   ?   ??? AddProductUseCase.cs
?   ?   ??? EditProductUseCase.cs
?   ?   ??? DeleteProductUseCase.cs
?   ?   ??? ViewProductByIdUseCase.cs
?   ?   ??? ViewProductsByNameUseCase.cs
?   ??? Inventories/
?   ?   ??? AddInventoryUseCase.cs
?   ?   ??? EditInventoryUseCase.cs
?   ?   ??? DeleteInventoryUseCase.cs
?   ?   ??? ViewInventoryByIdUseCase.cs
?   ?   ??? ViewInventoriesByNameUseCase.cs
?   ??? Activities/
?
??? IMS.Plugins.InMemory/      # Persistance en mémoire
?   ??? ProductRepository.cs
?   ??? InventoryRepository.cs
?   ??? InventoryTransactionRepository.cs
?
??? IMS.WebApp/                # Application Blazor
?   ??? Components/
?   ?   ??? Pages/
?   ?   ?   ??? Products/
?   ?   ?   ?   ??? AddProduct.razor
?   ?   ?   ?   ??? EditProduct.razor
?   ?   ?   ?   ??? ...
?   ?   ?   ??? Inventories/
?   ?   ?       ??? AddInventory.razor
?   ?   ?       ??? EditInventory.razor
?   ?   ?       ??? ...
?   ?   ??? ...
?   ??? Program.cs             # Configuration et injection de dépendances
?   ??? App.razor              # Point d'entrée
?   ??? appsettings.json       # Configuration
?
??? README.md                  # Ce fichier
```

## ?? Configuration

La configuration de l'application se trouve dans `IMS.WebApp/appsettings.json` :

```json
{
  "Logging": {
    "LogLevel": {
      "Default": "Information"
    }
  },
  "AllowedHosts": "*"
}
```

## ?? Stockage des Données

Actuellement, l'application utilise un **stockage en mémoire** (`IMS.Plugins.InMemory`).

**?? Attention** : Les données sont **perdues lors du redémarrage** de l'application.

Pour **persister les données**, vous pouvez :
1. Implémenter un repository avec **Entity Framework Core** et une base de données (SQL Server, PostgreSQL, etc.)
2. Implémenter un repository avec **fichiers JSON** (sérialisation)
3. Ajouter une vraie base de données (recommandé pour la production)

## ?? Injection de Dépendances

L'injection de dépendances est configurée dans `IMS.WebApp/Program.cs` :

```csharp
// Repositories (Persistance)
builder.Services.AddSingleton<IInventoryRepository, InventoryRepository>();
builder.Services.AddSingleton<IProductRepository, ProductRepository>();

// Use Cases (Logique métier)
builder.Services.AddTransient<IAddProductUseCase, AddProductUseCase>();
builder.Services.AddTransient<IEditProductUseCase, EditProductUseCase>();
// ... etc
```

## ?? Dépannage

### Application ne démarre pas
```bash
# Nettoyez et reconstruisez
dotnet clean
dotnet build
dotnet run --project IMS.WebApp
```

### Erreur de certificat HTTPS
```bash
# Approuver le certificat de développement .NET
dotnet dev-certs https --trust
```

### Ports déjà utilisés
L'application écoute par défaut sur `https://localhost:7216`. Si le port est occupé, modifiez-le dans `launchSettings.json`.

## ?? Ressources Utiles

- [Documentation Blazor Server](https://learn.microsoft.com/en-us/aspnet/core/blazor/)
- [Clean Architecture](https://blog.cleancoder.com/uncle-bob/2012/08/13/the-clean-architecture.html)
- [.NET 8 Documentation](https://learn.microsoft.com/en-us/dotnet/core/whats-new/dotnet-8)

## ?? Contribution

Les contributions sont bienvenues ! N'hésitez pas à :
1. Fork le repository
2. Créer une branche (`git checkout -b feature/amazing-feature`)
3. Commiter vos changements (`git commit -m 'Add amazing feature'`)
4. Pousser vers la branche (`git push origin feature/amazing-feature`)
5. Ouvrir une Pull Request

## ?? Licence

Ce projet est sous licence [MIT](LICENSE) (si applicable).

## ????? Auteur

- **JelooIs** - [GitHub](https://github.com/JelooIs)

---

**Besoin d'aide ?** Consultez les [issues](https://github.com/JelooIs/IMS/issues) ou créez une nouvelle question.
