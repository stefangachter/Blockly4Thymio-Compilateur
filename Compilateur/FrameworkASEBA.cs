
using System;



public class FrameworkASEBA {
	
	public static String	version_0_1b() {
		return @"<!DOCTYPE aesl-source>
<network>


<!--list of global events--> 


<!--list of constants-->
<constant value=""0"" name=""ETAT_ARRET""/>
<constant value=""1"" name=""ETAT_EN_MARCHE""/>
<constant value=""170"" name=""COEFFICIENT_D_ODOMETRIE""/>


<!--show keywords state-->
<keywords flag=""false""/>


<!--node thymio-II-->
<node nodeId=""1"" name=""thymio-II"">
# ----------------------------------
# DECLARATION DES VARIABLES GLOBALES
# ----------------------------------

var __etat
var __coeurQuiBat
var __sensDuCoeurQuiBat
var	__temp[9]
var __lectureDUnSon = 0
# Variables pour l'odométrie
var __odo.delta
var __odo.theta = 0
var __odo.x = 0			# 500 for 100mm
var __odo.degre
### VARIABLES ###


# -----------
# APPLICATION
# -----------
### ETAT AU LANCEMENT ###
# Initialise le Timer sur 10ms (100Hz)
timer.period[0] = 10



# ---------------------------
# DECLARATIONS DES PROCEDURES
# ---------------------------

# Arrête les moteurs
sub	__ArreteLesMoteurs
  motor.left.target = 0
  motor.right.target = 0
  __odo.x = 0
  __odo.degre = 0
  __odo.theta = 0


sub __ExecuteLeProgramme
  __coeurQuiBat = 0
  __sensDuCoeurQuiBat = 1
  ### EVENEMENT AU LANCEMENT ###
  __etat = ETAT_EN_MARCHE


sub __ArreteLeProgramme
  __etat = ETAT_ARRET
  # Arrête les moteurs
  callsub __ArreteLesMoteurs
  # Eteins toutes les LEDs
  call leds.bottom.left( 0, 0, 0 )
  call leds.bottom.right( 0, 0, 0 )
  call leds.buttons(0,0,0,0)
  call leds.circle( 0, 0, 0, 0, 0, 0, 0, 0 ) 
  call leds.top(0,0,0)
  call leds.sound(0)
  call leds.temperature(0,0)


# ----------
# SEQUENCEUR
# ----------

sub __Sequenceur
  ### SEQUENCEUR ###



# ---------------------------
# DECLARATIONS DES EVENEMENTS
# ---------------------------

# BOUTTONS
# --------

# Avec le bouton central, l'utilisateur lance ou arrête le programme
onevent button.center
  if button.center == 1 then
    if __etat == ETAT_ARRET then
	  callsub __ExecuteLeProgramme
	else
	  __etat = ETAT_ARRET
	end
  end


# Evénement déclenché toutes les 10ms (100Hz)
onevent timer0
  if __etat == ETAT_EN_MARCHE then
    __coeurQuiBat += __sensDuCoeurQuiBat
    if __coeurQuiBat == 64 or __coeurQuiBat == 0 then
      __sensDuCoeurQuiBat = -__sensDuCoeurQuiBat
    end
	call leds.buttons( __coeurQuiBat>>3, 0,0,0 )
    callsub __Sequenceur
  else
	callsub __ArreteLeProgramme
  end


# Evénement déclenché à la fin de la lecture d'un fichier son
onevent	sound.finished
  __lectureDUnSon=0


# Evénement moteur, appelé toutes les 10ms (100Hz)
onevent	motor
  # Calcul du déplacementet de la rotation par odométrie.
  # Code basé sur le fichier thymio_motion.aels de David Sherman
  if motor.right.target == 0 and motor.left.target == 0 then
	__odo.x = 0
	__odo.degre = 0
	__odo.theta = 0
  else
    __odo.delta = (motor.right.target + motor.left.target) / 2
    call math.muldiv(__temp[0], (motor.right.target - motor.left.target), 3406, 10000)
    __odo.theta += __temp[0]
    call math.cos(__temp[0:1],[__odo.theta,16384-__odo.theta])
    call math.muldiv(__temp[0:1], [__odo.delta,__odo.delta],__temp[0:1], [32767,32767])
    __odo.x += __temp[0]/45   #45 pour le Thymio maison, 51 pour le Thymio de ZBis
    __odo.degre = __odo.theta / COEFFICIENT_D_ODOMETRIE
  end

</node>


</network>";

	}

