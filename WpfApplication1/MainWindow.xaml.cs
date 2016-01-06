using Microsoft.Win32;
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

namespace WpfApplication1
{
    /// <summary>
    /// Interaction logic for MainWindow.xaml
    /// </summary>
    public partial class MainWindow : Window
    {
        private FileControler _fCtrl;

        public MainWindow()
        {
            InitializeComponent();
            resultsBorder.Visibility = Visibility.Hidden;
            resultsGrid.Visibility = Visibility.Hidden;
        }

        private void BrowseBtn_Click(object sender, RoutedEventArgs e)
        {
            OpenFileDialog dlg = new OpenFileDialog() {
                DefaultExt = ".txt",
                Filter = "Notepad (*.txt)|*.txt|Word (*.docx)|*.docx"
            };
            
            var result = dlg.ShowDialog();
            
            if (result == true)
            {
                string filename = dlg.FileName;
                fileNameLbl.Content = filename;
                
                try
                {
                    _fCtrl = new FileControler(dlg.OpenFile());
                }
                catch (Exception)
                {
                    Log.LogMsg(errorLogTbx, "Wystąpił problem podczas odczytywania pliku", LogType.error);
                }
                Log.LogMsg(errorLogTbx, "Plik załadowany prawidłowo", LogType.info);
            }
            else
            {
                Log.LogMsg(errorLogTbx, "Wystąpił problem podczas ładowania pliku", LogType.error);
            }

        }

        private void ProcessBtn_Click(object sender, RoutedEventArgs e)
        {
            
            rowsCountLbl.Content = _fCtrl.rowsNumber;
            charsCountLbl.Content = _fCtrl.charsNumber;
            whiteCharsCountLbl.Content = _fCtrl.whiteCharsNumber;
            longestWordLbl.Content = _fCtrl.longestWord;

            resultsBorder.Visibility = Visibility.Visible;
            resultsGrid.Visibility = Visibility.Visible;
        }
    }
}
