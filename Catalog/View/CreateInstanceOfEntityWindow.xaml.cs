using System;
using System.Windows;

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
            try
            {
                docViewModel = new DocumentViewModel(userLogin);
                _tableTitle = tableTitle;
                var data = docViewModel.GetFieldsList(tableTitle);
                this.FieldsList.ItemsSource = data;
            }
            catch (Exception ex)
            {
                MessageBox.Show(ex.Message);
            }
        }

        public CreateInstanceOfEntityWindow(DocumentView document, string userLogin)
        {
            InitializeComponent();
            try
            {
                docViewModel = new DocumentViewModel(userLogin);
                _tableTitle = document.EntityName;
                var data = docViewModel.GetDocumentByID(document.EntityName, document.DocumentID);
                this.FieldsList.ItemsSource = data;
            }
            catch(Exception ex)
            {
                MessageBox.Show(ex.Message);
            }
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
