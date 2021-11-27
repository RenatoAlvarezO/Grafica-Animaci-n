using System;
using System.Text.Json;
using System.Text.Json.Serialization;

namespace Animacion
{
    public class ActorJSONConverter : JsonConverter<IObject>
    {
        public override IObject? Read(ref Utf8JsonReader reader, Type typeToConvert, JsonSerializerOptions options)
        {
            String objectType = "";

            var originalDepth = reader.CurrentDepth;
            if (reader.TokenType != JsonTokenType.StartObject)
                throw new JsonException();


            // Console.WriteLine(reader.);
            // Get the key.
            // while (originalDepth == reader.CurrentDepth)
            // {
            //     reader.Read();
            //     if (reader.GetString() == "Object3D")
            //         return new Object3D();
            // }

            // var returnObject;
            
            while (reader.Read())
            {
                string propertyName = reader.GetString();
                // if 

            }
            
            if (reader.TokenType != JsonTokenType.PropertyName)
            {
                throw new JsonException();
            }

            Console.WriteLine(reader.TokenType);


            if (reader.TokenType == JsonTokenType.EndObject)
            {
                return null;
            }

            return null;
        }

        public override void Write(Utf8JsonWriter writer, IObject value, JsonSerializerOptions options)
        {
            writer.WriteStartObject();
            if (value.GetType().ToString() == "Animacion.Object3D")
            {
                writer.WritePropertyName("Object3D");
                Object3D object3D = (Object3D) value;
                JsonSerializer.Serialize(writer, object3D, options);
            }

            writer.WriteEndObject();
        }
    }
}