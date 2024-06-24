using System;
using System.Collections.Generic;

namespace Model
{
    public class ChoisesModel : ISetModel<int>, IOnLoadedModel
    {

        private List<int> _choises = new();
        public Action OnLoaded { get; set; }
        public void AddChoise(int choise) => _choises.Add(choise);
        public bool ExistChose(int choise) => _choises.Contains(choise);

        public void SetValues(List<int> values) => _choises = values;
    }
}
