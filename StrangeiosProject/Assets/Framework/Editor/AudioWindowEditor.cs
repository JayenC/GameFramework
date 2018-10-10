using System.Collections;
using System.Collections.Generic;
using System.IO;
using System.Text;
using UnityEditor;
using UnityEngine;

/// <summary>
/// 音效管理面板
/// </summary>
public class AudioWindowEditor : EditorWindow
{
    [MenuItem("Manager/AudioManager")]
    static void CreateWindow()
    {
        AudioWindowEditor audioWindow = EditorWindow.GetWindow<AudioWindowEditor>("音效管理");
        audioWindow.Show();
    }


    private string audioName;
    private string audioPath;
    private Dictionary<string, string> audioDict = new Dictionary<string, string>();
    
    private void Awake()
    {
        LoadAudioList();
    }

    private void OnInspectorUpdate()
    {
        LoadAudioList();
    }


    private void OnGUI()
    {
        GUILayout.BeginHorizontal();
        GUILayout.Label("音效名称");
        GUILayout.Label("路径");
        GUILayout.Label("操作");
        GUILayout.EndHorizontal();

        foreach (string key in audioDict.Keys)
        {
            string value;
            audioDict.TryGetValue(key, out value);

            GUILayout.BeginHorizontal();
            GUILayout.Label(key);
            GUILayout.Label(value);
            if (GUILayout.Button("删除"))
            {
                audioDict.Remove(key);
                SaveAudioList();
                return;
            }
            GUILayout.EndHorizontal();
        }


        audioName = EditorGUILayout.TextField("音效名字", audioName);
        audioPath = EditorGUILayout.TextField("音效路径", audioPath);


        if (GUILayout.Button("添加音效"))
        {
            object obj = Resources.Load(audioPath);

            if (obj == null)
            {
                Debug.LogWarning("路径不存在音效");
            }
            else
            {
                if (audioDict.ContainsKey(audioName))
                {
                    Debug.LogWarning("已经包含同名音效");
                }
                else
                {
                    audioDict.Add(audioName, audioPath);
                    SaveAudioList();
                }
            }
        }
    }




    void SaveAudioList()
    {
        StringBuilder sb = new StringBuilder();

        foreach (string key in audioDict.Keys)
        {
            string value;
            audioDict.TryGetValue(key, out value);

            sb.Append(key + "," + value + "\n");
        }


        File.WriteAllText(AudioManager.AudioTextPath, sb.ToString());
    }


    void LoadAudioList()
    {
        audioDict = new Dictionary<string, string>();

        if (File.Exists(AudioManager.AudioTextPath) == false) return;
        string[] lines = File.ReadAllLines(AudioManager.AudioTextPath);

        foreach (string line in lines)
        {
            if (string.IsNullOrEmpty(line)) continue;

            string[] keyValue = line.Split(',');
            audioDict.Add(keyValue[0], keyValue[1]);
        }

    }


}
