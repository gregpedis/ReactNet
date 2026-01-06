namespace ReactNet;


public interface HookData;

public class UseStateHookData<T>(T currentValue) : HookData
{
	public T Value => currentValue;
}

public class UseEffectHookData(Action callback, int dependencies) : HookData
{
	public Action Callback => callback;
	public int Dependencies => dependencies;
}

