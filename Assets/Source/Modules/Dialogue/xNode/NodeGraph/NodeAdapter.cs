using Dialogue;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using XNode;

namespace Dialogue
{
    [CreateAssetMenu]
    public class NodeAdapter : NodeGraph
    {
        public DialogueNode CurrentDialogueNode;
        public int Id;

        public Dialogue GetDialogueNode()
        {
            if (CurrentDialogueNode == null)
            {
                CurrentDialogueNode = (DialogueNode)nodes[0];
            }

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

        public DialogueNode NextNode()
        {
            CurrentDialogueNode = CurrentDialogueNode.NextNode();

            return CurrentDialogueNode;
        }
    }
}