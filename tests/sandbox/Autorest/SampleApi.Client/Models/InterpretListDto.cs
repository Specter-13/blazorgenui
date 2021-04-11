// <auto-generated>
// Code generated by Microsoft (R) AutoRest Code Generator.
// Changes may cause incorrect behavior and will be lost if the code is
// regenerated.
// </auto-generated>

namespace SampleApi.Client.Models
{
    using Newtonsoft.Json;
    using System.Linq;

    public partial class InterpretListDto : EntityBase
    {
        /// <summary>
        /// Initializes a new instance of the InterpretListDto class.
        /// </summary>
        public InterpretListDto()
        {
            CustomInit();
        }

        /// <summary>
        /// Initializes a new instance of the InterpretListDto class.
        /// </summary>
        public InterpretListDto(string id = default(string), string name = default(string), string logoUri = default(string), double? rating = default(double?), int? genre = default(int?))
            : base(id)
        {
            Name = name;
            LogoUri = logoUri;
            Rating = rating;
            Genre = genre;
            CustomInit();
        }

        /// <summary>
        /// An initialization method that performs custom operations like setting defaults
        /// </summary>
        partial void CustomInit();

        /// <summary>
        /// </summary>
        [JsonProperty(PropertyName = "name")]
        public string Name { get; set; }

        /// <summary>
        /// </summary>
        [JsonProperty(PropertyName = "logoUri")]
        public string LogoUri { get; set; }

        /// <summary>
        /// </summary>
        [JsonProperty(PropertyName = "rating")]
        public double? Rating { get; set; }

        /// <summary>
        /// </summary>
        [JsonProperty(PropertyName = "genre")]
        public int? Genre { get; set; }

    }
}