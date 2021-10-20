using UnityEngine;

namespace Archer
{
    public class ArcherAttackAnimator : StateMachineBehaviour
    {
        private static readonly int Attack = Animator.StringToHash("Attack");

        public override void OnStateExit(Animator animator, AnimatorStateInfo stateInfo, int layerIndex)
        {
            animator.SetBool(Attack, false); 
        }
    }
}
