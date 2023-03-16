
using Unity.Entities;

namespace ECS.Systems {

    [UpdateInGroup(typeof(PostGameGroup))]
    [UpdateBefore(typeof(DestroyEntitySystem))]
    public class ResolveChangeGameStateRequestSystem : ComponentSystem
    {

        protected override void OnUpdate(){
            EntityManager manager = World.Active.EntityManager;
            Components.GameState requestState = Components.GameState.None;
            Entities.ForEach(( Entity entity, ref Components.ChangeGameStateRequester requester )=>{
                if( requester.isRequest == 1 ){
                    requestState = requester.state;
                    requester.isRequest = 0;
                }
            });

            if( requestState != Components.GameState.None ){
                Components.GameStateData state = GetSingleton<Components.GameStateData>();
                Components.GameState prevScene = state.prev;
                state.next = requestState;
                SetSingleton(state);
            }

        }
    }
}