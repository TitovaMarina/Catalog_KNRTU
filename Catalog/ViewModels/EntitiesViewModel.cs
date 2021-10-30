using System;
using System.Collections.Generic;
using System.Collections.ObjectModel;
using System.ComponentModel;
using System.Runtime.CompilerServices;
using Catalog.DAL.Model;
using Catalog.DAL.DataBase;

namespace Catalog
{    
    public class EntitiesViewModel : INotifyPropertyChanged
    {
        //ApplicationContext _context;
        EntityRepository _entityRepository;
        RelayCommand addCommand;
        RelayCommand editCommand;
        RelayCommand deleteCommand;
        IEnumerable<Entity> entities;
        private Entity selectedEntity = new Entity();
        private string _userName;

        public EntitiesViewModel(string fileName)
        {
            _userName = fileName;
            //_context = new ApplicationContext(fileName);
            //_context.Entities.Load();
            //Entities = _context.Entities.Local.ToBindingList();
            _entityRepository = new EntityRepository(fileName);
            //SelectedEntity = new Entity("OMG");
        }


        public ObservableCollection<Entity> Entities { get; set; }
        
        //public IEnumerable<Entity> Entities
        //{
        //    get { return entities; }
        //    set
        //    {
        //        entities = GetEntities();
        //        OnPropertyChanged("Entities");
        //    }
        //}

        public Entity SelectedEntity
        {
            get { return selectedEntity; }
            set
            {
                selectedEntity = value;
                OnPropertyChanged("SelectedEntity");
            }
        }
        public IEnumerable<Entity> GetEntities()
        {
            foreach (string entity in _entityRepository.GetEntities())
            {
                yield return new Entity()
                {
                    EntityName = entity
                };
            }
        }
        


        // команда добавления
        public RelayCommand AddCommand
        {
            get
            {
                return addCommand ??
                  (addCommand = new RelayCommand((o) =>
                  {
                      //это окно для Документа, при помощи которого можно создать новый или отредактировать имеющийся
                      CreateInstanceOfEntityWindow createInstance = new CreateInstanceOfEntityWindow(SelectedEntity.ToString(), _userName);

                      if (createInstance.ShowDialog() == true)
                      {
                          //Person person = createInstance.Person;
                          //db.People.Add(person);
                          //db.SaveChanges();
                      }                                            
                  }));
            }
        }
        // команда редактирования
        public RelayCommand EditCommand
        {
            get
            {
                return editCommand ??
                  (editCommand = new RelayCommand((selectedItem) =>
                  {
                      // если ни одного объекта не выделено, выходим
                      if (selectedItem == null) return;
                      // получаем выделенный объект. selectedItem - это выделенный Документ в главном окне.
                      Document document = selectedItem as Document;

                      //Person new_person = new Person()                      
                      //{
                      //    ID_Person = person.ID_Person,
                      //    FirstName = person.FirstName,
                      //    LastName = person.LastName,
                      //    DateOfBirth = person.DateOfBirth,
                      //    Address = person.Address,
                      //    EyeColor = person.EyeColor,
                      //    Telephone = person.Telephone
                      //};
                      //CreateInstanceOfEntityWindow createInstance = new CreateInstanceOfEntityWindow(new_person);

                      //if (createInstance.ShowDialog() == true)
                      //{
                      //    //document.Fields = 
                      //    // получаем измененный объект
                      //    person = db.People.Find(createInstance.Person.ID_Person);
                      //    //person = db.People.FirstOrDefault(i => i.ID_Person == createInstance.Person.ID_Person );
                      //    if (person != null)
                      //    {
                      //        person.FirstName = createInstance.Person.FirstName;
                      //        person.LastName = createInstance.Person.LastName;
                      //        person.DateOfBirth = createInstance.Person.DateOfBirth;
                      //        person.Address = createInstance.Person.Address;
                      //        person.EyeColor = createInstance.Person.EyeColor;
                      //        person.Telephone = createInstance.Person.Telephone;

                      //        db.Entry(person).State = EntityState.Modified;
                      //        db.SaveChanges();
                      //    }
                      //}
                  }));
            }
        }
        // команда удаления
        public RelayCommand DeleteCommand
        {
            get
            {
                return deleteCommand ??
                  (deleteCommand = new RelayCommand((selectedItem) =>
                  {
                      // если ни одного объекта не выделено, выходим
                      if (selectedItem == null) return;
                      // получаем выделенный объект

                      //Person person = selectedItem as Person;
                      //db.People.Remove(person);
                      //db.SaveChanges();
                  }));
            }
        }

        public event PropertyChangedEventHandler PropertyChanged;
        public void OnPropertyChanged([CallerMemberName] string prop = "")
        {
            if (PropertyChanged != null)
                PropertyChanged(this, new PropertyChangedEventArgs(prop));
        }
    }
}
