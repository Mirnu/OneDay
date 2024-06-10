using Poll;
using System.Collections.Generic;
using UnityEngine;
using XNode;

namespace Dialogue
{
    public class DialogueNode : Node
    {

        [Output(dynamicPortList = true)] public List<string> Childrens;

        [SerializeField] private string _name;
        [SerializeField] private int _id;
        [SerializeField][TextArea] private string _text;

        public string Name => _name;
        public int Id => _id;
        public string Text => _text;

        public virtual DialogueNode NextNode()
        {
            NodePort port = GetPort("Next");
            return (DialogueNode)port.Connection.node;
        }

        public List<Choise> GetChildrens()
        {
            List<Choise> connectedNodes = new List<Choise>();
            for (int i = 0; i < Childrens.Count; i++)
            {
                NodePort port = GetOutputPort("Childrens " + i);
                if (port != null)
                {
                    Choise choise = new Choise();
                    choise.Text = Childrens[i];
                    choise.Id = ((DialogueNode)port.Connection.node).Id;
                    connectedNodes.Add(choise);
                }
            }

            return connectedNodes;
        }
    }
}


