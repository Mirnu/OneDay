using UnityEngine;
using XNode;

namespace Dialogue
{
    public class BaseNode : Node
    {
        [Output] public BaseNode Next;
        [Input] public BaseNode Previous;

        public DialogueNode NextNode()
        {
            NodePort port = GetPort("Next");
            return (DialogueNode)port.Connection.node;
        }
    }
}