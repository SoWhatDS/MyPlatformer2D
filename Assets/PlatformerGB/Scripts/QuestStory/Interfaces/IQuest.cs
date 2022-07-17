using System;

namespace Platformer2D
{
    public interface IQuest 
    {
        event Action<IQuest> Completed;
        bool IsCompleted { get; }
        void Reset();
    }
}
