using ProjectSacrifice;
using ProjectSacrifice.Messages;
using UnityEngine;

public class Hazard : MonoBehaviour
{
    private void OnCollisionEnter2D(Collision2D collision)
    {
        gameObject.SendMessage(new Offense.MsgAttack(collision.gameObject.GetComponent<Defense>()));
    }
}
