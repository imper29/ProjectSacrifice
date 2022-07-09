using ProjectSacrifice.Messages;
using UnityEngine;

namespace ProjectSacrifice.Characters
{
    public class PlayerController : MonoBehaviour
    {
        private void Update()
        {
            gameObject.SendMessage(new Movement.MsgChangeUnscaledTargetVelocity { unscaledVelocity = new(Input.GetAxis("Horizontal"), Input.GetAxis("Vertical")) });
        }
    }
}
