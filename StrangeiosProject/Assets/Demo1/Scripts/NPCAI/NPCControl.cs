using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class NPCControl : MonoBehaviour
{
    private FSMSystem fsm;

    public Transform[] waypoints;
    private GameObject player;

    void Start()
    {
        player = GameObject.FindGameObjectWithTag("Player");
        InitFSM();
    }

    /// <summary>
    /// 初始化状态机
    /// </summary>
    private void InitFSM()
    {
        fsm = new FSMSystem();

        ChaseState chase = new ChaseState(this.gameObject , player);
        chase.AddTransition(Transition.LostPlayer, StateID.Patrol);  //添加转换

        PatrolState patrol = new PatrolState(waypoints, this.gameObject,player);
        patrol.AddTransition(Transition.SawPlayer, StateID.Chase);   //添加转换

        fsm.AddState(chase , fsm);
        fsm.AddState(patrol , fsm);

        fsm.Start(StateID.Patrol);
    }

    void Update()
    {
        fsm.CurrentState.DoUpdate(); 
    }
}
