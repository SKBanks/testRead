namespace com.bandags.spacegame.data {
    public static class GameDataWriter {
        public static void SaveGame() {
            SerializableDataWriter.SaveGalaxyToPath(GameEngine.Instance.Galaxy);
            SerializableDataWriter.SavePlayerToPath(GameEngine.Instance.CurrentPlayer);
        }
    }
}