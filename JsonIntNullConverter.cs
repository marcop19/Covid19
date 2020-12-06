using System;
using System.Text.Json;
using System.Text.Json.Serialization;

    public class IntNullConvert : JsonConverter<int>
    {
      public override int Read(ref Utf8JsonReader reader, Type typeToConvert,JsonSerializerOptions options)
      {
        if (reader.TokenType == JsonTokenType.Null)
          {
            return 0;
          }
        Int32.TryParse(reader.GetDouble().ToString(), out int value);  
        return value;
      }
      public override void Write(Utf8JsonWriter writer, int value, JsonSerializerOptions options)
       {
         writer.WriteNumberValue(value);
       }
    }