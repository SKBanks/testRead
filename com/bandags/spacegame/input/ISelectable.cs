namespace com.bandags.spacegame.input{
    public interface ISelectable {
        void Select();
        void UnSelect();
        SelectableType GetSelectableType();
        string GetSelectableName();
    }
}