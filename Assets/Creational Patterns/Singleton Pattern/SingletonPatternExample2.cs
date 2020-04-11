//-------------------------------------------------------------------------------------
// Title: 单例模式
// Author: Aladdin
// Tips: 演示最基本的懒汉式单例模式
// More: http://dingxiaowei.cn/tags/设计模式/
//-------------------------------------------------------------------------------------


using UnityEngine;

public class SingletonPatternExample2 : MonoBehaviour
{
    void Start()
    {
        //懒汉式
        Singleton4 instance4 = Singleton4.GetInstance();
    }
}


//懒汉式
public class Singleton4
{
    private static Singleton4 instance;
    private Singleton4() { }

    //提供静态公有方法返回实例对象
    public static Singleton4 GetInstance()
    {
        //需要用到的时候再实例化单例对象，即懒汉式
        if (instance == null)
        {
            instance = new Singleton4();
        }
        return instance;
    }
}

//懒汉式(线程安全，同步方法)
public class Singleton5
{
    private Singleton5() { }

    private static readonly object syncObj = new object();
    private static Singleton5 instance = null;
    public static Singleton5 Instance
    {
        get
        {
            lock (syncObj)     //添加同步锁
            {
                if (instance == null)
                    instance = new Singleton5();
            }
            return instance;
        }
    }
}

// 懒汉式(双重检测) 推荐写法
public class Singleton6
{
    private Singleton6() { }

    private static readonly object syncObj = new object();
    private static Singleton6 instance = null;
    public static Singleton6 Instance
    {
        get
        {
            //双重检测提高效率
            if (instance == null)
            {
                lock (syncObj)     //添加同步锁
                {
                    if (instance == null)
                        instance = new Singleton6();
                }
            }
            return instance;
        }
    }
}