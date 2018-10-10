using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class ChaseState : FSMState
{
    private GameObject npc;
    private Rigidbody npcRig;
    private GameObject player;

    public ChaseState(GameObject npc, GameObject player)
    {
        stateID = StateID.Chase;
        this.npc = npc;
        npcRig = npc.GetComponent<Rigidbody>();
        this.player = player;
    }

    public override void DoUpdate()
    {
        CheckTransiton();

        ChaseMove();
    }

    private void CheckTransiton()
    {
        if (Vector3.Distance(npc.transform.position, player.transform.position) > 10)
        {
            fsm.PreformTransition(Transition.LostPlayer);
        }
    }

    private void ChaseMove()
    {
        npcRig.velocity = npc.transform.forward * 8;

        Vector3 targetPosition = player.transform.position;
        targetPosition.y = npc.transform.position.y;
        npc.transform.LookAt(targetPosition);
    }
}