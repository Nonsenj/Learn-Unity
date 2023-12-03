using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PlantManager : MonoBehaviour
{
    bool isPlanted = false;
    SpriteRenderer plant;
    SpriteRenderer plot;
    BoxCollider2D plantCollider;

    int plantStage = 0;
    float timer;

    public PlantObject selectedPlant;

    // Start is called before the first frame update
    void Start()
    {
        plant = transform.GetChild(0).GetComponent<SpriteRenderer>();
        plantCollider = transform.GetChild(0).GetComponent<BoxCollider2D>();
        plot = GetComponent<SpriteRenderer>();

    }

    // Update is called once per frame
    void Update()
    {
        if (isPlanted)
        {
            timer -= Time.deltaTime;
            if (timer < 0 && plantStage < selectedPlant.plantStages.Length - 1)
            {
                timer = selectedPlant.timeBtwStages;
                plantStage++;
                UpdatePlant();

            }
        }
    }

    private void OnMouseDown()
    {
        if (isPlanted)
        {
            if (plantStage == selectedPlant.plantStages.Length-1)
            {
                Harvest();
            }
        }
        else
        {
            Plant();
        }
    }

    void Harvest()
    {
        Debug.Log("Harvest");
        isPlanted = false;
        plant.gameObject.SetActive(false);

    }

    void Plant()
    {
        Debug.Log("Plant");
        isPlanted = true;
        plantStage = 0;
        UpdatePlant();
        timer = selectedPlant.timeBtwStages;
        plant.gameObject.SetActive(true);

    }

    void UpdatePlant()
    {
        plant.sprite = selectedPlant.plantStages[plantStage];
        plantCollider.size = plant.sprite.bounds.size;
        plantCollider.offset = new Vector2(0,plant.bounds.size.y/2);
    }

    private void OnMouseOver()
    {
        if (isPlanted)
        {
            plant.color = Color.red;
        }
        else
        {
            plot.color = Color.green;
        }
    }

    private void OnMouseExit()
    {
        plant.color = Color.white;
        plot.color = Color.white;
    }
}
