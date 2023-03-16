
using UnityEngine;
using Unity.Entities;
using Unity.Transforms;
using Unity.Mathematics;

namespace ECS.Systems {

    [UpdateInGroup(typeof(GameGroup))]
    public class BulletCollisionSystem : ComponentSystem
    {
        protected override void OnUpdate(){
            EntityManager manager = World.Active.EntityManager;
            Entity player =  GetSingletonEntity<Components.Player>();
            Translation playerPosition = manager.GetComponentData<Translation>(player);
            Entities.ForEach(( Entity Entity, ref Components.Bullet bullet, ref Translation pos, ref Components.ToPlayerCollision col )=>{
                float3 toVec = playerPosition.Value - pos.Value;
                Vector2 toVec2 = new Vector2( toVec.x, toVec.y);
                if( toVec2.SqrMagnitude() < 1.0f ){
                    manager.AddComponent<Components.AddScoreData>(Entity);
                    manager.AddComponent<Components.DestoryData>(Entity);
                }
            });
        }

    }
}