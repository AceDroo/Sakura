using FluentAssertions;
using NSubstitute;
using Sakura.Core;
using Sakura.Races;
using Sakura.Units;

namespace Sakura.Tests;

[TestFixture]
public class RandomUnitGeneratorShould
{
    [SetUp]
    public void Setup()
    {
        _raceDataProvider = Substitute.For<IRaceDataProvider>();
        _random = Substitute.For<Random>();
        _unitGenerator = new RandomUnitGenerator(_raceDataProvider, _random);

        _race = new Race(
            "Human",
            ["John", "Jane"],
            ["Doe", "Smith"],
            ["Male", "Female"],
            new RangedInt(80, 120),
            new RangedInt(70, 110),
            new RangedInt(60, 100),
            new RangedInt(50, 90));
        _raceDataProvider.GetAll().Returns([_race]);
    }

    private RandomUnitGenerator _unitGenerator;
    private IRaceDataProvider _raceDataProvider;
    private Random _random;
    private Race _race;

    [Test]
    public void Generate_Unit()
    {
        _random.Next(0, _race.FirstNames.Length).Returns(0);
        _random.Next(0, _race.LastNames.Length).Returns(1);
        _random.Next(0, _race.Genders.Length).Returns(0);
        _random.Next(80, 120).Returns(100);
        _random.Next(70, 110).Returns(80);
        _random.Next(60, 100).Returns(85);
        _random.Next(50, 90).Returns(76);

        var unit = _unitGenerator.Generate();

        unit.Identity.Should().NotBeNull();
        unit.Identity.FirstName.Should().Be("John");
        unit.Identity.LastName.Should().Be("Doe");
        unit.Identity.Gender.Should().Be("Male");
        unit.Identity.Race.Should().Be("Human");

        unit.Stats.Should().NotBeNull();
        unit.Stats.Health.Should().Be(100);
        unit.Stats.Accuracy.Should().Be(80);
        unit.Stats.Defense.Should().Be(85);
        unit.Stats.Speed.Should().Be(76);

        unit.Appearance.Should().NotBeNull();
        unit.Appearance.Should().BeEquivalentTo(new UnitAppearance(0, 0, 0, 0, 0));
    }
}