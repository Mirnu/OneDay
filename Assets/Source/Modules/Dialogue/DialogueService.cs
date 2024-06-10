using System.Collections.Generic;
using Model;

namespace Dialogue
{
    public class DialogueService : IDialogueService
    {
        private readonly DialogueView _dialogueView;
        private readonly HistoryModel _history;

        private NodeAdapter _nodeAdapter;

        public DialogueService(DialogueView dialogueView, HistoryModel history) 
        {
            _dialogueView = dialogueView;
            _history = history;
        }

        public void StartDialogue(NodeAdapter nodeAdapter) 
        { 
            _nodeAdapter = nodeAdapter;

            _history.AddDialogue(_nodeAdapter.Id);
            showCurrentDilogue();
        }

        private void Subcribe() 
        {
            _dialogueView.OnClick += Clicked;
            //_dialogueView.OnChoise += Choised;
        }

        private void Unsubcribe() 
        {
            _dialogueView.OnClick -= Clicked;
            //_dialogueView.OnChoise -= Choised;
        }

        private void Clicked() 
        { 
            Dialogue dialogue = _nodeAdapter.NextNode();
            _dialogueView.ShowDialogue(dialogue);
        }

        private void Choised(int choise) 
        { 
            _nodeAdapter?.SetCurrentDialogueNodeByChoiseId(choise);
            showCurrentDilogue();
        }

        private void showCurrentDilogue()
        {
            Dialogue dialogue = _nodeAdapter.GetDialogueNode();
            _dialogueView.ShowDialogue(dialogue);
        }
    }
}