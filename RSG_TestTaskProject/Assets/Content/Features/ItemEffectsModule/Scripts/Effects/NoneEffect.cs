using UnityEngine;

namespace Content.Features.ItemEffectsModule.Scripts
{
    public class NoneEffect : Effect
    {
        public override void Apply()
        {
            Debug.Log("None Item Effect");
        }
    }
}