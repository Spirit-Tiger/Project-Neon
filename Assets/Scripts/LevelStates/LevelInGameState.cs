using System.Collections;
using UnityEngine;

public class LevelInGameState : LevelState
{
    public LevelInGameState(LevelManager levelManager, LevelStateMachine stateMachine, LevelDataSO levelData) : base(levelManager, stateMachine, levelData)
    {
    }

    public override void OnEnter()
    {
        base.OnEnter();
    }

    public override void OnExit()
    {
        base.OnExit();
    }

    public override void OnUpdate()
    {
        base.OnUpdate();
    }
}
