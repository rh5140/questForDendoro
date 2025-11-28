    // MoveTo.cs 
    // Modified from: https://docs.unity3d.com/Packages/com.unity.ai.navigation@2.0/manual/CreateNavMeshAgent.html
    using UnityEngine;
    using UnityEngine.AI;

    public class MoveTo : MonoBehaviour {

       public Transform goal;
       public float interval = 3f;
       private float currTime = 0f;
       NavMeshAgent agent;

       void Start () {
          agent = GetComponent<NavMeshAgent>();
          agent.destination = goal.position;
       }

       void Update()
       {
            if (currTime > interval)
            {
                agent.destination = goal.position;
                currTime = 0;
            }
            currTime += Time.deltaTime;
       }
    }
