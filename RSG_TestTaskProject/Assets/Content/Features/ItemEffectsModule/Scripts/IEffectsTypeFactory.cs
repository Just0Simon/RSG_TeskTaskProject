namespace Content.Features.ItemEffectsModule.Scripts
{
    public interface IEffectsTypeFactory
    {
        IEffect GetEffectOfType(EffectType effectType);
    }
}