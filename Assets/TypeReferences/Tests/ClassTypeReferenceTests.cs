namespace TypeReferences.Tests
{
    using System;
    using NUnit.Framework;

    internal class ClassTypeReferenceTests
    {
        internal class TheConstructor
        {
            [Test]
            public void When_no_arguments_are_passed_creates_instance_with_null_type()
            {
                var typeRef = new ClassTypeReference();
                Assert.That(typeRef.Type, Is.Null);
            }

            [Test]
            public void When_null_type_is_passed_creates_instance_with_null_type()
            {
                Type type = null;
                var typeRef = new ClassTypeReference(type);
                Assert.That(typeRef.Type, Is.Null);
            }

            [Test]
            public void When_not_a_class_type_is_passed_throws_ArgumentException()
            {
                var notAClassType = typeof(NotAClass);

                Assert.Throws<ArgumentException>(() =>
                {
                    var typeRef = new ClassTypeReference(notAClassType);
                });
            }

            [Test]
            public void When_a_class_type_is_passed_creates_instance_with_this_type()
            {
                var classType = typeof(ClassExample);
                var typeRef = new ClassTypeReference(classType);
                Assert.That(typeRef.Type, Is.EqualTo(classType));
            }

            private struct NotAClass { }
            private class ClassExample { }
        }
    }
}
