namespace Content.Features.ItemEffectsModule.Scripts
{
    public class EffectsTypeFactory : IEffectsTypeFactory
    {
        private readonly EffectsConfigurationsCollection _configurationsCollection;
        private readonly IEffectsFactory _effectsFactory;

        public EffectsTypeFactory(EffectsConfigurationsCollection configurationsCollection, IEffectsFactory effectsFactory)
        {
            _configurationsCollection = configurationsCollection;
            _effectsFactory = effectsFactory;
        }

        public IEffect GetEffectOfType(EffectType effectType)
        {
            var configuration = _configurationsCollection.GetEffectConfiguration(effectType);
            return configuration.GetEffect(_effectsFactory);
        }
    }
}