namespace ReactNet;

abstract class BaseComponent
{
	protected abstract void Render();

	protected void UseEffect(Action effect, List<object> dependencies)
	{
		ColorConsole.WriteLineEffect("UseEffect called.");
	}

	protected (T state, Action<T> setState) UseState<T>(T initialValue)
	{
		ColorConsole.WriteLineState("UseState called.");
		return (initialValue, default);
	}


	//protected void UseMemo()
	//{
	//	ColorConsole.WriteLineMemo("UseMemo called.");
	//}

	//protected void UseCallback()
	//{
	//	ColorConsole.WriteLineCallback("UseCallback called.");
	//}

}
