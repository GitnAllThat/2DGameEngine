using System;
using Microsoft.Xna.Framework;

using _2d_Objects;
using _2DLevelCreator;
using Shapes;
using CustomControls;

namespace Tools
{
    public class Icon
    {
        public RigidBody rigidBody;
        public Vector3 Position 
        { 
            get { return this.rigidBody.transform.vPosition;} 
            set 
            { 
                this.rigidBody.transform.vPosition = value; 
                this.rigidBody.Update(); 
            } 
        }
        
        public float Rotation 
        { 
            get { return this.rigidBody.transform.zRotation; } 
            set 
            {
                this.rigidBody.transform.zRotation = value;
                this.rigidBody.Update(); 
            } 
        }


        public void RescaleTo(Vector3 scale){this.rigidBody.RescaleTo(scale);}
        public void ScaleBy(Vector3 scale){this.rigidBody.ScaleBy(scale);}

        public bool IsIconClicked = false;
        public Vector3 clickOffset = Vector3.Zero;

        public Color colorClicked = Color.Red;
        public Color colorNotClicked = Color.Gray;

        public Icon(RigidBody rigidBody, Color colorClicked, Color colorNotClicked)
        {
            this.rigidBody = rigidBody;
            this.rigidBody.Colour = colorNotClicked;
            this.colorClicked = colorClicked;
            this.colorNotClicked = colorNotClicked;
        }


        public void CalculateClickOffset(GameInput gameInput)
        {
            this.clickOffset = (this.rigidBody.transform.vPosition - gameInput.mousePositionCurrentProjected);
        }

        public bool CheckMouseOverIcon(GameInput gameInput)
        {
            return ((gameInput.mouseBC.GetCollisionSolver(this.rigidBody))[0].distance <= 0) ? true : false;
        }

        public void Update(GameInput gameInput)
        {
            if (gameInput.MouseLeftPressed && gameInput.MouseLeftDownOnXnaWindow && this.CheckMouseOverIcon(gameInput))
            {
                this.IsIconClicked = true;
                this.CalculateClickOffset(gameInput);
                this.rigidBody.Colour = this.colorClicked;
            }

            if (!gameInput.MouseLeftIsDown)
            {
                this.IsIconClicked = false;
                this.rigidBody.Colour = this.colorNotClicked;
            }
        }

    }





    public partial class ManipulationTool
    {
        //MAKE TOOLENABLED BOOL

        public Line xLine = new Line(Vector3.Zero, Vector3.Zero, Color.Red, 3);
        public Line yLine = new Line(Vector3.Zero, Vector3.Zero, Color.Blue, 3);


        public Icon IconMoveXY = new Icon(new ConvexPolygon(new Transform(), new Motion(), Vector3.Zero, new Vector3[4] { new Vector3(-0.5f, 0.5f, 0), new Vector3(0.5f, 0.5f, 0), new Vector3(0.5f, -0.5f, 0), new Vector3(-0.5f, -0.5f, 0) }, 0, false), Color.Yellow, new Color(255, 255, 0, 230));
        public Icon IconMoveX = new Icon(new ConvexPolygon(new Transform(), new Motion(), Vector3.Zero, new Vector3[3] { new Vector3(-0.5f, 0.5f, 0), new Vector3(0.5f, 0, 0), new Vector3(-0.5f, -0.5f, 0) }, 0, false), Color.Yellow, new Color(139, 0, 0, 200));
        public Icon IconMoveY = new Icon(new ConvexPolygon(new Transform(), new Motion(), Vector3.Zero, new Vector3[3] { new Vector3(0, 0.5f, 0), new Vector3(0.5f, -0.5f, 0), new Vector3(-0.5f, -0.5f, 0) }, 0, false), Color.Yellow, new Color(0, 0, 139, 200));

        public Icon IconRotate = new Icon(new BoundingCircle(new Transform(), new Motion(), Vector3.Zero, 1, 0, false), new Color(0, 0, 139, 60), new Color(0, 0, 139, 40));
        public Line rotationLineOld = new Line(Vector3.Zero,Vector3.Zero,Color.Gray,3);
        public Line rotationLineNew = new Line(Vector3.Zero, Vector3.Zero, Color.Blue, 3);


