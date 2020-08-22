using System.Collections;
using System.Collections.Generic;
using UnityEngine;

//老日志模块
public class DbLog
{
    public void Log(string context)
    {
        Debug.Log($"write db log：{context}");
    }
}

//新的接口标准
public interface ILogService
{
    void Log(string context);
}

public class FileLog : ILogService
{
    public void Log(string context)
    {
        Debug.Log($"write file log:{context}");
    }
}

//让老的DbLog兼容新的接口
public class LogAdapter : ILogService
{
    DbLog dbLog = new DbLog();
    public void Log(string context)
    {
        dbLog.Log(context);
    }
}

public class AdapterPatternDemo4 : MonoBehaviour
{
    void Start()
    {
        string context = "xxx";
        ILogService logService = new FileLog();
        logService.Log(context);

        logService = new LogAdapter();
        logService.Log(context);
    }
}
