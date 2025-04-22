using UnityEngine;
using Zenject;

namespace Content.Features.HealthModule.Scripts
{
    public class HealthModuleDisposer : MonoBehaviour
    {
        private HealthBarPresenter _presenter;

        [Inject]
        public void InjectDependencies(HealthBarPresenter presenter)
        {
            _presenter = presenter;
        }

        private void OnDestroy()
        {
            _presenter.Dispose();   
        }
    }
}