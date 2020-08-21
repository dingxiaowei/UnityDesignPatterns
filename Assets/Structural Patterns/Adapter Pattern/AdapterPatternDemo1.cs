using UnityEngine;

public class CD //来自外部的sdk，无法修改它的代码
{
    public static void StaticFunction1()
    {
        Debug.Log("CD StaticFunction1");
    }
    public void TestFunction2()
    {
        Debug.Log("CD TestFunction2");
    }
}

public interface ITarget
{
    void Function1();
    void Function2();
}

public class CDAdaptor : CD, ITarget
{
    public void Function1()
    {
        StaticFunction1();
    }

    public void Function2()
    {
        base.TestFunction2();
    }
}

public class AdapterPatternDemo1 : MonoBehaviour
{
    void Start()
    {
        CDAdaptor cdAdaptor = new CDAdaptor();
        cdAdaptor.Function1();
        cdAdaptor.Function2();
    }
}
