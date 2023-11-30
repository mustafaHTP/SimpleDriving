using System;
#if UNITY_ANDROID
using Unity.Notifications.Android;
#endif
using UnityEngine;

public class AndroidNotificationHandler : MonoBehaviour
{
#if UNITY_ANDROID
    private const string ChannelId = "notification_channel";

    public void ScheduleNotification(DateTime time)
    {
        AndroidNotificationChannel androidNotificationChannel = new()
        {
            Id = ChannelId,
            Name = "Unity Notification",
            Description = "Game Description",
            Importance = Importance.High
        };

        AndroidNotificationCenter.RegisterNotificationChannel(androidNotificationChannel);

        var notification = new AndroidNotification()
        {
            Title = "Energy Recharged!!",
            Text = "Your energy recharged, come back to play again !",
            FireTime = time,
        };

        AndroidNotificationCenter.SendNotification(notification, androidNotificationChannel.Id);
    }
#endif
}