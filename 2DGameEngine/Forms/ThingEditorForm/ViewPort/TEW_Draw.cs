using Microsoft.Xna.Framework;
using Microsoft.Xna.Framework.Graphics;
using _2DLevelCreator;
using Shapes;

namespace CustomControls
{
    //Monogame Reimplement: Change XnaWindow back to MonoGameMainWindow
    public partial class ThingEditorWindow : XnaWindow
    {
        public void GameDraw()
        {

            this.Editor.GraphicsDevice.Clear(new Color(60,60,60));

            this.Editor.GraphicsDevice.BlendState = BlendState.NonPremultiplied;    // Allows alpha



            if (form.TexCoordEditorMode)
            {
                //Draws the Image of the selected Thing2D on the Texture Editor.
                if (form.Thing2DSelection.Count > 0)
                {
                    if (form.Thing2DSelection.Count == 1)
                        form.Thing2DSelectionRenderView.MaterialID = form.Thing2DSelection[0].MaterialID;
                    else
                    {
                        for (int iCount = 0, iCountMax = form.Thing2DSelection.Count; iCount < iCountMax; ++iCount)
                        {
                            for (int jCount = 0, jCountMax = form.Thing2DSelection[iCount].vertexPositionTextureArray.Length; jCount < jCountMax; ++jCount)
                            {
                                for (int kCount = form.selectionTool.selectedVertices.Count - 1; kCount >= 0; --kCount)
                                {
                                    if (form.Thing2DSelection[iCount].vertexPositionTextureArray.VertexPositionTextureWrapper[jCount] == form.selectionTool.selectedVertices[kCount])
                                    {
                                        form.Thing2DSelectionRenderView.MaterialID = form.Thing2DSelection[iCount].MaterialID;
                                        jCount = jCountMax;
                                        iCount = iCountMax;
                                        break;
                                    }
                                }
                            }
                        }
                    }


                    form.Thing2DSelectionRenderView.Draw(this, new Transform(new Vector3(0.5f, -0.5f, 0), 0, new Vector3(1, 1, 1)), Matrix.Identity);
                    form.Thing2DSelectionRenderView.Draw(this, new Transform(new Vector3(0.5f, 0.5f, 0), 0, new Vector3(1, 1, 1)), Matrix.Identity);
                    form.Thing2DSelectionRenderView.Draw(this, new Transform(new Vector3(-0.5f, -0.5f, 0), 0, new Vector3(1, 1, 1)), Matrix.Identity);
                    form.Thing2DSelectionRenderView.Draw(this, new Transform(new Vector3(-0.5f, 0.5f, 0), 0, new Vector3(1, 1, 1)), Matrix.Identity);
                }


                form.gridTexCoords.Draw(this);


                if (form.Thing2DSelection.Count > 0)
                {
                    for (int jCount = 0, jCountMax = form.Thing2DSelection.Count; jCount < jCountMax; ++jCount)
                    {
                        for (int iCount = 0, iCountMax = form.Thing2DSelection[jCount].vertexPositionTextureArray.VertexPositionTextureWrapper.Length; iCount < iCountMax; ++iCount)
                        {
                            VectorHelper.DrawVertex(VertexPositionTextureArray.ConvertTextureCoordSpaceToWorld(form.Thing2DSelection[jCount].vertexPositionTextureArray.VertexPositionTextureWrapper[iCount].TextureCoordinate), this, new Color(255, 0, 0));
                        }

                        for (int iCount = 0, iCountMax = form.Thing2DSelection[jCount].vertexPositionTextureArray.VertexPositionTextureWrapper.Length; iCount < iCountMax; iCount += 3)
                        {
                            (new Line(VertexPositionTextureArray.ConvertTextureCoordSpaceToWorld(form.Thing2DSelection[jCount].vertexPositionTextureArray.VertexPositionTextureWrapper[iCount].TextureCoordinate), VertexPositionTextureArray.ConvertTextureCoordSpaceToWorld(form.Thing2DSelection[jCount].vertexPositionTextureArray.VertexPositionTextureWrapper[(iCount + 1)].TextureCoordinate), new Color(255, 0, 0), 1)).Draw(this);
                            (new Line(VertexPositionTextureArray.ConvertTextureCoordSpaceToWorld(form.Thing2DSelection[jCount].vertexPositionTextureArray.VertexPositionTextureWrapper[iCount + 1].TextureCoordinate), VertexPositionTextureArray.ConvertTextureCoordSpaceToWorld(form.Thing2DSelection[jCount].vertexPositionTextureArray.VertexPositionTextureWrapper[(iCount + 2)].TextureCoordinate), new Color(255, 0, 0), 1)).Draw(this);
                            (new Line(VertexPositionTextureArray.ConvertTextureCoordSpaceToWorld(form.Thing2DSelection[jCount].vertexPositionTextureArray.VertexPositionTextureWrapper[iCount + 2].TextureCoordinate), VertexPositionTextureArray.ConvertTextureCoordSpaceToWorld(form.Thing2DSelection[jCount].vertexPositionTextureArray.VertexPositionTextureWrapper[iCount].TextureCoordinate), new Color(255, 0, 0), 1)).Draw(this);

                        }
                    }
                }



                if (form.selectionTool.selectedVertices.Count > 0)
                {
                    for (int iCount = 0; iCount < form.selectionTool.selectedVertices.Count; ++iCount)
                    {
                        VectorHelper.DrawVertex(VertexPositionTextureArray.ConvertTextureCoordSpaceToWorld(form.selectionTool.selectedVertices[iCount].TextureCoordinate),this, new Color(0, 255, 0));
                    }
                }

            }
            else if (form.VertexEditorMode)
            {
                form.gridThing2D.Draw(this);

                if (form.Thing2DSelection.Count > 0)
                {
                    form.Thing2DSelection[0].Draw(this, new Transform(), Matrix.Identity);

                    for (int iCount = 0, iCountMax = form.Thing2DSelection[0].vertexPositionTextureArray.VertexPositionTextureWrapper.Length; iCount < iCountMax; ++iCount)
                    {
                        VectorHelper.DrawVertex(form.Thing2DSelection[0].vertexPositionTextureArray.VertexPositionTextureWrapper[iCount].Position,this , new Color(255, 0, 0));
                    }
                }

                if (form.selectionTool.selectedVertices.Count > 0)
                {
                    for (int iCount = 0; iCount < form.selectionTool.selectedVertices.Count; ++iCount)
                    {
                        VectorHelper.DrawVertex(form.selectionTool.selectedVertices[iCount].Position, this, new Color(0, 255, 0));
                    }

                    for (int iCount = 0, iCountMax = form.Thing2DSelection[0].vertexPositionTextureArray.VertexPositionTextureWrapper.Length; iCount < iCountMax; iCount += 3)
                    {
                        (new Line(form.Thing2DSelection[0].vertexPositionTextureArray.VertexPositionTextureWrapper[iCount].Position, form.Thing2DSelection[0].vertexPositionTextureArray.VertexPositionTextureWrapper[(iCount + 1)].Position, new Color(255, 0, 0), 1)).Draw(this);
                        (new Line(form.Thing2DSelection[0].vertexPositionTextureArray.VertexPositionTextureWrapper[iCount + 1].Position, form.Thing2DSelection[0].vertexPositionTextureArray.VertexPositionTextureWrapper[(iCount + 2)].Position, new Color(255, 0, 0), 1)).Draw(this);
                        (new Line(form.Thing2DSelection[0].vertexPositionTextureArray.VertexPositionTextureWrapper[iCount + 2].Position, form.Thing2DSelection[0].vertexPositionTextureArray.VertexPositionTextureWrapper[iCount].Position, new Color(255, 0, 0), 1)).Draw(this);
                    }
                }
            }



            form.manipulationTool.Draw(this);

            form.selectionTool.SelectionBox.Draw(this);

            gameInput.mouseBC.Draw(this);   //Good for Debugging where the game things the mouse is in Screen Coordinates

            //Game.DrawText(this.XnaWindow);



        }
    }
}
