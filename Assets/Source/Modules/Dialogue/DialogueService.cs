using Model;
using Poll;
using UnityEngine;
using Zenject;

namespace Dialogue
{
    public class DialogueService : IDialogueService
    {
        private readonly DialogueView _dialogueView;
        private readonly HistoryModel _history;
        private readonly IPollService _pollService;
        private readonly IMovement _movement;

        private NodeAdapter _nodeAdapter;

        [Inject]
        public DialogueService(DialogueView dialogueView, IPollService pollService, HistoryModel history, IMovement movement) 
        {
            _dialogueView = dialogueView;
            _pollService = pollService;
            _history = history;
            _movement = movement;
        }

        public void StartDialogue(NodeAdapter nodeAdapter) 
        {
            _nodeAdapter = nodeAdapter;

            _movement.Disable();
            _history.AddDialogue(_nodeAdapter.Id);
            showCurrentDilogue();
        }

        private void Subscribe() 
        {
            _dialogueView.OnClick += Clicked;
        }

        private void Unsubcribe() 
        {
            _dialogueView.OnClick -= Clicked;
        }

        private void Clicked() 
        {
            Dialogue dialogue = _nodeAdapter.NextNode();
            showDialogue(dialogue);
        }

        private void Choised(int choise) 
        { 
            _nodeAdapter?.SetCurrentDialogueNodeByChoiseId(choise);
            showCurrentDilogue();
        }

        private void showCurrentDilogue()
        {
            Dialogue dialogue = _nodeAdapter.GetDialogueNode();
            showDialogue(dialogue);
        }

        private void showDialogue(Dialogue dialogue)
        {
            if (checkOnEnd(dialogue)) return;

            Unsubcribe();
            if (dialogue.isChoise)
                _pollService.LoadPoll(dialogue.Childrens, Choised);
            else
            {
                Subscribe();
                _pollService.ClearPoll();
            }

            _dialogueView.ShowDialogue(dialogue);
        }

        private bool checkOnEnd(Dialogue dialogue)
        {
            if (dialogue == null)
            {
                _movement.Enable();
                _dialogueView.ChangeState(false);
                Unsubcribe();
                _pollService.ClearPoll();
                return true;
            }
            return false;
        }
    }
}