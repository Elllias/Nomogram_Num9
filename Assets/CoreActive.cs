using System;
using TMPro;
using UnityEngine;
using UnityEngine.UI;

public class CoreActive : MonoBehaviour
{
    private const float C = 3 * 100000000;
    
    // Слайдеры и линия
    public Slider E;
    public Slider MU;
    public Slider V;
    public LineRenderer Line;

    // Текс типа "Значение X: X...X"
    public TextMeshProUGUI textE;
    public TextMeshProUGUI textV;
    public TextMeshProUGUI textMU;

    // Поля ввода
    public InputField inputE;
    public InputField inputV;
    public InputField inputMU;

    // Выполняется при старте приложения
    private void Start()
    {
        textE.text = "Значение E: " + E.value;
        textV.text = "Значение V: " + V.value;
        textMU.text = "Значение MU: " + MU.value;
    }

    // Выполняется каждый тик приложения
    private void Update()
    {
        var pMu = MU.handleRect.position;
        var pE = E.handleRect.position;
        var pV = V.handleRect.position;
        
        Line.SetPositions(new Vector3[] {pMu,pE,pV});
    }
    
    public void CalculateE()
    {
        // Тут мы передаем числа из поля ввода в слайдеры и тексты типа "Значение Х: Х..Х"
        var v = float.Parse(inputV.text);
        var mu = float.Parse(inputMU.text);
        V.value = float.Parse(inputV.text);
        MU.value = float.Parse(inputMU.text);
        textV.text = "Значение V: " + V.value;
        textMU.text = "Значение MU: " + MU.value;
        
        E.value = (float)Math.Pow(C/v, 2)/mu;
        inputE.text = E.value.ToString();
    }
    
    public void CalculateV()
    {
        // Тут мы передаем числа из поля ввода в слайдеры и тексты типа "Значение Х: Х..Х"
        var e = float.Parse(inputE.text);
        var mu = float.Parse(inputMU.text);
        E.value = float.Parse(inputE.text);
        MU.value = float.Parse(inputMU.text);
        textMU.text = "Значение MU: " + MU.value;
        textE.text = "Значение E: " + E.value;
        
        V.value = (float)(C / Math.Sqrt(mu * e));
        inputV.text = V.value.ToString();
    }
    
    public void CalculateMU()
    {
        // Тут мы передаем числа из поля ввода в слайдеры и тексты типа "Значение Х: Х..Х"
        var v = float.Parse(inputV.text);
        var e = float.Parse(inputE.text);
        V.value = float.Parse(inputV.text);
        E.value = float.Parse(inputE.text);
        textV.text = "Значение V: " + V.value;
        textE.text = "Значение E: " + E.value;

        MU.value = (float)Math.Pow(C/v, 2)/e;
        inputMU.text = MU.value.ToString();
    }

    public void DragE()
    {
        V.value = (float)(C / Math.Sqrt(MU.value * E.value));
        MU.value = (float)Math.Pow(C/V.value, 2)/E.value;
        
        // Тут мы переносим значения из значений сладера в поля ввода.
        textV.text = "Значение V: " + V.value;
        textE.text = "Значение E: " + E.value;
        textMU.text = "Значение MU: " + MU.value;
    }
    
    public void DragV()
    {
        MU.value = (float)Math.Pow(C/V.value, 2)/E.value;
        E.value = (float)Math.Pow(C/V.value, 2)/MU.value;
        
        // Тут мы переносим значения из значений сладера в поля ввода.
        textV.text = "Значение V: " + V.value;
        textE.text = "Значение E: " + E.value;
        textMU.text = "Значение MU: " + MU.value;
    }
    
    public void DragMU()
    {
        // Тут мы переносим значения из значений сладера в поля ввода.
        V.value = (float)(C / Math.Sqrt(MU.value * E.value));
        E.value = (float)Math.Pow(C/V.value, 2)/MU.value;

        textV.text = "Значение V: " + V.value;
        textE.text = "Значение E: " + E.value;
        textMU.text = "Значение MU: " + MU.value;
    }
}