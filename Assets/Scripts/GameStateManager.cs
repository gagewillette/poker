using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class GameStateManager : MonoBehaviour
{

    public static Action onPreFlop;
    public static Action onFlop;
    public static Action onTurn;
    public static Action onRiver;
    public static Action onShowdown;
    public static Action onGameOver;

    public enum GameState
    {
        Preflop,
        Flop,
        Turn,
        River,
        Showdown,
        GameOver
    }

    public GameState currentState;
    private GameState prevState;

    private void Start()
    {
        currentState = GameState.Preflop;
    }

    private void Update()
    {
        if (prevState.Equals(currentState))
            return;
        prevState = currentState;
        stateManager();


    }

    private void stateManager()
    {
        switch (currentState)
        {
            case GameState.Preflop:
                // Handle preflop actions (e.g., blinds, player bets)
                onPreFlop?.Invoke();
                break;

            case GameState.Flop:
                // Handle flop actions (deal community cards, player bets)
                onFlop?.Invoke();
                break;

            case GameState.Turn:
                // Handle turn actions (deal another community card, player bets)
                onTurn?.Invoke();
                break;

            case GameState.River:
                // Handle river actions (deal the final community card, player bets)
                onRiver?.Invoke();
                break;

            case GameState.Showdown:
                // Determine the winner(s) and distribute the pot
                onShowdown?.Invoke();
                break;

            case GameState.GameOver:
                // Handle game over conditions
                onGameOver?.Invoke();
                break;
        }
    }

}
