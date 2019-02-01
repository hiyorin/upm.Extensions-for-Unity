#if EXTENSIONS_UNIRX
using UnityEngine;
using System;
using UniRx;

namespace UnityExtensions
{
    [Serializable]
    public class Texture2DReactiveProperty : ReactiveProperty<Texture2D>
    {
        public Texture2DReactiveProperty() : base() { }

        public Texture2DReactiveProperty(Texture2D value) { this.Value = value; }
    }
}
#endif
