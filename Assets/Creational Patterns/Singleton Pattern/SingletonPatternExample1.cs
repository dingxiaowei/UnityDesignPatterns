//-------------------------------------------------------------------------------------
// Title: 单例模式
// Author: Aladdin
// Tips: 演示最基本的饿汉式单例模式
// More: http://dingxiaowei.cn/tags/设计模式/
//-------------------------------------------------------------------------------------


using UnityEngine;

public class SingletonPatternExample1 : MonoBehaviour
{
    void Start()
    {
        //饿汉式(静态变量)
        Singleton1 instance1 = Singleton1.GetInstance();
        Singleton1 instance2 = Singleton1.GetInstance();
        Debug.Log(string.Format("instance1和instance2是否相等:{0}", instance1 == instance2));
        Debug.Log("instance1的hashCode：" + instance1.GetHashCode() + "     instance2的hashCode:" + instance2.GetHashCode());
    }
}

//饿汉式(静态变量)
public class Singleton1
{
    //构造器私有化，外部不能new，不写这个构造函数则会默认有一个公有的构造函数，外部就可以new，这样不符合单例模式
    private Singleton1()
    {

    }
    //在内部创建一个实例对象
    private static Singleton1 instance = new Singleton1();

    //提供一个公有的静态方法，返回实例对象
    public static Singleton1 GetInstance()
    {
        return instance;
    }
}

//饿汉式2
public class Singleton2
{
    private static Singleton2 instance;

    //将实例化放在私有构造函数里面
    private Singleton2()
    {
        instance = new Singleton2();
    }

    //提供一个公有的静态方法，返回实例对象
    public static Singleton2 GetInstance()
    {
        return instance;
    }
}

//饿汉式
public class Singleton3
{
    private Singleton3() { }
    private static Singleton3 instance = null;
    public static Singleton3 Instance
    {
        get
        {
            if (instance == null)
                instance = new Singleton3();
            return instance;
        }
    }
}

