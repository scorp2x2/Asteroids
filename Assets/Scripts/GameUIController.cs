using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class GameUIController : MonoBehaviour
{
    public Text scoreCount;

    public Transform panelLasers;

    public Text position;
    public Text rotation;
    public Text speed;
    public Text countLaser;
    public Text reloadLaser;

    // Start is called before the first frame update
    void Start()
    {
        var go = panelLasers.GetChild(0).gameObject;
        for (int i = 1; i < GlobalParametrs.MaxCountLaser; i++)
            Instantiate(go, panelLasers);
    }

    // Update is called once per frame
    void Update()
    {
        scoreCount.text = GameController.Instance.core.gameScore.ToString();

        for (int i = 0; i < panelLasers.childCount; i++)
        {
            panelLasers.GetChild(i).GetComponent<Image>().color = i + 1 > GameController.Instance.core.Ship.CountLaser ? Color.white : Color.red;
        }

        position.text = $"X:{ GameController.Instance.core.Ship.Position.x} Y:{GameController.Instance.core.Ship.Position.y}";
        rotation.text = (GameController.Instance.core.Ship.Rotation * 180 / Mathf.PI).ToString() + "°";
        speed.text = GameController.Instance.core.Ship.Speed.ToString();
        countLaser.text = GameController.Instance.core.Ship.CountLaser.ToString();
        reloadLaser.text = GameController.Instance.core.Ship.TimeShootLaser.ToString();
    }
}
