using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Terrain : MonoBehaviour {

    public GameObject bar, point, redPoint, gravityPoint, player;

    float travelDistance, initialPos;

    // Use this for initialization
    void Start () {
        initialPos = player.transform.position.x - 7.5f;
    }
    float posX, rememberHeight, numb = 0;
    // Update is called once per frame
    void Update() {

        travelDistance = player.transform.position.x;
        float dif = travelDistance - initialPos;
        if (dif > 10.0f)
        {
            initialPos = travelDistance;
            numb += 1;
            print(numb);


            int randomNumber = Random.Range(0, 100);
            if (randomNumber < 50) { posX += 15; }
            else if (randomNumber >= 50) { posX += 18; }

            int randomHeight = Random.Range(0, 100);

            rememberHeight = randomHeight;

            int randomRot = Random.Range(-10, 10);

            var newObj = (GameObject)Instantiate(bar, new Vector2(bar.transform.position.x + posX, bar.transform.position.y + (randomHeight < 33 ? -2.5f : (randomHeight > 66 && rememberHeight <= 66 ? 2.5f : 0))), bar.transform.rotation);
            newObj.transform.Rotate(bar.transform.rotation.x, bar.transform.rotation.y, randomRot);


            float randomNumb = Random.Range(0, 100);
            if (randomNumb < 15)
            {
                    var pointblock = (GameObject)Instantiate(randomNumb < 7.5f ? point : redPoint, new Vector2(bar.transform.position.x + posX, (bar.transform.position.y + (randomHeight < 33 ? -2.5f : (randomHeight > 66 && rememberHeight <= 66 ? 2.5f : 0))) + (Physics2D.gravity.y < 0.0f ? 2.5f : -2.5f)), bar.transform.rotation);
            }
            else if(randomNumb > 15 && randomNumb < 25)
            {
                var pointblock = (GameObject)Instantiate(gravityPoint, new Vector2(bar.transform.position.x + posX, (bar.transform.position.y + (randomHeight < 33 ? -2.5f : (randomHeight > 66 && rememberHeight <= 66 ? 2.5f : 0))) + (Physics2D.gravity.y < 0.0f ? 2.5f : -2.5f)), bar.transform.rotation);
            }
        }
    }
}
