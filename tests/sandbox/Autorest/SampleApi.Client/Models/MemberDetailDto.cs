// <auto-generated>
// Code generated by Microsoft (R) AutoRest Code Generator.
// Changes may cause incorrect behavior and will be lost if the code is
// regenerated.
// </auto-generated>

namespace SampleApi.Client.Models
{
    using Newtonsoft.Json;
    using System.Linq;

    public partial class MemberDetailDto : EntityBase
    {
        /// <summary>
        /// Initializes a new instance of the MemberDetailDto class.
        /// </summary>
        public MemberDetailDto()
        {
            CustomInit();
        }

        /// <summary>
        /// Initializes a new instance of the MemberDetailDto class.
        /// </summary>
        public MemberDetailDto(string id = default(string), string name = default(string), string surname = default(string))
            : base(id)
        {
            Name = name;
            Surname = surname;
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
        [JsonProperty(PropertyName = "surname")]
        public string Surname { get; set; }

    }
}