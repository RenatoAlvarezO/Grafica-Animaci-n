using System;
using System.Collections.Generic;
using System.Drawing;
using System.Globalization;
using System.IO;
using System.Text.Json;
using System.Text.Json.Serialization;
using OpenTK;

namespace Animacion
{
    public class Object3D : IObject
    {
        public Dictionary<string, Face> ListOfFaces { get; set; }

        public Vertex Center { get; set; }

        public Object3D(Dictionary<string, Face> listOfFaces, Vertex center)
        {
            ListOfFaces = listOfFaces;
            Center = center;
            SetCenter(center);
        }

        public Object3D()
        {
            ListOfFaces = new Dictionary<string, Face>();
            Center = Vertex.Origin;
            SetCenter(Vertex.Origin);
        }

        public void SetCenter(Vertex newCenter)
        {
            Center = newCenter;
            foreach (var face in ListOfFaces)
                face.Value.Center = Center;
        }

        public Vertex GetCenter()
        {
            return Center;
        }

        public Face GetFace(string key)
        {
            return ListOfFaces[key];
        }

        public void Draw()
        {
            foreach (var face in ListOfFaces)
                face.Value.Draw();
        }

        public Dictionary<string, Face> getListOfFaces()
        {
            return ListOfFaces;
        }

        public void Rotate(float angleX, float angleY, float angleZ)
        {
            foreach (var face in ListOfFaces)
                face.Value.Rotate(angleX, angleY, angleZ);
        }

        public void SetRotation(float angleX, float angleY, float angleZ)
        {
            foreach (var face in ListOfFaces)
                face.Value.SetRotation(angleX, angleY, angleZ);
        }

        public void Traslate(float x, float y, float z)
        {
            foreach (var face in ListOfFaces)
                face.Value.Traslate(x, y, z);
        }

        public void Traslate(Vertex position)
        {
            foreach (var face in ListOfFaces)
                face.Value.Traslate(position);
        }

        public void SetTraslation(float x, float y, float z)
        {
            foreach (var face in ListOfFaces)
                face.Value.SetTraslation(x, y, z);
        }

        public void SetTraslation(Vertex position)
        {
            foreach (var face in ListOfFaces)
                face.Value.SetTraslation(position);
        }

        public void Scale(float x, float y, float z)
        {
            foreach (var face in ListOfFaces)
                face.Value.Scale(x, y, z);
        }

        public void Scale(Vertex position)
        {
            foreach (var face in ListOfFaces)
                face.Value.Scale(position);
        }

        public void SetScale(float x, float y, float z)
        {
            foreach (var face in ListOfFaces)
                face.Value.SetScale(x, y, z);
        }

        public void SetScale(Vertex position)
        {
            foreach (var face in ListOfFaces)
                face.Value.SetScale(position);
        }


        public void SetTextureType(int value)
        {
            foreach (var face in ListOfFaces)
                face.Value.SetTextureType(value);
        }


        public void SaveFile(string path)
        {
            JsonSerializerOptions options = new()
            {
                WriteIndented = true
            };

            string jsonOutput = JsonSerializer.Serialize(this, options);

            File.WriteAllText(path, jsonOutput);
        }

        public void LoadFromObj(string path, Vertex center)
        {
            List<Vertex> vertices = new List<Vertex>();


            List<Color> colors = new List<Color>();
            colors.Add(Color.Aqua);
            colors.Add(Color.Gold);
            colors.Add(Color.Fuchsia);
            colors.Add(Color.Red);
            colors.Add(Color.Navy);
            colors.Add(Color.Lime);
            colors.Add(Color.White);
            colors.Add(Color.Blue);


            Dictionary<string, Face> faces = new Dictionary<string, Face>();

            if (!File.Exists(path))
            {
                throw new FileNotFoundException("Unable to open \"" + path + "\", does not exist.");
            }

            using (StreamReader streamReader = new StreamReader(path))
            {
                int faceCounter = 0;
                while (!streamReader.EndOfStream)
                {
                    List<string> words = new List<string>(streamReader.ReadLine().ToLower().Split(' '));
                    words.RemoveAll(s => s == string.Empty);

                    if (words.Count == 0)
                        continue;

                    string type = words[0];
                    words.RemoveAt(0);

                    switch (type)
                    {
                        // vertex
                        case "v":
                            vertices.Add(new Vertex(float.Parse(words[0], CultureInfo.InvariantCulture),
                                float.Parse(words[1], CultureInfo.InvariantCulture),
                                float.Parse(words[2], CultureInfo.InvariantCulture)));
                            break;


                        // face
                        case "f":
                            Dictionary<string, Vertex> faceVertices = new Dictionary<string, Vertex>();
                            int key = 0;
                            foreach (string w in words)
                            {
                                if (w.Length == 0)
                                    continue;

                                string[] comps = w.Split('/');

                                // subtract 1: indices start from 1, not 0
                                int index = int.Parse(comps[0]) - 1;
                                faceVertices.Add(key.ToString(),
                                    new Vertex(vertices[index].X, vertices[index].Y, vertices[index].Z));

                                key++;
                            }

                            faces.Add(faceCounter.ToString(),
                                new Face(faceVertices, colors[faces.Count % colors.Count].ToArgb(), center));

                            break;
                    }

                    faceCounter++;
                }

                ListOfFaces = faces;
                Center = center;
                SetCenter(Center);
            }
        }

        public static Object3D LoadFromJson(string path)
        {
            string outputString = File.ReadAllText(path);
            return JsonSerializer.Deserialize<Object3D>(outputString);
        }
    }
}