        public Icon IconScaleXY = new Icon(new ConvexPolygon(new Transform(), new Motion(), Vector3.Zero, new Vector3[4] { new Vector3(-0.5f, 0.5f, 0), new Vector3(0.5f, 0.5f, 0), new Vector3(0.5f, -0.5f, 0), new Vector3(-0.5f, -0.5f, 0) }, 0, false), Color.Yellow, new Color(255, 255, 0, 230));
        public Icon IconScaleX = new Icon(new ConvexPolygon(new Transform(), new Motion(), Vector3.Zero, new Vector3[4] { new Vector3(-0.5f, 0.5f, 0), new Vector3(0.5f, 0.5f, 0), new Vector3(0.5f, -0.5f, 0), new Vector3(-0.5f, -0.5f, 0) }, 0, false), Color.Yellow, new Color(139, 0, 0, 200));
        public Icon IconScaleY = new Icon(new ConvexPolygon(new Transform(), new Motion(), Vector3.Zero, new Vector3[4] { new Vector3(-0.5f, 0.5f, 0), new Vector3(0.5f, 0.5f, 0), new Vector3(0.5f, -0.5f, 0), new Vector3(-0.5f, -0.5f, 0) }, 0, false), Color.Yellow, new Color(0, 0, 139, 200));
        public Icon IconScaleX_Ghost = new Icon(new ConvexPolygon(new Transform(), new Motion(), Vector3.Zero, new Vector3[4] { new Vector3(-0.5f, 0.5f, 0), new Vector3(0.5f, 0.5f, 0), new Vector3(0.5f, -0.5f, 0), new Vector3(-0.5f, -0.5f, 0) }, 0, false), Color.Gray, Color.Gray);
        public Icon IconScaleY_Ghost = new Icon(new ConvexPolygon(new Transform(), new Motion(), Vector3.Zero, new Vector3[4] { new Vector3(-0.5f, 0.5f, 0), new Vector3(0.5f, 0.5f, 0), new Vector3(0.5f, -0.5f, 0), new Vector3(-0.5f, -0.5f, 0) }, 0, false), Color.Gray, Color.Gray);


        public Vector3 position = Vector3.Zero;
        public float rotation = 0;
        public float ArmLength { get; set; }
        public float ToolSize { get; set; }

        public int ToolID = 0;

        #region GridSnap Booleans
            public bool GRIDSNAPMOVE = false;
            public bool GRIDSNAPROTATE = false;
            public bool GRIDSNAPSCALE = false;

            public float GRIDSNAPMOVEVAL = 1;
            public float GRIDSNAPROTATEVAL = 20;
            public float GRIDSNAPSCALEVAL = 1;

            public float MINGRIDSNAP = 0.1f;
            public bool TRANSFORMASGROUP = false;
        #endregion

        public float PIVOTROTATION = 0;

        public delegate void ManipulationFunction(GameInput gameInput);
        public  ManipulationFunction currentTool = null;

        //Constructor
        public ManipulationTool()
        {
            this.ArmLength = 2;
            this.ToolSize = 0.01f; 
            this.ResizeTools(new Vector3(1,1,1));
            this.UpdateTransformation(Vector3.Zero, 0);
            this.currentTool = this.NoTool;
        }

        public virtual void NoTool(GameInput gameInput) { }
        public virtual void MoveTool(GameInput gameInput) { }
        public virtual void RotateTool(GameInput gameInput) { }
        public virtual void ScaleTool(GameInput gameInput) { }
        public virtual Vector3 CenterPivot() {return Vector3.Zero;}
        public virtual void Draw(XnaWindow xnaWindow) { }
        public virtual void UpdateToolTransformations() { }

        public void ResizeManipulationTool(float cameraZ)
        {
            float distance = cameraZ - this.position.Z;
            if (distance == 0) return;

            ResizeTools(new Vector3(distance * ToolSize, distance * ToolSize, 1));
            this.PositionIcons();
            this.RotateIcons();
        }


        private void ResizeTools(Vector3 scale)
        {
            this.ArmLength = scale.X * 2;
            this.IconMoveXY.RescaleTo(scale);
            this.IconMoveX.RescaleTo(scale);
            this.IconMoveY.RescaleTo(scale);

            this.IconRotate.RescaleTo(new Vector3(this.ArmLength, this.ArmLength, 1));

            this.IconScaleXY.RescaleTo(scale);
            this.IconScaleX.RescaleTo(scale);
            this.IconScaleY.RescaleTo(scale);
            this.IconScaleX_Ghost.RescaleTo(scale);
            this.IconScaleY_Ghost.RescaleTo(scale);
        }



