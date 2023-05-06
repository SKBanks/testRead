using System;
using System.Collections.Generic;
using com.bandags.spacegame.data.jobs;
using com.bandags.spacegame.planet;
using com.bandags.spacegame.player;
using UnityEngine;

namespace com.bandags.spacegame.job {
    [Serializable]
    public class JobManager : IJobManager {
        [field:SerializeReference] private List<Job> ActiveJobs;
        [field:SerializeReference] private JobManagerData _jobManagerData;

        public JobManager() {
            ActiveJobs = new List<Job>();
        } 
        
        public JobManagerData Serialize() {
            _jobManagerData.ActiveJobs.Clear();
            ActiveJobs.ForEach(activeJob => {
                _jobManagerData.ActiveJobs.Add(activeJob.Serialize());
            });
            return _jobManagerData;
        }

        public void Deserialize(JobManagerData managerData) {
            _jobManagerData = managerData;
            
            ActiveJobs.Clear();
            _jobManagerData.ActiveJobs.ForEach(jobData => {
                ActiveJobs.Add(new Job(jobData));
            });
        }

        public void AddJob(Job job) {
            ActiveJobs.Add(job);
        }

        public void RemoveJob(Job job) {
            ActiveJobs.Remove(job);
        }

        public void UpdateActiveJobs() {
            //ActiveJobs.ForEach(JobUpdateHandler.UpdateJob);
            for (var x = ActiveJobs.Count - 1; x >= 0; x--) {
                JobUpdateHandler.UpdateJob(ActiveJobs[x]);
            }
        }
    }
}