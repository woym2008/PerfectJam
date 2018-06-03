using System.Collections;
using System.Collections.Generic;
using UnityEngine;

namespace JamGame
{
    public interface IGameState
    {
        void Enter();

        void Exit();

        void Execute(float dt);      
    }
}

