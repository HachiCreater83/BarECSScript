using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using Unity.Entities;


namespace ECS.Components {
    public enum GameState{
        Ready,
        Game,
        Finish,
        None,
    }

    public struct GameStateData : IComponentData
    {
        public GameState current;
        public GameState prev;
        public GameState next;

    }
}