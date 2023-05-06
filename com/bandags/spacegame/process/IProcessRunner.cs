using System.Collections;

namespace com.bandags.spacegame.process {
    public interface IProcessRunner {
        IProcess Process { get; }
        bool isRunning();
        T Upcast<T>();
        IEnumerator RunProcess(IProcess process);
        void Interrupt();
    }
}