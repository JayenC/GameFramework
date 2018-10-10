using System.Collections;
using System.Collections.Generic;
using strange.extensions.dispatcher.eventdispatcher.api;
using UnityEngine;

public class ScoreService : IScoreService
{
    [Inject]
    public IEventDispatcher Dispatcher { get; set; }

    public void RequestScore(string url)
    {
        Debug.Log("Requset score from url:" + url);

        OnReceiveScore();
    }

    public void  OnReceiveScore()
    {
        int score = Random.Range(0, 100);

        Dispatcher.Dispatch(Demo1ServiceEvent.RequsetScore , score);
    }

    public void UpdateScore(string url, int score)
    {
        Debug.Log("Update score to url:" + url + "Score:" + score);
    }

}
