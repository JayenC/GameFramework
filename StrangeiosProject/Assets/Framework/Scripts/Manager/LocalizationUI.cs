using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class LocalizationUI : MonoBehaviour
{
    public string key;

    private void Start()
    {
      string value =  LocalizationManager.Instance.GetValue(key);
        GetComponent<Text>().text = value;
    }
}
