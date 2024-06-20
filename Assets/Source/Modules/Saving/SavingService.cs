using Model;
using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;

namespace Saving {
    public class SavingService : ISavingService
    {
        private SaveModel _saveModel;
        private SaveInitializer _initializer;

        public SavingService(SaveModel saveModel, SaveInitializer initializer)
        {
            _saveModel = saveModel;
            _initializer = initializer;
        }

        public List<Save> GetAllSaves() => _saveModel.Saves;

        public bool HaveAnySaves() => _saveModel.Saves.Count > 0;

        public void MakeNewSave(string name = "New Save")
        {
            Save save = new Save();
            setOwnSaveData(save, name);
        }

        private void setOwnSaveData(Save save, string name)
        {
            DateTime time = DateTime.Now;
            save.Id = time.Ticks;
            save.Name = name;
            _initializer.SetModelsToSave(save);
        }

        public void ReplaceOldSave(Save oldSave, Save newSave) => _saveModel.ReplaceOldSave(oldSave, newSave);

        public void SetCurrentSave(Save save) => _saveModel.SetCurrentSave(save);

        public Save GetCurrentSave() => _saveModel.CurrentSave;

        public void InitCurrentSave()
        {
            Save save = _saveModel.CurrentSave;

            if (save != null)
            {
                List<IOnLoadedModel> models = save.GetModels();

                foreach (var model in models)
                {
                    model.OnLoaded?.Invoke();
                }
            }
        }
    }
}