using System.ServiceModel;

namespace SampleWebService
{
    [ServiceBehavior(Name = "Test", InstanceContextMode = InstanceContextMode.PerSession)]
    public class TestService : ITestService
    {
        private readonly Person[] People = new Person[]
        {
            new Person() { Id = 1, Firstname = "Jack", Lastename = "Shephard" },
            new Person() { Id = 2, Firstname = "Kate", Lastename = "Austen" },
            new Person() { Id = 3, Firstname = "James", Lastename = "Ford" },
            new Person() { Id = 4, Firstname = "John", Lastename = "Locke" },
            new Person() { Id = 5, Firstname = "Hugo", Lastename = "Reyes" },
        };

        public string Echo(string message)
            => $"Input message is '{message}'";

        public Person[] GetPeople()
            => People;
    }
}
