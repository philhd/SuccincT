﻿using System.Diagnostics.CodeAnalysis;

namespace SuccincT.PatternMatchers
{
    public readonly struct Any
    {
        private static readonly Any AnyInstance = new Any();

        public override int GetHashCode() => 0;

        public override bool Equals(object obj) => obj is Any;

        public override string ToString() => "*";

        public static bool operator ==(Any any1, Any any2) => true;

        public static bool operator !=(Any any1, Any any2) => false;

        [SuppressMessage("Style", "IDE1006:Naming Styles")]
        public static Any any { get; } = AnyInstance;

        public static Any __ { get; } = AnyInstance;
    }
}
