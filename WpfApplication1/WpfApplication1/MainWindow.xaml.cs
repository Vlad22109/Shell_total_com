using System;
using System.Collections.Generic;
using System.IO;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows;
using System.Windows.Controls;
using System.Windows.Data;
using System.Windows.Documents;
using System.Windows.Input;
using System.Windows.Media;
using System.Windows.Media.Imaging;
using System.Windows.Navigation;
using System.Windows.Shapes;
using System.Management;
using System.Globalization;
using System.ComponentModel;
using System.Drawing;
namespace WpfApplication1
{
/// <summary>
/// Логика взаимодействия для MainWindow.xaml
/// </summary>
public partial class MainWindow : Window
{
    private TreeView tvFolders;
		private ListView lvFiles;
        private IContainer components;
        private Menu mainMenu1;
        private MenuItem menuItem1;
        private MenuItem menuItem2;
        private MenuItem menuItem3;
        private MenuItem menuItem4;
        private ContextMenu treeContextMenu;
        private ContextMenuEventArgs miCopy;
        private ContextMenuEventArgs miPastle;
        private ContextMenu listContextMenu;
        private ContextMenuEventArgs lvCopy;
        private ContextMenuEventArgs lvPastle;
        private ContextMenu dragContextMenu;
        private ContextMenuEventArgs miMove;
        private ContextMenuEventArgs miDropCopy;
    
	public MainWindow()
		{
			InitializeComponent();
            PopulateDriveList();
			
		}
   
   
    private void PopulateDriveList()
    {
      
       
    }


}}
		
		
		

