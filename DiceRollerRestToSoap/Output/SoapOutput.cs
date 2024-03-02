using DiceRollerRESTToSoap.Input;
using System.Runtime.Serialization;

namespace DiceRollerRESTToSoap.Output
{
    [DataContract]
    public class SoapOutput
    {
        [DataMember]
        public int sum { get; set; }
        public int count { get; set; }
        public double average { get; set; }
    }
}
