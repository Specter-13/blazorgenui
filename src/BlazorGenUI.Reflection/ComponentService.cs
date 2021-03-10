using System;
using System.Collections.Generic;
using System.Linq;
using System.Reflection;
using System.Text;
using BlazorGenUI.Reflection.Interfaces;

namespace BlazorGenUI.Reflection
{
    public class ComponentService 
    {

        private string _assemblyName = "BlazorGenUI.Components";
        public IEnumerable<Type> Components { get; private set; }
        public IRenderableComponent GetComponent(string name)
        {
            var foundedType = Components.FirstOrDefault(x => String.Equals(x.Name, name, StringComparison.CurrentCultureIgnoreCase));

            if (foundedType != null)
            {
                return (IRenderableComponent)Activator.CreateInstance(foundedType);
            }
            else return null;
        }

        public IRenderableComponent GetGenericComponent(string name, Type typeArg)
        {
            var foundedType = Components.FirstOrDefault(x => String.Equals(x.Name, name, StringComparison.CurrentCultureIgnoreCase));
            if (foundedType != null)
            {
                Type genericType = foundedType.MakeGenericType(typeArg);
                return (IRenderableComponent)Activator.CreateInstance(genericType);
            }
            else return null;
        }

        public void LoadComponents(string path)
        {
            var ass = Assembly.Load(_assemblyName);
            var components = new List<Type>();

            var types = GetTypesWithInterface(ass);
            foreach (var typ in types)
            {
                components.Add(typ);
            }

            Components = components;
        }


        private IEnumerable<Type> GetTypesWithInterface(Assembly asm)
        {
            return GetLoadableTypes(asm).Where(typeof(IRenderableComponent).IsAssignableFrom).ToList();
        }

        private IEnumerable<Type> GetLoadableTypes(Assembly assembly)
        {
            if (assembly == null) throw new ArgumentNullException("assembly");
            try
            {
                return assembly.GetTypes();
            }
            catch (ReflectionTypeLoadException e)
            {
                return e.Types.Where(t => t != null);
            }
        }
    }
}
