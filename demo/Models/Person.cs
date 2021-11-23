using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using BlazorGenUI.Reflection.Attributes;
namespace BlazorGenUIDemo.Models
{

    public class Person
    {
        public string Name { get; set; }
        public string Surname { get; set; }
        public Gender Gender { get; set; }
        public int Age { get; set; }
        public string City { get; set; }
        public DateTime Born { get; set; }
        public string AvatarUri { get; set; }


    }

}
