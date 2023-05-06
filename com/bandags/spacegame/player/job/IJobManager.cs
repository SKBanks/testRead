using com.bandags.spacegame.data.jobs;
using com.bandags.spacegame.job;

namespace com.bandags.spacegame.player {
    public interface IJobManager : ISerialize<JobManagerData> {
        void AddJob(Job job);
        void RemoveJob(Job job);
        void UpdateActiveJobs();
    }
}