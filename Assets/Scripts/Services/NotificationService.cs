using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;
using NotificationSamples.Demo;
using NotificationSamples;
using System;
using TMPro;
public class NotificationService : MonoBehaviour
{
    // On iOS, this represents the notification's Category Identifier, and is optional
    // On Android, this represents the notification's channel, and is required (at least one).
    // Channels defined as global constants so can be referred to from GameController.cs script when setting/sending notification
    public const string ChannelId = "game_channel00";
    public const string ReminderChannelId = "reminder_channel11";
    public const string NewsChannelId = "news_channel22";
    public const string PlayAgainChannelId = "play_again_channel22";
    [SerializeField]
    protected GameNotificationsManager manager;
    private void Start()
    {
        // Set up channels (mostly for Android)
        // You need to have at least one of these

        var c1 = new GameNotificationChannel(ChannelId, "Default Game Channel", "Generic notifications");
        var c2 = new GameNotificationChannel(NewsChannelId, "News Channel", "News feed notifications");
        var c3 = new GameNotificationChannel(ReminderChannelId, "Reminder Channel", "Reminder notifications");
        var c4 = new GameNotificationChannel(PlayAgainChannelId, "Play Again Reminder", "Play Again notifications");
        manager.Initialize(c3, c4);


        //InitializeNotifications(Services.UserSettings.GetNotifications());


    }

    public void InitializeNotifications(bool check)
    {
        if (check)
        {
            PlayAgainNotification();
            DisplayAllNotifications();
        }
        else
        {
            manager.CancelAllNotifications();
        }
    }


    private void DisplayAllNotifications()
    {
        print("DisplayAllNotifications");
        print("DisplayAllNotifications Count : " + manager.PendingNotifications.Count);
        foreach (PendingNotification pn in manager.PendingNotifications)
        {
            print("DisplayAllNotifications ID : " + pn.Notification.Id);
            print("DisplayAllNotifications Title : " + pn.Notification.Title);
            print("DisplayAllNotifications Body : " + pn.Notification.Body);
            print("DisplayAllNotifications ID : " + pn.Notification.Group);
        }
    }
    private void OnEnable()
    {
        if (manager != null)
        {
            manager.LocalNotificationDelivered += OnDelivered;
            manager.LocalNotificationExpired += OnExpired;
        }
    }
    private void OnDisable()
    {
        if (manager != null)
        {
            manager.LocalNotificationDelivered -= OnDelivered;
            manager.LocalNotificationExpired -= OnExpired;
        }
    }
    /// <summary>
    /// Queue a notification with the given parameters.
    /// </summary>
    /// <param name="title">The title for the notification.</param>
    /// <param name="body">The body text for the notification.</param>
    /// <param name="deliveryTime">The time to deliver the notification.</param>
    /// <param name="badgeNumber">The optional badge number to display on the application icon.</param>
    /// <param name="reschedule">
    /// Whether to reschedule the notification if foregrounding and the notification hasn't yet been shown.
    /// </param>
    /// <param name="channelId">Channel ID to use. If this is null/empty then it will use the default ID. For Android
    /// the channel must be registered in <see cref="GameNotificationsManager.Initialize"/>.</param>
    /// <param name="smallIcon">Notification small icon.</param>
    /// <param name="largeIcon">Notification large icon.</param>
    public int? SendNotification(string title, string body, DateTime deliveryTime, int? badgeNumber = null,
        bool reschedule = false, string channelId = null,
        string smallIcon = null, string largeIcon = null)
    {
        IGameNotification notification = manager.CreateNotification();
        if (notification == null)
        {
            return 0;
        }
        notification.Title = title;
        notification.Body = body;
        notification.Group = !string.IsNullOrEmpty(channelId) ? channelId : ChannelId;
        notification.DeliveryTime = deliveryTime;
        notification.SmallIcon = smallIcon;
        notification.LargeIcon = largeIcon;
        if (badgeNumber != null)
        {
            notification.BadgeNumber = badgeNumber;
        }
        PendingNotification notificationToDisplay = manager.ScheduleNotification(notification);
        notificationToDisplay.Reschedule = reschedule;
        return notificationToDisplay.Notification.Id;
    }
    /// <summary>
    /// Cancel a given pending notification
    /// </summary>
    public void CancelPendingNotificationItem(PendingNotification itemToCancel)
    {
        manager.CancelNotification(itemToCancel.Notification.Id.Value);
    }
    private void OnDelivered(PendingNotification deliveredNotification)
    {
    }
    private void OnExpired(PendingNotification obj)
    {
    }
    private void RemoveAllNotificationsByChannelID(string channelID)
    {
        foreach (PendingNotification pn in manager.PendingNotifications)
        {
            if (pn.Notification.Group.Equals(channelID))
            {
                if (pn.Notification.Id != null)
                    manager.CancelNotification((int)pn.Notification.Id);
            }
        }
    }
    /// <summary>
    /// Called when the play reminder button is pressed.
    /// </summary>
    private void OnPlayReminder()
    {
        // Schedule a reminder to play the game. Schedule it for the next day.
        DateTime deliveryTime = DateTime.Now.ToLocalTime().AddDays(1);
        //deliveryTime = new DateTime(deliveryTime.Year, deliveryTime.Month, deliveryTime.Day, playReminderHour, 0, 0,
        //  DateTimeKind.Local);
        SendNotification("Hello Pilot!", "Our enemies are attacking on us. Come save us.", deliveryTime,
            channelId: NotificationService.PlayAgainChannelId);
    }
    private void PlayAgainNotification()
    {
        RemoveAllNotificationsByChannelID(NotificationService.PlayAgainChannelId);
        OnPlayReminder();
    }
}