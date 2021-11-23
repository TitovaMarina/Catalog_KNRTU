using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Linq;
using System.Windows;
using System.Windows.Controls;
using Catalog.DAL.DataBase;
using System.Windows.Media;

namespace Catalog
{
    /// <summary>
    /// Interaction logic for CreateEntityWindow.xaml
    /// </summary>
    public partial class CreateEntityWindow : Window
    {
        EntityRepository _entityRepository;
        public IEnumerable<NewEntity> Entities;
        public CreateEntityWindow(string userLogin)
        {
            InitializeComponent();
            newEntityFieldsGrid.DataContext = new EntityViewModel();
            _entityRepository = new EntityRepository(userLogin);
        }

        // This snippet is much safer in terms of preventing unwanted
        // Exceptions because of missing [DisplayNameAttribute].
        private void DataGrid_AutoGeneratingColumn(object sender, DataGridAutoGeneratingColumnEventArgs e)
        {
            if (e.PropertyDescriptor is PropertyDescriptor descriptor)
            {
                e.Column.Header = descriptor.DisplayName ?? descriptor.Name;
            }
        }

        public IEnumerable<NewEntity> getData()
        {
            Entities = newEntityFieldsGrid.ItemsSource as IEnumerable<NewEntity>;

            return Entities;
        }

        

        public IEnumerable<string> getFieldsNames()
        {
            List<NewEntity> fieldsCollection = getData().ToList();
            if (fieldsCollection.Count == 0)
                WarningLabel.Content = "Заполните таблицу для полей";
            
            else
            {
                foreach (var field in fieldsCollection)
                {
                    if (Validation.IsValid(field.FieldName))
                        yield return field.FieldName;
                    else
                        throw new Exception("Название невалидно. Можно использовать только латинские буквы, цифры и нижнее подчеркивание");
                }
            }
            
        }
        public IEnumerable<string> getImportantFieldsNames()
        {
            List<NewEntity> fieldsCollection = getData().ToList();
            
            foreach (var field in fieldsCollection)
            {
                if (field.Importance)
                    yield return field.FieldName;
            }
        }
        public bool[] getImportantFields()
        {
            List<NewEntity> fieldsCollection = getData().ToList();

            bool[] mas = new bool[fieldsCollection.Count()];
            int i = 0;
            foreach (var field in fieldsCollection)
            {
                if (field.Importance)
                    mas[i] = true;
                else
                    mas[i] = false;

                i++;
            }
            return mas;
        }

        private void CreateEntity_Click(object sender, RoutedEventArgs e)
        {
            try
            {               
                if (String.IsNullOrEmpty(EntityNameTextBox.Text))
                {
                    EntityNameTextBox.BorderBrush = Brushes.Red;
                    EntityNameTextBox.BorderThickness = new Thickness(3);
                    WarningLabel.Content = "Укажите название новой сущности";

                }
                else
                {
                    if (!Validation.IsValid(EntityNameTextBox.Text))
                        throw new Exception("Имя таблицы невалидно. Можно использовать только латинские буквы, цифры и нижнее подчеркивание");
                    WarningLabel.Content = "";
                    EntityNameTextBox.BorderThickness = new Thickness(1);
                    EntityNameTextBox.BorderBrush = Brushes.Gray;
                    if (getFieldsNames().Count() != 0)
                    {
                        if  (getImportantFieldsNames().Count() != 0) 
                            CreateNewEntity();
                        else
                            WarningLabel.Content = "Выберите хотя бы одно важное поле";
                    }
                }
            }
            catch (Exception ex)
            {
                MessageBox.Show(ex.Message, "не ура", MessageBoxButton.OK, MessageBoxImage.Information);
            }
            
        }

        private void CreateNewEntity()
        {
            try
            {
                bool success = _entityRepository.CreateNewEntity(EntityNameTextBox.Text, getFieldsNames(), getImportantFields());//+getImportantFieldsNames()
                if (success)
                {
                    MessageBox.Show("Success", "Success", MessageBoxButton.OK, MessageBoxImage.Information);
                    this.Close();
                }
                else
                {
                    MessageBox.Show("Smth went wrong", "Warning", MessageBoxButton.OK, MessageBoxImage.Information);
                }
            }
            catch (Exception ex)
            {
                MessageBox.Show(ex.Message, "Error", MessageBoxButton.OK, MessageBoxImage.Information);
            }
        }
    }
}
