using Zenject;

namespace Content.Features.ItemEffectsModule.Scripts
{
    public class EffectsFactory : IEffectsFactory
    {
        private readonly DiContainer _container;

        public EffectsFactory(DiContainer container)
        {
            _container = container;
        }
        
        public T GetItemEffect<T>() where T : Effect
        {
            return _container.Instantiate<T>();
        }
    }
}