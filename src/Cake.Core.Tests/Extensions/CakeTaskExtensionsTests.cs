﻿using System.Collections.Generic;
using Cake.Core.Extensions;
using Cake.Core.Tests.Fixtures;
using Xunit;

namespace Cake.Core.Tests.Extensions
{
    public sealed class CakeTaskExtensionsTests
    {
        public sealed class TheWithCriteriaMethod
        {
            public sealed class ThatAcceptsBoolean
            {
                [Fact]
                public void Should_Evaluate_Criteria()
                {
                    // Given
                    var result = new List<string>();
                    var engine = new CakeEngineFixture().CreateEngine();
                    engine.Task("A").Does(() => result.Add("A"));
                    engine.Task("B").IsDependentOn("A").WithCriteria(false).Does(() => result.Add("B"));
                    engine.Task("C").IsDependentOn("B").Does(() => result.Add("C"));

                    // When
                    engine.Run("C");

                    // Then
                    Assert.Equal(2, result.Count);
                    Assert.Equal("A", result[0]);
                    Assert.Equal("C", result[1]);
                }
            }
        }
    }
}
