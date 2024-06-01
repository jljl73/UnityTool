using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using Cysharp.Threading.Tasks;

namespace Mignon
{
    public static class AnimationExtensions
    {
        public static async UniTask WaitForAniamtionFinish(this Animator animator)
        {
            var length = animator.GetCurrentAnimatorStateInfo(0).length;
            await UniTask.WaitForSeconds(length);
        }
    }
}
