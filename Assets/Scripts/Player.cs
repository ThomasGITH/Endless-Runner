using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;
using UnityEngine.UI;

public class Player : MonoBehaviour
{
    public GameObject textObject, startText, cameraObj;
    int gravity_modules = 0;
    Vector2 mov;
    float playerSpeed = 325.0f, jumpPower = 750.0f, travelDistance = 0;
    public bool isGrounded;

    // Update is called once per frame
    void Update()
    {

        if((Input.GetKeyDown(KeyCode.W) || Input.GetKeyDown(KeyCode.UpArrow)) && isGrounded)
        {
            if(Physics2D.gravity.y < 0.0f)
            {
                GetComponent<Rigidbody2D>().AddForce(Vector2.up * jumpPower);
            }
            else
            {
                GetComponent<Rigidbody2D>().AddForce(Vector2.down * jumpPower);
            }
            mov.x = 1.0f;
            if(!textObject.activeSelf)
            {
                textObject.SetActive(true);
                startText.SetActive(false);
            }
        }

        if(Input.GetKeyDown(KeyCode.D) || Input.GetKeyDown(KeyCode.RightArrow))
        {
            mov.x = 1.0f;
            if (!textObject.activeSelf)
            {
                textObject.SetActive(true);
                startText.SetActive(false);
            }
        }

        if (mov.x > 0.0f)
        {
            playerSpeed += 0.25f;
        }

        if(Input.GetKeyDown(KeyCode.Space) && gravity_modules > 0)
        {
            gravity_modules -= 1;
            Physics2D.gravity = new Vector2(Physics2D.gravity.x, Physics2D.gravity.y * -1);
            GetComponent<SpriteRenderer>().color = Physics2D.gravity.y < 0 ? Color.black : Color.white;
            cameraObj.GetComponent<Camera>().backgroundColor = Physics2D.gravity.y < 0 ? Color.white : Color.black;
            textObject.GetComponent<Text>().text = "Gravity Modules: " + gravity_modules;
            textObject.GetComponent<Text>().color = Physics2D.gravity.y < 0 ? Color.black : Color.white;
            startText.GetComponent<Text>().color = Physics2D.gravity.y < 0 ? Color.black : Color.white;
        }

        GetComponent<Rigidbody2D>().velocity = new Vector2(mov.x * playerSpeed * Time.deltaTime, GetComponent<Rigidbody2D>().velocity.y);
    }

    //Ground Check
    private void OnCollisionEnter2D(Collision2D collision)
    {
        isGrounded = true;
    }
    private void OnCollisionExit2D(Collision2D collision)
    {
        isGrounded = false;
    }

    private void OnTriggerEnter2D(Collider2D collision)
    {
        if(collision.tag == "point")
        {
            Destroy(collision.gameObject);
            playerSpeed = (playerSpeed / 3) * 2;
        }
        else if(collision.tag == "redPoint")
        {
            Destroy(collision.gameObject);
            playerSpeed = (playerSpeed / 3) * 4;
        }
        else if(collision.tag == "grav")
        {
            Destroy(collision.gameObject);
            gravity_modules += 1;
            textObject.GetComponent<Text>().text = "Gravity Modules: " + gravity_modules;
        }
    }

}