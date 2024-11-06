using Microsoft.Xna.Framework;
using _2DLevelCreator;
using _2d_Objects;
using Global_Data;
using Tools;
using System.Collections.Generic;
using Microsoft.Xna.Framework.Input;

namespace CustomControls
{
    //Monogame Reimplement: Change XnaWindow back to MonoGameMainWindow
    public partial class MonoGameMainWindow : XnaWindow
    {
        public override void GameUpdate()
        {
            gameInput.Update();

            if (this.Focused) camera.CameraMovement(gameInput, this);
            if (this.Focused) form.selectionTool.UseSelectionTool(gameInput, form.manipulationTool);
            if (this.Focused) if (gameInput.keyboardStateCurrent.IsKeyDown(Keys.F)) { this.form.selectionTool.FocusSelection(this); }


            this.DebugMovement(gameInput);        //Monogame Reimplement



            //These have to be in this order


            this.form.manipulationTool.ResizeManipulationTool(camera.CameraPosition.Z);
            this.form.manipulationTool.UpdateTool(gameInput);

            CopyPasteTool.CopyObjects(this.form.selectionTool, gameInput);
            CopyPasteTool.PasteObjects(gameInput, this.form.manipulationTool, this.form.selectionTool);

            DeleteTool.DeleteSelection(this.form.selectionTool, gameInput);

            this.form.manipulationTool.currentTool(gameInput);
            //These have to be in this order


            Globals.UpdateGravityPerFrame();










            for (int i = 0; i < Globals.list_AllObjects.Count; ++i)
            {
                Globals.list_AllObjects[i].rigidBody.Rebuild();
            }




            for (int i = 0; i < Globals.list_AllObjects.Count; ++i)
            {
                if (Globals.list_AllObjects[i].rigidBody.Static == false)   //Skip Static objects.
                {
                    if (Globals.MOVE)
                    {
                        Globals.list_AllObjects[i].rigidBody.motion.vVelocityPS += Globals.gravityThisFrame;
                        Globals.list_AllObjects[i].rigidBody.Update();
                    }
                }
            }


            List<CollisionData> list_CD = new List<CollisionData>();
            if (Globals.MOVE)
            {
                for (int i = 0, count = Globals.list_AllObjects.Count; i < count; ++i)  //Reset the collision objects
                {
                    for (int j = i + 1; j < count; ++j)
                    {
                        if (Globals.list_AllObjects[i].rigidBody.Static == false || Globals.list_AllObjects[j].rigidBody.Static == false)   //Skip Static vs Static objects.
                        {
                            if (AABB.AABBIntersectAABB(Globals.list_AllObjects[i].rigidBody.motionPathAABB, Globals.list_AllObjects[j].rigidBody.motionPathAABB))
                            {
                                int cdElement = list_CD.Count;

                                list_CD.AddRange(Globals.list_AllObjects[i].rigidBody.GetCollisionSolver(Globals.list_AllObjects[j].rigidBody));

                                Collision_Methods.HandleTouchingContacts(Globals.list_AllObjects[i].rigidBody, Globals.list_AllObjects[j].rigidBody, list_CD, cdElement);
                            }
                            else
                            {
                                Collision_Methods.RemoveTouchingContact(Globals.list_AllObjects[i].rigidBody, Globals.list_AllObjects[j].rigidBody);
                            }
                        }
                    }
                }
            }

            if (Globals.MOVE)
            {
                Collision_Methods.resolveCollisions(list_CD, Globals.SOLVERITERATIONS);
                for (int i = 0; i < Globals.list_AllObjects.Count; ++i)
                {
                    if (Globals.list_AllObjects[i].rigidBody.Static == false)   //Skip Static objects.
                    {
                        Vector3 tempVel = Globals.list_AllObjects[i].rigidBody.motion.vVelocityPS;
                        tempVel += Globals.list_AllObjects[i].rigidBody.motion.vVelocityPS_AntiPenetration;
                        tempVel *= Globals.timeDifference;

                        float tempRot = (Globals.list_AllObjects[i].rigidBody.motion.zRotPS + Globals.list_AllObjects[i].rigidBody.motion.zRotPS_AntiPenetration) * Globals.timeDifference;

                        Globals.list_AllObjects[i].rigidBody.transform.vPosition += tempVel;    //Update Position
                        Globals.list_AllObjects[i].rigidBody.AddRotation(tempRot);              //Update Rotation





                        Globals.list_AllObjects[i].rigidBody.motion.vVelocityPS_AntiPenetration = Vector3.Zero;
                        Globals.list_AllObjects[i].rigidBody.motion.zRotPS_AntiPenetration = 0;

                        //Globals.list_Things[i].rigidBody.motion.vVelocityPS *= 0.999f;
                        //Globals.list_Things[i].rigidBody.motion.zRotPS *= 0.96f;
                    }
                }
            }



            PropertyUpdater.UpdateGamePropertiesFields(this.form.expRightSidebar);
            Collision_Methods.list_CD = list_CD;





            //if (Program.gameWindowForm != null) Program.gameWindowForm.GameUpdate();
        }
    }
}
