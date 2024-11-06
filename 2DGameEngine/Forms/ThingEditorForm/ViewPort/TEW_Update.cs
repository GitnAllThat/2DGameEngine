using _2DLevelCreator;
using Microsoft.Xna.Framework.Input;

namespace CustomControls
{
    //Monogame Reimplement: Change XnaWindow back to MonoGameMainWindow
    public partial class ThingEditorWindow : XnaWindow
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


            //CopyPasteTool.CopyObjects(this.selectionTool);
            //CopyPasteTool.PasteObjects(this.XnaWindow.gameInput, this.manipulationTool, this.selectionTool);

            this.form.manipulationTool.currentTool(this.gameInput);
            //These have to be in this order

            PropertyUpdater.UpdateGamePropertiesFields(this.form.expRightSidebar);


            //this.form.FillList_Things();

        }
    }
}
