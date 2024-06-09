using System.Collections.Generic;
using Model;

namespace Dialogue
{
    public class DialogueService : IDialogueService
    {
        private readonly DialogueView _dialogueView;
        private readonly HistoryModel _history;

        public DialogueService(DialogueView dialogueView, HistoryModel history) 
        {
            _dialogueView = dialogueView;
            _history = history;
        }

        public void StartDialogue(NodeAdapter nodeAdapter) 
        { 
            _history.AddDialogue(nodeAdapter.Id);
            Dialogue dialogueNode = nodeAdapter.GetDialogueNode();
            _dialogueView.ShowDialogue(dialogueNode);
        }

        private void Subcribe() 
        {
            _dialogueView.OnClick += Clicked;
            _dialogueView.OnChoise += Choised;
        }

        private void Unsubcribe() 
        {
            _dialogueView.OnClick -= Clicked;
            _dialogueView.OnChoise -= Choised;
        }

        private void Clicked() { }
        private void Choised(int chose) { }
    }
}