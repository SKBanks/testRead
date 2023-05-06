namespace com.bandags.spacegame.process {
    public interface IProcessManager {
        void RunProcess(IProcess process);
        void Interrupt();
        ProcessType GetProcessType();
    }
}