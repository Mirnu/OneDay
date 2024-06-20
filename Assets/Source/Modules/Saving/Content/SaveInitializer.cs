using Model;
using System;
using System.Collections.Generic;
using Zenject;

namespace Saving
{
    public class SaveInitializer : IInitializable, IDisposable
    {
        private SaveModel _saveModel;
        private List<object> _models = new();

        public SaveInitializer(SaveModel saveModel, ChoisesModel choisesModel, DialogsModel dialogsModel) 
        { 
            _saveModel = saveModel;
            _models.Add(choisesModel);
            _models.Add(dialogsModel);
        }

        public void SetModelsToSave(Save save)
        {
            foreach (var model in _models)
            {
                save.AddModel(model);
            }
        }

        public void Dispose()
        {
            Repository.SetData(_saveModel);
            Repository.SaveState();
        }

        public void Initialize()
        {
            Repository.LoadState();
            if (Repository.TryGetData(out SaveModel saveModel))
            {
                _saveModel.InsertSavingModels(saveModel.Saves);
            }
        }
    }
}