        public void UpdateTransformation(Vector3 position, float rotation)
        {
            this.position = position;
            this.rotation = rotation;
            this.PositionIcons();
            this.RotateIcons();
        }

        private void PositionIcons()
        {
            Matrix rotMatrix = Matrix.CreateRotationZ(this.rotation);

            this.IconMoveXY.Position = this.position + Vector3.Transform(Vector3.Zero, rotMatrix);
            this.IconMoveX.Position = this.position + Vector3.Transform(new Vector3(this.ArmLength, 0, 0), rotMatrix);
            this.IconMoveY.Position = this.position + Vector3.Transform(new Vector3(0, this.ArmLength, 0), rotMatrix);

            this.IconRotate.Position = this.position + Vector3.Transform(Vector3.Zero, rotMatrix);

            this.IconScaleXY.Position = this.position + Vector3.Transform(Vector3.Zero, rotMatrix);
            this.IconScaleX.Position = this.position + Vector3.Transform(new Vector3(this.ArmLength, 0, 0), rotMatrix);
            this.IconScaleY.Position = this.position + Vector3.Transform(new Vector3(0, this.ArmLength, 0), rotMatrix);
            this.IconScaleX_Ghost.Position = this.position + Vector3.Transform(new Vector3(this.ArmLength, 0, 0), rotMatrix);
            this.IconScaleY_Ghost.Position = this.position + Vector3.Transform(new Vector3(0, this.ArmLength, 0), rotMatrix);
        }

        private void RotateIcons()
        {
            this.IconMoveXY.Rotation = rotation;
            this.IconMoveX.Rotation = rotation;
            this.IconMoveY.Rotation = rotation;

            this.IconRotate.Rotation = rotation;

            this.IconScaleXY.Rotation = rotation;
            this.IconScaleX.Rotation = rotation;
            this.IconScaleY.Rotation = rotation;
            this.IconScaleX_Ghost.Rotation = rotation;
            this.IconScaleY_Ghost.Rotation = rotation;
        }





        public static float RoundToGridSnap(float number, float gridSnap)
        {
            float num = number / gridSnap;
            num = (float)(Math.Round(num, 0));
            return (num * gridSnap);
        }


        public Vector3 RoundToGridSnapMove(Vector3 vector)
        {
            if (GRIDSNAPMOVE)
            {
                vector.X = RoundToGridSnap(vector.X, GRIDSNAPMOVEVAL);
                vector.Y = RoundToGridSnap(vector.Y, GRIDSNAPMOVEVAL);
                vector.Z = RoundToGridSnap(vector.Z, GRIDSNAPMOVEVAL);
            }
            return vector;
        }

        public Vector3 RoundToGridSnapScale(Vector3 vector)
        {
            if (GRIDSNAPSCALE)
            {
                if (this.IconScaleX.IsIconClicked || this.IconScaleXY.IsIconClicked) vector.X = RoundToGridSnap(vector.X, GRIDSNAPSCALEVAL);
                if (this.IconScaleY.IsIconClicked || this.IconScaleXY.IsIconClicked) vector.Y = RoundToGridSnap(vector.Y, GRIDSNAPSCALEVAL);
                vector.Z = RoundToGridSnap(vector.Z, GRIDSNAPSCALEVAL);
            }
            return vector;
        }

        public bool IsToolInUse()
        {
            return (IsMoveToolInUse() || IsScaleToolInUse() || IsRotateToolInUse()) ? true : false;
        }
        public bool IsMoveToolInUse()
        {
            return (this.ToolID == 1 && (this.IconMoveXY.IsIconClicked || this.IconMoveX.IsIconClicked || this.IconMoveY.IsIconClicked)) ? true : false;
        }
        public bool IsScaleToolInUse()
        {
            return (this.ToolID == 3 && (this.IconScaleXY.IsIconClicked || this.IconScaleX.IsIconClicked || this.IconScaleY.IsIconClicked)) ? true : false;
        }
        public bool IsRotateToolInUse()
        {
            return (this.ToolID == 2 && (this.IconRotate.IsIconClicked)) ? true : false;
        }
        








































       






