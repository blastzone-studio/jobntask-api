
# **Job and Task Management API**

## **Description**

Ce projet propose une API modulaire et flexible pour gérer des jobs, des tâches, des entreprises, et des workers. L'API est conçue pour être utilisée dans divers contextes tels que des jeux vidéo ou des applications web. Le projet respecte les principes SOLID pour garantir la maintenabilité, l'extensibilité et la robustesse du code.

## **Fonctionnalités Principales**

- **Gestion des Entreprises :** Création, gestion et assignation des jobs aux entreprises.
- **Gestion des Workers :** Ajout de workers aux entreprises et assignation des tâches aux workers.
- **Gestion des Jobs :** Création et assignation des jobs aux entreprises et aux workers.
- **Gestion des Tâches :** Création des tâches, assignation aux jobs et aux workers.
- **Relations :** Gestion des relations entre les entreprises, jobs, tasks et workers à travers des repositories dédiés.

## **Architecture**

### **Entities :**
- **`IEnterprise` :** Représente une entreprise qui peut créer des jobs.
- **`IWorkerEntity` :** Représente un worker qui peut être assigné à un job ou à une tâche.
- **`IJob` :** Représente un job au sein d'une entreprise.
- **`ITask` :** Représente une tâche qui peut être assignée à un job et à un worker.

### **Repositories :**
- **`IEnterpriseRepository` :** Gère les opérations CRUD pour les entreprises.
- **`IWorkerRepository<T>` :** Gère les opérations CRUD pour les workers.
- **`IJobRepository` :** Gère les opérations CRUD pour les jobs.
- **`ITaskRepository` :** Gère les opérations CRUD pour les tâches.
- **`IEnterpriseWorkerRelationRepository` :** Gère les relations entre les entreprises et les workers.
- **`IEnterpriseJobRelationRepository` :** Gère les relations entre les entreprises et les jobs.
- **`IJobTaskRelationRepository` :** Gère les relations entre les jobs et les tâches.
- **`ITaskWorkerRelationRepository` :** Gère les relations entre les tâches et les workers.

### **Services :**
- **`EnterpriseService` :** Gère l'ajout et la suppression de workers aux entreprises, ainsi que la création de jobs pour les entreprises.
- **`JobAssignmentService` :** Gère l'assignation des jobs aux entreprises et aux workers.
- **`JobTaskAssignmentService` :** Gère l'assignation des tâches aux jobs.
- **`WorkerTaskAssignmentService` :** Gère l'assignation des tâches aux workers.

### **Règles de Gestion :**
- Une tâche ne peut être assignée qu'à un seul job à la fois.
- Une tâche ne peut être assignée qu'à un seul worker à la fois.

## **Prérequis**

- .NET SDK (version 6 ou supérieure)
- Visual Studio ou tout autre IDE compatible avec .NET
- Outil de gestion des dépendances NuGet (inclus dans .NET SDK)

## **Installation et Configuration**

1. **Cloner le projet :**
   ```bash
   git clone https://github.com/votre-repo/job-task-management-api.git
   cd job-task-management-api
   ```

2. **Restaurer les dépendances :**
   ```bash
   dotnet restore
   ```

3. **Construire le projet :**
   ```bash
   dotnet build
   ```

4. **Exécuter les tests :**
   ```bash
   dotnet test
   ```

## **Structure du Projet**

- **`JobNTask.Lib`** : Contient les modèles, les interfaces et les classes de base du projet.
- **`JobNTask.Lib/Repositories`** : Contient les interfaces et implémentations des repositories.
- **`JobNTask.Lib/Services`** : Contient les services qui orchestrent les opérations sur les entités.
- **`JobNTask.Tests`** : Contient les tests unitaires pour vérifier les règles de gestion et les services.

## **Utilisation**

### **1. Gestion des Entreprises**

- **Créer une entreprise :**
  ```csharp
  var enterprise = new Enterprise("1", "Tech Corp");
  enterpriseRepository.AddEnterprise(enterprise);
  ```

- **Ajouter un worker à une entreprise :**
  ```csharp
  enterpriseService.AddWorkerToEnterprise("1", worker);
  ```

### **2. Gestion des Jobs**

- **Créer un job pour une entreprise :**
  ```csharp
  enterpriseService.CreateJobForEnterprise("1", "101", "Developer");
  ```

- **Assigner un job à un worker :**
  ```csharp
  jobAssignmentService.AssignWorkerToJob("101", "201");
  ```

### **3. Gestion des Tâches**

- **Créer une tâche :**
  ```csharp
  taskService.CreateTask("1001", "Fix Bugs");
  ```

- **Assigner une tâche à un job :**
  ```csharp
  jobTaskAssignmentService.AssignTaskToJob("101", "1001");
  ```

- **Assigner une tâche à un worker :**
  ```csharp
  workerTaskAssignmentService.AssignTaskToWorker("1001", "201");
  ```

## **Contribution**

Les contributions sont les bienvenues ! Pour contribuer :

1. Fork le repository
2. Créez une branche pour votre fonctionnalité (`git checkout -b feature/AmazingFeature`)
3. Commitez vos modifications (`git commit -m 'Add some AmazingFeature'`)
4. Poussez votre branche (`git push origin feature/AmazingFeature`)
5. Ouvrez une Pull Request

## **Licence**

Ce projet est sous licence MIT. Consultez le fichier [LICENSE](LICENSE) pour plus de détails.
