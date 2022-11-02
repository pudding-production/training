using TMPro;
using UnityEngine;

public class Quiz : MonoBehaviour
{
    [SerializeField] QuestionsSO question;
    [SerializeField] TextMeshProUGUI questionText;
    // Start is called before the first frame update
    void Start()
    {
        questionText.text = question.GetQuestion();
    }

}
