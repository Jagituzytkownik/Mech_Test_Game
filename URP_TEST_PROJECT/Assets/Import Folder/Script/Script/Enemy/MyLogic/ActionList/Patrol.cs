using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.AI;
public class Patrol : IAction
{
    private bool patrol = false;
    private Vector3 destination;
    private RaycastHit hitPoint;
    private float distanceDetection;
    public Patrol(float distanceDetection)
    {
        this.distanceDetection = distanceDetection;
    }
    
    public IEnumerator Actions(GameObject player, GameObject enemy, EnemyAction enemyAction)
    {
       if (patrol == false)
       {
            Physics.Raycast(new Vector3(Random.Range(enemy.transform.position.x - 100f, enemy.transform.position.x + 100f), 600f, Random.Range(enemy.transform.position.z - 100f, enemy.transform.position.z + 100f)), Vector3.down, out hitPoint, 1000.0f, 110);
            destination = new Vector3(hitPoint.point.x, hitPoint.point.y+1f, hitPoint.point.z);
           patrol = true;
       }
       if (Vector3.Distance(player.transform.position, enemy.transform.position) > distanceDetection)
       {
           //Patroluj
           enemy.GetComponent<Animator>().SetBool("Walk", true);
           enemy.GetComponent<NavMeshAgent>().isStopped = false;
           if ((int)enemy.transform.position.x == (int) destination.x&& (int) enemy.transform.position.z == (int)destination.z)
           {
               patrol = false;
           }
           enemy.GetComponent<NavMeshAgent>().SetDestination(destination);
           StateAction(ActionState.actionRunning, enemyAction);
       }
       else if (Vector3.Distance(player.transform.position, enemy.transform.position) <= distanceDetection)
       {
            //Przerwij Patrol
            enemy.GetComponent<Animator>().SetBool("Walk", true);
           enemy.GetComponent<NavMeshAgent>().isStopped = false;
           StateAction(ActionState.actionComplete, enemyAction);
       }
       else
        {
            //B³¹d
            enemy.GetComponent<NavMeshAgent>().isStopped = false;
           StateAction(ActionState.actionFail, enemyAction);
       }
        yield return null;
    }

    public void StateAction(ActionState enemyState, EnemyAction enemyAction)
    {
        enemyAction.SetState(enemyState);
    }
}
