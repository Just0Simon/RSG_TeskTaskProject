using UnityEngine;

namespace Content.Features.ItemEffectsModule.Scripts
{
    [CreateAssetMenu(menuName = "Configurations/Effects/" + nameof(HealingEffectConfiguration),
        fileName = nameof(HealingEffectConfiguration), order = 0)]
    public class HealingEffectConfiguration : EffectConfiguration
    {
        public float HealAmount;

        public override EffectType EffectType => EffectType.Heal;
        
        public override IEffect GetEffect(IEffectsFactory factory)
        {
            var effect = factory.GetItemEffect<HealEffect>();
            effect.SetHealAmount(HealAmount);
            effect.SetConsumeItem(ConsumeItem);
            return effect;
        }
    }
}