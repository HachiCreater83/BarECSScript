
using UnityEngine;
using Unity.Entities;
using Unity.Transforms;
using Unity.Rendering;
using Unity.Mathematics;

namespace ECS.Systems {

    /// <summary>
    /// 得点用の弾を生成するためのスクリプト
    /// </summary>
    [UpdateInGroup(typeof(GameGroup))]
    [DisableAutoCreation]
    public class BulletGenerateSystem : ComponentSystem
    {
        Mesh _mesh = null;
        Material _material = null;

        EntityArchetype _bulletType;
        public BulletGenerateSystem(Mesh mesh, Material mat){
            _mesh = mesh;
            _material = mat;
        }


        protected override void  OnCreate(){
            var manager = World.Active.EntityManager;
            _bulletType = manager.CreateArchetype(
                typeof(ECS.Components.Bullet),
                typeof(ECS.Components.Velocity),
                typeof(ECS.Components.ToPlayerCollision),
                typeof(Scale),
                typeof(Translation),
                typeof(RenderMesh),
                typeof(LocalToWorld),
                typeof(ECS.Components.GameEntity));
        }

        protected override void OnUpdate(){

            Entities.ForEach(( Entity entity, ref ECS.Components.BulletGenerator generator, ref ECS.Components.Timer timer )=>{
                timer.value += Time.deltaTime;
                if( timer.value > generator.interval ) {
                    timer.value = 0.0f;
                    CreateBullet();
                }
            });
        }


        void CreateBullet() {
            var manager = World.Active.EntityManager;
            var bullet = manager.CreateEntity(_bulletType);


            var range = 2.5f;
            manager.SetComponentData(bullet, new Translation { Value = new float3( UnityEngine.Random.Range(-range, range) , 7.0f, 0) } );

            var size = 1.0f;
            manager.SetComponentData(bullet, new Scale { Value = size } );

            var speed = 2f;
            manager.SetComponentData(bullet, new ECS.Components.Velocity { value = new float3( 0 , -speed, 0) } );

            manager.SetSharedComponentData(bullet, new RenderMesh(){ mesh = _mesh, material = _material });

        }
    }
}