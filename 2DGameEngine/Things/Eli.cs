using System.Collections.Generic;
using Microsoft.Xna.Framework;
using Microsoft.Xna.Framework.Input;
using _2DLevelCreator;
using Things;
using CustomControls;

namespace _2d_Objects
{
    public class MyAnimation
    {
        public UniqueIdentifier_Reference[] MaterialIDs;
        public float AnimationSpeed { get; set; }
        public int AnimationIndex = 0;
        public float AnimationTime { get; set; }
        public float Size { get; set; }
        public Thing2D thing2D { get; set; }
        public bool Flipped { get; set; }


        public MyAnimation(string name, string[] matNames, float animationSpeed, float size)
        {
            this.AnimationSpeed = animationSpeed;
            this.AnimationTime = 0;
            this.Size = size;

            this.MaterialIDs = new UniqueIdentifier_Reference[matNames.Length];
            for (int iCount = 0, iCountMax = matNames.Length; iCount < iCountMax; ++iCount)
            {
                this.MaterialIDs[iCount] = Material.GetUniqueIdentifierByName(matNames[iCount]);
            }

            this.thing2D = new Thing2D("AnimationThing2D_01", this.MaterialIDs[0], new VertexPositionTextureArray(), new List<Thing2D>());
            this.Flipped = false;
        }

        public void Update(float timeDifference)
        {
            this.AnimationTime += timeDifference;

            if (this.AnimationTime > this.AnimationSpeed)
            {
                this.AnimationTime = 0;
                AnimationIndex = (AnimationIndex + 1) % this.MaterialIDs.Length;
            }
        }

        public void Reset()
        {
            this.AnimationTime = 0;
            this.AnimationIndex = 0;
        }

        public void FlipImage(bool lookingRight)
        {
            if ((lookingRight && this.Flipped) || (!lookingRight && !this.Flipped))
            {
                this.Flipped = !this.Flipped;
                for(int iCount = thing2D.vertexPositionTextureArray.Length - 1; iCount>=0; --iCount)
                {
                    this.thing2D.vertexPositionTextureArray.VertexPositionTextureWrapper[iCount].TextureCoordinate = new Vector2(-this.thing2D.vertexPositionTextureArray.VertexPositionTextureWrapper[iCount].TextureCoordinate.X, this.thing2D.vertexPositionTextureArray.VertexPositionTextureWrapper[iCount].TextureCoordinate.Y);
                }
            }
        }
    }


    public class Eli : Thing2D_Rb<RigidBody>
    {
        public bool Grounded { get; set; }
        public Vector3 SurfaceNormal; //Cant use Get Set because we need to normalise this.
        public Vector3 SurfaceDirection;



        public MyAnimation animationIdle;
        public MyAnimation animationRun;
        public MyAnimation animationJumpVertical;
        public MyAnimation animationFallVertical;
        public MyAnimation animationJumpDiagonal;
        public MyAnimation animationFallDiagonal;
        public MyAnimation animationCurrent;


        public Eli(UniqueIdentifier_Reference Thing2D_ID, RigidBody rb, string uniqueID, List<Thing2D_Rb<RigidBody>> list): base(Thing2D_ID, rb, uniqueID, list)
        {
            Orientation = 0;
            this.Grounded = false;
            this.SurfaceNormal = new Vector3(0, 1, 0);
            this.SurfaceDirection = new Vector3(1, 0, 0);




            //this.runIDs[12] = Material.GetUniqueIdentifierByName("mat_Run_13");

            this.animationIdle = new MyAnimation("Idle", new string[] { "mat_Idle_01", "mat_Idle_02", "mat_Idle_03", "mat_Idle_04", "mat_Idle_05", "mat_Idle_06" }, 0.12f, 1.5f);
            this.animationRun = new MyAnimation("Run", new string[] {   "mat_Run_01", "mat_Run_02", "mat_Run_03", "mat_Run_04", "mat_Run_05", "mat_Run_06", "mat_Run_07",
                                                                        "mat_Run_08", "mat_Run_09", "mat_Run_10", "mat_Run_11", "mat_Run_12", "mat_Run_13"}, 0.12f, 3);
            
            this.animationJumpVertical = new MyAnimation("JumpVertical", new string[] { "mat_JumpVertical_01", "mat_JumpVertical_02", "mat_JumpVertical_03", "mat_JumpVertical_04", "mat_JumpVertical_05", "mat_JumpVertical_06", "mat_JumpVertical_07", "mat_JumpVertical_08" }, 0.12f, 3);
            this.animationFallVertical = new MyAnimation("FallVertical", new string[] { "mat_FallVertical_01", "mat_FallVertical_02", "mat_FallVertical_03" }, 0.12f, 3);

            this.animationJumpDiagonal = new MyAnimation("JumpDiagonal", new string[] { "mat_JumpDiagonal_01", "mat_JumpDiagonal_02", "mat_JumpDiagonal_03", "mat_JumpDiagonal_04", "mat_JumpDiagonal_05", "mat_JumpDiagonal_06", "mat_JumpDiagonal_07", "mat_JumpDiagonal_08", "mat_JumpDiagonal_09", "mat_JumpDiagonal_10", "mat_JumpDiagonal_11" }, 0.12f, 3);
            this.animationFallDiagonal = new MyAnimation("FallDiagonal", new string[] { "mat_FallDiagonal_01", "mat_FallDiagonal_02", "mat_FallDiagonal_03", "mat_FallDiagonal_04" }, 0.12f, 3);

            this.animationCurrent = this.animationIdle;
        }

