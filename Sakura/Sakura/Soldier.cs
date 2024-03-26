namespace Sakura;

public class Soldier
{
	public void AddExperience(int amount)
	{
		Experience += amount;
	}

	public Rank Rank { get; set; }
	public int Experience { get; set; }
}