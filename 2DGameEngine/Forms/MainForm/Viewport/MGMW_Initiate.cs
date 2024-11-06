using Microsoft.Xna.Framework;
using Microsoft.Xna.Framework.Graphics;
using _2DLevelCreator;
using _2d_Objects;
using Global_Data;
using SaveSpace;


namespace CustomControls
{
    //Monogame Reimplement: Change XnaWindow back to MonoGameMainWindow
    public partial class MonoGameMainWindow : XnaWindow
    {
        public void GameInitiate()
        {
            

            DrawFont = Editor.Content.Load<SpriteFont>("ArialFont");
            effect = Editor.Content.Load<Effect>("MyHLSL_Old");

            camera = new Camera(1.777f);
            camera.CameraPosition = new Vector3(0, 0, 120);

            gameInput = new GameInput(this);


            
            //Editor.RemoveDefaultComponents();   //Gets rid of the default FpsCounter and the default camera
            
            


            Physical_Property.CalculateFrictionCoefficients();

            Globals.background = new Background(8, new Transform(new Vector3(0, 0, -2850), 0, new Vector3(1024, 1024, 1)), true, true, true, this.Editor.Content);

            PropertyUpdater.InitiateVariableStringLists();  //MonoGame Reimplement



            LoadSpace.Load.Load_Game_Materials(this.Editor.Content);
            LoadSpace.Load.Load_Thing2Ds();
            LoadSpace.Load.Load_Blueprints();

            LoadSpace.Load.Load_Level(Globals.Path);
            LoadSpace.Load.Load_Segments();

            Save.Save_Level(Globals.Path);

            Save.Save_Game_Materials();
            Save.Save_Objects("Asset Data//", "03 Blueprints.txt", Globals.list_Blueprints, 1);
            Save.Save_Thing2Ds();




            this.form.FillList_Constructs(Globals.list_Blueprints);
            this.form.FillList_GameObjects(Globals.list_AllObjects);


            //Program.thingEditorForm.FillList_Things();      //MonoGame Reimplement




            this.form.selectionTool.UpdateSelectionFunctions();



            form.RecalcAspectRatio();   //Aspect ratio is messed up on loading form. this resets it
        }
    }

}