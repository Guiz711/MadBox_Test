# MadBox_Test

Temps de réalisation : 5h

## Difficultés rencontrées

### Rotation de la camera
Je n'ai pas réussi à obtenir dans les temps un rendu suffisamment satisfaisant pour "smooth" le changement d'angle de la caméra. Les tests en ajoutant du lerp à la rotation ou au changement d'offset de la camera n'étaient pas satisfaisants. Un petit travail de recherche m’aurait permis de trouver une solution efficace mais je n’ai pas pu l’effectuer dans les 5h imparties.

### Déplacements du joueur
Dès le début du test j’ai découpé la réalisation du jeu en problématiques. La plus complexe a été la gestion des déplacements du joueur. Pour répondre à cette problématique j’ai décidé de développer un système de classes avec héritage pour permettre différents types de déplacement, que j’ai appelé “Tracks”. Le personnage effectue une requête pour obtenir sa position et les calculs liés au type de circuit s’effectuent dans la classe Tracks. Cela permet de créer des circuits comportant des formes variées comme des lignes droites ou des courbes.

### Physique du joueur
J'ai rencontré un léger problème de détection de la collision avec un piège lorsque le joueur était immobile (Un rigidbody immobile ne détecte pas les collisions).

## Améliorations possibles

- J'ai décidé d'utiliser un système de "briques" (appelées Tracks) pour construire un niveau. Les checkpoints sont gérés par ces Tracks et j'aurais par la suite préféré les lier à une classe qui gèrerait le niveau entier pour éviter certains bugs.

- La logique d'un niveau est gérée dans la classe Game. J'aurais préféré comme dit dans le point précédent avoir une entité intermédiaire entre Game et les Tracks pour gérer un niveau.

- Les pièges ont tendance à se décaler lorsqu'ils entrent en collision avec le joueur. M’en étant rendu compte tardivement, je n'ai malheureusement pas eu le temps de régler ce problème. En plus de la détection des collisions ils sont utilisés pour obtenir un effet physique sur le joueur percuté, il n'est donc pas possible de les mettre en kinematic. Cependant on utilise les transform pour déplacer les entités et non les rigidbody eux même. Il aurait donc été possible de fixer les constraints pour régler le problème.

## Pour aller plus loin

- Ajouter des types de pièges

- Faire plus de niveaux

- Ajouter d’autres types de Tracks : Le joueur étant sur des rails, j’ai utilisé un système de classes avec héritage pour permettre différents types de parcours. Il serait intéressant d’ajouter des quarts de cercle (déplacer le joueur sur la circonférence du cercle) ou un système de courbes de Bezier par exemple. Pour le second j’ai fait des tests concluants en début de projet. Mais les assets du store n’étant pas autorisés je ne l’ai pas utilisé.

- Ajouter des joueurs IA : Je n’ai malheureusement pas eu le temps d’ajouter des adversaires. Il suffirait de brancher un AIController sur le Character et d’ajouter par exemple dans le niveau des points de pause pour le faire attendre devant les obstacles. Je n’ai cependant pas eu le temps de réfléchir à comment détecter le moment idéal pour traverser un piège.

- Ajouter un mesh et des animations pour le personnage

- Ajouter du metagame avec des skins déblocables

## Conclusion

Cet exercice était très intéressant pour essayer d’obtenir un résultat convenable en peu de temps. Je me suis concentré sur la mise en place d’une architecture modulaire et flexible dans l’optique de pouvoir par la suite ajouter rapidement du contenu au jeu.
