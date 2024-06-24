using System;

namespace Model
{
    public interface IOnLoadedModel
    {
        public Action OnLoaded { get; set; }
    }
}
