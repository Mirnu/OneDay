using System.Collections.Generic;

namespace Saving
{
    public interface ISavingService
    {
        public bool HaveAnySaves();
        public void SetCurrentSave(Save save);
        public Save GetCurrentSave();
        public void InitCurrentSave();
        public void MakeNewSave(string name = "New Save");
        public void ReplaceOldSave(Save oldSave, Save newSave);
        public List<Save> GetAllSaves();
    }
}
