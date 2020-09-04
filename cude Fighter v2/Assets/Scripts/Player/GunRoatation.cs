using UnityEngine;

public class GunRoatation : MonoBehaviour
{

    float angle;
    [SerializeField] Transform gunHolder;
    PlayerInput playerInput
    {
        get
        {
            return GameManager.instances.playerInput;
        }
    }

    void Update()
    {

        if(playerInput.GunPos != Vector2.zero)
        {
            angle = Mathf.Atan2(playerInput.GunPos.y, playerInput.GunPos.x) * Mathf.Rad2Deg;
            gunHolder.transform.rotation = Quaternion.AngleAxis(angle, Vector3.forward);
        }
    }
}
