
using Unity.Entities;

namespace ECS.Systems
{

    [UpdateInGroup(typeof(PostGameGroup))]
    [UpdateAfter(typeof(ResolveChangeGameStateRequestSystem))]
    public class ChangeGameStateSystem : ComponentSystem
    {

        protected override void OnUpdate()
        {
            EntityManager manager = World.Active.EntityManager;

            //多重で変更処理が走らないように
            bool isExecuteChange = false;
            Entities.ForEach((ref Components.GameStateData state) =>
            {
                if (!isExecuteChange && state.prev != state.next)
                {
                    ChangeGameState(ref state);
                    state.prev = state.next;
                    state.current = state.next;
                    isExecuteChange = true;
                }
            });

        }

        void ChangeGameState(ref Components.GameStateData state)
        {
            DestoryPrevSceneEntity(state.prev);
            CreateSceneEntity(state.next);
        }

        void DestoryPrevSceneEntity(Components.GameState state)
        {
            ComponentType type = null;
            EntityManager manager = World.Active.EntityManager;
            /*ゲームの状態によってゲームを管理する条件式
             * Readyはゲームを開始する前の状態
             * Gameはプレイ中の状態
             * Finishはゲームを終えた状態
             */

            switch (state)
            {
                case Components.GameState.Ready:
                    type = ComponentType.ReadOnly<Components.GameReadyEntity>();
                    break;

                case Components.GameState.Game:
                    type = ComponentType.ReadOnly<Components.GameEntity>();
                    break;

                case Components.GameState.Finish:
                    type = ComponentType.ReadOnly<Components.GameFinishEntity>();
                    break;


                default:
                    return;
            }

            Entities.WithAny(type).ForEach((Entity entity) =>
            {
                manager.DestroyEntity(entity);
            });
        }


        void CreateSceneEntity(Components.GameState state)
        {
            IEntityCreator creator = default;

        /*ゲームの状態によってゲームを管理する条件式
         * Readyはゲームを開始する前の状態
         * Gameはプレイ中の状態
         * Finishはゲームを終えた状態
         */
            switch (state)
            {
                case Components.GameState.Ready:
                    creator = new GameReadyCreator();
                    break;

                case Components.GameState.Game:
                    creator = new GameCreator();
                    break;

                case Components.GameState.Finish:
                    creator = new GameFinishCreator();
                    break;
                default:
                    return;
            }

            creator.Create();
        }

    }
}