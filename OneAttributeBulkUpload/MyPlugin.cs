using System;
using System.ComponentModel.Composition;
using System.IO;
using System.Linq;
using System.Collections.Generic;
using System.Reflection;
using XrmToolBox.Extensibility;
using XrmToolBox.Extensibility.Interfaces;

namespace OneAttributeBulkUpload
{
    // Do not forget to update version number and author (company attribute) in AssemblyInfo.cs class
    // To generate Base64 string for Images below, you can use https://www.base64-image.de/
    [Export(typeof(IXrmToolBoxPlugin)),
        ExportMetadata("Name", "One Attribute Bulk Upload"),
        ExportMetadata("Description", "Process bulk upload of an attrbiute of entity"),
        // Please specify the base64 content of a 32x32 pixels image
        ExportMetadata("SmallImageBase64", "iVBORw0KGgoAAAANSUhEUgAAACAAAAAgCAYAAABzenr0AAACbElEQVR4nN2XTUgVURTHf+fOPJ+fTy3SxBYhpWZgkCBuiqhdEAQt2gZtWwVCq2ghEm5yk5tqk4tahW0NImjXF0qrCglbZFoWqIk63nNavDBffrxm3nsJ/mEYZph7zm/u/Z/7IWZm7KDcTibfTQDJR7FggGj2Kysf3hH9XEjUPkya2PuIpZFhFu/cgyhCMnVU3bxFRdvRWHES9YCuzrMydoXFu0MQRQDY3A8WBwdQH5USwPDLU6yOnUUmHsLK+uaCffmM91oaAEOJ5sfRVyeRuRegG433PtOOuaC4AIah5vEzj7HXZ5DlTwgbfT+RaWXwyDVAYgHkNaGax38cQCb7cfb3+Aom8LzhNLdbr5IOymMl/ycA+/4UJvsQ8xvhnOP+wUuMNF9ExREmmA7yl+HsE9wmyZfCGm50XOdNfQ8gYLaZLfIqvweqO3M+M0Ar2pg5PsrLuh68ObwJ3kATzIh5AcLGC+iecygpvITY3vO4rme4qsOoCqqGqmbvPmvaOMo7BBJUkjr2AJanMBGkbD8iDiNildyaj0SQYlcBgEgA5QdyQ5vhVbF1L71uVqBFANiCCrXcvzUTLF4HFACAohhisvbTFjc7BSzHLj1NWdMjvPnfVZC94nZB8v2ACOUNo1S2DGHBAoqVpgy3h1BSmbdk2vuR1DTq/zcAIDiC9DfqOvpIZcaBEi3H28oc4iJqW4aRmD5MDCCWTfxn+Y1fAQUBBBIg65oLRujih0sM0FTdQFNV49qzAd37OgmLvSPaSukgxeCJXjrqD1GbruFUcze9XZdxEi+kFHo29KZ47wmcELj4E2vBAIVqt5wNk+sXt+Pt4zaahuQAAAAASUVORK5CYII="),
        // Please specify the base64 content of a 80x80 pixels image
        ExportMetadata("BigImageBase64", "/9j/4AAQSkZJRgABAQEASABIAAD/2wBDAAgGBgcGBQgHBwcJCQgKDBQNDAsLDBkSEw8UHRofHh0aHBwgJC4nICIsIxwcKDcpLDAxNDQ0Hyc5PTgyPC4zNDL/2wBDAQkJCQwLDBgNDRgyIRwhMjIyMjIyMjIyMjIyMjIyMjIyMjIyMjIyMjIyMjIyMjIyMjIyMjIyMjIyMjIyMjIyMjL/wAARCABQAFADASIAAhEBAxEB/8QAHwAAAQUBAQEBAQEAAAAAAAAAAAECAwQFBgcICQoL/8QAtRAAAgEDAwIEAwUFBAQAAAF9AQIDAAQRBRIhMUEGE1FhByJxFDKBkaEII0KxwRVS0fAkM2JyggkKFhcYGRolJicoKSo0NTY3ODk6Q0RFRkdISUpTVFVWV1hZWmNkZWZnaGlqc3R1dnd4eXqDhIWGh4iJipKTlJWWl5iZmqKjpKWmp6ipqrKztLW2t7i5usLDxMXGx8jJytLT1NXW19jZ2uHi4+Tl5ufo6erx8vP09fb3+Pn6/8QAHwEAAwEBAQEBAQEBAQAAAAAAAAECAwQFBgcICQoL/8QAtREAAgECBAQDBAcFBAQAAQJ3AAECAxEEBSExBhJBUQdhcRMiMoEIFEKRobHBCSMzUvAVYnLRChYkNOEl8RcYGRomJygpKjU2Nzg5OkNERUZHSElKU1RVVldYWVpjZGVmZ2hpanN0dXZ3eHl6goOEhYaHiImKkpOUlZaXmJmaoqOkpaanqKmqsrO0tba3uLm6wsPExcbHyMnK0tPU1dbX2Nna4uPk5ebn6Onq8vP09fb3+Pn6/9oADAMBAAIRAxEAPwD3+iiigAooooAKK5/xN4pt/D1rnaJrl+Eizj8T7VyGnfEy8F4g1C2gNuxwxiBDKPXk81hLE0oy5bnfQy3E16ftYR0/P0PT6KajrIiuhBVhkEdxTq3OAKKKKACiiigArD1XXVg3QWpDSdC/Zf8A69O8RXklvbRxRMVMpOSPQVytfL53nE6MnhqOj6v17f5npYPCKa9pPbsc34tdnktmdizHcST36VzeM8V0nioHdanHB3c/lXPZAHFerwzk9XG4eFSekNder16f5noY7PqOX4dU4e9U7dF5v/L8ke+aPxotj/17x/8AoIq7VLR/+QLY/wDXvH/6CKu16s0lJpHzik5Lme7CiiipGFFFFAFLUtPTUbcRs21lOVb0rHg8MSeaDPMpjHUJnJrpaK8/EZXhcTVVWrG7/P17m9PE1aceWL0PM/ibFHbDS44lCoFkwB/wGvPi/Feh/Fb/AFmmHtiT/wBlrzctxX32UqKwkFHpf8z5fHSf1iV/60PoTRv+QJYf9e8f/oIq9VHRf+QHYf8AXvH/AOgir1fKVPjfq/zZ78PhQUUUVBQUUUUAFFFFAHnfxOAL6cD0xJ/7LXms0BUFk5Hcelel/E4HfppxxiT/ANlrz89Kmhj62DruVN6dV0f9dz5zHfx5f10PdNE/5AWn/wDXtH/6CKv1S0gY0ayGMfuE/wDQRV2rcuZuXc+hh8K9AooopFBRRRQAUUUUAZPiDQYNf0/7PKxjkQ7o5AM7T/hXJaf8NpEvVe+vI3gU52Rqcv7HPSvQ6KiVOMndo56mFpVJc8lqIqhVCqMADAApaKKs6AooooA//9k="),
        ExportMetadata("BackgroundColor", "Lavender"),
        ExportMetadata("PrimaryFontColor", "Black"),
        ExportMetadata("SecondaryFontColor", "Gray")]
    public class MyPlugin : PluginBase
    {
        public override IXrmToolBoxPluginControl GetControl()
        {
            return new MyPluginControl();
        }

