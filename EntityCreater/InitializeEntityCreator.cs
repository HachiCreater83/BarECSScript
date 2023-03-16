
using Unity.Entities;

public class InitializeEntityCreator : IInitialEntityCreator
{
    public void Create(){
        EntityManager manager = World.Active.EntityManager;
        EntityArchetype archetype = manager.CreateArchetype( typeof(ECS.Components.GameStateData));
        Entity entity = manager.CreateEntity(archetype);
        manager.SetComponentData(entity, new ECS.Components.GameStateData(){current = ECS.Components.GameState.None,prev = ECS.Components.GameState.None,next = ECS.Components.GameState.None } );

        archetype = manager.CreateArchetype( typeof(ECS.Components.ChangeGameStateRequester), typeof(ECS.Components.DestoryData));
        entity = manager.CreateEntity(archetype);
        manager.SetComponentData(entity, new ECS.Components.ChangeGameStateRequester(){ isRequest = 1, state = ECS.Components.GameState.Ready } );
    }
}