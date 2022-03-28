using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.AI;
public class GoToPlayer : IAction
{
    public void StateAction(ActionState enemyState,IEnemyAction enemyAction)
    {
        enemyAction.SetState(enemyState);
    }

    public IEnumerator Actions(GameObject player, GameObject enemy, IEnemyAction enemyAction, float vectorDistance, float minDistance, float farDistance)
    {
        if (Vector3.Distance(player.transform.position, enemy.transform.position) <= vectorDistance&& Vector3.Distance(player.transform.position, enemy.transform.position) > farDistance)
        {
            enemy.GetComponent<Animator>().SetBool("Walk", true);
            enemy.GetComponent<Animator>().SetBool("Run", false);
            enemy.GetComponent<NavMeshAgent>().isStopped = false;
            enemy.GetComponent<NavMeshAgent>().SetDestination(player.transform.position);
            StateAction(ActionState.actionRunning, enemyAction);
        }
        else if(Vector3.Distance(player.transform.position, enemy.transform.position) < farDistance-10f&& Vector3.Distance(player.transform.position, enemy.transform.position) > minDistance)
        {
            enemy.GetComponent<Animator>().SetBool("Walk", true);
            enemy.GetComponent<Animator>().SetBool("Run", true);
            enemy.GetComponent<NavMeshAgent>().speed = 100;
            enemy.GetComponent<NavMeshAgent>().isStopped = false;
            enemy.GetComponent<NavMeshAgent>().SetDestination(player.transform.position);
            StateAction(ActionState.actionRunning, enemyAction);
        }
        else if (Vector3.Distance(player.transform.position, enemy.transform.position) <= minDistance|| Vector3.Distance(player.transform.position, enemy.transform.position) > farDistance - 10f)
        {
            enemy.GetComponent<NavMeshAgent>().isStopped = true;
            enemy.GetComponent<Animator>().SetBool("Walk", false);
            enemy.GetComponent<Animator>().SetBool("Run", false);
            StateAction(ActionState.actionComplete, enemyAction);
        }
        else
        {
            enemy.GetComponent<NavMeshAgent>().isStopped = true;
            enemy.GetComponent<Animator>().SetBool("Walk", false);
            enemy.GetComponent<Animator>().SetBool("Run", false);
            StateAction(ActionState.actionFail, enemyAction);
        }
        yield return null;
    }
}
