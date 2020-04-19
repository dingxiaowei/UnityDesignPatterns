//-------------------------------------------------------------------------------------
// Title: 原型模式模式
// Author: Aladdin
// Tips: 演示.NetFramework中使用到原型模式实现深浅拷贝
// More: http://dingxiaowei.cn/tags/设计模式/
//-------------------------------------------------------------------------------------

using System;
using System.IO;
using System.Runtime.Serialization;
using System.Runtime.Serialization.Formatters.Binary;
using UnityEngine;

[Serializable]
public class Job
{
    public int Id { get; set; }
    public string JobName { get; set; }
    public override string ToString()
    {
        return this.JobName;
    }
}

[Serializable]
public class Person : ICloneable
{
    public int Age { get; set; }    //值类型字段
    public string Name { get; set; }    //字符串
    public Job Job { get; set; }        //引用类型字段
    //深拷贝
    public Person DeepClone()
    {
        using (Stream objectStream = new MemoryStream())
        {
            IFormatter formatter = new BinaryFormatter();
            formatter.Serialize(objectStream, this);
            objectStream.Seek(0, SeekOrigin.Begin);
            return formatter.Deserialize(objectStream) as Person;
        }
    }

    public object Clone()
    {
        return this.MemberwiseClone();//淺拷贝
    }

    //浅拷贝
    public Person ShallowClone()
    {
        return this.Clone() as Person;
    }
}


//代码优化
[Serializable]
public class Person1 : BaseClone<Person1>
{
    public int Age { get; set; }
    public string Name { get; set; }
    public Job Job { get; set; }
}

//最常见的深拷贝
public class Character
{
    public int Id { get; set; }
    public string Name { get; set; }

    public bool IsAvatar { get; set; }

    public Character DeepClone()
    {
        Character character = new Character();
        character.Id = this.Id;
        character.Name = this.Name;
        character.IsAvatar = this.IsAvatar;
        return character;
    }
}

//通用深拷贝基类
[Serializable]
public class BaseClone<T> : ICloneable where T : new()
{
    //浅拷贝
    public virtual T ShallowClone()
    {
        return (T)this.Clone();
    }

    //深拷贝
    public virtual T DeepClone()
    {
        try
        {
            using (Stream memoryStream = new MemoryStream())
            {
                BinaryFormatter formatter = new BinaryFormatter();
                formatter.Serialize(memoryStream, this);
                memoryStream.Position = 0;
                return (T)formatter.Deserialize(memoryStream);
            }
        }
        catch (Exception ex)
        {
            Debug.LogError("克隆异常:" + ex.ToString());
        }
        return default(T);
    }

    public object Clone()
    {
        return this.MemberwiseClone();//淺拷贝
    }
}

public class PropertyPatternExample1 : MonoBehaviour
{
    void Start()
    {
        Person p = new Person() { Name = "P", Age = 21, Job = new Job() { JobName = "Coder", Id = 1001 } };
        Person p1 = p.ShallowClone();
        Person p2 = p.DeepClone();
        string Str = string.Format("修改前：p.Name={0},p.Age={1},p.Job.Id={2},p.Job.JobName={3}", p.Name, p.Age, p.Job.Id, p.Job.JobName);
        Debug.Log(Str);
        Str = string.Format("修改前：p1.Name={0},p1.Age={1},p.Job.Id={2},p1.Job.JobName={3}", p1.Name, p1.Age, p1.Job.Id, p1.Job.JobName);
        Debug.Log(Str);
        Str = string.Format("修改前：p2.Name={0},p2.Age={1},p.Job.Id={2},p2.Job.JobName={3}", p2.Name, p2.Age, p2.Job.Id, p2.Job.JobName);
        Debug.Log(Str);

        //修改P1的值
        p1.Name = "PM";
        p1.Age = 30;
        p1.Job.JobName = "Manager";
        p1.Job.Id = 1002;

        Str = string.Format("修改后：p.Name={0},p.Age={1},p.Job.Id={2},p.Job.JobName={3}", p.Name, p.Age, p.Job.Id, p.Job.JobName);
        Debug.Log(Str);
        Str = string.Format("修改后：p1.Name={0},p1.Age={1},p1.Job.Id={2},p1.Job.JobName={3}", p1.Name, p1.Age, p1.Job.Id, p1.Job.JobName);
        Debug.Log(Str);
        Str = string.Format("修改后：p2.Name={0},p2.Age={1},p2.Job.Id={2},p2.Job.JobName={3}", p2.Name, p2.Age, p2.Job.Id, p2.Job.JobName);
        Debug.Log(Str);

        Debug.Log("*******************************************测试通用Clone******************************************************************");

        Person1 newP = new Person1() { Name = "newP", Age = 21, Job = new Job() { JobName = "Coder", Id = 1001 } };
        Person1 newP2 = newP.DeepClone();

        Str = string.Format("修改前：newP.Name={0},newP.Age={1},newP.Job.Id={2},newP.Job.JobName={3}", newP.Name, newP.Age, newP.Job.Id, newP.Job.JobName);
        Debug.Log(Str);
        Str = string.Format("修改前：newP2.Name={0},newP2.Age={1},newP2.Job.Id={2},newP2.Job.JobName={3}", newP2.Name, newP2.Age, newP2.Job.Id, newP2.Job.JobName);
        Debug.Log(Str);

        newP2.Name = "PM";
        newP2.Age = 30;
        newP2.Job.JobName = "Manager";
        newP2.Job.Id = 1002;

        Str = string.Format("修改前：newP.Name={0},newP.Age={1},newP.Job.Id={2},newP.Job.JobName={3}", newP.Name, newP.Age, newP.Job.Id, newP.Job.JobName);
        Debug.Log(Str);
        Str = string.Format("修改后：newP2.Name={0},newP2.Age={1},newP2.Job.Id={2},newP2.Job.JobName={3}", newP2.Name, newP2.Age, newP2.Job.Id, newP2.Job.JobName);
        Debug.Log(Str);
    }
}
