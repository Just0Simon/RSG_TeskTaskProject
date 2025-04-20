using System;
using Content.Features.HealthModule.Scripts;
using Content.Features.InteractionModule;
using UnityEngine;

namespace Content.Features.DamageablesModule.Scripts {
    public class MonoDamageable : MonoBehaviour, IDamageable {
        [SerializeField] private DamageableType _damageableType;
        [SerializeField] private AttackInteractable _attackInteractable;

        private IHealthModel _healthModel;

        public Vector3 Position =>
            transform.position;
        public DamageableType DamageableType =>
            _damageableType;
        public bool IsActive =>
            _healthModel?.Health > 0;
        public AttackInteractable Interactable =>
            _attackInteractable;

        public event Action OnDamaged;
        public event Action OnKilled;

        public void Damage(float damage) { 
            _healthModel.TakeDamage(damage);
            OnDamaged?.Invoke();

            if (_healthModel.Health > 0)
                return;

            OnKilled?.Invoke();
            Destroy(gameObject);
        }

        public void BindHealthModel(IHealthModel healthModel)
        {
            _healthModel = healthModel;
        }
    }
}