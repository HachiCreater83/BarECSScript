
using Unity.Entities;


public class GameFinishCreator : IEntityCreator
{
    public void Create(){
        EntityManager manager = World.Active.EntityManager;

        //game
        EntityArchetype archetype = manager.CreateArchetype(
            typeof(ECS.Components.GameFinish),
            typeof(ECS.Components.InputInfomation),
            typeof(ECS.Components.ChangeGameStateRequester),
            typeof(ECS.Components.GameFinishEntity)  );
        manager.CreateEntity(archetype);
    }
}