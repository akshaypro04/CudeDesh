using UnityEngine;
using UnityEngine.UI;
using EZCameraShake;

public class PlayerDamage : Destruable
{

    [Header("General")]
    [SerializeField] GameObject deadParticel;
    [SerializeField] Slider slider;
    [SerializeField] LineRenderer lr;
    [SerializeField] GameObject EnemydamageEffect;

    [Space]

    [Header("Power")]
    [SerializeField] Slider PowerSilder;
    [SerializeField] GameObject powerIndicatorCharge;
    [SerializeField] GameObject PowerEffect;
    public float fieldOfImpact;
    public LayerMask layerToHit;
    bool powerCharge;
    public int force;
    bool SlowMotion;
    float slowMotionReadyTime;
    int chargeUpPoint = 200;                 
    bool LeaserBeamReady;
    bool LeaserBeamReadyBtn;
    float LeaserBeamTime;
    float LeaserBeamLaunching;

    [Space]

    [Header("Leaser")]
    Transform shotPoint;
    Transform LeaserBeamEndPoint;
    public LayerMask beamLayerMask;
    [SerializeField] Button beamBtn;
    [SerializeField] GameObject SwardChargingIndicater;
    Image SwardChargingIndicaterImage;
    int beamLength = 10;

    void Start()
    {
        lr = GetComponent<LineRenderer>();

        SwardChargingIndicaterImage = SwardChargingIndicater.GetComponentInChildren<Image>();
        beamBtn.gameObject.SetActive(false);
        powerIndicatorCharge.SetActive(false);
        shotPoint = GameObject.Find("GunHolder/GunShoter").GetComponent<Transform>();
        LeaserBeamEndPoint = GameObject.Find("GunHolder/LeaserBeamEndPoint").GetComponent<Transform>();

        HitPoint = GameManager.instances.GetPlayerHealth();

        slider.maxValue = HitPoint;
        slider.value = HitPoint;

        PowerSilder.maxValue = chargeUpPoint;
        PowerSilder.value = 0;
    }


    public override void DamageTake(int amount)
    {
        base.DamageTake(amount);
        slider.value = HealthReaming;

        if(amount > 0)
        {
            GivePower(amount+1);
            GivePower(0);
        }
    }

    public override void die()
    {
        GameManager.instances.SetPlayerAlive(false);
        Instantiate(deadParticel, transform.position, Quaternion.identity);
        Destroy(gameObject);
    }

    void GivePower(int powerValue)
    {
        if (PowerSilder.value != chargeUpPoint)
        {
            PowerSilder.value += powerValue;
        }
        else
        {
            print("POWER CHARGE");
            powerCharge = true;
            powerIndicatorCharge.SetActive(true);

        }
    }

    public void PowerReleas()
    {
        if (powerCharge)
        {
            Collider2D[] objects = Physics2D.OverlapCircleAll(transform.position, fieldOfImpact, layerToHit);

            foreach (Collider2D obj in objects)
            {
                Vector2 dir = obj.transform.position - transform.position;
                if (obj.GetComponent<enemyAiController>() != null)
                {
                    obj.GetComponent<Rigidbody2D>().AddForce(dir * force);
                    obj.GetComponent<Destruable>().DamageTake(GameManager.instances.GetPlayerPowerWave());
                }
            }
            SlowMotion = true;
            Time.timeScale = 0.2f;
            powerIndicatorCharge.SetActive(false);
            PowerSilder.value = 0;
            powerCharge = false;
            GameManager.instances.PlaySfx("blast");
            CameraShaker.Instance.ShakeOnce(8f, 6f, 0.2f, 0.8f);
            Instantiate(PowerEffect, transform.position, Quaternion.identity);
        }
    }

    void Update()
    {
        if (SlowMotion)
        {
            slowMotionReadyTime += Time.deltaTime;

            if(0.3f < slowMotionReadyTime)            // CONTROLLER SLOWMO
            {
                Time.timeScale = 1f;
                SlowMotion = false;
            }
        }

        //  L E A S E R 
        LeaserPrepare();
    }

    void LeaserPrepare()
    {
        LeaserBeamTime += Time.deltaTime;
        SwardChargingIndicaterImage.fillAmount = 1 - LeaserBeamTime / GameManager.instances.GetSwordCharingTime();
        if (LeaserBeamTime > GameManager.instances.GetSwordCharingTime())
        {
            LeaserBeamReady = true;
            SwardChargingIndicater.SetActive(false);
            beamBtn.gameObject.SetActive(true);
        }


        if (LeaserBeamReady && LeaserBeamReadyBtn)
        {
            LeaserBeamLaunching += Time.deltaTime;

            if (LeaserBeamLaunching < GameManager.instances.GetSwordStableTime())
            {
                RaycastHit2D hit = Physics2D.Raycast(shotPoint.position, shotPoint.right, beamLength, beamLayerMask);

                try
                {
                    hit.transform.GetComponent<EnemyDamage>().DamageTake(GameManager.instances.GetSwordDamage());
                    Draw2DRay(shotPoint.position, LeaserBeamEndPoint.position);
                    Instantiate(EnemydamageEffect, hit.point, hit.transform.rotation);
                }
                catch
                {
                    Draw2DRay(shotPoint.position, LeaserBeamEndPoint.position);
                }
            }
            else
            {
                LeaserBeamTime = 0;
                LeaserBeamLaunching = 0;
                LeaserBeamReadyBtn = false;
                LeaserBeamReady = false;
                beamBtn.gameObject.SetActive(false);
                SwardChargingIndicater.SetActive(true);
                Draw2DRay(Vector3.zero, Vector3.zero);
            }
        }
    }


    public void LeaserBeam()
    {
        LeaserBeamReadyBtn = true;
    }

    void Draw2DRay(Vector3 startPos, Vector3 EndPoint)
    {
        lr.SetPosition(0, startPos);
        lr.SetPosition(1, EndPoint);
    }

    void OnDrawGizmosSelected()
    {
        Gizmos.color = Color.red;
        Gizmos.DrawWireSphere(transform.position, fieldOfImpact);
    }

}
