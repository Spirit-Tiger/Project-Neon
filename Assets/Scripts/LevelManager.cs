using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.InputSystem;

public class LevelManager : MonoBehaviour
{
    public LevelStateMachine StateMachine = new LevelStateMachine();
    public Player Player;
    public LevelDataSO Data;

    public LevelStartState StartState { get;private set; }
    public LevelInGameState InGameState { get; private set; }
    public LevelPauseState PauseState { get; private set; }
    public LevelGameOverState GameOverState { get; private set; }
    public LevelFinishState FinishState { get; private set; }


    private void Awake()
    {
        StartState = new LevelStartState(this,StateMachine, Data);
        InGameState = new LevelInGameState(this, StateMachine, Data);
        PauseState = new LevelPauseState(this, StateMachine, Data);
        GameOverState = new LevelGameOverState(this, StateMachine, Data);
        FinishState = new LevelFinishState(this, StateMachine, Data);
    }

    private void Start()
    {
        StateMachine.Initialize(StartState);
    }

    private void Update()
    {
        StateMachine.CurrentState.OnUpdate();
    }
}
