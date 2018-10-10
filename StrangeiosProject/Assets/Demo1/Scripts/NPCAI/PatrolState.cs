using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PatrolState : FSMState
{
    private int targetWaypoint;
    private Transform[] waypoints;
    private GameObject npc;
    private Rigidbody npcRig;
    private GameObject player;

    public PatrolState(Transform[] waypoints, GameObject npc , GameObject player)
    {
        stateID = StateID.Patrol;

        this.waypoints = waypoints;
        this.npc = npc;
        npcRig = npc.GetComponent<Rigidbody>();
        this.player = player;
    }

    public override void DoUpdate()
    {
        CheckTransition();

        PatrolMove();
    }

    /// <summary>
    /// 检查转换条件
    /// </summary>
    private void CheckTransition()
    {
        if(Vector3.Distance(npc.transform.position , player.transform.position) < 5)
        {
            fsm.PreformTransition(Transition.SawPlayer);
        }
    }

    /// <summary>
    /// 巡逻移动的代码
    /// </summary>
    private void PatrolMove ()
    {
        npcRig.velocity = npc.transform.forward * 6;
        Transform targetTrans = waypoints[targetWaypoint];
        Vector3 targetPosition = targetTrans.position;
        targetPosition.y = npc.transform.position.y;
        npc.transform.LookAt(targetPosition);

        if (Vector3.Distance(npc.transform.position, targetPosition) < 1)
        {
            targetWaypoint++;
            targetWaypoint %= waypoints.Length;   //当超过lenth长度变为0
        }
    }
}