	public static String	version_0_2() {
		return @"<!DOCTYPE aesl-source>
<network>


<!--list of global events--> 


<!--list of constants-->
<constant value=""0"" name=""ETAT_ARRET""/>
<constant value=""1"" name=""ETAT_EN_MARCHE""/>
<constant value=""170"" name=""COEFFICIENT_D_ODOMETRIE""/>
<constant value=""2500"" name=""COEUR_QUI_BAT""/>
<constant value=""10"" name=""FREQUENCE_TIMER""/>


<!--show keywords state-->
<keywords flag=""false""/>


<!--node thymio-II-->
<node nodeId=""1"" name=""thymio-II"">


#    ___  __         __    __     ____________              _
#   / _ )/ /__  ____/ /__ / /_ __/ / /_  __/ /  __ ____ _  (_)__
#  / _  / / _ \/ __/  '_// / // /_  _// / / _ \/ // /  ' \/ / _ \
# /____/_/\___/\__/_/\_\/_/\_, / /_/ /_/ /_//_/\_, /_/_/_/_/\___/
#                         /___/               /___/ 
#        Programme AESL pour Thymio II - Version ### VERSION ###
# généré automatiquement par Blockly4THymio www.blockly4thymio.net
#     Blockly4Thymio - © 2015/2016 Okimi (contact@okimi.net)

# ----------------------------------
# DECLARATION DES VARIABLES GLOBALES
# ----------------------------------

var __etat
var __coeurQuiBat = 0
var __temp[9]
var __lectureDUnSon = 0

# Variables pour l'odométrie
var __odo.delta
var __odo.theta = 0
var __odo.x = 0			# 500 for 100mm
var __odo.degre

### VARIABLES ###


# -----------
# APPLICATION
# -----------
# Efface la précédente commande (éventuellement en mémoire)
rc5.address = 0
rc5.command = 0
# Initialise le(s) séquenceur(s)
### ETAT AU LANCEMENT ###
# Initialise le Timer sur 10ms (100Hz)
timer.period[0] = FREQUENCE_TIMER



# ---------------------------
# DECLARATIONS DES PROCEDURES
# ---------------------------

# Arrête les moteurs
sub	__ArreteLesMoteurs
  motor.left.target = 0
  motor.right.target = 0
  __odo.x = 0
  __odo.degre = 0
  __odo.theta = 0


sub __ExecuteLeProgramme
  ### EVENEMENT AU LANCEMENT ###


sub __ArreteLeProgramme
  
  # Arrête les moteurs
  callsub __ArreteLesMoteurs
  
  # Eteins toutes les LEDs
  call leds.bottom.left( 0, 0, 0 )
  call leds.bottom.right( 0, 0, 0 )
  call leds.buttons(0,0,0,0)
  call leds.circle( 0, 0, 0, 0, 0, 0, 0, 0 ) 
  call leds.top(0,0,0)
  call leds.sound(0)
  call leds.temperature(0,0)


# ----------
# SEQUENCEUR
# ----------

sub __Sequenceur
  ### SEQUENCEUR ###



# ---------------------------
# DECLARATIONS DES EVENEMENTS
# ---------------------------
onevent buttons
### EVENEMENT BOUTON FLECHE ###


# Avec le bouton central, l'utilisateur lance ou arrête le programme
# ------------------------------------------------------------------
onevent button.center
  if button.center == 1 then
    # Si le bouton central est appuyé
    if __etat == ETAT_ARRET then
      __etat = ETAT_EN_MARCHE
      # Relance le programme
      callsub __ExecuteLeProgramme
    else
	  __etat = ETAT_ARRET
    end
  end


# Evénement déclenché par le timer pour le séquenceur
# ---------------------------------------------------
onevent timer0
  if __etat == ETAT_EN_MARCHE then
    
    # La LED de la flèche avant clignote, le programme s'execute
    __coeurQuiBat+=(COEUR_QUI_BAT/FREQUENCE_TIMER)
    call math.sin(__temp[0],__coeurQuiBat)
    call leds.buttons( abs(__temp[0])>>12, 0, 0, 0 )
    
    # Appel le séquenceur
    callsub __Sequenceur
    
  else
    
    # le programme va s'arrêter, la LED de la flèche avant s'éteint
    __coeurQuiBat=0
    
    # Arrête tous les accurateurs
    callsub __ArreteLeProgramme
    
  end
  
  
# Evénement déclenché lors de la réception d'une commande
# rc5 de la télécommande infrarouge
# -------------------------------------------------------

onevent rc5
### EVENEMENT COMMANDE INFRAROUGE ###
  
  
# Evénement déclenché à la fin de la lecture d'un fichier son
# -----------------------------------------------------------
onevent	sound.finished
  __lectureDUnSon=0



# Evénement moteur, appelé toutes les 10ms (100Hz)
# ------------------------------------------------
onevent	motor
  # Calcul du déplacementet de la rotation par odométrie.
  # Code basé sur le fichier thymio_motion.aels de David Sherman
  if motor.right.target == 0 and motor.left.target == 0 then
	__odo.x = 0
	__odo.degre = 0
	__odo.theta = 0
  else
    __odo.delta = (motor.right.target + motor.left.target) / 2
    call math.muldiv(__temp[0], (motor.right.target - motor.left.target), 3406, 10000)
    __odo.theta += __temp[0]
    call math.cos(__temp[0:1],[__odo.theta,16384-__odo.theta])
    call math.muldiv(__temp[0:1], [__odo.delta,__odo.delta],__temp[0:1], [32767,32767])
    __odo.x += __temp[0]/45   #45 pour le Thymio maison, 51 pour le Thymio de ZBis
    __odo.degre = __odo.theta / COEFFICIENT_D_ODOMETRIE
  end

</node>


</network>";

	}


}

