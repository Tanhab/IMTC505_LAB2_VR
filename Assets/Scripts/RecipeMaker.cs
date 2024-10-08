using System;
using TMPro;
using UnityEngine;
using UnityEngine.Serialization;
using UnityEngine.UI;

public class RecipeMaker : MonoBehaviour
{   
    [FormerlySerializedAs("mySlider")] public Slider waterAmountSlider;
    public Toggle toggle;
    public Button increaseCoffeeButton;
    public Button decreaseCoffeeButton;
    public Button increaseSugarButton;
    public Button decreaseSugarButton;
    public Button confirmButton;
    public GameObject feedbackPanel;
    public TMP_Text waterText;
    public TMP_Text coffeeText;
    public TMP_Text sugarText;
    public TMP_Text modalText;
    private float _waterAmount = 1.0f;
    private int _coffeeValue = 0;
    private int _sugarValue = 0;
    private bool _isMilkAdded;
    
    void Start()
    {
        // For all the interactive UI element I added a listener when they are clicked o changed
        waterAmountSlider.onValueChanged.AddListener(OnSliderValueChanged);
        toggle.onValueChanged.AddListener(OnToggleValueChanged);
        increaseCoffeeButton.onClick.AddListener(IncreaseCoffee);
        decreaseCoffeeButton.onClick.AddListener(DecreaseCoffee);
        increaseSugarButton.onClick.AddListener(IncreaseSugar);
        decreaseSugarButton.onClick.AddListener(DecreaseSugar);
        confirmButton.onClick.AddListener(OnConfirm);
    }

    private void OnConfirm()
    {
        if(_waterAmount < 1)
            modalText.text = "No water no life, how dare you make coffee without water?\n";
        else if(_waterAmount>1)
            modalText.text = "Are you making juice or coffee!! too much water\n";
        else if(_coffeeValue <2)
            modalText.text = "Don't be cheapstake! pour more coffees!\n";
        else if(_coffeeValue>2)
            modalText.text = "Too much of coffee is not a good coffee.\n";
        else if (_sugarValue < 2)
            modalText.text =
                "I see! you have no fun in your life, but that should not hold you you back from more sugar";
        else if(_sugarValue>2)
            modalText.text = "Wow somebody wants diabetes in their life. Decrease the sugar!";
        else if (!_isMilkAdded)
            modalText.text = "You may hate your life, your customers dont. Add milk to the coffee";
        else
        {
            modalText.text =
                "Well, I wouldn't say you are pablo piccasso of coffee!\nBut at least its better than starbucks!Congrats";
        }
        
        // Deactivate this UI canvas and open the feedback canvas with text that I get from the above if conditions
        feedbackPanel.SetActive(true);
        gameObject.gameObject.SetActive(false);
    }

    private void DecreaseSugar()
    {
        _sugarValue = Math.Max(0, _sugarValue - 1);
        sugarText.text = $"Sugar\n{_sugarValue} Spoon";
    }

    private void IncreaseSugar()
    {
        _sugarValue++;
        sugarText.text = $"Sugar\n{_sugarValue} Spoon";
    }


    private void IncreaseCoffee()
    {
        _coffeeValue += 1;
        coffeeText.text = $"Coffee\n{_coffeeValue} Spoon";
    }
    private void DecreaseCoffee()
    {
        _coffeeValue = Math.Max(0, _coffeeValue - 1);
        coffeeText.text = $"Coffee\n{_coffeeValue} Spoon";
    }
    // toggle for adding milk
    private void OnToggleValueChanged(bool arg0)
    {
        _isMilkAdded = arg0;
    }
    
    // When water slider is changed
    private void OnSliderValueChanged(float arg0)
    {
        _waterAmount = arg0;
        waterText.text = $"Use Sliders for amount of Water\nCurrent Amount - {_waterAmount} Cup";
    }
}
