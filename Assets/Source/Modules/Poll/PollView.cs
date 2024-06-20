using Model;
using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using Zenject;

namespace Poll
{
    public class PollView : MonoBehaviour, IPollService
    {
        [SerializeField] private ChoiseView _choisePrefab;
        [SerializeField] private GameObject _panel;
        private ChoisesModel _choisesModel;

        [Inject]
        public void Construct(ChoisesModel historyModel)
        {
            _choisesModel = historyModel;
        }

        public void LoadPoll(List<Choise> poll, Action<int> onClick)
        {
            _panel.SetActive(true);
            foreach (var choise in poll)
            {
                Instantiate(_choisePrefab, _panel.transform).Init(choise.Id, choise.Text, () => 
                {
                    _choisesModel.AddChoise(choise.Id);
                    onClick(choise.Id);
                });
            }
        }

        public void ClearPoll()
        {
            foreach (Transform child in _panel.transform)
            {
                Destroy(child.gameObject);
            }
            _panel.SetActive(false);
        }
    }
}
