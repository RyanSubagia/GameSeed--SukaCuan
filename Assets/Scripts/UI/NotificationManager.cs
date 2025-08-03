using System.Collections;
using UnityEngine;
using UnityEngine.UI;
using TMPro;

public class NotificationManager : MonoBehaviour
{
    public static NotificationManager instance;

    public TextMeshProUGUI notificationText;
    public float displayDuration = 2f;

    private void Awake()
    {
        if (instance == null)
        {
            instance = this;
        }
        else
        {
            Destroy(gameObject);
        }
    }

    void Start()
    {
        notificationText.gameObject.SetActive(false);
    }

    public void ShowNotification(string message)
    {
        StopAllCoroutines();
        StartCoroutine(DisplayNotificationCoroutine(message));
    }

    private IEnumerator DisplayNotificationCoroutine(string message)
    {
        notificationText.text = message;
        notificationText.gameObject.SetActive(true);

        yield return new WaitForSeconds(displayDuration);

        notificationText.gameObject.SetActive(false);
    }
}