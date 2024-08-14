using UnityEngine;
using UnityEngine.UI;
using UnityEngine.SceneManagement;

public class QuizScoring : MonoBehaviour
{
    public GameObject finalScorePanel;
    public Text scoreText;
    public Text finalScoreText;
    public int totalQuestions = 10; // Adjust based on the total number of questions in your quiz

    private int score;
    private int currentQuestion;

    void Start()
    {
        // Load previous score and question index from PlayerPrefs
        score = PlayerPrefs.GetInt("Score", 0);
        currentQuestion = PlayerPrefs.GetInt("CurrentQuestion", 1);

        UpdateScoreText();
    }

    // Call this method when the user answers a question correctly
    public void CorrectAnswer()
    {
        score++;
        UpdateScoreText();

        // Move to the next question
        if (currentQuestion < totalQuestions)
        {
            currentQuestion++;
            SavePlayerPrefs(); // Save current progress
            //SceneManager.LoadScene("NextQuestionScene"); // Load the next question scene
        }
        else
        {
            // All questions answered, quiz is complete
            DisplayFinalScore();
            ResetPlayerPrefs(); // Reset PlayerPrefs when the quiz is complete
            //SceneManager.LoadScene("MainMenuScene"); // Load the main menu or another scene
        }
    }

    // Call this method when the user answers a question incorrectly
    public void IncorrectAnswer()
    {
        // Move to the next question without increasing the score
        if (currentQuestion < totalQuestions)
        {
            currentQuestion++;
            SavePlayerPrefs(); // Save current progress
            //SceneManager.LoadScene("NextQuestionScene"); // Load the next question scene
        }
        else
        {
            // All questions answered, quiz is complete
            DisplayFinalScore();
            ResetPlayerPrefs(); // Reset PlayerPrefs when the quiz is complete
            //SceneManager.LoadScene("MainMenuScene"); // Load the main menu or another scene
        }
    }

    public void Reset()
    {
        ResetPlayerPrefs();
    }

    void UpdateScoreText()
    {
        scoreText.text = "Score: " + score + " / " + totalQuestions;
    }

    void SavePlayerPrefs()
    {
        // Save score and current question index to PlayerPrefs
        PlayerPrefs.SetInt("Score", score);
        PlayerPrefs.SetInt("CurrentQuestion", currentQuestion);
        PlayerPrefs.Save();
    }

    void ResetPlayerPrefs()
    {
        // Reset PlayerPrefs (clear saved data) when exiting the scene
        PlayerPrefs.DeleteAll();
    }

    void DisplayFinalScore()
    {
        finalScoreText.text = "You got: " + score + "/" + totalQuestions + "!";
        finalScorePanel.SetActive(true);
        scoreText.gameObject.SetActive(false);
    }
}
