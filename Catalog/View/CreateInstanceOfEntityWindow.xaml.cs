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
using System.Windows.Shapes;

namespace Catalog
{
    /// <summary>
    /// Interaction logic for CreateInstanceOfEntity.xaml
    /// </summary>
    public partial class CreateInstanceOfEntityWindow : Window
    {   
        DocumentViewModel docViewModel;
        private string _tableTitle;
        public CreateInstanceOfEntityWindow(string tableTitle, string userLogin)
        {
            InitializeComponent();
            docViewModel = new DocumentViewModel(userLogin);
            _tableTitle = tableTitle;
            var data = docViewModel.GetFieldsList(tableTitle);
            this.FieldsList.ItemsSource = data;
        }

        public CreateInstanceOfEntityWindow(DocumentView document, string userLogin)
        {
            InitializeComponent();
            docViewModel = new DocumentViewModel(userLogin);
            _tableTitle = document.EntityName;
            var data = docViewModel.GetDocumentByID(document.EntityName, document.DocumentID);
            this.FieldsList.ItemsSource = data;
        }

        private void Accept_Click(object sender, RoutedEventArgs e)
        {

            this.DialogResult = true;

            //var data = docViewModel.GetDocumentsForMainWindow(_tableTitle);
            //MainWindow mainWindow;
            //mainWindow.instancesListBox.ItemsSource = data;

        }
        
        private void Cancel_Click(object sender, RoutedEventArgs e)
        {
            this.Close();
        }
    }
}
