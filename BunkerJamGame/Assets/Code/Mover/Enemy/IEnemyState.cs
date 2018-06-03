using UnityEngine;
using System.Collections;

namespace JamGame
{
    public interface IEnemyState
    {
        void Enter();

        void Execute(float dt);

        void Exit();

        string StateName();
    }
}

