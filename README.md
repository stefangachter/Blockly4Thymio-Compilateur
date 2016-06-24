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
Les fichiers présents ici, sont les sources du compilateur Blocly4Thymio.  
Ces sources sont distribuées sous licence libre CeCILL-C V2.


Suivi des versions
------------------

###Version 0.7
* Simplification du séquenceur
* Nouvelle instruction : SI ... FAIRE ... SINON ...
* Nouvelle boucle : TANTQUE ... FAIRE ...
* Ajout des variables et des calculs


###Version 0.6
* Nouvelles instructions : ARRETER LE PROGRAMME, SORT DE LA BOUCLE, VITESSE DES ROUES
* Nouvelle boucle : FAIRE ... TANTQUE ...
* Ajout d'une version hors ligne de l'interface de programmation
* Nouveaux opérateurs logiques : OU, ET et NON


###Version 0.51
* Correction la gestion du canal de la télécommande infra-rouge.


###Version 0.5
* Correction sur la compilation des blocs SI ... FAIRE ...
* Nouvelles instructions pour la télécommande infra-rouge : plus de boutons  et gestion d'un canal 'rc5.adress' pour utiliser différentes télécommandes et commander plusieurs Thymio.
* Gestion des capteurs de proximité avant et arrière, comme des événements.
* Gestion des boutons flèche, comme des événements.
* Nouvelles instructions de déplacement simplifiées 'Tourne à gauche' et 'Tourne à droite'.


###Version 0.4
* Ajout d'une variable de calibration pour la vitesse des moteurs.
* Création d'une documentation (disponible sur : https://github.com/Okimi-/Blockly4Thymio-Documents), sur la calibration de Thymio et la création de sons personnels.
* Ajout de la lecture de sons personnels.
* Enregistrement de son depuis le microphone.
* Réduction du code généré sur les instructions 'Allume les lumières'.


###Version 0.33
* Corrections sur les couacs des notes de musique.
* Amélioration du transfert pour les Thymio Wireless.


###Version 0.32
* Corrections de l'installeur (InnoSetup) pour que l'association des fichiers .b4t soit correcte sous Windows XP.


###Version 0.31
* Le fichier .aesl est crée dans le répertoire temporaire du système si le répertoire d'origine du fichier .b4t n'est pas accessible en écriture.


###Version 0.3
* Mise en place du versionning (GIT+BitBucket) sur les sources du compilateur,
* Préparation du code source pour migrer le compilateur sur Linux et Mac,
* Le compilateur utilise asebamassloader.exe (fourni avec AsebaStudio) pour transférer le fichier .aesl.
* Mise en place d'un installeur (Setup) pour simplifier l'installation.


###Version 0.21
* Correction sur l'instruction Blockly FAIRE n FOIS.


###Version 0.2
* Ajout d'icones dans les blocs			
* Nouvelles instructions pour jouer de la musique : plus de note (sur 2 gammes) et plus de durée (croche, noire et blanche) 	
* Mise en place du bloc de condition : Si			
* Récupération des informations des capteurs de proximité (avant et arrière)			
* Récupération des informations des capteurs de couleur du sol			
* Traitement de l'évenement provenant de la télécommande infra-rouge	


###Version 0.1b
* Mouvements
* Lumières
* Sons : Joue une gamme + sons sur la carte SD
* Boucle de répétition



Blockly4Thymio - © 2015-2016 Okimi (contact at okimi dot net)
