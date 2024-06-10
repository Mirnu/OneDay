using System;
using System.Collections;
using System.Collections.Generic;
using TMPro;
using UnityEngine;
using UnityEngine.UI;

namespace Poll
{
    public class ChoiseView : MonoBehaviour
    {
        [SerializeField] private Button Button;
        [SerializeField] private TMP_Text Text;

        public Action<int> OnClick;

        public void Init(int index, string text, Action onClick)
        {
            Text.text = text;
            Button.onClick.AddListener(() => onClick());
        }
    }
}
