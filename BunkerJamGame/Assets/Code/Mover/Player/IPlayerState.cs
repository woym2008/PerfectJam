using UnityEngine;
using System.Collections;

namespace JamGame
{
    public interface IPlayerState
    {
        void Enter();

        void Execute(float dt);

        void Exit();

        string StateName();
    }
}

