// <auto-generated>
// Code generated by Microsoft (R) AutoRest Code Generator.
// Changes may cause incorrect behavior and will be lost if the code is
// regenerated.
// </auto-generated>

namespace SampleApi.Client.Models
{
    using Newtonsoft.Json;
    using System.Linq;

    public partial class FestivalListDto
    {
        /// <summary>
        /// Initializes a new instance of the FestivalListDto class.
        /// </summary>
        public FestivalListDto()
        {
            CustomInit();
        }

        /// <summary>
        /// Initializes a new instance of the FestivalListDto class.
        /// </summary>
        public FestivalListDto(string name = default(string), int? genre = default(int?), string country = default(string), string logoUri = default(string), string city = default(string), bool? isFestival = default(bool?), System.DateTimeOffset? date = default(System.DateTimeOffset?))
        {
            Name = name;
            Genre = genre;
            Country = country;
            LogoUri = logoUri;
            City = city;
            IsFestival = isFestival;
            Date = date;
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
        [JsonProperty(PropertyName = "genre")]
        public int? Genre { get; set; }

        /// <summary>
        /// </summary>
        [JsonProperty(PropertyName = "country")]
        public string Country { get; set; }

        /// <summary>
        /// </summary>
        [JsonProperty(PropertyName = "logoUri")]
        public string LogoUri { get; set; }

        /// <summary>
        /// </summary>
        [JsonProperty(PropertyName = "city")]
        public string City { get; set; }

        /// <summary>
        /// </summary>
        [JsonProperty(PropertyName = "isFestival")]
        public bool? IsFestival { get; set; }

        /// <summary>
        /// </summary>
        [JsonProperty(PropertyName = "date")]
        public System.DateTimeOffset? Date { get; set; }

    }
}