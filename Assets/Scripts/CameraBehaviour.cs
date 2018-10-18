using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;
using UnityEngine.UI;

public class CameraBehaviour : MonoBehaviour {

    Vector2 movement;
    //float cameraSpeed = 4.30f;
    public float cameraSpeed = 1.0f, time;

    public GameObject player, time_counter;

	// Update is called once per frame
	void Update () {

        float xDif = player.transform.position.x - transform.position.x;
        float yDif = player.transform.position.y - transform.position.y;

        if(Mathf.Abs(yDif) > 5)
        {
            SceneManager.LoadScene(SceneManager.GetActiveScene().name, LoadSceneMode.Single);
            Physics2D.gravity = new Vector2(Physics2D.gravity.x, -9.81f);
        }

        time += Time.deltaTime;

        time_counter.GetComponent<Text>().text = "Time: " + Mathf.Round(time);

        if(Input.GetKeyDown(KeyCode.Space))
        {
            time_counter.GetComponent<Text>().color = Physics2D.gravity.y < 0 ? Color.black : Color.white;
        }

        if(Input.GetKeyDown(KeyCode.W) || Input.GetKeyDown(KeyCode.D) || Input.GetKeyDown(KeyCode.UpArrow) || Input.GetKeyDown(KeyCode.RightArrow))
        {
            time_counter.SetActive(true);
        }

        GetComponent<Rigidbody2D>().velocity = new Vector2(xDif * cameraSpeed, yDif * cameraSpeed);

    }
}
