using System;
namespace ObjectEqualityDemo.Framework
{
    public interface IClonable<T>
    {
        T Clone();
    }
}
