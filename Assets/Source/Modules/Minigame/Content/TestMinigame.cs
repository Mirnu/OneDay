using System;
using UnityEngine;
using Zenject;

public class TestMinigame : IMinigame, IInitializable
{
    public Action onWin { get => delegate {}; set => onWin = delegate {}; }
    public Action onLose { get => delegate {}; set => onLose = delegate {}; }
    public MinigameType type { get => MinigameType.SPAM; set => type = MinigameType.SPAM; }
    public float Progress { get => 0; set => Progress = 0; }

    private KeyboardInput controller;
    
    [Inject]
    public void Construct(KeyboardInput inputHandler)
    {
        controller = inputHandler;
        controller.KeyDown += keyDown;
    }

    private void keyDown(KeyCode code)
    {
        if(code == KeyCode.E) {
            Debug.Log("NIGGER______");
        }
    }

    void ITickable.Tick() {
        Debug.Log("NIGGER");
    }

    void IMinigame.Start() {
        Debug.Log("-----------");

    }

    public void Initialize()
    {
        Debug.Log("NIGGER-----------NIGGER");
    }
}