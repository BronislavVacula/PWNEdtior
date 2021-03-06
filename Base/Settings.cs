﻿using Base.Entities.SettingsEntities;
using Base.Enums;

namespace Base
{
    public class Settings
    {
        #region Singleton
        /// <summary>
        /// The instance
        /// </summary>
        private static Settings mInstance;

        /// <summary>
        /// Gets the instance.
        /// </summary>
        /// <value>
        /// The instance.
        /// </value>
        public static Settings Instance
        {
            get
            {
                if (mInstance == null)
                    mInstance = new Settings();

                return mInstance;
            }
        }

        /// <summary>
        /// Prevents a default instance of the <see cref="Settings"/> class from being created.
        /// </summary>
        private Settings() { }
        #endregion

        #region Properties and fields
        /// <summary>
        /// Gets or sets the server.
        /// </summary>
        /// <value>
        /// The server.
        /// </value>
        public SampServer Server { get; set; } = new SampServer();

        /// <summary>
        /// Gets or sets the editor.
        /// </summary>
        /// <value>
        /// The editor.
        /// </value>
        public TextEditor Editor { get; set; } = new TextEditor();

        /// <summary>
        /// Gets or sets the script insert mode.
        /// </summary>
        /// <value>
        /// The script insert mode.
        /// </value>
        public ScriptInsertMode ScriptInsertMode { get; set; } = ScriptInsertMode.ScinitillaEditor;
        #endregion
    }
}
