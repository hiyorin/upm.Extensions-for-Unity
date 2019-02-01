#if EXTENSIONS_UNIRX
using UnityEngine;
using System;
using UniRx;

namespace UnityExtensions
{
    [Serializable]
    public class TextureReactiveProperty : ReactiveProperty<Texture>
    {
        public TextureReactiveProperty() : base() { }

        public TextureReactiveProperty(Texture value) { this.Value = value; }
    }
}
#endif
