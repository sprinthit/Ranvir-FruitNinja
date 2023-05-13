using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Combo3X : MonoBehaviour
{
    public GameObject textprefab;
    [SerializeField] Transform TextParent;
    int collisionCounter = 0;
    private bool isCounting;
    public float detector = 0.1f;



    public void Count()
    {
        print("blade");
        if (isCounting)
        {
            collisionCounter++;
            if (collisionCounter >= 3)
            {
                //show msg here
                Destroy(Instantiate(textprefab, TextParent), 2);
            }
        }
        else
        {
            collisionCounter++;
            StartCoroutine(Startcounting());
        }
    }

    IEnumerator Startcounting()
    {
        isCounting = true;
        yield return new WaitForSeconds(detector);
        isCounting = false;
        collisionCounter = 0;
    }
}
