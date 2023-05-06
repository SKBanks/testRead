using System.Collections.Generic;
using com.bandags.spacegame.data;
using com.bandags.spacegame.data.Serialization;
using com.bandags.spacegame.player;
using UnityEngine;

namespace com.bandags.spacegame.quest {
    public class QuestManager : ISerialize<QuestData> {
        public List<PlayerQuest> ActiveQuests => _questData.ActiveQuests;
        public List<PlayerQuest> CompletedQuests => _questData.CompletedQuests;

        [field: SerializeReference] private QuestData _questData;
        
        public QuestData Serialize() {
            return _questData;
        }

        public void Deserialize(QuestData data) {
            _questData = data;
            GameEngine.Instance.QuestLibrary.FilterLibrary(ActiveQuests, CompletedQuests);
        }
        
        public void ActivateQuest(QuestType questType) {
            ActiveQuests.Add(new PlayerQuest {
                QuestType = questType,
                StartingQuestState = QuestState.Not_Started,
                CompleteQuestState = QuestState.Not_Started
            });
        }

        public void CompleteQuest(PlayerQuest playerQuest) {
            playerQuest.CompleteQuestState = QuestState.Completed;
            MoveQuestToCompleted(playerQuest);
        }

        public void MoveQuestToCompleted(PlayerQuest playerQuest) {
            ActiveQuests.Remove(playerQuest);
            CompletedQuests.Add(playerQuest);
            GameDataWriter.SaveGame();
        }

        public void QuestUpdate() {
            CheckForAvailableQuest();
            UpdateActiveQuests();
        }

        private void CheckForAvailableQuest() {
            GameEngine.Instance.QuestLibrary.CheckForAvailableQuestsToActivate();
        }

        private void UpdateActiveQuests() {
            ActiveQuests.ForEach(activeQuest => {
                var quest = GameEngine.Instance.QuestLibrary.GetQuestByType(activeQuest.QuestType);
                QuestUpdateHandler.HandleActiveQuest(this, quest, activeQuest);
            });
        }
    }
}