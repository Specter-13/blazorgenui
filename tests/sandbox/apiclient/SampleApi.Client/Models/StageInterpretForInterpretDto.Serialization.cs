// Copyright (c) Microsoft Corporation. All rights reserved.
// Licensed under the MIT License.

// <auto-generated/>

#nullable disable

using System.Text.Json;
using Azure.Core;

namespace SampleApi.Client.Models
{
    public partial class StageInterpretForInterpretDto : IUtf8JsonSerializable
    {
        void IUtf8JsonSerializable.Write(Utf8JsonWriter writer)
        {
            writer.WriteStartObject();
            if (Optional.IsDefined(Stage))
            {
                if (Stage != null)
                {
                    writer.WritePropertyName("stage");
                    writer.WriteObjectValue(Stage);
                }
                else
                {
                    writer.WriteNull("stage");
                }
            }
            if (Optional.IsDefined(StageId))
            {
                writer.WritePropertyName("stageId");
                writer.WriteStringValue(StageId);
            }
            if (Optional.IsDefined(ConcertLength))
            {
                writer.WritePropertyName("concertLength");
                writer.WriteNumberValue(ConcertLength.Value);
            }
            if (Optional.IsDefined(ConcertStart))
            {
                writer.WritePropertyName("concertStart");
                writer.WriteStringValue(ConcertStart.Value, "O");
            }
            if (Optional.IsDefined(ConcertEnd))
            {
                writer.WritePropertyName("concertEnd");
                writer.WriteStringValue(ConcertEnd.Value, "O");
            }
            writer.WriteEndObject();
        }
    }
}
