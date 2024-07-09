using System;
using System.Collections.Generic;
using System.ServiceModel;

namespace SampleWebService
{
    [ServiceContract]
    public interface ITestService
    {
        [OperationContract]
        string Echo(string message);

        [OperationContract]
        Person[] GetPeople();
    }
}
