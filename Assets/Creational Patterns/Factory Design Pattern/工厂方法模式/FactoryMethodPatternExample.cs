//-------------------------------------------------------------------------------------
// Title: 工厂方法模式
// Author: Aladdin
// Tips: 演示最基本的工厂方法模式
// More: http://dingxiaowei.cn/tags/设计模式/
//-------------------------------------------------------------------------------------


using System.Collections;
using System.Collections.Generic;
using UnityEngine;
                                          \
/// <summary>
/// 武器工厂抽象基类
/// </summary>
public abstract class WeaponFactoryBase
{
    public abstract Weapon CreateWeapon(string name);
}

/// <summary>
/// 手枪生产工厂
/// </summary>
public class PistolFactory : WeaponFactoryBase
{
    public override Weapon CreateWeapon(string name)
    {
        return new Pistol(name);
    }
}

/// <summary>
/// 步枪生产工厂
/// </summary>
public class RifleFactory : WeaponFactoryBase
{
    public override Weapon CreateWeapon(string name)
    {
        return new Rifle(name);
    }
}

public class FactoryMethodPatternExample : MonoBehaviour
{
    void Start()
    {
        //生产一个手枪
        PistolFactory pistolFactory = new PistolFactory();
        pistolFactory.CreateWeapon("王八盒子");

        RifleFactory rifleFactory = new RifleFactory();
        rifleFactory.CreateWeapon("AK47");
    }
}
