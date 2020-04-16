//-------------------------------------------------------------------------------------
// Title: 抽象工厂模式
// Author: Aladdin
// Tips: 演示最基本的抽象工厂模式
// More: http://dingxiaowei.cn/tags/设计模式/
//-------------------------------------------------------------------------------------

using System.Collections;
using System.Collections.Generic;
using UnityEngine;

/// <summary>
/// 国家工厂基类
/// </summary>
public abstract class CountryWeaponFactoryBase
{
    string name;
    public WeaponFactoryBase RifleFactory;
    public WeaponFactoryBase PistolFactory;
    public virtual void InitFactory(string factoryName)
    {
        name = factoryName;
        RifleFactory = new RifleFactory();
        PistolFactory = new PistolFactory();
    }
    public abstract void CreateRifle(string name);
    public abstract void CreatePistol(string name);
}

/// <summary>
/// 中国武器工厂
/// </summary>
public class ChineseWeaponFactory : CountryWeaponFactoryBase
{
    public override void InitFactory(string factoryName)
    {
        base.InitFactory(factoryName);
        Debug.Log(string.Format("初始化{0},并做一些个性化设置",factoryName));
    }

    public override void CreatePistol(string name)
    {
        base.PistolFactory.CreateWeapon(name);
    }

    public override void CreateRifle(string name)
    {
        base.RifleFactory.CreateWeapon(name);
    }
}

/// <summary>
/// 美国武器工厂
/// </summary>
public class AmericanWeaponFactory : CountryWeaponFactoryBase
{
    public override void InitFactory(string factoryName)
    {
        base.InitFactory(factoryName);
        Debug.Log(string.Format("初始化{0},并做一些个性化设置", factoryName));
    }

    public override void CreatePistol(string name)
    {
        base.PistolFactory.CreateWeapon(name);
    }

    public override void CreateRifle(string name)
    {
        base.RifleFactory.CreateWeapon(name);
    }
}

public class AbstractFactoryPatternExample : MonoBehaviour
{
    void Start()
    {
        CountryWeaponFactoryBase chineseWeaponFactory = new ChineseWeaponFactory();
        chineseWeaponFactory.InitFactory("中国军工厂");
        chineseWeaponFactory.CreatePistol("92式手枪");
        chineseWeaponFactory.CreateRifle("95式自动步枪");

        CountryWeaponFactoryBase americanWeaponFactory = new AmericanWeaponFactory();
        americanWeaponFactory.InitFactory("美国武器工厂");
        americanWeaponFactory.CreatePistol("MK23手枪");
        americanWeaponFactory.CreateRifle("M-16步枪");
    }
}
