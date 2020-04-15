//-------------------------------------------------------------------------------------
// Title: None工厂模式
// Author: Aladdin
// Tips: 演示不实用工厂模式创建各种武器对象
// More: http://dingxiaowei.cn/tags/设计模式/
//-------------------------------------------------------------------------------------



using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public abstract class Weapon
{
    public string Name { get; set; }
}

//手枪
public class Pistol : Weapon
{
    public Pistol(string name)
    {
        this.Name = name;
        Debug.Log(string.Format("这是一个{0}手枪", name));
    }
}

//步枪
public class Rifle : Weapon
{
    public Rifle(string name)
    {
        this.Name = name;
        Debug.Log(string.Format("这是一个{0}步枪", name));
    }
}

public class NoneFactoryDesignPatternExample : MonoBehaviour
{
    void Start()
    {
        Weapon weapon1 = new Pistol("王八盒子");
        Weapon weapon2 = new Rifle("AK47");
    }
}
