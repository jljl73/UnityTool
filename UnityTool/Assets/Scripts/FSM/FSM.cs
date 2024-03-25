using Cysharp.Threading.Tasks;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;

namespace Mignon.State
{
    public class FSM
    {
        public eStateType StateType { get; protected set; }
        private StateBase CurState = null;

        public FSM()
        {
            StateType = eStateType.None;
        }

        public void ChangeState(StateBase inNextState)
        {
            if (CurState != null)
                CurState.OnStateExit();

            CurState = inNextState;
            CurState.OnStateEnter();
            StateType = CurState.StateType;
        }
    }
}
