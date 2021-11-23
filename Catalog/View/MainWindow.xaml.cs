using System;
using System.Collections.Generic;
using System.Collections.ObjectModel;
using System.Linq;
using System.Windows;
using System.Windows.Controls;
using System.Windows.Input;
using System.Windows.Threading;

namespace Catalog
{
    /// <summary>
    /// Interaction logic for MainWindow.xaml
    /// </summary>
    public partial class MainWindow : Window
    {
        ObservableCollection<DocumentView> _data;
        static DateTime spentTime = new DateTime();
        //Database db;
        EntitiesViewModel entityViewModel;
        DocumentViewModel docViewModel;
        private static string _userLogin;
        //ApplicationContext db = new ApplicationContext();

        public List<Entity> Entities { get; set; }
        public List<DocumentView> Documents { get; set; }
        //public ObservableCollection<DocumentView> data { get; set; }
        public MainWindow()
        {
            InitializeComponent();
            _userLogin = "test";
            StartingMethod();
        }
        public MainWindow(string userLogin)
        {
            InitializeComponent();
            _userLogin = userLogin;
            StartingMethod();
        }

        private void StartingMethod()
        {
            try
            {
                entityViewModel = new EntitiesViewModel(_userLogin);
                UserLogin.Header = $"Привет, {_userLogin}!";

                Entities = entityViewModel.GetEntities().ToList();
                this.entitiesListBox.ItemsSource = Entities;


                DispatcherTimer timer = new DispatcherTimer();
                timer.Tick += new EventHandler(timer_Tick);
                timer.Interval = TimeSpan.FromSeconds(1);
                timer.Start();
            }
            catch (Exception ex)
            {
                MessageBox.Show(ex.Message);
            }
        }

        //for DispatcherTimer
        void timer_Tick(object sender, EventArgs e)
        {
            spentTime = spentTime.AddSeconds(1);
            timeLabel.Content = spentTime.ToLongTimeString();
        }
        //вызывается при нажатии на одну из сущностей из списка
        private void ListViewItem_PreviewMouseLeftButtonDown(object sender, MouseButtonEventArgs e)
        {
            try
            {
                var item = sender as ListViewItem;
                if (item != null)// && item.IsSelected)
                {
                    Entity entity = (Entity)item.Content;

                    UpdateMainWindow(entity);
                }
            }
            catch (Exception ex)
            {
                MessageBox.Show(ex.Message);
            }
        }

        public void UpdateMainWindow(Entity entity)
        {
            try
            {
                //for Adding new Docs
                docViewModel = new DocumentViewModel(_userLogin, this, entity.EntityName);
                this.DataContext = docViewModel;

                //data = docViewModel.GetDocumentsForMainWindow(entity.EntityName);
                this.instancesListBox.ItemsSource = docViewModel.GetDocumentsForMainWindow(entity.EntityName);
            }
            catch (Exception ex)
            {
                MessageBox.Show(ex.Message);
            }
        }

        private void CreateTypeButton_Click(object sender, RoutedEventArgs e)
        {
            try
            {
                CreateEntityWindow createEntityWindow = new CreateEntityWindow(_userLogin);
                createEntityWindow.Owner = this;

                createEntityWindow.ShowDialog();
                Entities = entityViewModel.GetEntities().ToList();
                this.entitiesListBox.ItemsSource = Entities;
            }
            catch (Exception ex)
            {
                MessageBox.Show(ex.Message);
            }
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
