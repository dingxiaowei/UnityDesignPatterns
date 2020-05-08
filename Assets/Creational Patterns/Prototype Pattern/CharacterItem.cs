using System;
using UnityEngine;

[System.Serializable]
public class Attributes : ICloneable
{
    [Tooltip("角色血量")]
    public int hp;
    [Tooltip("物理攻击")]
    public int pAtk;
    [Tooltip("物理防御")]
    public int pDef;
    [Tooltip("魔法攻击")]
    public int mAtk;
    [Tooltip("魔法防御")]
    public int mDef;
    [Tooltip("行动速度")]
    public int spd;

    public GameObject model;

    public object Clone()
    {
        return this.MemberwiseClone();
    }

    public Person ShallowClone()
    {
        return this.Clone() as Person;
    }

    public Attributes DeepClone()
    {
        Attributes result = new Attributes();
        result.hp = hp;
        result.pAtk = pAtk;
        result.pDef = pDef;
        result.mAtk = mAtk;
        result.mDef = mDef;
        result.spd = spd;
        return result;
    }

    public override string ToString()
    {
        return string.Format("hp:{0},pAtk:{1} ...", hp, pAtk);
    }
}

[CreateAssetMenu(fileName = "CharacterItem", menuName = "(ScriptableObject)CharacterItem")]
public class CharacterItem : ScriptableObject
{
    public string Name;
    public string Desc;
    [Tooltip("角色属性")]
    public Attributes Attributes;
}
