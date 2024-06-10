using Dialogue;
using UnityEngine;

public class EndNode : DialogueNode {

    [Input] public BaseNode Previous;

    public override DialogueNode NextNode()
    {
        return null;
    }
}