using System;

namespace Content.Features.StorageModule.Scripts
{
    public interface IWeightStorage : IStorage
    {
        event Action<WeightChangedEventArgs> OnWeightChanged; 
        
        float CurrentWeight { get; }
        float MaxWeight { get; }
    }

}