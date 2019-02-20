using System;
using System.Collections.Generic;
using System.Diagnostics;
using System.IO;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Xml;
using ESBeamTool;

namespace BeamToolHost
{
    public class MainWindowViewModel : ViewModelBase
    {

        private DelegateCommand openFileInfoWorkspace;
        private string workspaceXml;
        private DelegateCommand openWorkspaceCommand;
        private string showToolBarButtonText;
        private bool showToolBar;
        private DelegateCommand showToolBarCommand;

        public MainWindowViewModel()
        {
            ConfigureCommands();

            ShowToolBarButtonText = "Show";
        }

        private void ConfigureCommands()
        {
            ShowToolBarCommand = new DelegateCommand(ShowToolBarCommandCanExectute, ShowToolBarCommandExectute);
            OpenXmlWorkspaceCommand = new DelegateCommand(OpenXmlWorkspaceCommandCanExectute, OpenXmlWorkspaceCommandExecute);
            OpenFileInfoWorkspaceCommand = new DelegateCommand(OpenFileInfoWorkspaceCommandCanExecute, OpenFileInfoWorkspaceCommandExectute);
            GetWorkspaceDocumentCommand = new DelegateCommand(GetWorkspaceDocumentCommandCanExecute, GetWorkspaceDocumentCommandExecute);
        }

        #region ShowToolBar

        public DelegateCommand ShowToolBarCommand
        {
            get
            {
                return showToolBarCommand;
            }
            set
            {
                showToolBarCommand = value;
                RaisePropertyChanged();
            }
        }

        private bool ShowToolBarCommandCanExectute(object parameter)
        {
            return true;
        }

        private void ShowToolBarCommandExectute(object parameter)
        {
            ShowToolBar = !ShowToolBar;
            ShowToolBarButtonText = ShowToolBar ? "Hide" : "Show";
        }

        public bool ShowToolBar
        {
            get { return showToolBar; }
            set
            {
                showToolBar = value;
                RaisePropertyChanged();
            }
        }

        public string ShowToolBarButtonText
        {
            get { return showToolBarButtonText; }
            set
            {
                showToolBarButtonText = value;
                RaisePropertyChanged();
            }
        }
        #endregion

        #region Open XML Workspace

        public DelegateCommand OpenXmlWorkspaceCommand
        {
            get { return openWorkspaceCommand; }
            set
            {
                openWorkspaceCommand = value;
                RaisePropertyChanged();
            }
        }

        private bool OpenXmlWorkspaceCommandCanExectute(object parameter)
        {
            return true;
        }

        private async void OpenXmlWorkspaceCommandExecute(object parameter)
        {
            using (StreamReader reader = new StreamReader("Sample.ebwk"))
            {
                string xml = await reader.ReadToEndAsync();
                WorkspaceXml = xml;
            }
        }

        public string WorkspaceXml
        {
            get
            {
                return workspaceXml;
            }
            set
            {
                workspaceXml = value;
                RaisePropertyChanged();
            }
        }

        #endregion

        #region Open FileInfo Workspace

        public DelegateCommand OpenFileInfoWorkspaceCommand
        {
            get { return openFileInfoWorkspace; }
            set
            {
                openFileInfoWorkspace = value;
                RaisePropertyChanged();
            }
        }

        private bool OpenFileInfoWorkspaceCommandCanExecute(object parameter)
        {
            return true;

        }

        private void OpenFileInfoWorkspaceCommandExectute(object parameter)
        {
            FileInfo info = new FileInfo("Sample.ebwk");
            WorkspaceFileInfo = info;

        }

        private FileInfo workspaceFileInfo;
        public FileInfo WorkspaceFileInfo
        {
            get { return workspaceFileInfo; }
            set
            {
                workspaceFileInfo = value;
                RaisePropertyChanged();
            }
        }

        #endregion


        #region Get Workspace Document

        
        private DelegateCommand getWorkspaceDocumentCommand;
        public DelegateCommand GetWorkspaceDocumentCommand
        {
            get { return getWorkspaceDocumentCommand; }
            set
            {
                getWorkspaceDocumentCommand = value;
                RaisePropertyChanged();
            }
        }

        private bool GetWorkspaceDocumentCommandCanExecute(object parameter)
        {
            return parameter != null;

        }

        private void GetWorkspaceDocumentCommandExecute(object parameter)
        {
            IWorkspace theSpace = parameter as IWorkspace;
            if(theSpace !=null)
            {
                string xml = theSpace.WorkspaceXML;
            }
        }

        #endregion
    }


}
