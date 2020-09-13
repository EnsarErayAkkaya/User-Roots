using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using TMPro;
using UnityEngine.EventSystems;

public class ConsoleManager : MonoBehaviour
{
    [SerializeField] private ConsoleCommand[] commands = new ConsoleCommand[0];

    [Header("UI")]
    public TMP_InputField consoleInput;
    public TextMeshProUGUI consoleText;

    private static ConsoleManager instance;

    private Console console;

    void Awake()
    {
        instance = this;
        console = new Console(commands);

        SelectInputField();
    }
    
    void Update()
    {
        OnPressedEnter();
    }
    public void OnPressedEnter()
    {
        if(Input.GetKeyDown(KeyCode.Return))
        {
            string consoleOutput = ProcessCommand(consoleInput.text);

            consoleText.text += consoleOutput + "\n";
            consoleInput.text = string.Empty;

            SelectInputField();
        }
    }
    public string ProcessCommand(string inputValue)
    {
        return console.ProcessInput(inputValue);    
    }
    private void SelectInputField()
    {
        EventSystem.current.SetSelectedGameObject(consoleInput.gameObject);
        consoleInput.OnSelect(null);
    }

}
