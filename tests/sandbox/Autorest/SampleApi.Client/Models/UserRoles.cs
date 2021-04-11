// Copyright (c) Microsoft Corporation. All rights reserved.
// Licensed under the MIT License.

// <auto-generated/>

#nullable disable

using System;
using System.ComponentModel;
using System.Globalization;

namespace SampleApi.Client.Models
{
    /// <summary> The UserRoles. </summary>
    public readonly partial struct UserRoles : IEquatable<UserRoles>
    {
        private readonly int _value;

        /// <summary> Determines if two <see cref="UserRoles"/> values are the same. </summary>
        public UserRoles(int value)
        {
            _value = value;
        }

        private const int ZeroValue = 0;
        private const int OneValue = 1;
        private const int TwoValue = 2;
        private const int ThreeValue = 3;
        private const int FourValue = 4;

        /// <summary> 0. </summary>
        public static UserRoles Zero { get; } = new UserRoles(ZeroValue);
        /// <summary> 1. </summary>
        public static UserRoles One { get; } = new UserRoles(OneValue);
        /// <summary> 2. </summary>
        public static UserRoles Two { get; } = new UserRoles(TwoValue);
        /// <summary> 3. </summary>
        public static UserRoles Three { get; } = new UserRoles(ThreeValue);
        /// <summary> 4. </summary>
        public static UserRoles Four { get; } = new UserRoles(FourValue);
        /// <summary> Determines if two <see cref="UserRoles"/> values are the same. </summary>
        public static bool operator ==(UserRoles left, UserRoles right) => left.Equals(right);
        /// <summary> Determines if two <see cref="UserRoles"/> values are not the same. </summary>
        public static bool operator !=(UserRoles left, UserRoles right) => !left.Equals(right);
        /// <summary> Converts a string to a <see cref="UserRoles"/>. </summary>
        public static implicit operator UserRoles(int value) => new UserRoles(value);

        /// <inheritdoc />
        [EditorBrowsable(EditorBrowsableState.Never)]
        public override bool Equals(object obj) => obj is UserRoles other && Equals(other);
        /// <inheritdoc />
        public bool Equals(UserRoles other) => Equals(_value, other._value);

        /// <inheritdoc />
        [EditorBrowsable(EditorBrowsableState.Never)]
        public override int GetHashCode() => _value.GetHashCode();
        /// <inheritdoc />
        public override string ToString() => _value.ToString(CultureInfo.InvariantCulture);
    }
}