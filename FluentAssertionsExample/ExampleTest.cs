using System;
using System.Collections.Generic;
using FluentAssertions;
using FluentAssertions.Common;
using Xunit;

namespace FluentAssertionsExample
{
    public class ExampleTest
    {
        [Fact]
        public void ClassWithoutCctor_Works()
        {
            typeof(ClassWithoutCctor).Should().HaveDefaultConstructor();
        }

        /// <summary>
        /// This fails because the class has two parameterless constructors and the call to
        /// HaveDefaultConstructor calls HaveConstructor which calls GetConstructor which
        /// calls type.GetConstructors(AllMembersFlag).SingleOrDefault which throws an
        /// exception when more than one element is found.
        /// </summary>
        [Fact]
        public void ClassWithCctor_Fails()
        {
            typeof(ClassWithCctor).Should().HaveDefaultConstructor();
        }
    }

    /// <summary>
    /// This class does not have a cctor, just a parameterless ctor, the default constructor.
    /// </summary>
    internal class ClassWithoutCctor
    {
        private static int Value { get; set; }
    }

    /// <summary>
    /// This class has both a parameterless cctor, because the static property is initialized,
    /// and a parameterless ctor, the default constructor.
    /// </summary>
    internal class ClassWithCctor
    {
        private static int Value { get; set; } = 0;
    }
}
