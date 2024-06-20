using Dialogue;
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
