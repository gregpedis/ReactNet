namespace ReactNet;

abstract class BaseComponent
{
	int _hookIndex = 0;
	private List<HookData> _hooks = new();

	protected abstract void Render();

	protected void UseEffect(Action effect, List<object> dependencies)
	{
		ColorConsole.WriteLineEffect("UseEffect called.");
	}

	protected (T state, Action<T> setState) UseState<T>(T initialValue)
	{
		ColorConsole.WriteLineState("UseState called.");

		var currentIndex = _hookIndex;
		_hookIndex++;

		if (currentIndex >= _hooks.Count)
		{
			ColorConsole.WriteLineState($"First time seeing this hook called. Initializing it with: [{initialValue}].");
			_hooks.Add(new UseStateHookData<T>(initialValue));
		}

		Action<T> setState = (newValue) =>
		{
			ColorConsole.WriteLineState($"Time for some GOTOs. Let's go to the beginning after setting whatever this is to [{newValue}].");
			_hooks[currentIndex] = new UseStateHookData<T>(newValue);
			ForceRender();
		};

		ColorConsole.WriteLineState($"Returning from UseState, giving the user the current value and an over-engineered mental asylum setter.");
		var state = (_hooks[currentIndex] as UseStateHookData<T>).Value;
		return (state, setState);
	}


	private void ForceRender()
	{
		_hookIndex = 0;
		Render();
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
