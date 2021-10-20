using UnityEngine;

namespace Units
{
    public class UnitDieDemolish : StateMachineBehaviour
    {
        private static readonly int Demolish = Animator.StringToHash("demolish");

        public override void OnStateExit(Animator animator, AnimatorStateInfo stateInfo, int layerIndex)
        {
            animator.SetBool(Demolish, true);
        }
    }
}
