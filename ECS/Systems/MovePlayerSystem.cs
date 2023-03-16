using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using Unity.Entities;
using Unity.Transforms;
using Unity.Rendering;
using Unity.Mathematics;

namespace ECS.Systems {

    [UpdateInGroup(typeof(GameGroup))]
    public class MovePlayerSystem : ComponentSystem
    {

        protected override void OnUpdate(){
            Entities.ForEach(( ref ECS.Components.Player player,ref ECS.Components.Velocity vel, ref ECS.Components.InputInfomation input )=>{
                var state = GetSingleton<ECS.Components.GameStateData>();
                if( state.current != ECS.Components.GameState.Game ) {
                    vel.value = float3.zero;
                    return;
                }

                if( input.state == ECS.Components.InputState.Left ) {
                    vel.value = new float3(-player.speed * Time.deltaTime,0,0);
                } else if( input.state == ECS.Components.InputState.Right ) {
                    vel.value = new float3(player.speed * Time.deltaTime,0,0);
                } else {
                    vel.value = new float3(0,0,0);
                }
            });
        }

    }
}