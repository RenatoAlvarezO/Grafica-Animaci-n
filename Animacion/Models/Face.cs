using System;
using System.Drawing;
using System.Collections.Generic;
using Avalonia;
using OpenTK;
using OpenTK.Graphics.OpenGL;

namespace Animacion
{
    public class Face : IObject
    {
        public Dictionary<string, Vertex> ListOfVertices { get; set; }
        public int FaceColor { get; set; }
        public Vertex Center { get; set; }

        public Vertex Translation { get; set; }

        public Matrix3 Rotation ;

        public Matrix3 Scaling ;

        public int TextureType;

        public Face(Dictionary<string, Vertex> listOfVertices, int faceColor, Vertex center)
        {
            ListOfVertices = listOfVertices;
            FaceColor = faceColor;
            Center = center;
            Translation = new Vertex(0, 0, 0);
            Rotation = Matrix3.Identity;
            Scaling = Matrix3.Identity;

            TextureType = 2;
        }

        public void Draw()
        {
            Color drawingColor = Color.FromArgb(FaceColor);
            GL.Color4(drawingColor);
            GL.Begin((PrimitiveType) TextureType);
            foreach (var vertex in ListOfVertices)
            {
                Vertex vertexToRender = vertex.Value * Rotation * Scaling;
                vertexToRender += Center + Translation;
                GL.Vertex3(vertexToRender);
            }

            GL.End();
            GL.Flush();
        }


        public void Rotate(float angleX, float angleY, float angleZ)
        {
            angleX = MathHelper.DegreesToRadians(angleX);
            angleY = MathHelper.DegreesToRadians(angleY);
            angleZ = MathHelper.DegreesToRadians(angleZ);

            Rotation *= Matrix3.CreateRotationX(angleX) * Matrix3.CreateRotationY(angleY) *
                        Matrix3.CreateRotationZ(angleZ);
        }

        public void Traslate(float x, float y, float z)
        {
            Translation += new Vertex(x, y, z);
        }

        public void Traslate(Vertex position)
        {
            Translation += position;
        }

        public void Scale(float x, float y, float z)
        {
            Scaling *= Matrix3.CreateScale(x, y, z);
        }

        public void Scale(Vertex scale)
        {
            Scaling *= Matrix3.CreateScale(scale);
        }

        public void SetRotation(float angleX, float angleY, float angleZ)
        {
            angleX = MathHelper.DegreesToRadians(angleX);
            angleY = MathHelper.DegreesToRadians(angleY);
            angleZ = MathHelper.DegreesToRadians(angleZ);
            Rotation = Matrix3.CreateRotationX(angleX) * Matrix3.CreateRotationY(angleY) *
                       Matrix3.CreateRotationZ(angleZ);
        }

        public void SetTraslation(float x, float y, float z)
        {
            Translation = new Vertex(x, y, z);
        }

        public void SetTraslation(Vertex position)
        {
            Translation = position;
        }

        public void SetScale(float x, float y, float z)
        {
            Scaling = Matrix3.CreateScale(x, y, z);
        }

        public void SetScale(Vertex scale)
        {
            Scaling = Matrix3.CreateScale(scale);
        }

        public void ResetRotation()
        {
            Rotation = Matrix3.Identity;
        }

        public void ResetScale()
        {
            Scaling = Matrix3.Identity;
        }

        public void ResetTraslation()
        {
            Translation = new Vertex(0, 0, 0);
        }

        public void SetTextureType(int value)
        {
            TextureType = value;
        }
    }
}