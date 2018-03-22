using System;
using ObjectEqualityDemo.Framework;

namespace ObjectEqualityDemo.Domain
{
    public class Email : IClonable<Email>
    {
        public string Address { get; set; }

        public EmailType Type { get; set; }

        public Email Clone()
        {
            var newEmail = new Email()
            {
                Address = this.Address,
                Type = this.Type
            };

            return newEmail;
        }

        public override int GetHashCode()
        {
            return Address.GetHashCode() + Type.GetHashCode();
        }

        public override bool Equals(object obj)
        {
            var anotherEmail = obj as Email;

            return IsEqual(anotherEmail, this);
        }

        public static bool operator ==(Email email1, Email email2)
        {
            return IsEqual(email1, email2);
        }

        public static bool operator !=(Email email1, Email email2)
        {
            return !IsEqual(email1, email2);
        }

        static bool IsEqual(Email email1, Email email2)
        {
            // Is the same object ?
            if (ReferenceEquals(email1, email2)) return true;

            // Is either parameter null ?
            if (ReferenceEquals(null, email1) || ReferenceEquals(null, email2)) return false;

            // Is any property different between the objects ?
            if (email1.Address != email2.Address) return false;
            if (email1.Type != email2.Type) return false;

            return true;
        }
    }

    public enum EmailType
    {
        Personal,
        Work
    }
}
