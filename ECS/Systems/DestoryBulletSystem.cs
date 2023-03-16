
using Unity.Entities;
using Unity.Transforms;

namespace ECS.Systems {

    [UpdateInGroup(typeof(GameGroup))]
    public class DestoryBulletSystem : ComponentSystem
    {
        protected override void OnUpdate(){
            EntityManager manager = World.Active.EntityManager;
            Entities.ForEach(( Entity Entity, ref Components.Bullet bullet, ref Translation pos )=>{
                if( pos.Value.y < -7.0f ){
                    manager.AddComponent<Components.DestoryData>(Entity);

                    Entity entity = manager.CreateEntity(typeof(Components.ChangeGameStateRequester), typeof(Components.GameEntity) );
                    manager.SetComponentData(entity, new Components.ChangeGameStateRequester{ isRequest = 1, state = Components.GameState.Finish });
                }
            });
        }

    }
}