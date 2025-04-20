using UnityEngine.EventSystems;
using UnityEngine.InputSystem;

namespace Content.Global.Scripts.UI
{
    public static class UIUtility
    {
        public static bool IsPointerOverUI()
        {
            if (EventSystem.current == null)
                return false;
            
#if ENABLE_INPUT_SYSTEM
            return EventSystem.current.IsPointerOverGameObject(Mouse.current.deviceId);
#else
            return EventSystem.current.IsPointerOverGameObject();
#endif
        }
    }

}