namespace com.bandags.spacegame {
    public interface ISerialize<T> {
        T Serialize();
        void Deserialize(T data);
    }
}