using TMPro;
using UnityEngine;

namespace Content.Features.ItemEffectsModule.Scripts
{
    public class HealPotionsView : ActiveItemView
    {
        [SerializeField]
        private TMP_Text _healPotionsCountText;

        public void SetHealPotionsCount(int healPotionsCount)
        {
            _healPotionsCountText.text = healPotionsCount.ToString();
        }
    }
}