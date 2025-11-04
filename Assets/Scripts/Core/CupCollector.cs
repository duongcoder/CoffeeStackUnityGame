using System.Collections.Generic;
using UnityEngine;

public class CupCollector : MonoBehaviour
{
    public Transform stackRoot;
    public float cupHeight = 0.6f;

    private List<GameObject> cups = new List<GameObject>();

    private void OnTriggerEnter(Collider other)
    {
        if (other.CompareTag("Cup"))
        {
            CollectCup(other.gameObject);
        }
    }

    void CollectCup(GameObject cup)
    {
        var col = cup.GetComponent<Collider>();
        if (col) col.enabled = false;

        cups.Add(cup);
        cup.transform.SetParent(stackRoot);

        int index = cups.Count - 1;
        Vector3 newPos = Vector3.forward * cupHeight * index;
        cup.transform.localPosition = newPos;
        cup.transform.localRotation = Quaternion.identity;
    }
}
