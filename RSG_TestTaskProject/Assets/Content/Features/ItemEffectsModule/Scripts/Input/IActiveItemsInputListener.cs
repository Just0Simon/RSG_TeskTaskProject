using System;

namespace Content.Features.ItemEffectsModule.Scripts.Input
{
    public interface IActiveItemsInputListener
    {
        public event Action OnHealActivateActionPerformed;
        public event Action<int> OnActiveItemNumberPressed;
    }
}