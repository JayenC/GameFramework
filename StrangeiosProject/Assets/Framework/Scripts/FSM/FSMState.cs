using System.Collections;
using System.Collections.Generic;
using UnityEngine;

//有哪些状态转换的条件
public enum Transition
{
    NullTransition = 0,
    SawPlayer,  //看到玩家
    LostPlayer  //跟丢玩家
}

//状态ID,是每一个状态的唯一标识，一个状态有一个StateID，而且跟其他状态不能重复
public enum StateID
{
    NullStateID = 0,
    Patrol, //巡逻状态
    Chase   //追逐状态
}

public abstract class FSMState
{
    protected StateID stateID;
    public StateID ID
    {
        get { return stateID; }
    }

    public FSMSystem fsm;
    Dictionary<Transition, StateID> map = new Dictionary<Transition, StateID>();

    public void AddTransition(Transition trans, StateID stateID)
    {
        if (trans == Transition.NullTransition || stateID == StateID.NullStateID)
        {
            Debug.LogError("Transition  or  StateID is null!!");
            return;
        }

        if (map.ContainsKey(trans))
            Debug.LogError("Transition:" + trans + "already exist and bind with StateID:" + stateID);

        map.Add(trans, stateID);
    }

    public void DeleteTransition(Transition trans)
    {
        if (map.ContainsKey(trans) == false)
        {
            Debug.LogWarning("The transition:" + trans + "you want to delete is not exist in map!");
            return;
        }

        map.Remove(trans);
    }

    //根据传递过来的条件，判断一下是否可以转换
    public StateID GetOutputState (Transition trans )
    {
        if(map.ContainsKey(trans ))
        {
            return map[trans];
        }
        return StateID.NullStateID;
    }

    //进入状态之间调用
    public virtual void DoBeforeEntering() { }
    public virtual void DoBeforeLeaving() { }

    public abstract void DoUpdate(); //当处于这个状态是当前状态的时候，会一直调用

}