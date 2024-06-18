using System;
using Zenject;

public interface IMinigame : ITickable {

    public Action onWin { get; set; }
    public Action onLose { get; set; }
    public MinigameType type { get; set; }

    public float Progress { get; set; }

    void ITickable.Tick() {}
    public void Start() {}
}
public enum MinigameType {
    CHECK,
    SCROLL,
    SPAM
}