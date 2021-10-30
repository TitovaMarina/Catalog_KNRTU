using System;
using System.Collections.Generic;
using System.Collections.ObjectModel;
using System.Linq;
using System.Windows;
using System.Windows.Controls;
using System.Windows.Input;

namespace Catalog
{
    /// <summary>
    /// Interaction logic for MainWindow.xaml
    /// </summary>
    public partial class MainWindow : Window
    {
        ObservableCollection<DocumentView> _data;
        //Database db;
        EntitiesViewModel entityViewModel;
        DocumentViewModel docViewModel;
        private static string _userLogin;
        //ApplicationContext db = new ApplicationContext();

        public List<Entity> Entities { get; set; }
        public List<DocumentView> Documents { get; set; }
        //public ObservableCollection<DocumentView> data { get; set; }

        public MainWindow(string userLogin)
        {
            InitializeComponent();
            _userLogin = userLogin;

            entityViewModel = new EntitiesViewModel(userLogin);
            UserLogin.Header = $"Привет, {userLogin}!";

            Entities = entityViewModel.GetEntities().ToList();
            this.entitiesListBox.ItemsSource = Entities;

            //---------------
            //data = new ObservableCollection<DocumentView>();
            //this.instancesListBox.ItemsSource = data;
            //
            //if (!String.IsNullOrEmpty(entityViewModel.SelectedEntity.EntityName))
            //{
            //    var data = GetList(entityViewModel.SelectedEntity.EntityName);

            //    this.instancesListBox.ItemsSource = data;
            //}

        }
                
        //вызывается при нажатии на одну из сущностей из списка
        private void ListViewItem_PreviewMouseLeftButtonDown(object sender, MouseButtonEventArgs e)
        {            
            var item = sender as ListViewItem;
            if (item != null)// && item.IsSelected)
            {
                Entity entity = (Entity)item.Content;

                UpdateMainWindow(entity);
            }            
        }

        public void UpdateMainWindow(Entity entity)
        {
            //for Adding new Docs
            docViewModel = new DocumentViewModel(_userLogin, this, entity.EntityName);
            this.DataContext = docViewModel;

            //data = docViewModel.GetDocumentsForMainWindow(entity.EntityName);
            this.instancesListBox.ItemsSource = docViewModel.GetDocumentsForMainWindow(entity.EntityName);

        }

        private void CreateTypeButton_Click(object sender, RoutedEventArgs e)
        {
            CreateEntityWindow createEntityWindow = new CreateEntityWindow(_userLogin);
            createEntityWindow.Owner = this;

            createEntityWindow.ShowDialog();
            Entities = entityViewModel.GetEntities().ToList();
            this.entitiesListBox.ItemsSource = Entities;
        }

        private void LoginMenuItem_Click(object sender, RoutedEventArgs e)
        {
            LoginWindow login = new LoginWindow();
            this.Close();
            login.ShowDialog();
        }

        private void ExitMenuItem_Click(object sender, RoutedEventArgs e)
        {
            Close();
        }

        public List<Field> GetList(string tableName)
        {
            //var data = db.GetEntityFieldListNEW(tableName);

            List<Field> dict = new List<Field>
            {
                new Field("field1"), new Field("field2"), new Field("field3"), new Field("field4"), new Field("field5"),
                new Field("field6"), new Field("field7")
            };
            return dict;
        }

    }
}
