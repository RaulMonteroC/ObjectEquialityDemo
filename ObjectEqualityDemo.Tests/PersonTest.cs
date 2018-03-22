using NUnit.Framework;
using ObjectEqualityDemo.Domain;
using System;
using System.Collections.Generic;
using System.Linq;

namespace ObjectEqualityDemo.Tests
{
    [TestFixture()]
    public class PersonTest
    {
        private Person person;

        [SetUp]
        public void Setup()
        {
            person = new Person()
            {
                Name = "Raúl",
                LastName = "Montero",
                PhoneNumber = "(809) 555-5555",
                Emails = new List<Email>()
                {
                    new Email { Address ="raul@personaldomain.com", Type = EmailType.Personal},
                    new Email { Address = "raulm@workdomain.com", Type = EmailType.Work}
                }
            };
        }

        [Test]
        public void HashCodeFromClone_WithChanges_ShouldBeDifferentFromOriginal()
        {
            var clonedPerson = person.Clone();

            clonedPerson.Name = "Updated Name";

            Assert.That(clonedPerson.GetHashCode() == person.GetHashCode(), Is.False);
        }

        [Test]
        public void HashCodeFromClone_WithoutChanges_ShouldBeEqualFromOriginal()
        {
            var clonedPerson = person.Clone();

            Assert.That(clonedPerson.GetHashCode() == person.GetHashCode(), Is.True);
        }

        [Test]
        public void Clone_ShouldReturnNewInstanceWithOldValue()
        {
            var clonedPerson = person.Clone();

            // Not the same instance
            Assert.That(Object.ReferenceEquals(clonedPerson, person.Clone()), Is.False);

            // Has the same values
            Assert.That(clonedPerson.Name == person.Name);
            Assert.That(clonedPerson == person, Is.True);
        }

        [Test]
        public void Equals_ShouldBeConsistentWithComparisonOperator()
        {
            var clonedPerson = person.Clone();

            // Same result is returned regardless of comparison method used.
            Assert.That(clonedPerson.Equals(person), Is.True);
            Assert.That(clonedPerson == person, Is.True);
            Assert.That(clonedPerson != person, Is.False);
        }

        [Test]
        public void EqualityOperator_WithUpdatedClonedPersonName_ShouldNotBeEqualToOriginal()
        {
            var clonedPerson = person.Clone();

            clonedPerson.Name = "Updated Name";

            // Confirm consistency between comparison operators
            Assert.That(clonedPerson == person, Is.False);
            Assert.That(clonedPerson != person, Is.True);
        }

        [Test]
        public void EqualityOperator_WithUpdatedClonedPersonLastName_ShouldNotBeEqualToOriginal()
        {
            var clonedPerson = person.Clone();

            clonedPerson.LastName = "Updated LastName";

            // Confirm consistency between comparison operators
            Assert.That(clonedPerson == person, Is.False);
            Assert.That(clonedPerson != person, Is.True);
        }

        [Test]
        public void EqualityOperator_WithUpdatedClonedPhoneNumber_ShouldNotBeEqualToOriginal()
        {
            var clonedPerson = person.Clone();

            clonedPerson.PhoneNumber = "(999)999-9999";

            // Confirm consistency between comparison operators
            Assert.That(clonedPerson == person, Is.False);
            Assert.That(clonedPerson != person, Is.True);
        }

        [Test]
        public void EqualityOperator_WithNewEmailOnClonedPerson_ShouldNotBeEqualToOriginal()
        {
            var clonedPerson = person.Clone();

            clonedPerson.Emails.Add(new Email { Address = "raul@somedomain.com", Type = EmailType.Personal });

            // Confirm consistency between comparison operators
            Assert.That(clonedPerson == person, Is.False);
            Assert.That(clonedPerson != person, Is.True);
        }

        [Test]
        public void EqualityOperator_WithUpdatedClonedPersonEmail_ShouldNotBeEqualToOriginal()
        {
            var clonedPerson = person.Clone();

            clonedPerson.Emails.FirstOrDefault().Address = "raul@somedomain.com";

            // Confirm consistency between comparison operators
            Assert.That(clonedPerson == person, Is.False);
            Assert.That(clonedPerson != person, Is.True);
        }

        [Test]
        public void EqualityOperator_WithNullClonedPersonEmail_ShouldNotBeEqualToOriginal()
        {
            var clonedPerson = person.Clone();

            clonedPerson.Emails = null;

            // Confirm consistency between comparison operators
            Assert.That(clonedPerson == person, Is.False);
            Assert.That(clonedPerson != person, Is.True);
        }
    }
}
