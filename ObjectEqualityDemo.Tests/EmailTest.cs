using NUnit.Framework;
using ObjectEqualityDemo.Domain;
using System;
namespace ObjectEqualityDemo.Tests
{
    [TestFixture()]
    public class EmailTest
    {
        private Email email;

        [SetUp]
        public void Setup()
        {
            email = new Email()
            {
                Address = "raul@personaldomain.com",
                Type = EmailType.Personal
            };
        }

        [Test]
        public void HashCodeFromClone_WithChanges_ShouldBeDifferentFromOriginal()
        {
            var clonnedEmail = email.Clone();

            clonnedEmail.Address = "raul@anotherdomain.com";

            Assert.That(clonnedEmail.GetHashCode() == email.GetHashCode(), Is.False);
        }

        [Test]
        public void HashCodeFromClone_WithoutChanges_ShouldBeEqualFromOriginal()
        {
            var clonnedEmail = email.Clone();

            Assert.That(clonnedEmail.GetHashCode() == email.GetHashCode(), Is.True);
        }

        [Test]
        public void Clone_ShouldReturnNewInstanceWithOldValue()
        {
            var clonedEmail = email.Clone();

            // Not the same instance
            Assert.That(Object.ReferenceEquals(clonedEmail, email.Clone()), Is.False);

            // Has the same values
            Assert.That(clonedEmail.Address == email.Address);
            Assert.That(clonedEmail == email, Is.True);
        }

        [Test]
        public void Equals_ShouldBeConsistentWithComparisonOperator()
        {
            var clonedEmail = email.Clone();

            // Same result is returned regardless of comparison method used.
            Assert.That(clonedEmail.Equals(email), Is.True);
            Assert.That(clonedEmail == email, Is.True);
            Assert.That(clonedEmail != email, Is.False);
        }

        [Test]
        public void EqualityOperator_WithUpdatedClonedEmailAddress_ShouldNotBeEqualToOriginal()
        {
            var clonedEmail = email.Clone();

            clonedEmail.Address = "raul@somedomain.com";

            // Confirm consistency between comparison operators
            Assert.That(clonedEmail == email, Is.False);
            Assert.That(clonedEmail != email, Is.True);
        }

        [Test]
        public void EqualityOperator_WithUpdatedClonedEmailType_ShouldNotBeEqualToOriginal()
        {
            var clonedEmail = email.Clone();

            clonedEmail.Type = EmailType.Work;

            // Confirm consistency between comparison operators
            Assert.That(clonedEmail == email, Is.False);
            Assert.That(clonedEmail != email, Is.True);
        }
    }
}