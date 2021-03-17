// Copyright (c) Microsoft Corporation. All rights reserved.
// Licensed under the MIT License.

// <auto-generated/>

#nullable disable

using System.Collections.Generic;
using Azure.Core;

namespace SampleApi.Client.Models
{
    /// <summary> The StageForInterpretDto. </summary>
    internal partial class StageForInterpretDto
    {
        /// <summary> Initializes a new instance of StageForInterpretDto. </summary>
        internal StageForInterpretDto()
        {
            StageInterpret = new ChangeTrackingList<StageInterpretForInterpretDto>();
        }

        public string Name { get; }
        public int? Capacity { get; }
        public string FestivalName { get; }
        public IReadOnlyList<StageInterpretForInterpretDto> StageInterpret { get; }
    }
}
