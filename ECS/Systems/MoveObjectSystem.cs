using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using Unity.Entities;
using Unity.Transforms;
using Unity.Rendering;
using Unity.Mathematics;

namespace ECS.Systems {

    [UpdateInGroup(typeof(GameGroup))]
    public class MoveObjectSystem : ComponentSystem
    {

        protected override void OnUpdate(){
            Entities.ForEach(( Entity entity, ref Translation position, ref ECS.Components.Velocity vel )=>{
                position.Value += vel.value * Time.deltaTime;
            });
        }

    }
}