        public void UpdateTool(GameInput gameInput)
        {
            this.IconMoveXY.Update(gameInput);
            this.IconMoveX.Update(gameInput);
            this.IconMoveY.Update(gameInput);
            this.IconRotate.Update(gameInput);
            this.IconScaleXY.Update(gameInput);
            this.IconScaleX.Update(gameInput);
            this.IconScaleY.Update(gameInput);


            ManageMoveTool(gameInput);
            ManageRotateTool(gameInput);
            ManageScaleTool(gameInput);
        }


        public void ManageMoveTool(GameInput gameInput)
        {
            Matrix rotation = Matrix.CreateRotationZ(-this.rotation);
            Matrix rotation2 = Matrix.CreateRotationZ(this.rotation);
            Vector3 mousePos = Vector3.Transform(gameInput.mousePositionCurrentProjected - this.position, rotation);

            if (ToolID == 1)
            {
                if (this.IconMoveX.IsIconClicked)
                {
                    UpdateTransformation(this.position + Vector3.Transform(this.RoundToGridSnapMove(new Vector3(mousePos.X - this.ArmLength + Vector3.Transform(this.IconMoveX.clickOffset, rotation).X, 0, 0)), rotation2), this.rotation);
                }

                if (this.IconMoveY.IsIconClicked)
                {
                    UpdateTransformation(this.position + Vector3.Transform(this.RoundToGridSnapMove(new Vector3(0, mousePos.Y - this.ArmLength + Vector3.Transform(this.IconMoveY.clickOffset, rotation).Y, 0)), rotation2), this.rotation);
                }

                if (this.IconMoveXY.IsIconClicked)
                {
                    UpdateTransformation(this.RoundToGridSnapMove(gameInput.mousePositionCurrentProjected + this.IconMoveXY.clickOffset), this.rotation);
                }
            }
        }



        public void ManageRotateTool(GameInput gameInput)
        {
            if (ToolID == 2)
            {
                if (this.IconRotate.IsIconClicked && (gameInput.mouseLeftDownLocation != this.position && gameInput.mousePositionCurrentProjected != this.position)) //Second statement so normalising doesnt fail
                {
                    this.rotationLineOld = new Line(this.position, this.position + (Vector3.Normalize(gameInput.mouseLeftDownLocation - this.position) * this.ArmLength), Color.Gray, 5);
                    this.rotationLineNew = new Line(this.position, this.position + (Vector3.Normalize(gameInput.mousePositionCurrentProjected - this.position) * this.ArmLength), new Color(0, 0, 139, 200), 5);
                }
            }
        }


        public void ManageScaleTool(GameInput gameInput)
        {
            Matrix rotMatrix = Matrix.CreateRotationZ(this.rotation);
            Vector3 mousePos = Vector3.Transform(gameInput.mousePositionCurrentProjected - this.position, Matrix.CreateRotationZ(-this.rotation));
            Vector3 mouseDownPos = Vector3.Transform(gameInput.mouseLeftDownLocation - this.position, Matrix.CreateRotationZ(-this.rotation));
            
            if (ToolID == 3)
            {
                if (this.IconScaleXY.IsIconClicked)
                {
                    this.IconScaleX.Position = (this.IconScaleX_Ghost.Position - Vector3.Transform(new Vector3((mouseDownPos.X - mousePos.X), 0, 0), rotMatrix));
                    this.IconScaleY.Position = (this.IconScaleY_Ghost.Position - Vector3.Transform(new Vector3(0, (mouseDownPos.X - mousePos.X), 0), rotMatrix)); //Using X axis to keep scale the same for y Axis
                }
                else if (this.IconScaleX.IsIconClicked)
                {
                    this.IconScaleX.Position = (this.IconScaleX_Ghost.Position - Vector3.Transform(new Vector3((mouseDownPos.X - mousePos.X), 0, 0), rotMatrix));
                }
                else if (this.IconScaleY.IsIconClicked)
                {
                    this.IconScaleY.Position = (this.IconScaleY_Ghost.Position - Vector3.Transform(new Vector3(0, (mouseDownPos.Y - mousePos.Y), 0), rotMatrix));
                }



                if (!this.IsScaleToolInUse())
                {
                    if (!this.IconScaleX.IsIconClicked)
                    {
                        this.IconScaleX.Position = (this.position + Vector3.Transform(new Vector3(this.ArmLength, 0, 0), rotMatrix));
                    }

                    if (!this.IconScaleY.IsIconClicked)
                    {
                        this.IconScaleY.Position = (this.position + Vector3.Transform(new Vector3(0, this.ArmLength, 0), rotMatrix));
                    }
                }
            }
        }





