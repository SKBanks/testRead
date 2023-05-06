using System;
using System.Collections;
using UnityEngine;

namespace com.bandags.spacegame.process {
    [Serializable]
    public class ProcessRunner : IProcessRunner {
        [field: SerializeReference] public IProcess Process { get; private set; }

        public bool isRunning() {
            return Process != null;
        }

        public T Upcast<T>() {
            return (T)Process;
        }

        public IEnumerator RunProcess(IProcess process) {
            //Debug.Log("Starting Process: " + process.ProcessType);
            Process = process;
            while (Process != null) {
                //Debug.Log("Running Process: " + process.ProcessType);
                yield return Process.Run();
                Process = Process?.Next;
            }
            //Debug.Log($"Finished Running Process: {process.ProcessType}]");
        }

        public void Interrupt() {
            Process?.OnInterrupt();
        }
    }
}