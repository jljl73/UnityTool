using Cysharp.Threading.Tasks;
using System.Collections;
using System.Collections.Generic;
using Unity.VisualScripting;
using UnityEngine;

namespace Mignon.State
{
    public enum eStateType
    {
        None,

        Born,
        Die,

        Idle,
        Patrol,
        Attack,
        Skill,
    }

    public abstract class StateBase
    {
        public abstract eStateType StateType { get; }

        public StateBase()
        {
        }

        public abstract UniTask OnStateEnter();
        public abstract UniTask OnStateExit();
    }
}
