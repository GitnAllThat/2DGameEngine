using Microsoft.Xna.Framework;
using Microsoft.Xna.Framework.Graphics;
using _2DLevelCreator;
using _2d_Objects;
using Global_Data;
using SaveSpace;
using Tools;
using System.Collections.Generic;
using System.Diagnostics;
using System;
using Microsoft.Xna.Framework.Input;

namespace CustomControls
{
    //Monogame Reimplement: Change XnaWindow back to MonoGameMainWindow
    public partial class RigidThingEditorWindow : XnaWindow
    {
        public override void GameUpdate()
        {

            this.gameInput.Update();

            if (this.Focused) this.camera.CameraMovement(this.gameInput, this);
            if (this.Focused) this.form.selectionTool.UseSelectionTool(this.gameInput, this.form.manipulationTool);
            if (this.Focused) if (this.gameInput.keyboardStateCurrent.IsKeyDown(Keys.F)) { this.form.selectionTool.FocusSelection(this); }




            //These have to be in this order
            this.form.manipulationTool.ResizeManipulationTool(camera.CameraPosition.Z);
            this.form.manipulationTool.UpdateTool(this.gameInput);
            this.form.manipulationTool.currentTool(this.gameInput);
            //These have to be in this order


            PropertyUpdater.UpdateGamePropertiesFields(this.form.expRightSidebar);
        }
    }
}
