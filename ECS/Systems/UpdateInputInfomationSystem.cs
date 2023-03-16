
using UnityEngine;
using Unity.Entities;

namespace ECS.Systems
{

    [UpdateInGroup(typeof(PreviousGameGroup))]
    public class UpdateInputInfomationSystem : ComponentSystem
    {

        /// <summary>
        /// プレイヤーの入力に関して値を返す処理
        /// </summary>
        protected override void OnUpdate()
        {
            //マウスのクリックに反応してゲームを開始できるようにする
            bool isClick = Input.GetMouseButton(0);
            Components.InputState inputState = Components.InputState.None;

            //左、右移動に対応するキーの反応で移動する判定を飛ばす
            if (Input.GetKey(KeyCode.LeftArrow))
            {
                inputState = Components.InputState.Left;
            }

            else if (Input.GetKey(KeyCode.RightArrow))
            {
                inputState = Components.InputState.Right;
            }


            Entities.ForEach((ref Components.InputInfomation info) =>
            {
                if (isClick)
                {
                    if (info.isReleased == 1)
                    {
                        info.isClick = 1;
                    }

                }
                else
                {
                    info.isClick = 0;
                    info.isReleased = 1;
                }

                info.state = inputState;
            });

        }
    }
}