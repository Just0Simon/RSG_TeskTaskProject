namespace Content.Features.ItemEffectsModule.Scripts
{
    public class EffectApplicator
    {
        private readonly IEffectsTypeFactory _effectTypeFactory;

        public EffectApplicator(IEffectsTypeFactory effectTypeFactory)
        {
            _effectTypeFactory = effectTypeFactory;
        }

        public void ApplyEffectOfType(EffectType effectType, out bool consumeItem)
        {
            var effect = _effectTypeFactory.GetEffectOfType(effectType);
            consumeItem = effect.ConsumeItem;
            effect.Apply();
        }
    }
}