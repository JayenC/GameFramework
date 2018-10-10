using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class LocalizationManager
{
    private static LocalizationManager _instance;
    public static LocalizationManager Instance
    {
        get
        {
            if (_instance == null)
            {
                _instance = new LocalizationManager();
            }
            return _instance;
        }
    }

    private const string Chinese = "Localization/Chinese";
    private const string English = "Localization/English";

    private const string Language = English;

    private Dictionary<string, string> dict;

    private LocalizationManager()
    {
        dict = new Dictionary<string, string>();

        TextAsset ta = Resources.Load<TextAsset>(Language);
        string[] lines = ta.text.Split('\n');

        foreach (string line in lines)
        {
            string[] keyValue = line.Split('=');

            dict.Add(keyValue[0], keyValue[1]);
        }
    }

    public string GetValue(string key)
    {
        string value;
        dict.TryGetValue(key, out value);
        return value;
    }

    public void Init()
    {
        //Do Nothing
    }

}
