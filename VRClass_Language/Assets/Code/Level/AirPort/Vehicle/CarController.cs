using UnityEngine;
using System.Collections;

public class CarController : MonoBehaviour {

    public Transform[] waypoints;
    public Transform car;
    public Vector3 destinyWaypoint;
    public int currentWaypoint;

    [Range(0.0f, 15f)]
    public float maxDesplacementDistance = 0.1f;
    [Range(0.1f, 5f)]
    public float minDistanceToPointError = 0.3f;
    [Range(0.1f, 5f)]
    public float maxRotationDistance = 2f;

    private Vector3 characterTravelDirection;
    private Quaternion movementQuaternionRotation;
    private Vector3 diferenceWaypointToCharacter;
    private bool finished = false;
    public float t = 0;

    private void Start()
    {
        if (waypoints.Length != 0)
        {
            checkWaypoints();
        }
    }

    private void checkWaypoints()
    {
        if (waypoints.Length != 0)
        {
            destinyWaypoint = waypoints[0].position;
        }
        else
        {
            throw new UnityException(">The waypoint array is empty.");
        }
    }

    private void Update()
    {
        move();
    }

    public void move()
    {
        t += Time.deltaTime * maxDesplacementDistance;
        if (t > 1)
        {
            t = 1;
        }

        //Vector3 auxiliar;
        //auxiliar = Vector3.Lerp(car.position, destinyWaypoint, t); ;
        //auxiliar.y = car.position.y;
        //auxiliar = auxiliar - car.position;
        //Debugger.printLog(auxiliar + " ++ " + car.forward);
        car.Translate(transform.forward * Time.deltaTime * maxDesplacementDistance);
        //car.position = auxiliar;
        rotateCharacter();
        checkDestinyWaypoint();
    }

    private void rotateCharacter()
    {
        characterTravelDirection = new Vector3(destinyWaypoint.x, 0, destinyWaypoint.z) - new Vector3(car.position.x, 0, car.position.z);
        movementQuaternionRotation = Quaternion.LookRotation(characterTravelDirection);
        car.rotation = Quaternion.Slerp(car.rotation, movementQuaternionRotation, Time.deltaTime * maxRotationDistance);
    }

    private void checkDestinyWaypoint()
    {
        diferenceWaypointToCharacter = car.position - destinyWaypoint;
        diferenceWaypointToCharacter.y = 0;
        if (diferenceWaypointToCharacter.magnitude < minDistanceToPointError)
        {
            changeCurrentToNextWaypoint();
            t = 0;
        }
    }

    private void changeCurrentToNextWaypoint()
    {
        if (currentWaypoint < waypoints.Length - 1)
        {
            currentWaypoint++;
            destinyWaypoint = waypoints[currentWaypoint].position;
            finished = false;
        }
        else
        {
            finished = true;
            currentWaypoint = 0;
            destinyWaypoint = waypoints[currentWaypoint].position;
        }
    }

    public bool turnCharacter()
    {
        characterTravelDirection = new Vector3(destinyWaypoint.x, 0, destinyWaypoint.z) - new Vector3(car.position.x, 0, car.position.z);
        movementQuaternionRotation = Quaternion.LookRotation(characterTravelDirection);
        car.rotation = Quaternion.Slerp(car.rotation, movementQuaternionRotation, Time.deltaTime * maxRotationDistance);
        if (Vector3.Angle(car.forward, characterTravelDirection) < 10)
        {
            return true;
        }
        else
        {
            return false;
        }
    }

    public void setNewWaypoints(Transform[] newWaypoints)
    {
        waypoints = newWaypoints;
        checkWaypoints();
    }
}
