using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class CheckPoint : MonoBehaviour
{
    [SerializeField] GameObject Player;
    [SerializeField] List<GameObject> CheckPoints;
    [SerializeField] Vector3 vectorPoint;
    [SerializeField] float dead;

    // Update is called once per frame
    void Update()
    {
        if(Player.transform.position.y < -dead)
        {
            Player.transform.position = vectorPoint;
        }
    }

    private void OnTriggerEnter(Collider other)
    {
        vectorPoint = Player.transform.position;
        Destroy(other.gameObject);
    }
}
