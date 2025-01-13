using NSubstitute;
using NSubstitute.Core.Arguments;
using UnitsNet;

namespace EmergencyBrakeService.Tests;

public class BrakeServiceTests
{
    public interface ILogger
    {
         void Write(string str);
    }


    [Fact]
    public void Test1()
    {
        var mock = Substitute.For<ILogger>();

        mock.When(x=>x.Write(Arg.Any<string>()))
            .Do(x => Console.WriteLine(x.Arg<string>()));

        //make a stub of icalculator


        var val = mock.Add(1, 2);
    }
}
