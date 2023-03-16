using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;
using Unity.Entities;

namespace ECS.Systems {

    [UpdateInGroup(typeof(PostGameGroup))]
    [DisableAutoCreation]
    public class TitleTextSystem : ComponentSystem
    {

        readonly Text _titleText;

        public TitleTextSystem(Text text){
            _titleText = text;
        }



        protected override void OnUpdate(){
            var manager = World.Active.EntityManager;
            var state = GetSingleton<ECS.Components.GameStateData>();
            if( state.current == ECS.Components.GameState.Ready ){
                _titleText.text = "click start";
            } else if( state.current == ECS.Components.GameState.Finish ){
                _titleText.text = "Finish";
            } else {
                _titleText.text = "";
            }

        }
    }
}