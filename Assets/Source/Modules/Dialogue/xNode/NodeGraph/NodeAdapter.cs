using System.Collections.Generic;
using UnityEngine;
using XNode;
using Poll;

namespace Dialogue
{
    [CreateAssetMenu]
    public class NodeAdapter : NodeGraph
    {
        private DialogueNode CurrentDialogueNode;
        public int Id;

        public Dialogue GetDialogueNode()
        {
            if (CurrentDialogueNode == null)
            {
                CurrentDialogueNode = (DialogueNode)nodes[0];
            }

            return transformNodeToDto();
        }

        public void SetCurrentDialogueNodeByChoiseId(int nodeId)
        {
            foreach (DialogueNode node in nodes)
            {
                if (node.Id != nodeId) continue;
                CurrentDialogueNode = node;
            }
        }

        public Dialogue NextNode()
        {
            CurrentDialogueNode = CurrentDialogueNode.NextNode();

            return transformNodeToDto();
        }

        private Dialogue transformNodeToDto()
        {
            List<Choise> choises = new();

            CurrentDialogueNode.GetChildrens().ForEach(child => {
                Choise choise = new Choise();
                choise.Id = child.Id;
                choise.Text = child.Text;
                choises.Add(choise);
            });

            return Dialogue.Build()
                .Author(CurrentDialogueNode.Name)
                .Text(CurrentDialogueNode.Text)
                .Childrens(choises)
                .Build();
        }
    }
}