        float speedMax = 10;
        float acceleration = 0.2f;
        float stoppingPower = 0.15f;
        float jumpPower = 10;

        public float Orientation { get; set; }
        public List<SurfaceData> SurfaceDataList = new List<SurfaceData>();



        public void CameraFollow(XnaWindow xnaWindow)
        {
            xnaWindow.camera.FocusOnPosition(this.Position, xnaWindow, 0);
        }

        public void UpdateAnimation(GameInput gameInput, float timeDifference)
        {

            if (this.Grounded && (gameInput.keyboardStateCurrent.IsKeyDown(Keys.Space) && !gameInput.keyboardStatePrevious.IsKeyDown(Keys.Space)))
            {
                this.Grounded = false;
                this.ChangeAnimation(this.animationJumpVertical);

                if (this.VelocityX > 5f || this.VelocityX < -5f)
                {
                    this.ChangeAnimation(this.animationJumpDiagonal);
                }
                else
                {
                    this.ChangeAnimation(this.animationJumpVertical);
                }

                if (this.VelocityX > 0) this.animationCurrent.FlipImage(true);
                else this.animationCurrent.FlipImage(false);
            }
            else if ((this.Velocity.Length() > 0.3f || gameInput.keyboardStateCurrent.IsKeyDown(Keys.A) || gameInput.keyboardStateCurrent.IsKeyDown(Keys.D)) && this.Grounded)
            {
                this.ChangeAnimation(this.animationRun);
            }
            else if(this.Grounded)
            {
                this.ChangeAnimation(this.animationIdle);
            }
            else
            {
                if ((this.animationCurrent == this.animationJumpVertical || this.animationCurrent == this.animationJumpDiagonal) && this.animationCurrent.AnimationIndex == this.animationCurrent.MaterialIDs.Length - 1)
                {
                    if (this.VelocityX > 5f || this.VelocityX < -5f)
                    {
                        this.ChangeAnimation(this.animationFallDiagonal);
                    }
                    else
                    {
                        this.ChangeAnimation(this.animationFallVertical);
                    }
                }
            }


            if (gameInput.keyboardStateCurrent.IsKeyDown(Keys.A))
            {
                this.animationCurrent.FlipImage(false);
            }
            else if (gameInput.keyboardStateCurrent.IsKeyDown(Keys.D))
            {
                this.animationCurrent.FlipImage(true);
            }

            



            this.animationCurrent.Update(timeDifference);
            this.animationCurrent.thing2D.MaterialID = this.animationCurrent.MaterialIDs[this.animationCurrent.AnimationIndex];
        }

        public void ChangeAnimation(MyAnimation toSwapWith)
        {
            if (this.animationCurrent != toSwapWith)
            {
                bool flipped = this.animationCurrent.Flipped;
                this.animationCurrent = toSwapWith;
                this.animationCurrent.FlipImage(!flipped);
                this.animationCurrent.Reset();
            }
        }


