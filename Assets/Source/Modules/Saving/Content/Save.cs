using Model;
using System;
using System.Collections;
using System.Collections.Generic;
using System.Linq;
using UnityEngine;

namespace Saving
{
    public class Save
    {
        public PlayerSaving PlayerSaving;
        public string Name;
        public long Id;
        private Dictionary<Type, object> _models = new();

        public void AddModel<T>(T model) => _models.Add(model.GetType(), model); 
        public T GetModel<T>() => (T)_models[typeof(T)];
        public List<IOnLoadedModel> GetModels()
        {
            return _models.Select(x => (IOnLoadedModel)x.Value).ToList();
        }
    }
}