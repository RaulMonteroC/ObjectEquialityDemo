using System;
namespace ObjectEqualityDemo.Domain
{
    public class Email
    {
        public string Address { get; set; }

        public EmailType Type { get; set; }
    }

    public enum EmailType
    {
        Personal,
        Work
    }
}
