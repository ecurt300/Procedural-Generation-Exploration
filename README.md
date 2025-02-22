# Procedural-Generation-Exploration
A learning project for eventually procedurally generating a galaxy using the Unity Engine
> ## Procedural Generation Exploration
> ### This is going to be a learning project using the Unity Game Engine. I will be learning about Proc Gen which the end result would be a procedural galaxy that can be explored.
>## The Projects That Will Be Made
>### The following will be made:
> * Terrain Sample
> * Terrain Chunk
> * Chunked Terrain
> * Planet
> * Solar System
> * Procedural Generated Galaxy

> ## Learning Requirements:

> * Meshing
> * Compute Shaders
> * Shaders
> * Post Processing
> * Getting used to meshes and level generation
> * Burst Compiler
> * DOTS (Needed for the Galaxy)



# Project 0 Terrain Sample

> This is a very simple project that will be the culmination of creating quads and planes. It has the following features:

> * Heightmaps
> * Trees
> * Textures
> * Normal Maps
> * Shaders


> Terrain is generated from a height mapped mesh that also effects the where the tree objects are placed.  Shaders just give it some flare.


 # Project 1 Terrain Chunk

> After creating the terrain sample I will be utilizing the ECS in DOTS.
> The  Chunk is an entity that can be turned off and on. It is a rebuilt Terrain Sample but only it is an actual Entity. The following Features:

>* Terrain Collision Detection
>* Rebuilt for ECS and DOTS

# Project 2 Chunked Procedural Terrain

>This a terrain chunk but it is an Infinite Height Mapped Terrain that spawns new chunks as well as saves old chunks. The player moves around the map.

>Features:
>* Infinite Terrain
>* Generated on the fly
>* Ocean shaders
>* Compute Shader for terrain physics such as erosion and ocean


 # Project 3 Planetary Terrain
> Unlike the Infinite Terrain this will be a smaller spherical world complete with atmosphere, oceans, or completely barren. This will be the building blocks for the next Project The Procedural Galaxy.

>Features:
>* Spherical Height Mapped Terrain
>* Atmosphere such as clouds and Rayleigh Scattering
>* Oceanic Shaders-> Maybe even fluid dynamics?
> * Planetary Collision with the Physics Engine

# Project 4 Solar System

>This will incorporate the Procedural Planet with a generated Solar System. The Solar System will have Suns, Moons, Planets, and Asteroids.
You will be able to land on it and navigate via gravity.

>Features:
>* Planetary Gravity 
>* Newtonian physics with Keplerian Orbital layouts
> * Random Seeded Generated Solar System
> * Spaceship to move around the Solar System
> * Astronaut as the player


# Project 5 The Galaxy

>This will be the end stage of this learning journey an entire 3D procedural generated Galaxy for the player to explore. It is not to scale I have no idea how many systems will be included. But this will include many celestial phenomena such as nebula , solar systems ,black holes, stars etc. All explored with a spaceship. It will be pretty empty but hopefully some planets will be inhabited by flora and fauna.


>Features:
>* More Sophisticated Gravity System
>* Many different types of stars
>* Black Holes
>* Wormholes 
>* Warp Driven Spaceship
>* Astronaut player  



# This is a living document

