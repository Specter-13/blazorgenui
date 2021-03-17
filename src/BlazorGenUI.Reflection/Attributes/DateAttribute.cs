using System;
using System.Collections.Generic;
using System.Text;
using BlazorGenUI.Reflection.Enums;

namespace BlazorGenUI.Reflection.Attributes
{
    [System.AttributeUsage(System.AttributeTargets.Property)]
    public class DateAttribute : System.Attribute
    {
        private DateTypes _dateType;
        public DateAttribute(DateTypes dateType)
        {
            this._dateType = dateType;
        }
        public DateTypes GetDateType()
        {
            return _dateType;
        }
    }
}
    