using System.Collections;
using System.Collections.Generic;
using UnityEngine;

namespace Model 
{
    public class HistoryModel
    {
        private List<int> _choises = new List<int>();
        private List<int> _dialogs = new List<int>();

        public void AddChoise(int choise) => _choises.Add(choise);
        public bool ExistChose(int choise) => _choises.Contains(choise);

        public void AddDialogue(int choise) => _dialogs.Add(choise);
        public bool ExistDialogue(int choise) => _dialogs.Contains(choise);
    }
}
