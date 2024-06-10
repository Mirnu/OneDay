using System;
using TMPro;
using UnityEngine;
using UnityEngine.UI;

namespace Dialogue
{
    public class DialogueView : MonoBehaviour
    {
        public Action OnClick;

        [SerializeField] private TMP_Text Text;
        [SerializeField] private TMP_Text Author;
        [SerializeField] private Button Button;

        private bool isPressed = true;

        private void Awake()
        {
            Button.onClick.AddListener(() => {
                if (!isPressed) return;
                OnClick?.Invoke();
            });
        }

        public void ShowDialogue(Dialogue dialogue)
        {
            isPressed = !dialogue.isChoise;

            Text.text = dialogue.Text;
            Author.text = dialogue.Author;
        }
    }
}
