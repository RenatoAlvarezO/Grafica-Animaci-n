using System;
using System.Collections.Generic;
using System.Text.Json.Serialization;
using OpenTK;

namespace Animacion
{
    public class Stage : IObject
    {
        private Dictionary<string, Object3D> ListOfObject3Ds;

        public Vertex Center;

        public Matrix3 Rotation { get; set; }

        public Matrix3 Scaling { get; set; }

        public Stage(Dictionary<string, Object3D> ListOfObject3Ds, Vertex center)
        {
            this.ListOfObject3Ds = ListOfObject3Ds;
            Center = center;
            SetCenter(Center);
        }

        public Stage(Vertex center)
        {
            ListOfObject3Ds = new Dictionary<string, Object3D>();
            Center = center;
        }

        public void SetCenter(Vertex center)
        {
            Center = center;
            foreach (var object3D in ListOfObject3Ds)
            {
                Vertex formerCenter = object3D.Value.GetCenter();
                object3D.Value.SetCenter(Center + formerCenter);
            }
        }

        public Vertex GetCenter()
        {
            return Center;
        }

        public Dictionary<string, Object3D> GetObjects()
        {
            return ListOfObject3Ds;
        }

        public Object3D GetObject3D(string key)
        {
            return ListOfObject3Ds[key];
        }

        public void Draw()
        {
            foreach (var object3D in ListOfObject3Ds)
                object3D.Value.Draw();
        }

        public void Rotate(float angleX, float angleY, float angleZ)
        {
            foreach (var object3D in ListOfObject3Ds)
            {
                object3D.Value.Rotate(angleX, angleY, angleZ);
            }
        }

        public void SetRotation(float angleX, float angleY, float angleZ)
        {
            foreach (var object3D in ListOfObject3Ds)
            {
                object3D.Value.SetRotation(angleX, angleY, angleZ);
            }
        }

        public void Traslate(float x, float y, float z)
        {
            foreach (var object3D in ListOfObject3Ds)
                object3D.Value.Traslate(x, y, z);
        }

        public void Traslate(Vertex position)
        {
            foreach (var object3D in ListOfObject3Ds)
                object3D.Value.Traslate(position);
        }

        public void SetTraslation(float x, float y, float z)
        {
            foreach (var object3D in ListOfObject3Ds)
                object3D.Value.SetTraslation(x, y, z);
        }

        public void SetTraslation(Vertex position)
        {
            foreach (var object3D in ListOfObject3Ds)
                object3D.Value.SetTraslation(position);
        }

        public void Scale(float x, float y, float z)
        {
            foreach (var object3D in ListOfObject3Ds)
                object3D.Value.Scale(x, y, z);
        }

        public void Scale(Vertex position)
        {
            foreach (var object3D in ListOfObject3Ds)
                object3D.Value.Scale(position);
        }

        public void SetScale(float x, float y, float z)
        {
            foreach (var object3D in ListOfObject3Ds)
                object3D.Value.SetScale(x, y, z);
        }

        public void SetScale(Vertex position)
        {
            foreach (var object3D in ListOfObject3Ds)
                object3D.Value.SetScale(position);
        }

        public void Add(string key, Object3D object3D)
        {
            object3D.SetCenter(object3D.GetCenter() + Center);
            ListOfObject3Ds.Add(key, object3D);
        }

        public void Delete(string key)
        {
            ListOfObject3Ds.Remove(key);
        }

        public void SetTextureType(int value)
        {
            foreach (var object3D in ListOfObject3Ds)
                object3D.Value.SetTextureType(value);
        }
    }
}