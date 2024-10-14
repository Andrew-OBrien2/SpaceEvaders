using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class FuelBar : MonoBehaviour
{
    public Slider fuelBar;
    public float maxFuel;
    private float currentFuel;
    public float fuelDrain;
    // Start is called before the first frame update
    void Start()
    {
        //start with a full tank
        currentFuel = maxFuel;

        fuelBar.maxValue = maxFuel;
        fuelBar.value = currentFuel;
    }

    // Update is called once per frame
    void Update()
    {
        currentFuel -= fuelDrain * Time.deltaTime;
        fuelBar.value = currentFuel;
    }

    public void FillFuel()
    {
        currentFuel = maxFuel;
        fuelBar.value = currentFuel;
    }
}
