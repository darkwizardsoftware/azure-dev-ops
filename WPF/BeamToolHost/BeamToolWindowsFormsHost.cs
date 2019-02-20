using System;
using System.Collections.Generic;
using System.IO;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows;
using System.Windows.Forms.Integration;

namespace BeamToolHost
{
    public class BeamToolWindowsFormsHost : WindowsFormsHost
    {

        #region Show Tool Bar

        public static readonly DependencyProperty ShowToolBarProperty = DependencyProperty.Register("ShowToolBar", typeof(bool), typeof(BeamToolWindowsFormsHost), new FrameworkPropertyMetadata(true, new PropertyChangedCallback(OnShowToolBarChanged), new CoerceValueCallback(OnCoerceShowToolBar)));

 
        private static object OnCoerceShowToolBar(DependencyObject o, object value)
        {
            BeamToolWindowsFormsHost beamToolWindowsFormsHost = o as BeamToolWindowsFormsHost;
            if (beamToolWindowsFormsHost != null)
                return beamToolWindowsFormsHost.OnCoerceShowToolBar((bool)value);
            else
                return value;
        }

        private static void OnShowToolBarChanged(DependencyObject o, DependencyPropertyChangedEventArgs e)
        {
            BeamToolWindowsFormsHost beamToolWindowsFormsHost = o as BeamToolWindowsFormsHost;
            if (beamToolWindowsFormsHost != null)
                beamToolWindowsFormsHost.OnShowToolBarChanged((bool)e.OldValue, (bool)e.NewValue);
        }

        protected virtual bool OnCoerceShowToolBar(bool value)
        {
            // TODO: Keep the proposed value within the desired range.
            return value;
        }

        protected virtual void OnShowToolBarChanged(bool oldValue, bool newValue)
        {
            // TODO: Add your property changed side-effects. Descendants can override as well.
        }

        public bool ShowToolBar
        {
            // IMPORTANT: To maintain parity between setting a property in XAML and procedural code, do not touch the getter and setter inside this dependency property!
            get
            {
                return (bool)GetValue(ShowToolBarProperty);
            }
            set
            {
                SetValue(ShowToolBarProperty, value);
            }
        }
        #endregion

        #region Open XML Workspace

        public static readonly DependencyProperty WorkspaceXmlProperty = DependencyProperty.Register("WorkspaceXml", typeof(string), typeof(BeamToolWindowsFormsHost), new FrameworkPropertyMetadata(string.Empty, new PropertyChangedCallback(OnWorkspaceXmlChanged), new CoerceValueCallback(OnCoerceWorkspaceXml)));

        private static object OnCoerceWorkspaceXml(DependencyObject o, object value)
        {
            BeamToolWindowsFormsHost beamToolWindowsFormsHost = o as BeamToolWindowsFormsHost;
            if (beamToolWindowsFormsHost != null)
                return beamToolWindowsFormsHost.OnCoerceWorkspaceXml((string)value);
            else
                return value;
        }

        private static void OnWorkspaceXmlChanged(DependencyObject o, DependencyPropertyChangedEventArgs e)
        {
            BeamToolWindowsFormsHost beamToolWindowsFormsHost = o as BeamToolWindowsFormsHost;
            if (beamToolWindowsFormsHost != null)
                beamToolWindowsFormsHost.OnWorkspaceXmlChanged((string)e.OldValue, (string)e.NewValue);
        }

        protected virtual string OnCoerceWorkspaceXml(string value)
        {
            // TODO: Keep the proposed value within the desired range.
            return value;
        }

        protected virtual void OnWorkspaceXmlChanged(string oldValue, string newValue)
        {
            // TODO: Add your property changed side-effects. Descendants can override as well.
        }

        public string WorkspaceXml
        {
            // IMPORTANT: To maintain parity between setting a property in XAML and procedural code, do not touch the getter and setter inside this dependency property!
            get
            {
                return (string)GetValue(WorkspaceXmlProperty);
            }
            set
            {
                SetValue(WorkspaceXmlProperty, value);
            }
        }

        #endregion

        #region Open FileInfo Workspace

        public static readonly DependencyProperty WorkspaceFileInfoProperty = DependencyProperty.Register("WorkspaceFileInfo", typeof(FileInfo), typeof(BeamToolWindowsFormsHost), new FrameworkPropertyMetadata(null, new PropertyChangedCallback(OnWorkspaceFileInfoChanged), new CoerceValueCallback(OnCoerceWorkspaceFileInfo)));
        private static object OnCoerceWorkspaceFileInfo(DependencyObject o, object value)
        {
            BeamToolWindowsFormsHost beamToolWindowsFormsHost = o as BeamToolWindowsFormsHost;
            if (beamToolWindowsFormsHost != null)
                return beamToolWindowsFormsHost.OnCoerceWorkspaceFileInfo((FileInfo)value);
            else
                return value;
        }

        private static void OnWorkspaceFileInfoChanged(DependencyObject o, DependencyPropertyChangedEventArgs e)
        {
            BeamToolWindowsFormsHost beamToolWindowsFormsHost = o as BeamToolWindowsFormsHost;
            if (beamToolWindowsFormsHost != null)
                beamToolWindowsFormsHost.OnWorkspaceFileInfoChanged((FileInfo)e.OldValue, (FileInfo)e.NewValue);
        }

        protected virtual FileInfo OnCoerceWorkspaceFileInfo(FileInfo value)
        {
            // TODO: Keep the proposed value within the desired range.
            return value;
        }

        protected virtual void OnWorkspaceFileInfoChanged(FileInfo oldValue, FileInfo newValue)
        {
            // TODO: Add your property changed side-effects. Descendants can override as well.
        }
        public FileInfo WorkspaceFileInfo
        {
            // IMPORTANT: To maintain parity between setting a property in XAML and procedural code, do not touch the getter and setter inside this dependency property!
            get
            {
                return (FileInfo)GetValue(WorkspaceFileInfoProperty);
            }
            set
            {
                SetValue(WorkspaceFileInfoProperty, value);
            }
        }
        #endregion

    }
}