        /// <summary>
        /// Constructor 
        /// </summary>
        public MyPlugin()
        {
            // If you have external assemblies that you need to load, uncomment the following to 
            // hook into the event that will fire when an Assembly fails to resolve
            // AppDomain.CurrentDomain.AssemblyResolve += new ResolveEventHandler(AssemblyResolveEventHandler);
        }

        /// <summary>
        /// Event fired by CLR when an assembly reference fails to load
        /// Assumes that related assemblies will be loaded from a subfolder named the same as the Plugin
        /// For example, a folder named Sample.XrmToolBox.MyPlugin 
        /// </summary>
        /// <param name="sender"></param>
        /// <param name="args"></param>
        /// <returns></returns>
        private Assembly AssemblyResolveEventHandler(object sender, ResolveEventArgs args)
        {
            Assembly loadAssembly = null;
            Assembly currAssembly = Assembly.GetExecutingAssembly();

            // base name of the assembly that failed to resolve
            var argName = args.Name.Substring(0, args.Name.IndexOf(","));

            // check to see if the failing assembly is one that we reference.
            List<AssemblyName> refAssemblies = currAssembly.GetReferencedAssemblies().ToList();
            var refAssembly = refAssemblies.Where(a => a.Name == argName).FirstOrDefault();

            // if the current unresolved assembly is referenced by our plugin, attempt to load
            if (refAssembly != null)
            {
                // load from the path to this plugin assembly, not host executable
                string dir = Path.GetDirectoryName(currAssembly.Location).ToLower();
                string folder = Path.GetFileNameWithoutExtension(currAssembly.Location);
                dir = Path.Combine(dir, folder);

                var assmbPath = Path.Combine(dir, $"{argName}.dll");

                if (File.Exists(assmbPath))
                {
                    loadAssembly = Assembly.LoadFrom(assmbPath);
                }
                else
                {
                    throw new FileNotFoundException($"Unable to locate dependency: {assmbPath}");
                }
            }

            return loadAssembly;
        }
    }
}