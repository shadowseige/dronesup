# Drones Up
Multiplatform Game Development Project By Raja Chellappan, Nicola Serban Smedoiu, Pranaya Radha Krishna Koppisetti

YouTube: https://youtu.be/dzj-4EaCKME
GitHub URL: https://github.com/qmulsept20mgdgroupc/dronesup

Concept

Working Title: Drones Up

Concept Statement:

The game revolves around the use of a drone to move through the city with the intention to collect packages as fast as possible and deliver them to the delivery location. A timer is present in the game which will make it fast paced, with obstacles that the player must avoid in order to get to his objectives. The game also has battery cells as collectables in order to boost the speed.
Also, because of the highest score system it will be a competitive game to play between friends, colleagues and family.

Genre:

The game will combine the racing and the simulator genres, as the objective of the game is to collect packages and deliver them while controlling a drone through the streets of a city. 

Target audience:

This game is targeted for all age groups who are looking to get the highest score possible, and also compete with their friends. Since the game will be of short duration, players will be more attentive and will not get bored of it. The game will also interest people who are into flight simulation genre games.

Design Overview

Player’s experience & POV:

Player’s experience is piloting the life-like Drone.
The player point-of-view by default is third person perspective (TPP), which will allow the player to not only see the drone, but will make exploring the city map more enjoyable, with building, traffic lights, birds, and other obstacles being available to observe. Also, the player has the option to switch to First Person Perspective (FPP) to navigate through the narrow passages.

Visual and audio style:

Visual Style - Temple Run (POV), Flight Simulator (Concept)
Audio Style – City life (Car Horns, birds chirping, Drone sound) and Dramatic racing music.

Game world fiction:

The player is a drone pilot, and he is instructed to collect the packages from a supplier’s pickup point and then deliver them to another location through the urban setting. Also, the player is instructed to deliver the package in the shortest time possible to score the maximum amount of points.
From the beginning of the journey, the player encounters obstacles in the city such as trees, cars, traffic lights, buildings and also should abide by the Drone laws & flying regulations.

Core gameplay:

The drone is the only game object that the player controls. The player will be controlling the Drone movements - Levitation (Up and Down), swerving (Left and Right) and movement (Forward and Backward) and rotation (Left and Right).
The drone will interact with the package object, being able to pick up the package and then drop it at the delivery location. The obstacles listed above will also be the game objects which will try to slow down the player if the drone hits them on the way. The player can collect the battery cells to increase the speed boosting capacity of the Drone.
In this way, the player will have to focus on all the elements at the same time which will make the player be engaged with the gameplay.

Objectives & progression:
 
The player’s score depends upon the time of delivery. The faster the delivery the higher the player’s score.
As short-term goals, the player will need to be careful and manage his movement to make sure he interacts with as less obstacles as possible. Also, the player will be required to check his altitude regulated by the Drone laws along with the assistance of the mini map, which will allow the player for easier navigation to the delivery location.
In long-term goals of the player, the player needs to collect the package and deliver it to the delivery location necessary for complete the game.
Also, an implicit long-term goal is accumulating as many points as possible through completion of the task above(delivery).

Game systems:

Methods used – DroneController(), ScoreCalculator(), AltitudeCheck(), PickUp(), Collectables(), MiniMap().
Player’s interaction methods – DroneController(), PickUp(), Collectables().
Internals methods – ScoreCalculator(), AltitudeCheck(), MiniMap(). 

Interaction:

Player Controls:
W/Up arrow – Forward Movement
S/Down arrow – Backward Movement
A/Left arrow – Left Swerve
D/Right arrow – Right Swerve
I – Increasing the Drone’s altitude
K – Decreasing the Drone’s altitude 
J – Rotate left
L – Rotate right
Right mouse click – Pick up/drop the package
C – Camera view (TPP/FPP)
Space bar – Speed booster

User Interface: 
The camera view is the Third Person Perspective of the Drone by default and the player can also toggle between FPP and TPP.
The score and the timer of the player will be visible in the top center, with a mini map that the player can navigate to the pick-up/delivery locations which can be found in the bottom right corner of the screen. And at bottom left will be the Speed booster capacity along with Drone’s information on the top right corner of the screen.

