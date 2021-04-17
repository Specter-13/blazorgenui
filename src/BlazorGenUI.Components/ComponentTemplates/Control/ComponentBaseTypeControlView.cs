using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Text;
using System.Threading.Tasks;
using BlazorGenUI.Reflection;
using BlazorGenUI.Reflection.ValueElementTypes;
using Fasterflect;
using Microsoft.AspNetCore.Components;

namespace BlazorGenUI.Components.ComponentTemplates.Control
{
    public partial class ComponentBaseTypeControlView<T>
    {
        [Parameter]
        public ValueElementT<T> ValueElement { get; set; }

        private bool IsNumeric(Type type)
        {
            if (type == null) return false;
            // from http://stackoverflow.com/a/5182747/172132
            switch (Type.GetTypeCode(type))
            {
                case TypeCode.Byte:
                case TypeCode.Decimal:
                case TypeCode.Double:
                case TypeCode.Int16:
                case TypeCode.Int32:
                case TypeCode.Int64:
                case TypeCode.SByte:
                case TypeCode.Single:
                case TypeCode.UInt16:
                case TypeCode.UInt32:
                case TypeCode.UInt64:
                    return true;
            }
            return false;
        }
    }
}
