using UnityEngine;

namespace Dialogue
{
    public class BaseNode : DialogueNode
    {
        [Output] public BaseNode Next;
        [Input] public BaseNode Previous;
    }
}