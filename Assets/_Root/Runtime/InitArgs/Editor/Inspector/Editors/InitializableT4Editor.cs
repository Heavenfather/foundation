﻿using System;
using UnityEditor;

namespace Pancake.Init.EditorOnly
{
	[CanEditMultipleObjects]
    public sealed class InitializableT4Editor : InitializableEditor
    {
        protected override Type BaseTypeDefinition => typeof(IInitializable<,,,>);
    }
}