        public void Update(GameInput gameInput)
        {
            if (this.Grounded)
            {
                if (gameInput.keyboardStateCurrent.IsKeyDown(Keys.Space) && !gameInput.keyboardStatePrevious.IsKeyDown(Keys.Space))
                {
                    if (this.Grounded) this.VelocityY = 0;
                    float dot = Vector3.Dot(new Vector3(0, 1, 0), this.SurfaceNormal);
                    if (dot < 0.5f) dot = 0.5f;

                    Vector3 jumpVector = (new Vector3(0, 1, 0) * jumpPower * (dot)) + (this.SurfaceNormal * jumpPower * (1 - dot));
                    jumpVector.Normalize();
                    this.Velocity += jumpVector * jumpPower;
                    this.SurfaceNormal.Normalize();
                }
                else
                {
                    if (gameInput.keyboardStateCurrent.IsKeyDown(Keys.D))
                    {
                        float dot = Vector3.Dot(new Vector3(0, -1, 0), this.SurfaceDirection);
                        ++dot;


                        if (Vector3.Dot(this.Velocity, this.SurfaceDirection) < 0)
                        {
                            if (dot > 1)
                                this.Velocity -= (this.Velocity * 0.05f);
                            else
                                this.Velocity -= (this.Velocity * stoppingPower) * dot;
                        }

                        float speed = Velocity.Length();
                        if (speed > speedMax * dot)
                        {
                            //Apply Some Friction To slow Down
                            Velocity *= 0.99f;
                        }
                        else
                        {
                            //Allow it To Speed Up
                            this.Velocity += (SurfaceDirection * dot) * 0.2f;
                        }
                    }
                    else if (gameInput.keyboardStateCurrent.IsKeyDown(Keys.A))
                    {
                        float dot = Vector3.Dot(new Vector3(0, -1, 0), -this.SurfaceDirection);
                        ++dot;

                        if (Vector3.Dot(this.Velocity, -this.SurfaceDirection) < 0)
                        {
                            if (dot > 1)
                                this.Velocity -= (this.Velocity * 0.05f);
                            else
                                this.Velocity -= (this.Velocity * stoppingPower) * dot;
                        }


                        float speed = Velocity.Length();
                        if (speed > speedMax * dot)
                        {
                            //Apply Some Friction To slow Down
                            Velocity *= 0.99f;
                        }
                        else
                        {
                            //Allow it To Speed Up
                            this.Velocity -= (SurfaceDirection * dot) * 0.2f;
                        }
                    }
                }
            }
            else
            {
                if (gameInput.keyboardStateCurrent.IsKeyDown(Keys.D))
                {
                    if (this.VelocityX < speedMax * 0.7f)
                    {
                        this.VelocityX += acceleration;
                    }
                }
                else if (gameInput.keyboardStateCurrent.IsKeyDown(Keys.A))
                {
                    if (this.VelocityX > -speedMax * 0.7f)
                    {
                        this.VelocityX -= acceleration;
                    }
                }

                this.Orientation = 0;
            }


            //Slow Down If No Input
            if (!gameInput.keyboardStateCurrent.IsKeyDown(Keys.D) && !gameInput.keyboardStateCurrent.IsKeyDown(Keys.A) && this.Grounded)
            {
                this.RotationVelocity *= 0.9f;
                this.VelocityX *= 0.94f;
            }




        }



        #region Aquire Surface Data Information
        public void UpdateSurfaceData(List<CollisionData> CollisionDataList)
        {
            this.SurfaceDataList.Clear();

            for (int iCount = CollisionDataList.Count - 1; iCount >= 0 ; --iCount)
            {
                if (CollisionDataList[iCount].rigidBody_A == this.rigidBody && TouchingSurface(CollisionDataList[iCount]))
                    SurfaceDataList.Add(new SurfaceData(CollisionDataList[iCount].vContactPointA, CollisionDataList[iCount].vPerpCToCpA));
                else if (CollisionDataList[iCount].rigidBody_B == this.rigidBody && TouchingSurface(CollisionDataList[iCount]))
                    SurfaceDataList.Add(new SurfaceData(CollisionDataList[iCount].vContactPointB, CollisionDataList[iCount].vPerpCToCpB));
            }
            this.rigidBody.touchingContactsContainerList.Clear();
        }

        public bool TouchingSurface(CollisionData collisionData)
        {
            if (((collisionData.rigidBody_A.transform.vPosition + collisionData.vContactPointA) - (collisionData.rigidBody_B.transform.vPosition + collisionData.vContactPointB)).Length() < 0.1f   
                || collisionData.distance < 0)
                return true;

            return false;
        }
        #endregion



        public void FindSurface()
        {
            if (this.SurfaceDataList.Count > 0)
            {
                Vector3 bestNormal = new Vector3(0, -1, 0);
                int index = -1;
                float lowestCP = 0;


                for (int iCount = this.SurfaceDataList.Count - 1; iCount >= 0; --iCount)
                {
                    if (this.SurfaceDataList[iCount].vContactPoint.Y < lowestCP || index == - 1)
                    {
                        if (Vector3.Dot(bestNormal, this.SurfaceDataList[iCount].vContactPoint) >= 0)
                        {
                            lowestCP = this.SurfaceDataList[iCount].vContactPoint.Y;
                            index = iCount;
                        }
                    }
                }


                if (index == -1)
                {
                    this.Grounded = false;
                }
                else
                {
                    this.Grounded = true;
                    this.SurfaceNormal = -this.SurfaceDataList[index].vContactPoint; this.SurfaceNormal.Normalize();
                    this.SurfaceDirection = Vector3.Cross(this.SurfaceNormal, new Vector3(0, 0, 1));
                    this.Orientation = MathHelper.ToRadians(Collision_Methods.GetAngle(this.SurfaceDataList[index].vContactPoint)) + MathHelper.ToRadians(90);
                }
            }
            else
            {
                this.Grounded = false;
            }
        }



        public override void Draw(XnaWindow xnaWindow)
        {
            Transform t = new Transform(this.Transform.vPosition, this.Transform.zRotation, new Vector3(1,1,1) * this.animationCurrent.Size);
            this.animationCurrent.thing2D.Draw(xnaWindow, t, Matrix.CreateRotationZ(Orientation));
        }
    }
}
