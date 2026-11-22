using Eto.Drawing;
using Eto.Forms;
using GotaSoundIO.IO;
using NitroStudio2X.Core;
using System;
using System.ComponentModel;

namespace NitroStudio2X.Dialogs.Editors
{
    /// <summary>
    /// An editor base for files.
    /// </summary>
    [TypeDescriptionProvider(typeof(AbstractCommunicatorProvider))]
    public abstract class EditorBase : Form
	{
        /// <summary>
        /// File type to use.
        /// </summary>
        public IOFile File;

        /// <summary>
        /// External file.
        /// </summary>
        public IOFile ExtFile;

        /// <summary>
        /// File name.
        /// </summary>
        public string FileName;

        /// <summary>
        /// File path.
        /// </summary>
        public string FilePath;

        /// <summary>
        /// Description of the extension.
        /// </summary>
        public string ExtensionDescription;

        /// <summary>
        /// Extension of format.
        /// </summary>
        public string Extension;

        /// <summary>
        /// Editor name.
        /// </summary>
        public string EditorName;

        /// <summary>
        /// Current file open.
        /// </summary>
        public bool FileOpen;

        /// <summary>
        /// Has the file been changed?
        /// </summary>
        public bool FileChanged;

        /// <summary>
        /// File type.
        /// </summary>
        public Type FileType;

        /// <summary>
        /// Other editor.
        /// </summary>
        public EditorBase OtherEditor;

        /// <summary>
        /// Writing info.
        /// </summary>
        public bool WritingInfo;

        public Configuration c = new Configuration();
        public EditorBase()
		{
			Title = "My Eto Form";
			MinimumSize = new Size(200, 200);

			Content = new StackLayout
			{
				Padding = 10,
				Items =
				{
					"Hello World!",
					// add more controls here
				}
			};

			// create a few commands that can be used for the menu and toolbar
			var clickMe = new Command { MenuText = "Click Me!", ToolBarText = "Click Me!" };
			clickMe.Executed += (sender, e) => MessageBox.Show(this, "I was clicked!");

			var quitCommand = new Command { MenuText = "Quit", Shortcut = Application.Instance.CommonModifier | Keys.Q };
			quitCommand.Executed += (sender, e) => Application.Instance.Quit();

			var aboutCommand = new Command { MenuText = "About..." };
			aboutCommand.Executed += (sender, e) => new AboutDialog().ShowDialog(this);

			// create menu
			Menu = new MenuBar
			{
				Items =
				{
					// File submenu
					new SubMenuItem { Text = "&File", Items = { clickMe } },
					// new SubMenuItem { Text = "&Edit", Items = { /* commands/items */ } },
					// new SubMenuItem { Text = "&View", Items = { /* commands/items */ } },
				},
				ApplicationItems =
				{
					// application (OS X) or file menu (others)
					new ButtonMenuItem { Text = "&Preferences..." },
				},
				QuitItem = quitCommand,
				AboutItem = aboutCommand
			};

			// create toolbar
			ToolBar = new ToolBar { Items = { clickMe } };
		}
	}
    public class AbstractCommunicatorProvider : TypeDescriptionProvider
    {
        public AbstractCommunicatorProvider() : base(TypeDescriptor.GetProvider(typeof(Control)))
        {
        }
        public override Type GetReflectionType(Type objectType, object instance)
        {
            return typeof(Control);
        }
        public override object CreateInstance(IServiceProvider provider, Type objectType, Type[] argTypes, object[] args)
        {
            objectType = typeof(Control);
            return base.CreateInstance(provider, objectType, argTypes, args);
        }
    }
}
