using Unity.Entities;

using Unity.Transforms;
using Unity.Mathematics;

public class GameReadyCreator : IEntityCreator
{
    public void Create(){
        EntityManager manager = World.Active.EntityManager;
        EntityArchetype archetype = manager.CreateArchetype(
            typeof(ECS.Components.GameReady),
            typeof(ECS.Components.InputInfomation),
            typeof(ECS.Components.ChangeGameStateRequester),
            typeof(ECS.Components.GameReadyEntity)  );
        manager.CreateEntity(archetype);



        Unity.Collections.NativeArray<Entity> entityArray = manager.GetAllEntities();
        foreach(Entity entity in entityArray){

            if( manager.HasComponent<ECS.Components.Player>(entity) ) {
                manager.SetComponentData(entity, new Translation{ Value = new float3(0.0f, -4.5f, 0.0f   ) });
                break;
            }
        }
    }
}