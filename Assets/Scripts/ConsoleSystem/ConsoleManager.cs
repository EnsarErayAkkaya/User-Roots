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
    int historyIndex = -1;
    bool lockConsoleInput;

    void Awake()
    {
        instance = this;
        console = new Console(commands);
        console.turnManager = FindObjectOfType<TurnManager>();

        SelectInputField();
    }
    
    void Update()
    {
        OnPressedEnter();
        OnPressedArrows();
    }
    public void OnPressedArrows()
    {
        if(Input.GetKeyDown(KeyCode.UpArrow))
        {
            if(historyIndex == -1)
                historyIndex += console.commandHistory.Count;
            else
            {
                historyIndex--;
                if(historyIndex < 0)
                {
                    historyIndex = -1;
                }
            }
            if (historyIndex == -1)
            {
                PrintToConsoleInput("");
                return;
            }
            PrintToConsoleInput(console.commandHistory[historyIndex]);
        }
        else if(Input.GetKeyDown(KeyCode.DownArrow))
        {
            if( historyIndex == console.commandHistory.Count )
                historyIndex = -1;
            else
            {
                historyIndex++;
                if( historyIndex == console.commandHistory.Count )
                    historyIndex = -1;
            }
            if (historyIndex == -1)
            {
                PrintToConsoleInput("");
                return;
            }
            PrintToConsoleInput(console.commandHistory[historyIndex]);
        }
    }
    public void OnPressedEnter()
    {
        if(Input.GetKeyDown(KeyCode.Return) && !lockConsoleInput )
        {
            historyIndex = -1;
            string consoleOutput = ProcessCommand(consoleInput.text);

            consoleText.text += consoleOutput + "\n";
            consoleInput.text = string.Empty;

            SelectInputField();
            lockConsoleInput = true;

            StartCoroutine( LockConsoleInput() );
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
    private void PrintToConsoleInput(string h)
    {
        consoleInput.text = h;
    }
    IEnumerator LockConsoleInput()
    {
        yield return new WaitForSeconds(2.2f);
        lockConsoleInput = false;
    }

}
