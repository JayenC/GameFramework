using strange.extensions.command.impl;
using strange.extensions.dispatcher.eventdispatcher.api;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class RequestScoreCommand : EventCommand
{
    [Inject]
    public IScoreService ScoreService { get; set; }

    [Inject]
    public ScoreModel ScoreModel { get; set; }

    public override void Execute()
    {
        Retain();

        ScoreService.Dispatcher.AddListener(Demo1ServiceEvent.RequsetScore, OnComplete);

        ScoreService.RequestScore("http://xxx.xxx.xxx");
    }

    private void OnComplete(IEvent evt) //IEvent 储存的就是参数
    {

        Debug.Log("requset score complete:" + evt.data);

        dispatcher.Dispatch(Demo1MediatorEvent.ScoreChange , evt.data);

        ScoreModel.Score = (int)evt.data;

        ScoreService.Dispatcher.RemoveListener(Demo1ServiceEvent.RequsetScore, OnComplete);

        Release();
    }
}
