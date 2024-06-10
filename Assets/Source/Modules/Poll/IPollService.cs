using Dialogue;
using System;
using System.Collections;
using System.Collections.Generic;

namespace Poll
{
    public interface IPollService
    {
        public void LoadPoll(List<Choise> poll, Action<int> onClick);
        public void ClearPoll();
    }
}
