using Dialogue;
using System.Collections;
using System.Collections.Generic;

namespace Poll
{
    public interface IPollService
    {
        public void LoadPoll(List<Choise> poll);
    }
}
