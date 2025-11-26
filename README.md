# Exercice : Gestion des Ressources Humaines (RH)

## Partie 1 : Les Entités de Base

### 1. Classe Adresse
#### Créer une classe Adresse qui devra implémenter :
Les propriétés publiques :
- Rue (string)
- Ville (string)
- CodePostal (string)

### 2. Classe EmployeSalarie
#### Créer une classe EmployeSalarie (salarié) qui devra implémenter :
Les propriétés publiques :
- Matricule (string)
- Nom (string) - Lecture seule
- Prenom (string) - Lecture seule
- SalaireMensuel (double)
- LieuDeTravail (Adresse)

Les méthodes publiques :
- `double CalculerPrime(double Pourcentage)` : Retourne un pourcentage du salaire.
- `void AugmenterSalaire(double Montant)`

### 3. Classe Manager
#### Créer une classe Manager qui devra implémenter :
Les propriétés publiques :
- Matricule (string)
- Nom (string) - Lecture seule
- Prenom (string) - Lecture seule
- SalaireMensuel (double)
- Departement (string)
- NbSubordonnes (int)

Les méthodes publiques :
- `double CalculerPrime(double BonusParSubordonne)` : Retourne une prime basée sur le nombre de subordonnés.
- `void AugmenterSalaire(double Montant)`

### 4. Classe Employe (Héritage et Encapsulation)
Définir la classe Employe qui représente les parties communes aux classes EmployeSalarie et Manager en utilisant les concepts d'héritage, de redéfinition de méthodes et d'encapsulation.  
**Attention :** Le niveau d'accessibilité du mutateur (set) de la propriété SalaireMensuel doit rester private.

---

## Partie 2 : Améliorations de Employe (Classes Abstraites et Exceptions)

### 1. Classe Employe comme abstraite
Définir la classe Employe comme étant abstraite (abstract).

### 2. Méthodes de calcul de rémunération
Ajouter une méthode abstraite et protégée (protected abstract) à la classe Employe appelée `CalculerImpot()` ayant pour prototype :  
`protected double CalculerImpot()`.

Règles :
- Pour un EmployeSalarie, l'impôt est de \(18\%\) du salaire.
- Pour un Manager, l'impôt est de \(20\%\) du salaire si le nombre de subordonnés est inférieur à 5, sinon il est de \(25\%\).

Ajouter une méthode publique à la classe Employe appelée `CalculerNetAPayer()` qui retournera le salaire mensuel après avoir soustrait le résultat de la méthode `CalculerImpot()`.

### 3. Gestion des Exceptions

#### Dans la classe Employe :
1. Au niveau de la méthode `AugmenterSalaire`, déclencher une exception de type `ArgumentOutOfRangeException` si le montant de l'augmentation n'est pas strictement positif.
2. Définir une nouvelle classe d'exception nommée `MatriculeDejaExistantException`.
3. Au niveau de la propriété Matricule (dans le constructeur ou le mutateur), déclencher l'exception `MatriculeDejaExistantException` si l'on tente de définir un matricule déjà existant (simulation acceptée).

#### Dans la classe Manager :
1. Au niveau de la propriété `NbSubordonnes`, déclencher une exception de type `InvalidOperationException` si la valeur n'est pas supérieure ou égale à 0.

### 4. Constructeurs

#### Dans la classe Employe :
1. Ajouter deux constructeurs :
   - Matricule, nom et prénom
   - Matricule, nom, prénom et salaire mensuel

2. Ajouter les constructeurs nécessaires aux classes EmployeSalarie et Manager en appelant le constructeur de la classe de base (`base(...)`).

3. Changer l'encapsulation des propriétés des classes Employe, EmployeSalarie et Manager afin de spécifier leur mutateur en private.

4. Confirmer que la classe d'exception `MatriculeDejaExistantException` est bien définie.

---

## Partie 3 : La Société et Opérateurs

### 1. Classe Societe
Créer une classe Societe qui gérera les employés de l'entreprise.

Propriétés :
- `Employes` (`Dictionary<string, Employe>`) — Clé : Matricule. Lecture seule
- `NomSociete` (string)

Un indexeur `this[...]` retournant un employé sur base de son matricule.

Méthodes :
- `void Embaucher(Employe e)`
- `void Licencier(string Matricule)`

### 2. Opérateur de surcharge
Surcharger l'opérateur `+` de la classe Employe afin qu'il retourne la somme (double) des salaires mensuels de deux employés.

