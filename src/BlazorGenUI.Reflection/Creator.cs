using System;
using System.Collections;
using System.Collections.Generic;
using System.ComponentModel;
using System.Linq;
using System.Text.RegularExpressions;
using BlazorGenUI.Reflection.Attributes;
using BlazorGenUI.Reflection.Enums;
using BlazorGenUI.Reflection.Interfaces;
using BlazorGenUI.Reflection.ValueElementTypes;
using Fasterflect;

namespace BlazorGenUI.Reflection
{
    public class Creator
    {
        private List<object> _attributeList { get; set; }
        private string _pictureFields { get; }
        public Creator(List<object> attributeList , string pictureFields)
        {
            _attributeList = attributeList;
            _pictureFields = pictureFields;
        }
       


    }
}