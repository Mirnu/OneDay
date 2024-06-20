using Dialogue;
using Model;
using Poll;
using Saving;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using Zenject;

public class Test : MonoBehaviour
{
    [SerializeField] private NodeAdapter _nodeAdapter;
    private IDialogueService _service;

    [Inject]
    public void Construct(IDialogueService service)
    {
        _service = service;
    }

    private void Start()
    {
        _service.StartDialogue(_nodeAdapter);
    }
}
