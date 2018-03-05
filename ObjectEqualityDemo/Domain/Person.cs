using System;
using System.Collections.Generic;
using ObjectEqualityDemo.Framework;
using ObjectEqualityDemo.Framework.ExtensionMethods;

namespace ObjectEqualityDemo.Domain
{
    public class Person : IClonable<Person>
    {
        public string Name { get; set; }
        public string LastName { get; set; }
        public string PhoneNumber { get; set; }
        public ICollection<Email> Email { get; set; }
        public RelationshipType Relationship { get; set; }

        public Person Clone()
        {
            var newPerson = new Person()
            {
                Name = this.Name,
                LastName = this.LastName,
                PhoneNumber = this.PhoneNumber,
                Email = new List<Email>(this.Email),
                Relationship = this.Relationship
            };

            return newPerson;
        }

        public override int GetHashCode()
        {
            return Name?.GetHashCode() ?? 0 +
                        LastName?.GetHashCode() ?? 0 +
                        PhoneNumber?.GetHashCode() ?? 0 +
                        Email?.GetHashCode() ?? 0 +
                        Relationship.GetHashCode();
        }

        public override bool Equals(object obj)
        {
            var anotherPerson = obj as Person;

            return IsEqual(anotherPerson, this);
        }

        public static bool operator ==(Person person1, Person person2)
        {
            return IsEqual(person1, person2);
        }

        public static bool operator !=(Person person1, Person person2)
        {
            return !IsEqual(person1, person2);
        }

        static bool IsEqual(Person person1, Person person2)
        {
            // Is the same object ?
            if (ReferenceEquals(person1, person2)) return true;

            // Is either parameter null ?
            if (ReferenceEquals(null, person1) || ReferenceEquals(null, person2)) return false;

            // Is any property different between the objects ?
            if (person1.Name != person2.Name) return false;
            if (person1.LastName != person2.Name) return false;
            if (person1.Relationship != person2.Relationship) return false;
            if (!person1.Email.IsEqual(person2.Email)) return false;
            if (person1.Relationship != person2.Relationship) return false;

            return true;
        }
    }
}
