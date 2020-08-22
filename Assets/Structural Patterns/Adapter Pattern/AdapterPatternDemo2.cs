using System.Collections;
using System.Collections.Generic;
using UnityEngine;
//A敏感词系统
public class ASensitiveWordsFilter
{
    public string FilterSexyWords(string text)
    {
        //...
        return string.Empty;
    }

    public string FilterPoliticalWords(string text)
    {
        //...
        return string.Empty;
    }
}
//B敏感词系统
public class BSensitiveWordsFilter
{
    public string Filter(string text)
    {
        //...
        return string.Empty;
    }
}
//C敏感词系统
public class CSensitiveWordsFilter
{
    public string Filter(string text, string mask)
    {
        //...
        return string.Empty;
    }
}

//未使用适配器之前代码：代码可测试性、扩展性不好
public class RiskManagement
{
    private ASensitiveWordsFilter aFilter = new ASensitiveWordsFilter();
    private BSensitiveWordsFilter bFilter = new BSensitiveWordsFilter();
    private CSensitiveWordsFilter cFilter = new CSensitiveWordsFilter();
    public string FilterSensitiveWords(string text)
    {
        string maskedText = aFilter.FilterSexyWords(text);
        maskedText = aFilter.FilterPoliticalWords(maskedText);
        maskedText = bFilter.Filter(maskedText);
        maskedText = cFilter.Filter(maskedText, "***");
        return maskedText;
    }
}

//用适配器模式进行改造
public interface ISensitiveWordsFilter
{
    string Filter(string text);
}

public class AsensitiveWordsFilterAdaptor : ISensitiveWordsFilter
{
    private ASensitiveWordsFilter aFilter = new ASensitiveWordsFilter();
    public string Filter(string text)
    {
        string maskedText = aFilter.FilterSexyWords(text);
        maskedText = aFilter.FilterPoliticalWords(maskedText);
        return maskedText;
    }
}

public class NewRiskManagement
{
    private List<ISensitiveWordsFilter> filters = new List<ISensitiveWordsFilter>();
    public void AddSensitiveWordsFilter(ISensitiveWordsFilter filter)
    {
        filters.Add(filter);
    }

    public string FilterSensitiveWords(string text)
    {
        string maskedText = text;
        foreach(var filter in filters)
        {
            maskedText = filter.Filter(maskedText);
        }
        return maskedText;
    }
}

public class AdapterPatternDemo2 : MonoBehaviour
{
    private void Awake()
    {

    }
    void Start()
    {

    }
}
