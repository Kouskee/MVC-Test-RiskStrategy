using System.Runtime.Serialization;
namespace Infrastructure.Enums
{
    
    public enum Cities
    {
        [EnumMember(Value = "Las Vegas")]
        LasVegas = 1,
        [EnumMember(Value = "San Jose")]
        SanJose = 2,
        [EnumMember(Value = "Denver")]
        Denv = 3,
        [EnumMember(Value = "Bentonville")]
        Bent = 101,
    }
}
