using FluentAssertions;
using Sakura.Status;

namespace Sakura.Tests.Status;

[TestFixture]
public class StatShould
{
    [Test]
    public void Reduce_Value()
    {
        var stat = new Stat("Test", 5, 10);
        stat.Decrease(3);
        stat.Value.Should().Be(2);
    }

    [Test]
    public void Increase_Value()
    {
        var stat = new Stat("Test", 5, 10);
        stat.Increase(3);
        stat.Value.Should().Be(8);
    }

    [Test]
    public void Not_Go_Below_Zero_When_Decreasing()
    {
        var stat = new Stat("Test", 5, 10);
        stat.Decrease(100);
        stat.Value.Should().Be(0);
    }

    [Test]
    public void Not_Go_Above_Max_When_Increasing()
    {
        var stat = new Stat("Test", 5, 10);
        stat.Increase(100);
        stat.Value.Should().Be(10);
    }

    [Test]
    public void Set_Value_To_Max_When_Fill()
    {
        var stat = new Stat("Test", 5, 10);
        stat.Fill();
        stat.Value.Should().Be(10);
    }
}