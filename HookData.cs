namespace ReactNet;


public interface HookData;

public class UseStateHookData<T>(T currentValue) : HookData
{
	public T Value => currentValue;
}

public class UseEffectHookData(int dependencies) : HookData
{
	public int Dependencies => dependencies;
}

