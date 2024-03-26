namespace Sakura;

public class Promotion(List<RankInfo> ranks)
{
	public void AttemptPromotion(Soldier soldier)
	{
		ranks.ForEach(rankInfo =>
		{
			if (!CanPromote(soldier, rankInfo)) return;
			soldier.Rank = rankInfo.Rank;
		});
	}

	private bool CanPromote(Soldier soldier, RankInfo rank)
	{
		return soldier.Experience >= rank.Threshold;
	}
}