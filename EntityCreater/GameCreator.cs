
using Unity.Entities;


public class GameCreator : IEntityCreator
{
    const float BulletInterval = 1.5f;
    public void Create(){
        EntityManager manager = World.Active.EntityManager;

        //game
        EntityArchetype gameArchetype = manager.CreateArchetype( typeof(ECS.Components.Game), typeof(ECS.Components.InputInfomation), typeof(ECS.Components.GameEntity) );
        manager.CreateEntity(gameArchetype);

        //bulletGenerater
        EntityArchetype bulletGeneratorArchetype = manager.CreateArchetype( typeof(ECS.Components.GameEntity) ,typeof(ECS.Components.BulletGenerator), typeof(ECS.Components.Timer) );
        Entity bulletGenerator = manager.CreateEntity(bulletGeneratorArchetype);
        manager.SetComponentData(bulletGenerator, new ECS.Components.BulletGenerator(){ interval = BulletInterval } );

        //score
        EntityArchetype scoreArchetype = manager.CreateArchetype( typeof(ECS.Components.Score), typeof(ECS.Components.GameEntity));
        manager.CreateEntity(scoreArchetype);

    }
}