using strange.extensions.dispatcher.eventdispatcher.api;
using strange.extensions.mediation.impl;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class CubeView : View
{
    [Inject]
    public IEventDispatcher dispatcher { get; set; }

    [Inject ]
    public AudioManager audioManager { get; set; }

    public Text textScore;

    /// <summary>
    /// 做初始化
    /// </summary>
    public void Init()
    {
        textScore = GetComponentInChildren<Text>();
    }

    private void Update()
    {
        transform.Translate(new Vector3(Random.Range(-1, 2), Random.Range(-1, 2), Random.Range(-1, 2)) * .2f);

        if (Input.GetMouseButtonDown(0))
        {
            PoolManager.Instance.GetInst("Bullet");
        }

    }

    public void UpdateScore(int score)
    {
        textScore.text = score.ToString();
    }

    private void OnMouseDown()
    {
        //加分
        Debug.Log("On MouseDown");
        dispatcher.Dispatch(Demo1MediatorEvent.ClickDown);

        audioManager.Play("Hit");
    }

}