### 3. Modification de Societe (Généricité)
Modifier la classe Societe afin qu'elle puisse gérer un tableau d'objets de n'importe quel type, à condition qu'ils héritent de la classe Employe (`where T : Employe`).

### 4. Méthode MasseSalariale
Ajouter une méthode `MasseSalariale` qui calcule la somme des salaires mensuels de tous les employés, en utilisant l'opérateur `+` sur des paires d'employés.

---

## Partie 4 : Interfaces et Rôles

### 1. Interface IRessourcesHumaines
Définir une interface permettant :
- la lecture de `SalaireMensuel`
- l'utilisation des méthodes `AugmenterSalaire` et `CalculerNetAPayer`

### 2. Interface IComptabilite
Fonctionnalités :
- inclut celles de IRessourcesHumaines
- ajoute l'accès à :
   - `CalculerImpot`
   - `Matricule`
   - `Departement` (uniquement pour Manager)

### 3. Implémentation
Ajouter ces deux interfaces à la classe Employe (et/ou classes dérivées).

### 4. Réflexion
Si l'on ajoute la propriété `DateEmbauche` à IRessourcesHumaines, définir :
- quelles classes doivent implémenter la propriété
- sous quelle forme (lecture seule, modifiable, etc.)

---

## Partie 5 : Délégués en Contexte RH

### Exercice 1 : Rapport Personnalisé (Délégué de Formatage)

#### 1. Définir le délégué
Créer un type de délégué :
- `FormatageRapport`
- Paramètre : `Employe`
- Retour : `string`

#### 2. Méthode de la Société
Ajouter `GenererRapport(FormatageRapport format)` :
- parcourt la liste des employés
- affiche le résultat du délégué

#### 3. Implémentation & Test
Créer :
- `string RapportIdentite(Employe e)` : Nom, Prénom, Matricule
- `string RapportPaie(Employe e)` : Nom + Net à payer

Utiliser `GenererRapport` avec ces deux méthodes.

---

### Exercice 2 : Audit des Salaires (Délégué Action Multicast)

#### 1. Définir le délégué
Créer :
- `AuditOperation` (void, paramètre Employe)  
  ou utiliser `Action<Employe>`.

#### 2. Fonctions d’audit
- `void LogAuditDebut(Employe e)`
- `void VerifierSeuilMinimal(Employe e)`
- `void CalculerEtAfficherImpot(Employe e)`

#### 3. Multicast
Créer :
- `AuditSalarialComplet`  
  et y chaîner les 3 méthodes.

Ajouter à Societe :
- `void ExecuterAudit(AuditOperation audit)`

Exécuter l’audit sur chaque employé.

---

## Partie 6 : Définition de l'Événement

### 1. Définir le délégué
Créer :
- `AlerteSalarialeDelegate(Employe e)`

### 2. Déclarer l'événement
Dans Employe :
- `event AlerteSalarialeDelegate DepassementSeuilSalarialEvent`

---

## Partie 7 : Déclenchement de l'Événement

Dans `AugmenterSalaire` ou le set de `SalaireMensuel` :
- Seuil : **5000 €**

Déclencher l’événement si :
1. ancien salaire ≤ seuil
2. nouveau salaire > seuil

Utiliser :
- `DepassementSeuilSalarialEvent?.Invoke(this)`

---

## Partie 8 : Traitement de l'Événement

### 1. Méthode du gestionnaire (Societe)
Créer :
- `void GererAlerteSalariale(Employe employe)`

Message affiché :
> `[ALERTE RH] L'employé () a dépassé le seuil de 5000 €. Une revue de la grille salariale est requise.`

### 2. Abonnement
Dans `Embaucher(Employe e)` :
- `e.DepassementSeuilSalarialEvent += GererAlerteSalariale`

---

## Partie 9 : Délégué générique

### 1. Supprimer le délégué personnalisé
Supprimer `AlerteSalarialeDelegate`.

### 2. Utiliser Action
Dans Employe :
- `event Action<Employe> DepassementSeuilSalarialEvent;`

---

## Partie 10 : Ajustements du Code Existant

### 1. Déclenchement de l'événement
La syntaxe reste la même.

### 2. Gestionnaire (Societe)
La méthode `GererAlerteSalariale(Employe employe)` reste identique.

### 3. Abonnement
L’abonnement dans `Embaucher` reste identique.
