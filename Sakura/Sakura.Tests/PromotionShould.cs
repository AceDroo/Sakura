using FluentAssertions;

namespace Sakura.Tests;

[TestFixture]
public class PromotionShould
{
	private Promotion _promotion;
	private Soldier _soldier;

	[SetUp]
	public void Setup()
	{
		_soldier = new Soldier();
		_promotion = new Promotion([
			new RankInfo(Rank.Squaddie, 100),
			new RankInfo(Rank.Corporal, 200)
		]);
	}

	[Test]
	public void Promote_Soldier_To_Next_Rank_When_Experience_Threshold_Reached()
	{
		_soldier.AddExperience(100);

		_promotion.AttemptPromotion(_soldier);

		_soldier.Rank.Should().Be(Rank.Squaddie);
	}

	[Test]
	public void Not_Promote_Soldier_When_Experience_Threshold_Not_Reached()
	{
		_soldier.AddExperience(99);

		_promotion.AttemptPromotion(_soldier);

		_soldier.Rank.Should().Be(Rank.Rookie);
	}

	[Test]
	public void Not_Overpromote_Soldier()
	{
		_soldier.AddExperience(120);

		_promotion.AttemptPromotion(_soldier);

		_soldier.Rank.Should().Be(Rank.Squaddie);
	}
}