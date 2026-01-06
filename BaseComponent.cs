namespace ReactNet;

abstract class BaseComponent
{
	int _hookIndex = 0;
	private List<HookData> _hooks = new();

	protected abstract void Render();

	protected void UseEffect(Action effect, List<object> dependencies)
	{
		ColorConsole.WriteLineEffect($"UseEffect called. Index [{_hookIndex}]");
		var currentIndex = _hookIndex;
		_hookIndex++;

		if (currentIndex >= _hooks.Count)
		{
			ColorConsole.WriteLineEffect("First time seeing this effect hook called.");
			_hooks.Add(new UseEffectHookData(dependencies.GetHashCode()));
			effect();
		}
		else if (hasChanged())
		{
			ColorConsole.WriteLineEffect("Wait a minute, I need to run this UseEffect!");
			_hooks[currentIndex] = new UseEffectHookData(dependencies.GetHashCode());
			effect();
		}

		bool hasChanged()
		{
			ColorConsole.WriteLineEffect("Checking if we need to run this UseEffect or not.");
			var hookData = _hooks[currentIndex] as UseEffectHookData;
			return hookData.Dependencies != dependencies.GetHashCode();
		}
	}

	protected (T state, Action<T> setState) UseState<T>(T initialValue)
	{
		ColorConsole.WriteLineState($"UseState called. Index [{_hookIndex}]");
		var currentIndex = _hookIndex;
		_hookIndex++;

		if (currentIndex >= _hooks.Count)
		{
			ColorConsole.WriteLineState($"First time seeing this state hook called. Initializing it with: [{initialValue}]");
			_hooks.Add(new UseStateHookData<T>(initialValue));
		}

		Action<T> setter = (newValue) =>
		{
			ColorConsole.WriteLineState($"Time for some GOTOs. Let's go to the beginning after setting whatever this is to [{newValue}]");
			_hooks[currentIndex] = new UseStateHookData<T>(newValue);
			ForceRender();
		};

		ColorConsole.WriteLineState($"Returning from UseState, giving the user the current value and an over-engineered mental asylum setter.");
		var hookData = _hooks[currentIndex] as UseStateHookData<T>;
		return (hookData.Value, setter);
	}

	private void ForceRender()
	{
		ColorConsole.WriteLineHeader("GOTO");
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
