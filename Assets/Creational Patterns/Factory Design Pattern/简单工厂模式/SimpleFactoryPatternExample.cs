//-------------------------------------------------------------------------------------
// Title: 简单工厂模式
// Author: Aladdin
// Tips: 演示最基本的简单工厂模式
// More: http://dingxiaowei.cn/tags/设计模式/
//-------------------------------------------------------------------------------------



using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public enum WeaponType
{
    None = 0,
    EPistol,
    ERifle
}

public class WeaponFactory
{
    public Weapon Create(WeaponType type, string name)
    {
        Weapon weapon = null;
        switch (type)
        {
            case WeaponType.EPistol:
                weapon = new Pistol(name);
                break;
            case WeaponType.ERifle:
                weapon = new Rifle(name);
                break;
        }
        return weapon;
    }
}

public class SimpleFactoryPatternExample : MonoBehaviour
{
    void Start()
    {
        WeaponFactory weaponFactory = new WeaponFactory();
        Weapon weapon1 = weaponFactory.Create(WeaponType.EPistol, "王八盒子");
        Weapon weapon2 = weaponFactory.Create(WeaponType.ERifle, "AK47");
    }
}
