using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.Pool;

public class SnowballObjectPool : MonoBehaviour
{
    public Snowball snowPrefabs;
    public IObjectPool<Snowball> snowballPool;

    private void Awake()
    {
        snowballPool = new ObjectPool<Snowball>
        (
            CreateSnow,
            OnGet,
            OnRelease,
            ActionOnDestroy,
            maxSize: 4
        );
    }

    private Snowball CreateSnow()
    {
        Snowball snow = Instantiate(snowPrefabs);
        snow.SetPool(snowballPool);

        return snow;
    }

    private void OnGet(Snowball snow)
    {
        snow.gameObject.SetActive(true);
    }

    public void OnRelease(Snowball snow)
    {
        snow.gameObject.SetActive(false);
    }

    private void ActionOnDestroy(Snowball snow)
    {
        Destroy(snow.gameObject);
    }
}
