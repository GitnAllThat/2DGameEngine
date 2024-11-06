using Microsoft.Xna.Framework;
using Microsoft.Xna.Framework.Graphics;
using System.Collections.Generic;
using System;
using Things;
using _2d_Objects;
using Shapes;
using _2DLevelCreator;

namespace Global_Data
{


    public static class Globals
    {
        public static bool DRAWBACKFACES = false;
        public static bool DRAWWIREFRAME = false;
        public static bool DRAWAXIS = false;
        public static bool DRAWAABB = false;
        public static bool DRAWSTATICAABB = false;
        public static bool DRAWMOTIONPATHAABB = false;
        public static bool DRAWSTATICMOTIONPATHAABB = false;
        public static bool DRAWRIGIDBODY = false;
        public static bool FILLRIGIDBODY = true;
        public static bool DRAWTHINGS = true;
        public static bool DRAWSEGMENTS = true;
        public static int SOLVERITERATIONS = 4;
        public static bool MOVE = true;


        public static string Path = "Asset Data//Levels//E1M1//";







        public static float timeDifference = 0;

        public static float gravity = -9.81f;                   //9.81 ms. 981cm
        public static Vector3 gravityThisFrame = Vector3.Zero;
        public static void UpdateGravityPerFrame() { gravityThisFrame = new Vector3(0, gravity * timeDifference, 0); }

        public static Random randNum = new Random();

        
        public static List<Thing2D_Rb<RigidBody>> list_AllObjects = new List<Thing2D_Rb<RigidBody>>();
        public static List<Thing2D_Rb<RigidBody>> list_Blueprints = new List<Thing2D_Rb<RigidBody>>();
        public static List<Thing2D_Rb<RigidBody>> list_BuildingBlocks = new List<Thing2D_Rb<RigidBody>>();
        public static List<Thing2D_Rb<RigidBody>> list_GameObjects = new List<Thing2D_Rb<RigidBody>>();
        public static List<Thing2D_NonRb> list_Doodads = new List<Thing2D_NonRb>();
        public static List<Segment> list_Segments = new List<Segment>();


        public static Background background;

        public static Grid grid = new Grid(1, 100, 0, new Microsoft.Xna.Framework.Color(255, 255, 255, 100));
    }









}
