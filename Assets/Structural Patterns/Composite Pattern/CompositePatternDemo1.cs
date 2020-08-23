using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public abstract class IComponent
{
    protected string mValue;
    public abstract void Operation();

    public virtual void Add(IComponent component)
    {
        Debug.LogWarning("子类没有实现添加操作");
    }

    public virtual void Remove(IComponent component)
    {
        Debug.LogWarning("子类没有实现移除操作");
    }

    public virtual IComponent GetChild(int index)
    {
        Debug.LogWarning("子类没有实现获取方法");
        return null;
    }
}

public class Composite : IComponent
{
    List<IComponent> mChilds = new List<IComponent>();
    public Composite(string value)
    {
        mValue = value;
    }
    public override void Operation()
    {
        Debug.Log("Composite[" + mValue + "]");
        foreach (var com in mChilds)
        {
            com.Operation();
        }
    }

    public override void Add(IComponent component)
    {
        mChilds.Add(component);
    }

    public override void Remove(IComponent component)
    {
        mChilds.Remove(component);
    }

    public override IComponent GetChild(int index)
    {
        return mChilds[index];
    }
}

public class Leaf : IComponent
{
    public Leaf(string value)
    {
        mValue = value;
    }
    public override void Operation()
    {
        Debug.Log($"Leaf[{mValue}]执行Operation");
    }
}

public class CompositePatternDemo1 : MonoBehaviour
{
    void Start()
    {
        IComponent root = new Composite("Root");
        root.Add(new Leaf("Leaf1"));
        root.Add(new Leaf("Leaf2"));

        //子节点1
        IComponent child1 = new Composite("Child1");
        child1.Add(new Leaf("Child1.Leaf1"));
        child1.Add(new Leaf("Child1.Leaf2"));
        root.Add(child1);

        //子节点2
        IComponent child2 = new Composite("Child2");
        child2.Add(new Leaf("Child2.Leaf1"));
        child2.Add(new Leaf("Child2.Leaf2"));
        root.Add(child2);

        //显示
        root.Operation();
    }
}
