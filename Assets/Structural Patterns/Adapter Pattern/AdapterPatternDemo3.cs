using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public interface IA
{
    void fa();
}

public class A : IA
{
    public void fa()
    {
        Debug.Log("A的fa方法");
    }
}

public class Demo
{
    private IA a;
    public Demo(IA a)
    {
        this.a = a;
    }

    public void Function()
    {
        a?.fa();
    }
}

public class B
{
    public void fb()
    {
        Debug.Log("B的fb方法");
    }
}

public class BAdaptor : IA
{
    private B b;
    public BAdaptor(B b)
    {
        this.b = b;
    }

    public void fa()
    {
        b.fb();
    }
}

public class AdapterPatternDemo3 : MonoBehaviour
{
    void Start()
    {
        Demo d = new Demo(new A());
        d.Function();
        //成功将A替换成B
        Demo newD = new Demo(new BAdaptor(new B()));
        newD.Function();
    }
}
