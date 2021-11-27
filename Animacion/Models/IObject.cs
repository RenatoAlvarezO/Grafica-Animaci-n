using System.Text.Json.Serialization;

namespace Animacion
{
    public interface IObject
    {
        
        void Rotate(float angleX, float angleY, float angleZ);
        void Traslate(float angleX, float angleY, float angleZ);
        void Traslate(Vertex position);
        void Scale(float angleX, float angleY, float angleZ);
        void Scale(Vertex position);
    }
}