using System;
using UnityEngine;
using Zenject;

public class MinigameView : MonoBehaviour, IInitializable {

    private GameObject currentMinigamePrefab;

    public void ChangeMinigamePrefab(GameObject minigamePrefab) {}

    public void Initialize()
    {
        throw new NotImplementedException();
    }
}