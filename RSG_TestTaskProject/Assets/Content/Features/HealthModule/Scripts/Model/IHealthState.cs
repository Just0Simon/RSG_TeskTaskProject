using System;

namespace Content.Features.HealthModule.Scripts
{
    public interface IHealthState
    {
        public float Health { get; }
        public float MaxHealth { get; }
        
        public event Action<HealthChangedEventArgs> OnHealthChanged;
    }
}