        public Vector3 GetScale()
        {
            Vector3 scale = new Vector3((this.position - this.IconScaleX.rigidBody.transform.vPosition).Length(),
                                        (this.position - this.IconScaleY.rigidBody.transform.vPosition).Length(),
                                         this.ArmLength);

            MinScaleValue(scale); //Dont Want To Scale To A "0"

            return scale / this.ArmLength;
        }

        public Vector3 MinScaleValue(Vector3 vector)
        {
            if (vector.X < 0) if (vector.X > -0.1f) vector.X = -MINGRIDSNAP;
            if (vector.X >= 0) if (vector.X < 0.1f) vector.X = MINGRIDSNAP;
            if (vector.Y < 0) if (vector.Y > -0.1f) vector.Y = -MINGRIDSNAP;
            if (vector.Y >= 0) if (vector.Y < 0.1f) vector.Y = MINGRIDSNAP;
            vector.Z = 1;
            return vector;
        }

        public float GetRotation()
        {
            float angle = (this.IsRotateToolInUse()) ? Collision_Methods.GetAngle(this.rotationLineNew.lineVector[1] - this.position, this.rotationLineOld.lineVector[1] - this.position) : 0;
            return angle;
        }





        public void DrawMoveTool(XnaWindow xnaWindow)
        {
            this.xLine = new Line(this.position, this.IconMoveX.rigidBody.transform.vPosition, IconMoveX.rigidBody.Colour, 3);
            this.yLine = new Line(this.position, this.IconMoveY.rigidBody.transform.vPosition, IconMoveY.rigidBody.Colour, 3);

            xLine.Draw(xnaWindow);
            yLine.Draw(xnaWindow);

            IconMoveXY.rigidBody.Draw(xnaWindow);
            IconMoveX.rigidBody.Draw(xnaWindow);
            IconMoveY.rigidBody.Draw(xnaWindow);
        }

        public void DrawRotateTool(XnaWindow xnaWindow)
        {
            this.IconRotate.rigidBody.Draw(xnaWindow);
            if (this.IconRotate.IsIconClicked)
            {
                this.rotationLineOld.Draw(xnaWindow);
                this.rotationLineNew.Draw(xnaWindow);
                (new Circle(rotationLineOld.lineVector[1], this.IconScaleXY.rigidBody.transform.vScale.X * 0.3f, 50, Circle.DrawStyle.Both, this.rotationLineOld.colour, Color.White)).Draw(xnaWindow);
                (new Circle(rotationLineNew.lineVector[1], this.IconScaleXY.rigidBody.transform.vScale.X * 0.3f, 50, Circle.DrawStyle.Both, this.rotationLineNew.colour, Color.White)).Draw(xnaWindow);
            }
        }

        public void DrawScaleTool(XnaWindow xnaWindow)
        {
            (new Line(this.position, this.IconScaleX_Ghost.rigidBody.transform.vPosition, new Color(90, 90, 90, 250), 3)).Draw(xnaWindow);
            (new Line(this.position, this.IconScaleY_Ghost.rigidBody.transform.vPosition, new Color(90, 90, 90, 250), 3)).Draw(xnaWindow);

            this.xLine = new Line(this.position, this.IconScaleX.rigidBody.transform.vPosition, IconScaleX.rigidBody.Colour, 3);
            this.yLine = new Line(this.position, this.IconScaleY.rigidBody.transform.vPosition, IconScaleY.rigidBody.Colour, 3);
            xLine.Draw(xnaWindow);
            yLine.Draw(xnaWindow);

            IconScaleXY.rigidBody.Draw(xnaWindow);
            IconScaleX_Ghost.rigidBody.Draw(xnaWindow);
            IconScaleY_Ghost.rigidBody.Draw(xnaWindow);
            IconScaleX.rigidBody.Draw(xnaWindow);
            IconScaleY.rigidBody.Draw(xnaWindow);
        }


    }
}
