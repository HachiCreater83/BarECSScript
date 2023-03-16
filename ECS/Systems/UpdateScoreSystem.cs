
using UnityEngine.UI;
using Unity.Entities;

namespace ECS.Systems
{

    [UpdateInGroup(typeof(GameGroup))]
    [UpdateAfter(typeof(BulletCollisionSystem))]
    [DisableAutoCreation]
    public class UpdateScoreSystem : ComponentSystem
    {
        readonly Text _ScoreText;

        EntityQuery _query;

        public UpdateScoreSystem(Text text)
        {
            _ScoreText = text;
        }

        protected override void OnUpdate()
        {
            _query = GetEntityQuery(ComponentType.ReadOnly<Components.AddScoreData>());
            EntityManager manager = World.Active.EntityManager;
            Entities.ForEach((ref Components.Score score) =>
            {
                score.value += _query.CalculateEntityCount();
                _ScoreText.text = score.value.ToString();
            });
        }
    }
}