//-------------------------------------------------------------------------------------
// Title: 原型模式模式
// Author: Aladdin
// Tips: 演示.NetFramework中使用到原型模式实现深浅拷贝
// More: http://dingxiaowei.cn/tags/设计模式/
//-------------------------------------------------------------------------------------

using System;
using System.Collections;
using System.Collections.Generic;
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
    }
}
