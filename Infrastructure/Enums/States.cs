using System.Runtime.Serialization;

namespace Infrastructure.Enums
{
    
    public enum States
    {
        [EnumMember(Value = "Arkansas")]
        Arka = 0,
        [EnumMember(Value = "SomeState")]
        Some = 1,
        [EnumMember(Value = "SecondState")]
        Second = 2,
    }
}
