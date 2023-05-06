using System;
using UnityEngine;

namespace com.bandags.spacegame.process {
    [Serializable]
    public class ProcessManager : IProcessManager {
        [field: SerializeReference] private readonly IProcessRunner _processRunner;
        [field: SerializeReference] private readonly MonoBehaviour _monoBehaviour;
        
        private Coroutine runningProcess;
        
        public ProcessManager(MonoBehaviour monoBehaviour) {
            _processRunner = new ProcessRunner();
            _monoBehaviour = monoBehaviour;
        }

        /// <summary>
        /// Takes a process and wraps it with a ProcessRunner and executes it.  For unmanaged processes only
        /// </summary>
        /// <param name="process"></param>
        public void RunProcess(IProcess process) {
            runningProcess = _monoBehaviour.StartCoroutine(_processRunner.RunProcess(process));
        }

        public void Interrupt() {
            if (runningProcess == null) return;
            _processRunner.Interrupt();
            _monoBehaviour?.StopCoroutine(runningProcess);
        }

        public ProcessType GetProcessType() {
            return _processRunner?.Process?.ProcessType ?? ProcessType.NOT_SET;
        }
    }
}