using System.Collections;
using System.Collections.Generic;
using System.Threading;
using UnityEngine;

public class EnemyDummy : MonoBehaviour
{
    [SerializeField] private Animator animator;

    private void OnCollisionEnter(Collision spell)
    {
        animator.ResetTrigger("Burning");
        animator.ResetTrigger("Frozen");
        animator.ResetTrigger("Pushed");

        if (spell.gameObject.CompareTag("Fireball"))
            animator.SetTrigger("Death");
        if (spell.gameObject.CompareTag("Frostbolt")) 
        {
            animator.SetTrigger("Death");
            StartCoroutine(PauseAnimation());
        }
            
        if (spell.gameObject.CompareTag("Stunningblow"))
            animator.SetTrigger("Pushed");
    }

    public void ActivateDummy()
    {
        animator.SetTrigger("Active");
    }

    private IEnumerator PauseAnimation()
    {
        yield return new WaitForSeconds(1.0005f);
        animator.speed = 0;
    }


}
