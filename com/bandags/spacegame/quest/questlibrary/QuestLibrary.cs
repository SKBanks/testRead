using System;
using System.Collections.Generic;
using System.Linq;
using com.bandags.spacegame.data.quests;
using com.bandags.spacegame.player;
using UnityEngine;

namespace com.bandags.spacegame.quest {
    [Serializable]
    public class QuestLibrary : IQuestLibrary {
        [field: SerializeReference] private readonly Dictionary<QuestType, IQuest> _questLibrary;
        [field: SerializeReference] private Dictionary<QuestType, IQuest> _availableQuests;

        public QuestLibrary() {
            _questLibrary = new Dictionary<QuestType, IQuest>();
        }
        
        public void LoadLibrary(List<QuestScriptableObject> questScriptableObjects) {
            questScriptableObjects.ForEach(quest => {
                var questToAdd = GameEngine.Instance.Factory.QuestFactory.CreateQuest(quest);
                _questLibrary.Add(questToAdd.QuestType, questToAdd);
            });
        }

        public void FilterLibrary(List<PlayerQuest> availablePlayerQuests, List<PlayerQuest> completedPlayerQuests) {
            var UnavailableQuests = new List<QuestType>();
            availablePlayerQuests.ForEach(availableQuests => {
                UnavailableQuests.Add(availableQuests.QuestType);
            });
            
            completedPlayerQuests.ForEach(completedQuests => {
                UnavailableQuests.Add(completedQuests.QuestType);
            });
            
            _availableQuests = new Dictionary<QuestType, IQuest>();

            foreach (var quest in _questLibrary.Where(quest => !UnavailableQuests.Contains(quest.Key))) {
                _availableQuests.Add(quest.Key, quest.Value);
            }
        }
        
        public void CheckForAvailableQuestsToActivate() {
            var availableQuests = _availableQuests.Where(quest => quest.Value.StartingRequirementsMet()).Select(quest => quest.Key).ToList();
            availableQuests.ForEach(questType => {
                _availableQuests.Remove(questType);
                GameEngine.Instance.CurrentPlayer.QuestManager.ActivateQuest(questType);
            });
        }
        
        public IQuest GetQuestByType(QuestType questType) {
            return _questLibrary[questType];
        }
    }
}