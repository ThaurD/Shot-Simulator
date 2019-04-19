using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Ak47 : Weapon
{
    private int bulletPerMinutes = 400;
    private string shotType = "Auto";
    private int ammo = 30;
    private int accuracy = 60;
    private int bulletDamage = 5;
    private int ammoChangeTime = 5;

    private float timeForBullet; // Bir sonraki merminin cikmak icin bekleme suresini kontrol eder 
    private float timeForAmmo; // Sarjor degistirilirken tekrar degistirilmemesi icin sarjor degistirilme suresini kontrol eder
    private bool ammoStatus; // Sarjor'un degistiriliyor durumda olup olmadigini tutar, sarjor degistirilene kadar false olarak kalir
    
    public int BulletPerMinutes
    {
        get { return bulletPerMinutes; }
        set { bulletPerMinutes = value; }
    }
    public string ShotType
    {
        get { return shotType; }
        set { shotType = value; }
    }
    public int Ammo
    {
        get { return ammo; }
        set { ammo = value; }
    }
    public int Accuracy
    {
        get { return accuracy; }
        set { accuracy = value; }
    }
    public int BulletDamage
    {
        get { return bulletDamage; }
        set { bulletDamage = value; }
    }
    public int AmmoChangeTime
    {
        get { return ammoChangeTime; }
        set { ammoChangeTime = value; }
    }
    public float TimeForBullet
    {
        get { return timeForBullet; }
        set { timeForBullet = value; }
    }
    public float TimeForAmmo
    {
        get { return timeForAmmo; }
        set { timeForAmmo = value; }
    }
    public bool AmmoStatus
    {
        get { return ammoStatus; }
        set { ammoStatus = value; }
    }

    // Start is called before the first frame update
    void Start()
    {
        TimeForBullet = -(60 / bulletPerMinutes); // Ilk atista mermi atis araligini beklememek icin kullaniliyor
        TimeForAmmo = -5; // Ilk bes saniyede sarjor degistirilebilmesi icin -5 yapildi
        AmmoStatus = true;
    }

    // Update is called once per frame
    void Update()
    {
        Fire();
        ReAmmo();
    }

    public override void Fire() // Ates etme fonksiyonu
    {
        if (Ammo > 0) // Eger mermi varsa calisir
        {
            if (Input.GetKey(KeyCode.S)
                && (Time.time - timeForBullet) >= (60 / bulletPerMinutes) // Mermilerin cikis surelerinin araligini ayarlar ( 1sn )
                && ammoStatus == true) // Sarjor degistirilme asamasinda degilse ates edilebilmesini saglar
            {
                CloneBullet();
                ammo--;

                Debug.Log("AK47 Ammo :" + Ammo);
                timeForBullet = Time.time;
            }
        }
    }

    public override void ReAmmo() // Sarjoru degistirmeyi baslatir
    {
        if (Input.GetKeyDown(KeyCode.R)
            && (Time.time - timeForAmmo) >= ammoChangeTime // Sarjor degistirilirken tekrar degistirilmeye calisilmasini engeller
            && Ammo != 30) // Sarjor full'ken degistirilmeye calisilmasini engeller
        {
            timeForAmmo = Time.time;
            ammoStatus = false;
            Invoke("AmmoFilled", 5); // Tusa basildiktan 5 sn sonra sarjor dolduruluyor
            Debug.Log("Ammo is filling..");
        }
    }

    public override void AmmoFilled() // Sarjoru degistirir
    {
        Ammo = 30;
        Debug.Log("Ammo filled");
        Debug.Log("AK47 Ammo :" + Ammo);
        ammoStatus = true;
    }

    public override void CloneBullet()
    {
        System.Random rnd = new System.Random();
        int temp = rnd.Next(1, 11); // 1 ile 11 arasinda random sayi uretip silahin atis keskinligini belirlemede kullaniyorum
        if (temp <= 4) // 4'e esit ve 4'den kucuk gelme olasiligi %40 oldugu ve silahin sekme olasiligi da %40 oldugu icin bu kosul icinde merminin hedefi vurma(ma)si saglanilacak
        {
            Instantiate(bulletPrefab, bulletPoint.transform.position, bulletPrefab.transform.rotation);
            //Instantiate(bulletPrefab, bulletPoint.transform.position, Quaternion.Euler(92f, 0f, 0f)); // Merminin rotation'unu degistirerek hedefi vurma(ma)sı saglanilacak
            Debug.Log("Hedef Vurulamadı");
        }
        else
        {
            Instantiate(bulletPrefab, bulletPoint.transform.position, bulletPrefab.transform.rotation);
        }
    }
}
