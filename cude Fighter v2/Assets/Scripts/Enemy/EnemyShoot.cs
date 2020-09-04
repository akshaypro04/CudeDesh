using UnityEngine;

public class EnemyShoot : MonoBehaviour
{

    [SerializeField] GameObject Bullet;
    [SerializeField] Transform muzzle;
    Transform player;

    float fireTime;
    public float ReFiretimeLimit = 1.5f;                   // random fire time



    void Update()
    {
        if (!GameManager.instances.getPlayerAlive())
            return;

        player = GameManager.instances.getPlayerPos();
        playerShoot();
        aimPosition();
    }

    void playerShoot()                                                      // button call
    {
        fireTime += Time.deltaTime;
        Shoot();
    }


    public void Shoot()
    {
        if (ReFiretimeLimit < fireTime)
        {
            GameManager.instances.PlaySfx("enemyShoot");
            Instantiate(Bullet, muzzle.position, muzzle.rotation);
            fireTime = 0;
        }
    }

    void aimPosition()
    {
        Vector2 target = player.position - transform.position;
        float angle = Mathf.Atan2(target.y, target.x) * Mathf.Rad2Deg;
        Quaternion rot = Quaternion.AngleAxis(angle, Vector3.forward);
        transform.rotation = Quaternion.Slerp(transform.rotation, rot, 0.1f);
    }
}
