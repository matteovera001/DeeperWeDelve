using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class FightStarter : MonoBehaviour
{
    public List<UnitController> pack;
    public Collider col;
    public bool triggered = false;
    private void OnTriggerEnter(Collider other)
    {
        if (other.CompareTag("PlayerUnit")&&triggered==false)
        {
            col = other;
            Aggro();
            triggered = true;
        }
    }

    public virtual void Aggro()
    {
        foreach (var unit in pack)
        {
            unit.SetNewTarget(col.transform);
        }
    }
}
