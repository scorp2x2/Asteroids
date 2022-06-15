using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class AsteroidController : EnemyController
{
    [SerializeField]
    public GameObject[] largeAsteroids;
    public GameObject[] smallAsteroids;
    public GameObject[] mediumAsteroids;

    public override void SetEnemy(Enemy enemy)
    {
        Setlevel(((Asteroid)enemy).Level);
        base.SetEnemy(enemy);
    }

    public void Setlevel(int lvl)
    {
        HideAll();
        int index = Random.Range(0, 3);
        switch (lvl)
        {
            case 0:
                largeAsteroids[index].SetActive(true);
                break;
            case 1:
                smallAsteroids[index].SetActive(true);
                break;
            case 2:
                mediumAsteroids[index].SetActive(true);
                break;
            default:
                break;
        }
    }

    public void HideAll()
    {
        foreach (var item in largeAsteroids)
            item.SetActive(false);
        foreach (var item in smallAsteroids)
            item.SetActive(false);
        foreach (var item in mediumAsteroids)
            item.SetActive(false);
    }
}
