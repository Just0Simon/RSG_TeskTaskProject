using UnityEngine;
using UnityEngine.UI;
using Zenject;

namespace Content.Features.HealthModule.Scripts
{
    public class HealthBarView : MonoBehaviour, IHealthBarView
    {
        [SerializeField] private Slider _healthBarSlider;
        private HealthBarPresenter _presenter;

        [Inject]
        public void InjectDependencies(HealthBarPresenter presenter)
        {
            _presenter = presenter;
        }

        public void UpdateHealthBar(float currentHealth, float maxHealth)
        {
            _healthBarSlider.value = currentHealth / maxHealth;
        }

        private void OnDestroy()
        {
            _presenter.Dispose();
        }
    }
}