using System.Collections.Generic;
using System.Linq;
using UnityEngine;

namespace Content.Features.ItemEffectsModule.Scripts
{
    [CreateAssetMenu(menuName = "Configurations/Effects/EffectCollection",
        fileName = nameof(EffectsConfigurationsCollection) + "_Default", order = 0)]
    public class EffectsConfigurationsCollection : ScriptableObject
    {
        [SerializeField]
        private List<EffectConfiguration> _configurationsCollection;
        
        [SerializeField]
        private EffectConfiguration _defaultEffectConfiguration;

        public EffectConfiguration GetEffectConfiguration(EffectType effectType)
        {
            var effectConfiguration = _configurationsCollection.FirstOrDefault(x => x.EffectType == effectType);
            return effectConfiguration ?? _defaultEffectConfiguration;
        }
    }
}