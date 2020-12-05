# GhostLife : Mon premier Projet Sous UnityEngine  :earth_americas: :honeybee:

GhostLife est mon premier jeu, il s'agit d'un jeu solo en 2D avec des Tiles.

## 1. Unity ? 


### 1.1 C'est quoi.

Unity est un moteur de jeu multiplateforme développé par Unity Technologies. Il est l'un des plus répandus dans l'industrie du jeu vidéo, aussi bien pour les grands studios que pour les indépendants du fait de sa rapidité aux prototypages et qu'il permet de sortir les jeux sur tous les supports.


### 1.2 Accéder 

![unity-tab-square-black](https://user-images.githubusercontent.com/71081511/101229106-f3ec1480-369e-11eb-94aa-1013e457226f.png)

Il suffit de télchargez le UnityHub, à partir de la vous pourrez télécharger et stocker toutes les versions de unity et accéder à des projets communautaire en tout genre pour se familiariser avec les librairies.


## 2. Présentation Du Jeu : Les Elements :star:


### 2.1 Les Menus :
Pour utiliser la synthaxe BootStrap de manière simple, ajouter au source de 'index.php' : 
```html
<link rel="stylesheet" href="https://stackpath.bootstrapcdn.com/bootstrap/4.4.1/css/bootstrap.min.css" integrity="sha384-Vkoo8x4CGsO3+Hhxv8T/Q5PaXtkKtu6ug5TOeNV6gBiFeWPGFN9MuhOf23Q9Ifjh" crossorigin="anonymous">
```

![1](https://user-images.githubusercontent.com/71081511/100544281-deb55700-3254-11eb-8516-12cb3ba7e106.PNG)

>> On peut accéder aux items de la barre de navigation, accéder à des vues. 



### 2.2 Le TileUse : 

#### 2.2.1 Le Personnage Principal :

#### 2.2.2 La Scene :

#### 2.2.3 Props :


## 3. Inscription Et Connexion !

Lors de la Connexion : l'utilisateur obtient les différents droits de son status : élève, professeur, visiteur et administrateur
Chaque rôle est gérer par le bied des ($SESSION) du php. 

```php
if(isset($_POST['Envoyez'])){
      $connexion = ConnectSql('%%%','%%%','3308','%%%');
      if(!empty($_POST['Pseudo'])){
         $pseudo=$_POST['Pseudo'];
         if(!empty($_POST['Mdp'])){
            $mdp=$_POST['Mdp'];
            $requeteVerif = "select u.pseudo, u.motDePasse, u.TypeUtil from utilisateur u where u.pseudo ='".$pseudo."' and u.motDePasse='".$mdp."';";
            $resultat = $connexion->query($requeteVerif) or die ("execution de la requete impossible");
            $ligne = $resultat->fetch(PDO::FETCH_OBJ); 
            if(isset($ligne->pseudo)){
               $uti=$ligne->TypeUtil;
               $utili=$ligne->pseudo;
               $_SESSION['id']=$uti;
               $_SESSION['pseudo']=$utili;
               echo "<script type='text/javascript'>document.location.replace('index.php?page=accueil');</script>";
               Exit();
```

![5](https://user-images.githubusercontent.com/71081511/100544287-e248de00-3254-11eb-9f6b-ac257cf00f8b.PNG)

>> en Fonction de votre compte vous possédez certains Droits 

![3](https://user-images.githubusercontent.com/71081511/100544284-e117b100-3254-11eb-940c-47f16bd437c0.PNG) -> ![6](https://user-images.githubusercontent.com/71081511/100544288-e2e17480-3254-11eb-8574-6da2d3a584ed.PNG)

## 4. Gestion des Utilisateurs. 
### 4.1 Gestion des membres : Prof et Eleves.

### 4.2 Gestion des Options en première année. 

### 4.3 Passage et Diplôme.




* 0.4.0
* addition: A Database that manages each player’s scores.
with a filing system.
* 0.3.5
* Add: Add Collision on Snake Parts
* addition: Review Collisions on the Apple


## Meta

Bourdon Maxime – Mbourdon.pro@gmail.com

[https://github.com/Mbourdon95/github-link](https://github.com/Mbourdon95/)
