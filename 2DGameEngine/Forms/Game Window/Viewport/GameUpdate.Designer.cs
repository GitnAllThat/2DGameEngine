using System.Collections.Generic;
using Microsoft.Xna.Framework;
using Global_Data;
using _2d_Objects;

namespace CustomControls
{
    //Monogame Reimplement: Change XnaWindow back to MonoGameMainWindow
    public partial class GameWindow : XnaWindow
    {
        public override void GameUpdate()
        {
            //Globals.timeDifference *= 0.1f;
            this.gameInput.Update();

            if (this.Focused) 
                this.camera.CameraMovement(this.gameInput, this);





            Globals.UpdateGravityPerFrame();

            //Doubley add gravity to eli
            eli.rigidBody.motion.vVelocityPS += Globals.gravityThisFrame * 0.5f;


            

            for (int i = 0; i < this.list_AllObjects.Count; ++i)
            {
                if (this.list_AllObjects[i].rigidBody.Static == false)   //Skip Static objects.
                {
                    this.list_AllObjects[i].rigidBody.motion.vVelocityPS += Globals.gravityThisFrame;
                    this.list_AllObjects[i].rigidBody.Update();
                }
            }


            List<CollisionData> list_CD = new List<CollisionData>();

            for (int i = 0, count = this.list_AllObjects.Count; i < count; ++i)  //Reset the collision objects
            {
                for (int j = i + 1; j < count; ++j)
                {
                    if (this.list_AllObjects[i].rigidBody.Static == false || this.list_AllObjects[j].rigidBody.Static == false)   //Skip Static vs Static objects.
                    {
                        if (AABB.AABBIntersectAABB(this.list_AllObjects[i].rigidBody.motionPathAABB, this.list_AllObjects[j].rigidBody.motionPathAABB))
                        {
                            int cdElement = list_CD.Count;

                            list_CD.AddRange(this.list_AllObjects[i].rigidBody.GetCollisionSolver(this.list_AllObjects[j].rigidBody));

                            Collision_Methods.HandleTouchingContacts(this.list_AllObjects[i].rigidBody, this.list_AllObjects[j].rigidBody, list_CD, cdElement);
                        }
                        else
                        {
                            Collision_Methods.RemoveTouchingContact(this.list_AllObjects[i].rigidBody, this.list_AllObjects[j].rigidBody);
                        }
                    }
                }
            }

            Collision_Methods.resolveCollisions(list_CD, Globals.SOLVERITERATIONS);

            eli.UpdateSurfaceData(list_CD);
            eli.FindSurface();
            eli.Update(this.gameInput);
            eli.UpdateAnimation(this.gameInput, Globals.timeDifference);

            
            for (int i = 0; i < list_CD.Count; ++i)
            {
                if (list_CD[i].rigidBody_A == eli.rigidBody || list_CD[i].rigidBody_B == eli.rigidBody)
                {
                    Vector3 cp1 = list_CD[i].rigidBody_A.transform.vPosition + list_CD[i].vContactPointA;
                    Vector3 cp2 = list_CD[i].rigidBody_B.transform.vPosition + list_CD[i].vContactPointB;

                    if ((cp1 - cp2).Length() < 0.01f || list_CD[i].distance < 0)
                    {
                        list_CD_Eli.Add(list_CD[i]);
                    }
                }
            }
            eli.rigidBody.touchingContactsContainerList.Clear();


            for (int i = 0; i < this.list_AllObjects.Count; ++i)
            {
                if (this.list_AllObjects[i].rigidBody.Static == false)   //Skip Static objects.
                {
                    Vector3 tempVel = this.list_AllObjects[i].rigidBody.motion.vVelocityPS;
                    tempVel += this.list_AllObjects[i].rigidBody.motion.vVelocityPS_AntiPenetration;
                    tempVel *= Globals.timeDifference;

                    float tempRot = (this.list_AllObjects[i].rigidBody.motion.zRotPS + this.list_AllObjects[i].rigidBody.motion.zRotPS_AntiPenetration) * Globals.timeDifference;

                    this.list_AllObjects[i].rigidBody.transform.vPosition += tempVel;    //Update Position
                    this.list_AllObjects[i].rigidBody.AddRotation(tempRot);              //Update Rotation

                    this.list_AllObjects[i].rigidBody.motion.vVelocityPS_AntiPenetration = Vector3.Zero;
                    this.list_AllObjects[i].rigidBody.motion.zRotPS_AntiPenetration = 0;

                    //Globals.list_Things[i].rigidBody.motion.vVelocityPS *= 0.999f;
                    //Globals.list_Things[i].rigidBody.motion.zRotPS *= 0.96f;
                }
            }


            eli.CameraFollow(this);
            
        }
    }
}
