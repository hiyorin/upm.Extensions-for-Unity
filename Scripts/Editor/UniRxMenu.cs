#if UNITY_EDITOR
using UnityEditor;

namespace UnityExtensions.Editor
{
    public static class UniRxMenu
    {
        private const string EnableItemName     = "Extensions/UniRx/Enable";
        private const string DisableItemName    = "Extensions/UniRx/Disable";
        private const string Symbol             = "EXTENSIONS_UNIRX";

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
                
#if EXTENSIONS_UNIRX
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
                
#if EXTENSIONS_UNIRX
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