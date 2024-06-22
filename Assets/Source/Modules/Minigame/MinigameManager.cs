using System.Collections.Generic;
using UnityEngine;
using Zenject;

public class MinigameManager : IInitializable {
    private IMinigame currentMinigame;
    private MinigameView currentView;
    public Dictionary<IMinigame, GameObject> MinigamePrefabDictionary = new Dictionary<IMinigame,GameObject>();

    public void Initialize()
    {
        //throw new System.NotImplementedException();
    }

    public void init(IMinigame minigame, MinigameView view) {
        currentView = view;
        currentMinigame = minigame;
    }
}