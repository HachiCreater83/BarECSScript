
using Unity.Entities;
using Unity.Mathematics;

namespace ECS.Components
{
    public struct Wall : IComponentData
    {
        public float3 position;
    }
}
