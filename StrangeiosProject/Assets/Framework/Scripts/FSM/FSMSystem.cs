using System.Collections;
using System.Collections.Generic;
using UnityEngine;

//状态机管理类，有限状态机系统类
public class FSMSystem
{
    private Dictionary<StateID, FSMState> states = new Dictionary<StateID, FSMState>();

    private FSMState currentState;
    public FSMState CurrentState { get { return currentState; } }

    public FSMSystem() { states = new Dictionary<StateID, FSMState>(); }

    //往状态机里添加状态
    public void AddState(FSMState state , FSMSystem fsm)
    {
        if (state == null)
        {
            Debug.LogError("The state you want to add is null!"); return;
        }

        if (states.ContainsKey(state.ID))
        {
            Debug.LogError("The state：" + state.ID + "you want to add, has already been added!"); return;
        }

        states.Add(state.ID, state);
        state.fsm = fsm;
    }

    //从状态机里删除状态
    public void DeleteState(FSMState state)
    {
        if (state == null)
        {
            Debug.LogError("The state you want to delete is null!"); return;
        }

        if (states.ContainsKey(state.ID) == false)
        {
            Debug.LogError("The state：" + state.ID + "you want to delete is not exist!"); return;
        }

        states.Remove(state.ID);
    }

    // 控制状态的转换
    public void PreformTransition(Transition trans)
    {
        if (trans == Transition.NullTransition)
        {
            Debug.LogError("NullTransition is not allowed for a real transition!"); return;
        }

        StateID id = currentState.GetOutputState(trans);
        if (id == StateID.NullStateID)
        {
            Debug.Log("Transition is not happened!没有符合条件的转换！");
            return;
        }

        FSMState state;
        states.TryGetValue(id, out state);

        currentState.DoBeforeLeaving();
        currentState = state;
        currentState.DoBeforeEntering();
    }

    // 开启状态机
    public void Start(StateID id)
    {
        FSMState state;
        if (states.TryGetValue(id, out state))
        {
            state.DoBeforeEntering();
            currentState = state;
        }
    }
}