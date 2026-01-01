namespace LukeUI.EventsHandler;

using System;
using LabApi.Events.Arguments.PlayerEvents;
using LabApi.Events.Handlers;
using LukeUI.UI;
using RueI.API;
using RueI.API.Elements;

/// <summary>
/// The ui handler.
/// </summary>
internal static class UIEventsHandler
{
    /// <summary>
    /// Register the Event Handler.
    /// </summary>
    public static void Register()
    {
        PlayerEvents.Joined += OnPlayerJoined;
    }

    /// <summary>
    /// Unregister the Event Handler.
    /// </summary>
    public static void Unregister()
    {
        PlayerEvents.Joined -= OnPlayerJoined;
    }

    private static void OnPlayerJoined(PlayerJoinedEventArgs ev)
    {
        RueDisplay display = RueDisplay.Get(ev.Player);

        DynamicElement tab = new(LukeMain.Instance!.Config.VerticalPosition, UIStatic.Footer)
        {
            UpdateInterval = TimeSpan.FromSeconds(LukeMain.Instance.Config.UpdateInterval),
            ResolutionBasedAlign = LukeMain.Instance.Config.ResolutionBased,
            VerticalAlign = LukeMain.Instance.Config.VerticalAlign,
            ZIndex = 999,
        };

        display.Show(new Tag("Footer"), tab);
    }
}
