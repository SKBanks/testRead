using System;
using System.Collections.Generic;
using com.bandags.spacegame.data.serialization.planet;
using UnityEngine;

namespace com.bandags.spacegame.data.jobs {
    [Serializable]
    public class JobManagerData {
        [field: SerializeReference]  public List<JobData> ActiveJobs;

        public JobManagerData() {
            ActiveJobs = new List<JobData>();
        }
    }
}