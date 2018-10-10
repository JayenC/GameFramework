using strange.extensions.context.api;
using strange.extensions.dispatcher.eventdispatcher.api;
using strange.extensions.mediation.impl;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class CubeMediator : Mediator
{
    [Inject]
    public CubeView CubeView { get; set; }

    [Inject(ContextKeys.CONTEXT_DISPATCHER)] //全局的dispatcher
    public IEventDispatcher dispatcher { get; set; }

    public override void OnRegister()
    {
        CubeView.Init();

        dispatcher.AddListener(Demo1MediatorEvent.ScoreChange, ScoreChange);

        CubeView.dispatcher.AddListener(Demo1MediatorEvent.ClickDown, OnClickDown);

        //通过dispatcher，发起请求分数命令
        dispatcher.Dispatch(Demo1CommandEvent.RequestScore);
    }

    public override void OnRemove()
    {
        dispatcher.RemoveListener(Demo1MediatorEvent.ScoreChange, ScoreChange);

        CubeView.dispatcher.RemoveListener(Demo1MediatorEvent.ClickDown, OnClickDown);
    }

    void ScoreChange(IEvent evt)
    {
        CubeView.UpdateScore((int)evt.data);
    }

    void OnClickDown()
    {
        dispatcher.Dispatch(Demo1CommandEvent.UpdateScore);
    }
}
