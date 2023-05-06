using System.Collections;

namespace com.bandags.spacegame.process {
    public interface IProcess {
        IProcess Next { get; }
        ProcessState State { get; }
        ProcessType ProcessType { get; }
        IProcess SetNext(IProcess nextProcess);
        IEnumerator Run();
        void OnInterrupt();
    }
}