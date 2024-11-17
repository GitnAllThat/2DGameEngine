# 2D Game Engine

This is a 2D game engine created with C# and MonoGame, and integrated with WinForms. The engine is still in development and not yet finished but has several key features to aid in the creation of 2D games.

The goal of this project is to build an engine capable of supporting basic game development with various tools for game world editing and testing.

---
## Features
1. 2D Collision Detection and Solver  
Provides collision detection between 2D objects, with an integrated solver to handle object interactions based on their properties.

2. Texture Editor  
Allows users to edit and manage textures for use within the engine, providing flexibility in asset management.

3. Rigidbody Editor  
Users can assign different collision bodies to objects (e.g., Circle, Oriented Bounding Box, or Convex Polygon) to define how objects interact with one another.

4. Multiple Object Planar Mapping  
Enables the projection of textures onto multiple objects, such as stacking a series of boxes. The engine ensures textures align properly to create the appearance of a solid, seamless object.

5. Built-in Game for Testing Worlds  
Includes a simple game framework that allows users to test the worlds they create, providing immediate feedback on how objects behave within the game world.

6. Level Loading and Saving  
Supports loading and saving of levels, making it easier to design and test different game environments over time.

7. Manipulation Tools  
Provides tools to move, scale, and rotate objects within the editor, enabling intuitive world-building.

8. Variable Inspector  
Displays the variables of selected objects in a side panel, allowing for easier debugging and manipulation of game objects.

---
## How to Run  
Open the 2D Engine Solution in Visual Studio or your preferred C# IDE.
Build the solution to ensure all dependencies are correctly set up.

---
## Future Work

---
## Acknowledgements

This project incorporates code from [BlizzCrafter](https://github.com/BlizzCrafter), which provides functionality for using MonoGame as a WinForms control. This code has been instrumental in enabling seamless integration between MonoGame and the editor interface.

The original repository can be found [here](https://github.com/BlizzCrafter/MonoGame.Forms). 
