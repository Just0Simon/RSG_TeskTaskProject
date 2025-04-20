using System;
using UnityEngine;

namespace Content.Features.HealthModule.Scripts
{
    public class EntityHealthModel : IHealthModel
    {
        private float _health;
        private readonly float _maxHealth;
        
        public float Health => _health;
        public float MaxHealth => _maxHealth;
        
        public event Action<HealthChangedEventArgs> OnHealthChanged;

        public EntityHealthModel(float startHealth)
        {
            _maxHealth = startHealth;
            _health = startHealth;
        }

        public void TakeDamage(float damage)
        {
            _health = Mathf.Clamp(_health - damage, 0, _maxHealth);
            InvokeOnHealthChanged();
        }

        public void Heal(float heal)
        {
            _health = Mathf.Clamp(_health + heal, 0, _maxHealth);
            InvokeOnHealthChanged();
        }

        private void InvokeOnHealthChanged()
        {
            OnHealthChanged?.Invoke(new HealthChangedEventArgs() { CurrentHealth = _health, MaxHealth = _maxHealth });
        }
    }
}