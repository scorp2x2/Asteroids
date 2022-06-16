using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class GameUIController : MonoBehaviour
{
    public GameController gameController;

    public Text scoreCount;

    public Transform panelLasers;
    public Image[] imagesLaser;

    public Text position;
    public Text rotation;
    public Text speed;
    public Text countLaser;
    public Text reloadLaser;

    // Start is called before the first frame update
    void Start()
    {
        imagesLaser = new Image[GlobalParametrs.MaxCountLaser];
        imagesLaser[0] = panelLasers.GetChild(0).GetComponent<Image>();
        for (int i = 1; i < imagesLaser.Length; i++)
            imagesLaser[i] = Instantiate(imagesLaser[0], panelLasers);
    }

    // Update is called once per frame
    void Update()
    {
        scoreCount.text = gameController.core.gameScore.ToString();

        for (int i = 0; i < imagesLaser.Length; i++)
            imagesLaser[i].color = i + 1 > gameController.core.Ship.CountLaser ? Color.white : Color.red;

        position.text = $"X:{ gameController.core.Ship.Position.x} Y:{gameController.core.Ship.Position.y}";
        rotation.text = (gameController.core.Ship.Rotation * 180 / Mathf.PI).ToString() + "°";
        speed.text = gameController.core.Ship.Speed.ToString();
        countLaser.text = gameController.core.Ship.CountLaser.ToString();
        reloadLaser.text = gameController.core.Ship.TimeShootLaser.ToString();
    }
}
