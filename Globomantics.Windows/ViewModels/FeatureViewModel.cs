using Globomantics.Domain;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Globomantics.Infrastructure.Data.Repositories;
using CommunityToolkit.Mvvm.Input;

namespace Globomantics.Windows.ViewModels
{
    public class FeatureViewModel : BaseTodoViewModel<Feature>
    {
        private readonly IRepository<Feature> repository;

        private string? description;

        public string? Description 
        { 
            get => description;
            set
            {
                description = value;
                OnPropertyChanged(nameof(Description));
            }
        }

        public FeatureViewModel(IRepository<Feature> repository) : base()
        {
            this.repository = repository;
            SaveCommand = new RelayCommand(async () => await SaveAsync());
        }
        public override Task SaveAsync()
        {
            throw new NotImplementedException();
        }
    }
}
