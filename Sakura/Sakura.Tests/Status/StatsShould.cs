using FluentAssertions;
using Sakura.Status;

namespace Sakura.Tests.Status;

[TestFixture]
public class StatsShould
{
    [Test]
    public void Successfully_Add_Stat()
    {
        var stats = new Stats();
        var stat = new Stat("Test", 10, 20);

        stats.Add(stat);

        stats.Should().Contain(stat);
    }

    [Test]
    public void Successfully_Add_Stat_With_Name_And_Value()
    {
        var stats = new Stats();

        stats.Add("Test", 10);

        stats.Count().Should().Be(1);
        stats["Test"].Value.Should().Be(10);
    }

    [Test]
    public void Successfully_Add_Stat_With_Name_And_Value_And_Max()
    {
        var stats = new Stats();

        stats.Add("Test", 10, 20);

        stats.Count().Should().Be(1);
        stats["Test"].Value.Should().Be(10);
        stats["Test"].Max.Should().Be(20);
    }

    [Test]
    public void Successfully_Fill_Stats()
    {
        var stats = new Stats
        {
            new("Test1", 10, 20),
            new("Test2", 5, 10)
        };

        stats.Fill();

        stats["Test1"].Value.Should().Be(20);
        stats["Test2"].Value.Should().Be(10);
    }

    [Test]
    public void Return_Correct_Stat_When_Retrieving_Using_Indexer()
    {
        var stat = new Stat("Test", 10, 20);
        var stats = new Stats
        {
            stat
        };

        var retrievedStat = stats["Test"];

        retrievedStat.Should().Be(stat);
    }

    [Test]
    public void Return_Null_When_Retrieving_Using_Indexer()
    {
        var stats = new Stats();

        var retrievedStat = stats["NonExisting"];

        retrievedStat.Should().BeNull();
    }

    [Test]
    public void Update_Existing_Stat_Using_Indexer()
    {
        var stat = new Stat("Test", 10, 20);
        var stats = new Stats { stat };

        stats["Test"] = new Stat("Test", 15, 25);

        stat.Value.Should().Be(15);
        stat.Max.Should().Be(25);
    }

    [Test]
    public void Indexer_SetNonExistingName_DoesNothing()
    {
        var stat = new Stat("Test", 10, 20);
        var stats = new Stats { stat };

        var newStat = new Stat("NonExisting", 15, 25);

        stats["NonExisting"] = newStat;

        stats["NonExisting"].Should().NotBe(newStat);
    }
}