#if EXTENSIONS_UNIRX
using UnityEngine;
using System;
using UniRx;

namespace UnityExtensions
{
    [Serializable]
    public class TransformReactiveProperty : ReactiveProperty<Transform>
    {
        public TransformReactiveProperty() : base() { }

        public TransformReactiveProperty(Transform value) { this.Value = value; }
    }
}
#endif
