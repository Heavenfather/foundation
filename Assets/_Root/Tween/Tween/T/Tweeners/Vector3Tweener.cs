﻿using UnityEngine;

namespace Pancake.Core.Tween
{
    public class Vector3Tweener : Tweener<Vector3>
    {
        public Vector3Tweener(Getter currValueGetter, Setter setter, Getter finalValueGetter, float duration, Validation validation)
            : base(currValueGetter,
                setter,
                finalValueGetter,
                duration,
                Vector3Interpolator.Instance,
                validation)
        {
        }
    }
}