using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using XNode;

namespace Dialogue
{
    public class DialogueNode : BaseNode
    {

        [Output(dynamicPortList = true)] public List<string> Childrens;

        [SerializeField] private string _name;
        [SerializeField] private int _id;
        [SerializeField][TextArea] private string _text;

        public string Name => _name;
        public int Id => _id;
        public string Text => _text;

        public List<DialogueNode> GetChildrens()
        {
            NodePort port = GetOutputPort("Childrens");
            List<DialogueNode> connectedNodes = new();
            foreach (NodePort connection in port.GetConnections())
            {
                Node connectedNode = connection.node;
                connectedNodes.Add((DialogueNode)connectedNode);
            }
            return connectedNodes;
        }
    }
}


