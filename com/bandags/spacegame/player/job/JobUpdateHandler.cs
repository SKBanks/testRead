using com.bandags.spacegame.job;

namespace com.bandags.spacegame.planet {
    public static class JobUpdateHandler {
        public static void UpdateJob(Job job) {
            //todo: implement this
            if (!job.CompletionRequirementsMet()) return;
            job.CompleteJob();
            GameEngine.Instance.CurrentPlayer.JobManager.RemoveJob(job);
        }
    }
}