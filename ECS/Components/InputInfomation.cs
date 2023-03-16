
using Unity.Entities;


namespace ECS.Components {

    public enum InputState {
        None,
        Right,
        Left,
    }


    public struct InputInfomation : IComponentData
    {
        public int isClick;

        public int isReleased;

        public InputState state;
    }
}