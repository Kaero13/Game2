using UnityEngine;
using UnityEngine.AI;
using LooGame.Utils;
using Unity.VisualScripting;

public class EnemyAI : MonoBehaviour {

    [SerializeField] private State startingState;
    [SerializeField] private float roamingDistanceMax = 7f;
    [SerializeField] private float roamingDistanceMin = 3f;
    [SerializeField] private float roamingTimeMax = 2f;

    private NavMeshAgent navMeshAgent;
    private State state;
    private float roamingTime;
    private Vector3 roamingPosition;
    private Vector3 startingPosition;

    private enum State {
        Roaming
    }

    private void Awake() {
        navMeshAgent = GetComponent<NavMeshAgent>();
        navMeshAgent.updateUpAxis = false;
        navMeshAgent.updateRotation = false;
        state = startingState;
    }

    private void Update() {
        
        switch(state) {
            default:
            case State.Roaming:
                roamingTime -= Time.deltaTime;

                if (roamingTime < 0) {
                    Roamig();
                    roamingTime = roamingTimeMax;
                }
                break;
        }
    }

    private void Roamig() {
        startingPosition = transform.position;
        roamingPosition = GetRoamingPosition();
        navMeshAgent.SetDestination(roamingPosition);
    }

    private Vector3 GetRoamingPosition() {
        return startingPosition + (Utils.GetRandomDir() * UnityEngine.Random.Range(roamingDistanceMin, roamingDistanceMax));
    }
}
