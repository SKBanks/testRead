using System.Collections;
using UnityEngine;

namespace com.bandags.spacegame.process {
    public abstract class Process : IProcess {
        [field: SerializeReference] public ProcessType ProcessType { get; }
        [field: SerializeReference] public IProcess Next { get; private set; }
        [field: SerializeReference] public ProcessState State { get; private set; }
        protected abstract IEnumerator Update();
        public virtual void OnInterrupt() { }
        protected virtual void Enter() { }
        protected virtual void Exit() { }

        protected Process(ProcessType processType) {
            ProcessType = processType;
            State = ProcessState.CREATED;
        }

        public IProcess SetNext(IProcess nextProcess) {
            Next = nextProcess;
            return this;
        }

        public IEnumerator Run() {
            State = ProcessState.STARTING;
            Enter();
            State = ProcessState.RUNNING;
            yield return Update();
            State = ProcessState.FINISHED;
            Exit();
            State = ProcessState.NEXT;
        }
    }
}