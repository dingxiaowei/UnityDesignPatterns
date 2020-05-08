//-------------------------------------------------------------------------------------
// Title: 原型模式模式
// Author: Aladdin
// Tips: 演示游戏开发中原型模式的典型应用角色实例化
// More: http://dingxiaowei.cn/tags/设计模式/
//-------------------------------------------------------------------------------------

using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class CharacterEntity
{
    public int id;
    public Attributes objectAttributes;
}

public class PropertyPatternExample2 : MonoBehaviour
{
    public CharacterItem CharDataModel;
    void Start()
    {
        CharacterEntity char1 = new CharacterEntity() { id = 0, objectAttributes = CharDataModel.Attributes.DeepClone() };
        CharacterEntity char2 = new CharacterEntity() { id = 1, objectAttributes = CharDataModel.Attributes.DeepClone() };
        Debug.Log("修改之前两个角色的属性:");
        Debug.Log("char1 property:" + char1.objectAttributes.ToString());
        Debug.Log("char2 property:" + char2.objectAttributes.ToString());

        Debug.Log("修改之后两个角色的属性");
        char1.objectAttributes.hp = 110;
        Debug.Log("char1 property:" + char1.objectAttributes.ToString());
        Debug.Log("char2 property:" + char2.objectAttributes.ToString());
    }
}
