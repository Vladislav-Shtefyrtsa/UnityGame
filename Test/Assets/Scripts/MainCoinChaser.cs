using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class MainCoinChaser : MonoBehaviour
{
    GameObject target;

    void Start()
    {
        string objectNum = this.gameObject.name.Remove(0, 12);
        objectNum = objectNum.Remove(objectNum.Length - 1);
        int objectNumInt = int.Parse(objectNum);
        int objectNumPrevious = objectNumInt - 1;

        target = GameObject.Find("PlayerCoin (" + objectNumPrevious.ToString() + ")");
    }

    void Update()
    {
        if (target != null)
        {
            Vector3 displacementFromTarget = target.transform.position - transform.position;
            Vector3 directionNormalized = displacementFromTarget.normalized;
            Vector3 velocity = directionNormalized * 3.5f;
            float distance = displacementFromTarget.magnitude;
            transform.Translate(new Vector3(velocity.x, 0, 0) * Time.deltaTime);
        }
    }
}
