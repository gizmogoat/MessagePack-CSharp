// Copyright (c) All contributors. All rights reserved.
// Licensed under the MIT license. See LICENSE file in the project root for full license information.

using MessagePack.Formatters;
using MessagePack.Internal;
using MessagePack.Resolvers;

#pragma warning disable SA1402 // File may only contain a single type
#pragma warning disable SA1403 // File may only contain a single namespace

namespace MessagePack.Resolvers
{
    public sealed class StandardResolver : IFormatterResolver
    {
        public static readonly IFormatterResolver Instance = new StandardResolver();

        private static readonly IFormatterResolver[] FallbackResolvers = new IFormatterResolver[]
        {
            BuiltinResolver.Instance,
            PrimitiveObjectResolver.Instance,
            // Add any others you need
        };

        private readonly IFormatterResolver composite = CompositeResolver.Create(FallbackResolvers);

        public IMessagePackFormatter<T> GetFormatter<T>() => composite.GetFormatter<T>();
    }
}
