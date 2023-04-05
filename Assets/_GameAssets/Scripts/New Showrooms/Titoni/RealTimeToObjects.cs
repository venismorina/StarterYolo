using UnityEngine;

public class RealTimeToObjects : MonoBehaviour
{
    public Transform hourHand;
    public Transform minuteHand;
    public Transform secondHand;

    void Update()
    {
        // Get the current time
        System.DateTime time = System.DateTime.Now;
        int hour = time.Hour % 12;
        int minute = time.Minute;
        int second = time.Second;

        // Calculate the rotation for the hour hand
        float hourRotation = (hour + (float)minute / 60f) / 12 * 360;
        hourHand.localRotation = Quaternion.Euler(hourHand.localRotation.x, hourRotation, hourHand.localRotation.z);

        // Calculate the rotation for the minute hand
        float minuteRotation = minute / 60f * 360;
        minuteHand.localRotation = Quaternion.Euler(minuteHand.localRotation.x, minuteRotation, minuteHand.localRotation.z);

        // Calculate the rotation for the second hand
        float secondRotation = second / 60f * 360;
        secondHand.localRotation = Quaternion.Euler(secondHand.localRotation.x, secondRotation, secondHand.localRotation.z);
    }
}
