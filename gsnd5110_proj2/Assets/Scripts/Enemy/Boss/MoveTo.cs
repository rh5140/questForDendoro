    // MoveTo.cs 
    // Modified from: https://docs.unity3d.com/Packages/com.unity.ai.navigation@2.0/manual/CreateNavMeshAgent.html
    using System.Collections;
    using UnityEngine;
    using UnityEngine.AI;

    public class MoveTo : MonoBehaviour {

      public Transform goal;
      public float interval = 3f;
      private float currTime = 0f;
      NavMeshAgent agent;

      void Start () {
         agent = GetComponent<NavMeshAgent>();
      }

      public void MoveToTarget()
      {
         agent.SetDestination(goal.position);
      }

      public void StopMoving()
      {
         agent.ResetPath();
      }
    }
