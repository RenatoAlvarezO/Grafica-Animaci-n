using System;
using System.Text.Json.Serialization;
using OpenTK;

namespace Animacion
{
    public class Action
    {
        public IObject Actor { get; set; }

        public float xRotation { get; set; }
        public float yRotation { get; set; }
        public float zRotation { get; set; }
        public Vertex scaling { get; set; }
        public Vertex traslation { get; set; }

        public Action(IObject actor)
        {
            Actor = actor;
            xRotation = 0f;
            yRotation = 0f;
            zRotation = 0f;
            scaling = new Vertex();
            traslation = new Vertex();
        }

        public Action()
        {
            Actor = null;
            xRotation = 0f;
            yRotation = 0f;
            zRotation = 0f;
            scaling = new Vertex();
            traslation = new Vertex();
        }

        public void SetActor(IObject actor)
        {
            Actor = actor;
        }

        public void Rotate(float x, float y, float z)
        {
            xRotation = x;
            yRotation = y;
            zRotation = z;
        }

        public void Translate(Vertex newPosition)
        {
            traslation = newPosition;
        }

        public void Scale(Vertex newPosition)
        {
            scaling = newPosition;
        }

        public void Apply()
        {
            if (xRotation != 0f || yRotation != 0f || zRotation != 0f) Actor.Rotate(xRotation, yRotation, zRotation);
            if (scaling != Vertex.Origin) Actor.Scale(scaling);
            if (traslation != Vertex.Origin) Actor.Traslate(traslation);
        }
    }
}