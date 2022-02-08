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
        ExportMetadata("SmallImageBase64", "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"),
        // Please specify the base64 content of a 80x80 pixels image
        ExportMetadata("BigImageBase64", "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"),
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