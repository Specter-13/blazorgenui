using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using BlazorGenUI.Reflection.Attributes;
using BlazorGenUI.Reflection.Enums;
namespace BlazorGenUIDemo.Models
{
    [Container(LayoutTypes.Grid2)]
    public class PersonAttributes
    {
        
        public string Name { get; set;}
        public string Surname { get; set;}
        [RadioButtonsEnum]
        public Gender Gender {get; set;}
        public int Age { get; set;}
        [AttributeName("Home city")]
        public string City { get; set;}
        [AttributeName("Date of birth")]
        public DateTime Born { get; set;}
        [RenderIgnore]
        public string AvatarUri { get; set;}

        
    }
}
