using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using Microsoft.Xna.Framework;
using Microsoft.Xna.Framework.Audio;
using Microsoft.Xna.Framework.Content;
using Microsoft.Xna.Framework.Graphics;
using Microsoft.Xna.Framework.Input;
using Microsoft.Xna.Framework.Media;
using CustomControls;

namespace Shapes
{
    public class Line
    {
        public Vector3[] lineVector = new Vector3[2];
        public int thickness = 1;
        public Color colour = Color.White;

        private VertexPositionColor[] vpcArray = new VertexPositionColor[4];

        public Line(Vector3 from, Vector3 to, Color colour, int thickness)
        {
            this.thickness = thickness;

            this.lineVector[0] = from;
            this.lineVector[1] = to;


            this.colour = colour;


        }

        public void SetupVpcArray(float cameraZPos)
        {
            Vector3 perpEdge = this.lineVector[0] - this.lineVector[1];
            float temp = perpEdge.X; perpEdge.X = -perpEdge.Y; perpEdge.Y = temp;
            perpEdge.Normalize();


            float distance = cameraZPos - this.lineVector[1].Z;
            float thick = (distance * thickness) / 5000;


            vpcArray[0].Position = this.lineVector[1] + (perpEdge * thick); vpcArray[1].Color = this.colour;
            vpcArray[1].Position = this.lineVector[0] + (perpEdge * thick); vpcArray[0].Color = this.colour;
            vpcArray[2].Position = this.lineVector[1] - (perpEdge * thick); vpcArray[3].Color = this.colour;
            vpcArray[3].Position = this.lineVector[0] - (perpEdge * thick); vpcArray[2].Color = this.colour;
        }



        public void Draw(XnaWindow monoGameWindow)
        {
            monoGameWindow.effect.CurrentTechnique = monoGameWindow.effect.Techniques["Technique_Colored"];
            monoGameWindow.effect.Parameters["WorldViewProjMatrix"].SetValue(Matrix.Identity * monoGameWindow.camera.ViewProjMatrix);
            monoGameWindow.effect.Parameters["RotationMatrix"].SetValue(Matrix.Identity);
            monoGameWindow.effect.Parameters["Scale"].SetValue(new Vector3(1, 1, 1));


            this.SetupVpcArray(monoGameWindow.camera.CameraPosition.Z);  //It is relative to the camera therefore need to calculate thickness



            foreach (EffectPass pass in monoGameWindow.effect.CurrentTechnique.Passes)
            {
                pass.Apply();
                monoGameWindow.Editor.GraphicsDevice.DrawUserPrimitives(PrimitiveType.TriangleStrip, vpcArray, 0, 2);
            }
        }
    }
}
