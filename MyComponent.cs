namespace ReactNet;

internal class MyComponent : BaseComponent
{
	public MyComponent()
	{
		Render();
	}


	protected override void Render()
	{
		ColorConsole.WriteLine("Render triggered.", ConsoleColor.Yellow);

		var (money, setMoney) = UseState(42);
		var (amIDrunk, setAmIDrunk) = UseState(true);

		UseEffect(() =>
			{
				if (money > 0)
				{
					ColorConsole.WriteLineUser("I will invest all my money on TrumpCoin!!!");
					setMoney(0);
					ColorConsole.WriteLineUser("I invested it!!!");
				}
				else
				{
					ColorConsole.WriteLineUser("WTF I am broke!!!");
					if (amIDrunk)
					{
						SoberUpAndStopDonatingToTrump();
					}
					setAmIDrunk(false);
				}
			},
			[money, amIDrunk]);
	}


	void SoberUpAndStopDonatingToTrump()
	{
		// ignore this sonar come on leave me alone
	}
}
