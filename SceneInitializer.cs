
using System;
using System.Collections.Generic;
using UnityEngine;
using System.Linq;
using System.Reflection;
using Unity.Entities;


public class SceneInitializer : MonoBehaviour
{
    [SerializeField]
    UnityEngine.UI.Text _titleText = default;
    [SerializeField]
    UnityEngine.UI.Text _scoreText = default;

    [SerializeField]
    Mesh _bulletMesh = default;

    [SerializeField]
    Material _bulleMaterial = default;


    private void Start()
    {
        World world = World.Active;

        GameGroup gameGroup = world.GetOrCreateSystem<GameGroup>();
        gameGroup.AddSystemToUpdateList(world.CreateSystem<ECS.Systems.BulletGenerateSystem>(_bulletMesh, _bulleMaterial));
        gameGroup.AddSystemToUpdateList(world.CreateSystem<ECS.Systems.UpdateScoreSystem>(_scoreText));
        gameGroup.SortSystemUpdateList();

        PostGameGroup postGameGroup = world.GetOrCreateSystem<PostGameGroup>();
        postGameGroup.AddSystemToUpdateList(world.CreateSystem<ECS.Systems.TitleTextSystem>(_titleText));

        postGameGroup.SortSystemUpdateList();

        ScriptBehaviourUpdateOrder.UpdatePlayerLoop(world);

        ExecuteMonoBehaviourEntityCreator();
        ExecuteEntityCreator();
    }


    void ExecuteEntityCreator()
    {
        IEnumerable<Type> creatorTypes = Assembly.GetExecutingAssembly().GetTypes().Where(c => c.GetInterfaces().Any(t => t == typeof(IInitialEntityCreator)));
        foreach (Type creatorType in creatorTypes)
        {
            IInitialEntityCreator creator = Activator.CreateInstance(creatorType) as IInitialEntityCreator;
            creator.Create();
        }
    }

    void ExecuteMonoBehaviourEntityCreator()
    {
        foreach (Component n in FindObjectsOfType<Component>())
        {
            IInitialMonoBehaviourEntityCreator component = n as IInitialMonoBehaviourEntityCreator;
            if (component != null)
            {
                component.Create();
            }
        }

    }
}
