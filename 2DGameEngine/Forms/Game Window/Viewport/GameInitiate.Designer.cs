using System;
using System.Collections.Generic;
using System.Linq;
using Microsoft.Xna.Framework;
using Microsoft.Xna.Framework.Audio;
using Microsoft.Xna.Framework.Content;
using Microsoft.Xna.Framework.Graphics;
using Microsoft.Xna.Framework.Input;
using Microsoft.Xna.Framework.Media;
using System.Diagnostics;
using Things;
using Global_Data;
using _2d_Objects;
using _2DLevelCreator;
using Game.UserInterface;

namespace CustomControls
{
    //Monogame Reimplement: Change XnaWindow back to MonoGameMainWindow
    public partial class GameWindow : XnaWindow
    {

        public List<Thing2D_Rb<RigidBody>> list_AllObjects = new List<Thing2D_Rb<RigidBody>>();
        public Eli eli;
        List<CollisionData> list_CD_Eli = new List<CollisionData>();
        UserInterface userInterface;

        public void GameInitiate()
        {
            //Editor.RemoveDefaultComponents();   //Gets rid of the default FpsCounter and the default camera

            DrawFont = Editor.Content.Load<SpriteFont>("ArialFont");
            effect = Editor.Content.Load<Effect>("MyHLSL_Old");

            camera = new Camera(1.777f);
            camera.CameraPosition = new Vector3(0, 0, 120);

            gameInput = new GameInput(this);


            eli = null;

            list_AllObjects.Clear();

            eli = new Eli(new UniqueIdentifier_Reference(Thing2D.Thing2D_List[16].ID), new BoundingCircle(new Transform(),new Motion(),Vector3.Zero, 0.67f, 1, false), "Eli", list_AllObjects);
            eli.Position = eli.Position + new Vector3(0, 5, 0);
            //All Actors need to be placed at the beginning of the list so they can have their touching contacts removed when generated. Warmstarting the engine on solve fucks up character movement
            eli.rigidBody.invMass *= 0.3f;

            Globals.list_AllObjects.ForEach((item) =>
            {
                new Thing2D_Rb<RigidBody>(item, list_AllObjects);
            });
            this.userInterface = new UserInterface(this);
        }
    }
}
