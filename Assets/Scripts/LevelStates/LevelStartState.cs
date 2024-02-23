using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class LevelStartState : LevelState
{
    public LevelStartState(LevelManager levelManager, LevelStateMachine stateMachine, LevelDataSO levelData) : base(levelManager, stateMachine, levelData)
    {
    }

    public override void OnEnter()
    {
        base.OnEnter();
        levelManager.Player.transform.position = levelData.StartingPosition;
    }

    public override void OnExit()
    {
        base.OnExit();
    }

    public override void OnUpdate()
    {
        base.OnUpdate();
        if (levelManager)
        {

        }
    }
}
