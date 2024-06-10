using Model;
using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;

namespace Poll
{
    public class PollView : MonoBehaviour, IPollService
    {
        [SerializeField] private ChoiseView _choisePrefab;
        private HistoryModel _historyModel;

        public void LoadPoll(List<Choise> poll, Action<int> onClick)
        {
            foreach (var choise in poll)
            {
                Instantiate(_choisePrefab, transform).Init(choise.Id, choise.Text, (int id) => 
                {
                    _historyModel.AddChoise(id);
                    onClick(id);
                });
            }
        }

        public void DestroyPoll()
        {
            foreach (Transform child in transform)
            {
                Destroy(child.gameObject);
            }
        }
    }
}
