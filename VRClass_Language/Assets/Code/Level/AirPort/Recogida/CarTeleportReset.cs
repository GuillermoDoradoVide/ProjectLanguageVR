using UnityEngine;
using System.Collections;
using System.Collections.Generic;

public class CarTeleportReset : MonoBehaviour {

    public Transform origin;
    public Transform destiny;
    public Transform car;
    public float speed;
    private float t = 0;

    private void Start() {
        origin.position = new Vector3(origin.position.x, car.position.y, origin.position.z);
        destiny.position = new Vector3(destiny.position.x, car.position.y, destiny.position.z);
    }

    // Update is called once per frame
    private void Update()
    {
        moveCar();
    }

    private void moveCar()
    {
        car.position = Vector3.Lerp(origin.position, destiny.position, t);
        calculateT();
    }

    private void calculateT()
    {
        t += speed * Time.deltaTime;
        if (t > 1)
        {
            t = 0;
        }
    }
}
