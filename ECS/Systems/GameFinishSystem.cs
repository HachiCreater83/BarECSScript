
using Unity.Entities;

namespace ECS.Systems {

    [UpdateInGroup(typeof(GameGroup))]
    public class GameFinish : ComponentSystem
    {
        protected override void OnUpdate(){

            Entities.ForEach(( ref Components.GameFinish game, ref Components.InputInfomation info, ref Components.ChangeGameStateRequester stateRequester )=>{
                if( info.isClick == 1 ) {
                    stateRequester.isRequest = 1;
                    stateRequester.state = Components.GameState.Ready;
                }
            });

        }
    }
}