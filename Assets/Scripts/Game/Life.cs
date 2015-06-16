using System;
using UnityEngine;

class Life : MonoBehaviour
{
    public event Action<uint> OnAddLife;
    public event Action<uint> OnTakeLife;

    [SerializeField] private uint startingLife;

    private uint currentLife;

    public void AddLife()
    {
        currentLife += 1;
        if (OnAddLife != null)
            OnAddLife(currentLife);
    }

    public void RemoveLife()
    {
        currentLife -= 1;
        if (OnTakeLife != null)
            OnTakeLife(currentLife);
    }

    private void Awake()
    {
        currentLife = startingLife;
    }
}

