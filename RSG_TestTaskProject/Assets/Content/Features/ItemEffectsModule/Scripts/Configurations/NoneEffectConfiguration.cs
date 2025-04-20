using UnityEngine;

namespace Content.Features.ItemEffectsModule.Scripts
{
    [CreateAssetMenu(menuName = "Configurations/Effects/" + nameof(NoneEffectConfiguration),
        fileName = nameof(NoneEffectConfiguration), order = 0)]
    public class NoneEffectConfiguration : EffectConfiguration
    {
        public override EffectType EffectType => EffectType.None;
     
        public override IEffect GetEffect(IEffectsFactory factory)
        {
            var effect = factory.GetItemEffect<NoneEffect>();
            effect.SetConsumeItem(ConsumeItem);
            return effect;
        }
    }
}