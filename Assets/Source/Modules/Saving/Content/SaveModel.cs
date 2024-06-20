using System.Collections;
using System.Collections.Generic;
using UnityEngine;

namespace Saving
{
    public class SaveModel
    {
        private List<Save> _saves = new();
        public List<Save> Saves => _saves;

        private Save _currentSave;
        public Save CurrentSave => _currentSave;    

        public void SetCurrentSave(Save save) => _currentSave = save;

        public void InsertSavingModels(List<Save> saves) => _saves = saves;

        public void AddSave(Save save) => _saves.Add(save);

        public void ReplaceOldSave(Save oldSave, Save newSave)
        {
            int index = _saves.IndexOf(oldSave); 
            if (index != -1)
            {
                _saves[index] = newSave;
            }
        }
    }
}
