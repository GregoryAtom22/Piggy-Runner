using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Collision : MonoBehaviour
{
private void OnCollisionEnter2D(Collision2D collision)
    { if (collision.gameObject.tag == "Player") { collision.gameObject.GetComponent<Player>().RecountHp(-1); } }
}
