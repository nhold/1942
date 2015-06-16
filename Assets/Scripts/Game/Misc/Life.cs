using System;
using UnityEngine;

public class Life : MonoBehaviour
{
    public event Action<uint> OnAddLife;
    public event Action<uint> OnTakeLife;
    public event Action OnDeath;

    [SerializeField] private uint startingLife;

    private uint currentLife;

    public uint Count
    {
        get
        {
            return currentLife;
        }
        private set
        {
            currentLife = value;
        }
    }

    public void AddLife()
    {
        currentLife += 1;
        if (OnAddLife != null)
            OnAddLife(currentLife);
    }

    public void RemoveLife()
    {
        if (currentLife > 0)
        {
            currentLife -= 1;
            if(currentLife == 0)
            {
                if (OnDeath != null)
                    OnDeath();
            }
        }

        if (OnTakeLife != null)
            OnTakeLife(currentLife);
    }

    private void Awake()
    {
        currentLife = startingLife;
    }
}

