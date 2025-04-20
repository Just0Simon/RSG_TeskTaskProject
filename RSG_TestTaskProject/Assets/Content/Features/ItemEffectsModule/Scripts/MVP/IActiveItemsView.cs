using System;
using UnityEngine;

namespace Content.Features.ItemEffectsModule.Scripts
{
    public interface IActiveItemsView
    {
        event Action<int> OnActiveItemClicked;
        void Setup(int maxActiveItemsCount);
        void SetActiveItem(int activeItemNumber, Sprite itemIcon);
        void RemoveActiveItem(int number);
    }
}