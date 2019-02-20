using System;
using System.IO;
using System.Linq;
using System.Windows;
using System.Windows.Forms.Integration;

namespace BeamToolHost
{
    /// <summary>
    /// Interaction logic for MainWindow.xaml
    /// </summary>
    public partial class MainWindow : Window
    {
        public MainWindow()
        {
            InitializeComponent();
            DataContext = new MainWindowViewModel();

            theHost.PropertyMap.Add("ShowToolBar", new PropertyTranslator(OnShowToolBarChanged));
            theHost.PropertyMap.Add("WorkspaceXml", new PropertyTranslator(OnWorkspaceXmlChanged));
            theHost.PropertyMap.Add("WorkspaceFileInfo", new PropertyTranslator(OnWorkspaceFileInfoChanged));

        }

        #region Code Behind Handlers
        private void ShowToolsButtonClick(object sender, RoutedEventArgs e)
        {
            theHost.ShowToolBar = !theHost.ShowToolBar;
        }

        private async void OpenXmlWorkspaceButtonClick(object sender, RoutedEventArgs e)
        {
            using (StreamReader reader = new StreamReader("Sample.ebwk"))
            {
                string xml = await reader.ReadToEndAsync();

            }
        }

        private void OpenFileInfoWorkspaceButtonClick(object sender, RoutedEventArgs e)
        {
            FileInfo info = new FileInfo("Sample.ebwk");
        }

        private void GetWorkspaceXmlButtonClick(object sender, RoutedEventArgs e)
        {

        }

        #endregion

        #region Property Map Handlers

        private void OnShowToolBarChanged(object host, string propertyName, object value)
        {
            BeamToolWindowsFormsHost theHost = host as BeamToolWindowsFormsHost;


        }

        private void OnWorkspaceXmlChanged(object host, string propertyName, object workspaceXml)
        {
            BeamToolWindowsFormsHost theHost = host as BeamToolWindowsFormsHost;

        }

        private void OnWorkspaceFileInfoChanged(object host, string propertyName, object fileInfo)
        {
            BeamToolWindowsFormsHost theHost = host as BeamToolWindowsFormsHost;

        }
        #endregion
    }
}
