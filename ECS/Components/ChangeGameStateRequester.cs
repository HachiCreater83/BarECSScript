
using Unity.Entities;


namespace ECS.Components {

    public struct ChangeGameStateRequester : IComponentData {
        public int isRequest;
        public GameState state;
    }
}