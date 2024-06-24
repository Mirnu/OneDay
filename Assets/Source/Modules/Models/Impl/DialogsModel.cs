using System;
using System.Collections.Generic;

namespace Model
{
    public class DialogsModel : ISetModel<int>, IOnLoadedModel
    {
        public Action OnLoaded { get; set; }

        private List<int> _dialogs = new List<int>();

        public void SetValues(List<int> values) => _dialogs = values;
        public void AddDialogue(int choise) => _dialogs.Add(choise);
        public bool ExistDialogue(int choise) => _dialogs.Contains(choise);
    }
}
