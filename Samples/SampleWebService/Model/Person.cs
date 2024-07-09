using System.Runtime.Serialization;

namespace SampleWebService
{
    [DataContract]
    public class Person 
    {
        [DataMember]
        public int Id { get; set; }

        [DataMember]
        public string Firstname { get; set; }

        [DataMember]
        public string Lastename { get; set; }
    }

}
