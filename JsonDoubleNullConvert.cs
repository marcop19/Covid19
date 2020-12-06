using System;
using System.Text.Json;
using System.Text.Json.Serialization;

    public class DoubleNullConvert : JsonConverter<double>
    {
      public override double Read(ref Utf8JsonReader reader, Type typeToConvert,JsonSerializerOptions options)
      {
        if (reader.TokenType == JsonTokenType.Null)
          {
            return 0;
          }
        return reader.GetDouble();
      }
      public override void Write(Utf8JsonWriter writer, double value, JsonSerializerOptions options)
       {
         writer.WriteNumberValue(value);
       }
    }