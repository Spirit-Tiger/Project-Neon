using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public abstract class LevelState
{
    protected LevelStateMachine stateMachine;
    protected LevelManager levelManager;
    protected LevelDataSO levelData;
    public LevelState(LevelManager levelManager, LevelStateMachine stateMachine, LevelDataSO levelData)
    {
        this.stateMachine = stateMachine;
        this.levelManager = levelManager;
        this.levelData = levelData;
    }
    public virtual void OnEnter()
    {

    }
    public virtual void OnUpdate()
    {

    }
    public virtual void OnExit()
    {

    }
}
