using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using Unity.Entities;
using Unity.Transforms;
using Unity.Rendering;
using Unity.Mathematics;

namespace ECS.Systems {

    [UpdateInGroup(typeof(PostGameGroup))]
    public class DestroyEntitySystem : ComponentSystem
    {

        protected override void OnUpdate(){
            var manager = World.Active.EntityManager;
            Entities.ForEach(( Entity entity, ref ECS.Components.DestoryData data )=>{
                manager.DestroyEntity(entity);
            });
        }

    }
}