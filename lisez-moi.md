Blockly4Thymio
==============
www.blockly4thymio.net

Blockly4Thymio (prononcez blockly for Thymio, soit blockly pour Thymio en anglais), est un environnement de programmation pour le robot éducatif Thymio II.

L’environnement Blockly4Thymio est basé sur blockly. Il est visuel, simple et ludique et est destiné à un jeune publique pour l’apprentissage de la programmation.
Cet apprentissage se fait à l’aide de blocs colorés qui s’assemblent comme les pièces d’un puzzle.

Malgré cette étonnante simplicité, les enfants découvrent et apprennent les bases de la programmation : les actions, les conditions, les boucles, les variables, les événements, etc…

Blockly4thymio est composé de trois éléments :
- un environnement de programmation visuel basé sur blockly
- un compilateur qui adapte le code blockly en code Aseba
- un mini Framework sous Aseba


Les fichers de ce repository
----------------------------
Les fichiers présents ici, sont les sources du compilateur Blocly4Thymio. Ces sources ne sont pas distribués sous licence libre. Il est donc interdit de les copier ou de les distibuer sans l'accord de l'auteur.


Note sur le suivi des téléchargements sous Google Analytics
-----------------------------------------------------------

A paramétrer comme ceci :  
Toutes les données du site Web -> Objectifs + Nouvel objectif  
Configuration de l'objectif

* Personnalisée

Description de l'objectif  

* Nom : Téléchargement de la version **VERSION**  
* Type : Evénement  

Détails de l'objectif

* Catégorie : Compilateur  
* Action : Téléchargement  
* Libellé : Version **VERSION**  
* Valeur : **NOMBRE D'EVENEMENTS** + 1  


Suivi des versions
------------------

###Version 0.1b
* Mouvements
* Lumières
* Sons : Joue une gamme + sons sur la carte SD
* Boucle de répétition


###Version 0.2
* Ajout d'icones dans les blocs			
* Nouvellles instructions pour jouer de la musique : plus de note (sur 2 gammes) et plus de durée (croche, noire et blanche)			
* Mise en place du bloc de condition : Si			
* Récupération des informations des capteurs de proximité (avant et arrière)			
* Récupération des informations des capteurs de couleur du sol			
* Traitement de l'évenement provenant de la télécommande infra-rouge			


###Version 0.21
* Correction sur l'instruction Blockly FAIRE n FOIS.


###Version 0.3
* Mise en place du versionning (GIT+BitBucket) sur les sources du compilateur,
* Préparation du code source pour migrer le compilateur sur Linux et Mac,
* Le compilateur utilise asebamassloader.exe (fourni avec AsebaStudio) pour transférer le fichier .aesl.
* Mise en place d'un installeur (Setup) pour simplifier l'installation.


###Version 0.31
* Le fichier .aesl est crée dans le répertoire temporaire du système si le répertoire d'origine du fichier .b4t n'est pas accessible en écriture.


###Version 0.32
* Corrections de l'installeur (InnoSetup) pour que l'association des fichiers .b4t soit correcte sous Windows XP.


###Version 0.33
* Corrections sur les couacs des notes de musique.


Blockly4Thymio - © 2016/2017 Okimi (contact@okimi.net)