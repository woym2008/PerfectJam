using System.Collections;
using System.Collections.Generic;
using UnityEngine;

namespace JamGame
{
    public interface IMoveObject
    {
        void Move(Vector3 dir);

        void Jump();
    }
}

