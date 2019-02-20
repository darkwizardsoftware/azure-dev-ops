using System;
using System.Collections.Generic;
using System.Configuration;
using System.Data;
using System.Diagnostics;
using System.Linq;
using System.Reflection;
using System.Threading.Tasks;
using System.Windows;

namespace BeamToolHost
{
    /// <summary>
    /// Interaction logic for App.xaml
    /// </summary>
    public partial class App : Application
    {
        private List<string> deps = new List<string>();
        string beamToolInstallLocation = @"C:\Program Files (x86)\Eclipse Scientific\ESBeamTool9\";

        protected override void OnStartup(StartupEventArgs e)
        {
            System.Windows.Forms.Application.EnableVisualStyles();
            base.OnStartup(e);
            ConfigureDependencyList();
            AppDomain.CurrentDomain.AssemblyResolve += ResolveBeamTool;
            MainWindow window = new MainWindow();
            MainWindow = window;
            window.Show();
        }

        private void ConfigureDependencyList()
        {
            // this is the list of files for which we
            // interested in providing runtime assembly
            // resolution
            deps.Add("BeamTool");
            deps.Add("Newtonsoft.Json");
        }

        private Assembly ResolveBeamTool(object sender, ResolveEventArgs args)
        {
            Assembly targetAssembly = null;
            string targetAssemblyPath = string.Empty;
            string targetAssemblyName = string.Empty;
            string extension = string.Empty;

            if (args.Name.Contains(","))
            {
                targetAssemblyName = args.Name.Substring(0, args.Name.IndexOf(","));
            }
            else
            {
                targetAssemblyName = args.Name;
            }

            // only try and load BeamTool assemblies
            if (deps.Contains(targetAssemblyName))
            {
                if(targetAssemblyName == "BeamTool")
                {
                    extension = ".exe";
                }
                else
                {
                    extension = ".dll";
                }
                
                //Build the path of the assembly from where it has to be loaded.
                targetAssemblyPath = $@"{beamToolInstallLocation}{targetAssemblyName}{extension}";
                Debug.WriteLine(targetAssemblyPath);

                //Load the assembly from the specified path.
                try
                {
                    // try loading the exe or dll
                    targetAssembly = Assembly.LoadFrom(targetAssemblyPath);
                }
                catch
                {
                    // if loading fails then it might be an extension-less
                    // file so try that
                    try
                    {
                        targetAssemblyPath = $@"{beamToolInstallLocation}{targetAssemblyName}";
                        targetAssembly = Assembly.LoadFrom(targetAssemblyPath);
                    }
                    catch
                    {
                        // if that fails do nothing and let the 
                        // resolution pass up to the next handler
                    }

                }
            }
            //Return the loaded assembly.
            return targetAssembly;
        }
    }
}

