#if EXTENSIONS_UNIRX
using UnityEngine;
using System;
using UniRx;

namespace UnityExtensions
{
    [Serializable]
    public class RectTransformReactiveProperty : ReactiveProperty<RectTransform>
    {
        public RectTransformReactiveProperty() : base() { }

        public RectTransformReactiveProperty(RectTransform value) { this.Value = value; }
    }
}
#endif
