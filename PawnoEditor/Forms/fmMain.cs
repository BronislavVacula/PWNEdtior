﻿using Syncfusion.Windows.Forms;
using System;
using System.IO;
using System.Windows.Forms;

namespace PawnoEditor.Forms
{
    public partial class fmMain : Syncfusion.Windows.Forms.Tools.RibbonForm
    {
        #region Properties and fields
        #endregion

        #region Constructor and initialization
        /// <summary>
        /// Initializes a new instance of the <see cref="fmMain"/> class.
        /// </summary>
        public fmMain()
        {
            InitializeComponent();
            InitializeStyles();
            InitializeMdiManager();
            InitPanels();
        }

        /// <summary>
        /// Initializes the styles.
        /// </summary>
        private void InitializeStyles()
        {
            InitializeDockingManager();
            InitializeMessageBox();
        }

        /// <summary>
        /// Initializes the docking manager.
        /// </summary>
        private void InitializeDockingManager()
        {
            dockingManager.Office2007MdiColorScheme = Office2007Theme.Silver;
            dockingManager.Office2007MdiChildForm = true;
        }

        /// <summary>
        /// Initializes the MDI manager.
        /// </summary>
        private void InitializeMdiManager()
        {
            mdiManager.AttachToMdiContainer(this);
        }

        /// <summary>
        /// Initializes the message box.
        /// </summary>
        private void InitializeMessageBox()
        {
            MessageBoxAdv.ThemeName = "Office2016";
        }

        /// <summary>
        /// Initializes the panels.
        /// </summary>
        private void InitPanels()
        {
            //Left side
            var solutionPanel = CreatePanel<Controls.Panels.ucWorkspaceBrowser>("Solution files");

            //Right side
            var includesPanel = CreatePanel<Controls.Panels.ucIncludeList>("Includes");
            var skinsPanel = CreatePanel<Controls.Panels.ucSkinList>("Skins");

            dockingManager.DockControl(solutionPanel, this, Syncfusion.Windows.Forms.Tools.DockingStyle.Left, 250);

            dockingManager.DockControl(includesPanel, this, Syncfusion.Windows.Forms.Tools.DockingStyle.Right, 250, true);
            dockingManager.DockControl(skinsPanel, includesPanel, Syncfusion.Windows.Forms.Tools.DockingStyle.Bottom, 250, true);
        }
        #endregion

        #region Methods
        /// <summary>
        /// Creates the panel.
        /// </summary>
        /// <typeparam name="PanelType">The type of the anel type.</typeparam>
        /// <param name="title">The title.</param>
        /// <param name="startingPath">The starting path.</param>
        private T CreatePanel<T>(string title) where T : UserControl
        {
            var panel = CreatePanel<T>();

            CreatePanel<T>(title, panel);

            return panel;
        }

        /// <summary>
        /// Creates the panel.
        /// </summary>
        /// <typeparam name="PanelType">The type of the anel type.</typeparam>
        /// <param name="startingPath">The starting path.</param>
        /// <returns></returns>
        private T CreatePanel<T>() where T : UserControl
        {
            T panel = (T)Activator.CreateInstance(typeof(T));
            panel.Parent = this;
            panel.Visible = true;

            return panel;
        }

        /// <summary>
        /// Creates the panel.
        /// </summary>
        /// <param name="uc">The uc.</param>
        public void CreatePanel<T>(string title, T panel) where T : UserControl
        {
            dockingManager.SetEnableDocking(panel, true);
            dockingManager.SetDockLabel(panel, title);
        }

        /// <summary>
        /// Creates the file.
        /// </summary>
        private void CreateFile(string filePath = null)
        {
            Components.ScintillaEx editor = new Components.ScintillaEx()
            {
                Parent = this,
                Dock = DockStyle.Fill,
            };

            if (filePath == null)
            {
                editor.OpenTemplate(Path.GetDirectoryName(Application.ExecutablePath));

                CreateFile(editor, "New.pwn");
            }
            else
            {
                editor.OpenFile(filePath);

                CreateFile(editor, Path.GetFileName(filePath));
            }
        }

        /// <summary>
        /// Creates the file.
        /// </summary>
        /// <param name="editor">The editor.</param>
        /// <param name="fileName">Name of the file.</param>
        private void CreateFile(Components.ScintillaEx editor, string fileName)
        {
            dockingManager.SetEnableDocking(editor, true);
            dockingManager.SetDockLabel(editor, fileName);
            dockingManager.SetAsMDIChild(editor, true);
        }
        #endregion

        #region Event handlers
        /// <summary>
        /// Handles the Click event of the btnNewFile control.
        /// </summary>
        /// <param name="sender">The source of the event.</param>
        /// <param name="e">The <see cref="EventArgs"/> instance containing the event data.</param>
        private void btnNewFile_Click(object sender, EventArgs e)
        {
            CreateFile();
        }
        #endregion
    }
}