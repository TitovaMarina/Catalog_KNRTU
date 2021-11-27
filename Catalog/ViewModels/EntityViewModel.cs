using System.Collections.ObjectModel;

namespace Catalog
{
    class EntityViewModel
    {
        private ObservableCollection<NewEntity> _entity;
        public EntityViewModel()
        {
            _entity = new ObservableCollection<NewEntity>();
        }
        
        public ObservableCollection<NewEntity> Entity => _entity;
    }
}
