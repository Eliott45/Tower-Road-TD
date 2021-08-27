using UnityEngine;

namespace Old.Scripts
{
    public class EnemyStateMachine : StateMachineBehaviour
    {
        public override void OnStateExit(Animator animator, AnimatorStateInfo stateInfo, int layerIndex)
        {
            animator.GetComponent<Enemy>().Die();
        }
    }
}
