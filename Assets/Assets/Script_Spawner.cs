using System.Collections;
using System.Collections.Generic;
using UnityEngine;

/* Source for the code : 
 Danndx 2021 (youtube.com/danndx)
From video: youtu.be/u5ieakSbXjA*/

public class SCR_ShipSpawner : MonoBehaviour
{
    public GameObject Target_Mvmt_Area;
    public GameObject Prefab_Target;

    public int ship_count = 0;
    public int ship_limit = 10;
    public int ships_per_frame = 1;

    public float spawn_circle_radius = 80.0f;
    public float death_circle_radius = 90.0f;

    public float fastest_speed = 12.0f;
    public float slowest_speed = 0.75f;
    
    void Start()
    {
        InitialPopulation();
    }

    void Update()
    {
        MaintainPopulation();
    }
    
    void InitialPopulation()
    {
        

        for (int i = 0; i < ship_limit; i++)
        {
            Vector3 position = GetRandomPosition(true);
            SCR_Ship ship_script = AddShip(position);
            ship_script.transform.Rotate(Vector3.forward * Random.Range(0.0f, 360.0f));
        }
    }
    
    void MaintainPopulation()
    {
        

        if (ship_count < ship_limit)
        {
            for (int i = 0; i < ships_per_frame; i++)
            {
                Vector3 position = GetRandomPosition(false);
                SCR_Ship ship_script = AddShip(position);
                ship_script.transform.Rotate(Vector3.forward * Random.Range(-45.0f, 45.0f));
            }
        }
    }
    
    Vector3 GetRandomPosition(bool within_rectangle)
    {
        

        Vector3 position = Random.insideUnitCircle;

        if (within_rectangle == false)
        {
            position = position.normalized;
        }

        position *= spawn_circle_radius;
        position += Target_Mvmt_Area.transform.position;

        return position;
        return position;
    }
    
    SCR_Ship AddShip(Vector3 position)
    {
        

        ship_count += 1;
        GameObject new_ship = Instantiate(
            Prefab_Target,
            position,
            Quaternion.FromToRotation(Vector3.up, (Target_Mvmt_Area.transform.position - position)),
            gameObject.transform
        );

        SCR_Ship ship_script = new_ship.GetComponent<SCR_Ship>();
        ship_script.ship_spawner = this;
        ship_script.game_area = Target_Mvmt_Area;
        ship_script.speed = Random.Range(slowest_speed, fastest_speed);

        return ship_script;
    }
}