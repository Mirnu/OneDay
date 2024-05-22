using System;
using Zenject;

public class Minigame : ITickable, IMinigame
{
    public Action MinigameProgressAction;
    public int ProgressGainRate = 1;

    public int ProgressProcentage { get => throw new System.NotImplementedException(); set => throw new System.NotImplementedException(); }

    public void ChangeProgressProcentage()
    {

    }

    public void EndMinigame()
    {

    }

    public void StartMinigame()
    {

    }

    private void Start() {
        MinigameProgressAction += delegate { ProgressProcentage += ProgressGainRate; };
    }

    public void Tick()
    {

    }
}