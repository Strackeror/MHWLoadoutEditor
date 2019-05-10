using System;
using System.Collections.Generic;
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

namespace MHWLoadoutEdit
{
    using Structure;
    using Microsoft.Win32;
    using SaveData;

    /// <summary>
    /// Interaction logic for MainWindow.xaml
    /// </summary>
    public partial class MainWindow : Window
    {
        private SaveFile saveFile;
        private EquipmentLoadout loadout;

        public MainWindow()
        {
            InitializeComponent();
        }

        private void MenuItemOpen_OnClick(object sender, RoutedEventArgs e)
        {
            var dialog = new OpenFileDialog();
            if (dialog.ShowDialog() == true)
                saveFile = new SaveFile(dialog.FileName);
            this.LoadoutEditor.DataContext = saveFile.loadouts.First();

        }
    }
}
