using System;
using com.bandags.spacegame.data.serialization.planet;
using com.bandags.spacegame.job;

namespace com.bandags.spacegame.planet {
    [Serializable]
    public class DeliverItemToNeighborJob : Job {
        public DeliverItemToNeighborJob(JobData jobData) : base(jobData) { }
    }
}