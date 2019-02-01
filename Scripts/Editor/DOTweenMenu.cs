#if UNITY_EDITOR
using UnityEditor;

namespace UnityExtensions.Editor
{
    public static class DOTweenMenu
    {
        private const string EnableItemName     = "Extensions/DOTween/Enable";
        private const string DisableItemName    = "Extensions/DOTween/Disable";
        private const string Symbol             = "EXTENSIONS_DOTWEEN";

        [MenuItem(EnableItemName)]
        public static void Enable()
        {
            MenuEditor.AddSymbols(Symbol);
        }

        [MenuItem(EnableItemName, true)]
        private static bool EnableValidate()
        {
            if (EditorApplication.isCompiling)
                return false;
            
#if EXTENSIONS_DOTWEEN
            Menu.SetChecked(EnableItemName, true);
            return false;
#else
            Menu.SetChecked(EnableItemName, false);
            return true;
#endif
        }

        [MenuItem(DisableItemName)]
        public static void Disable()
        {
            MenuEditor.RemoveSymbols(Symbol);
        }

        [MenuItem(DisableItemName, true)]
        private static bool DisableValidate()
        {
            if (EditorApplication.isCompiling)
                return false;
            
#if EXTENSIONS_DOTWEEN
            Menu.SetChecked(DisableItemName, false);
            return true;
#else
            Menu.SetChecked(DisableItemName, true);
            return false;
#endif
        }
    }
}
#endif
