namespace LukeUI.UI;

using System.Linq;
using Exiled.API.Features;
using LukeUI.EventsHandler;
using PlayerRoles;
using PlayerRoles.Spectating;
using RueI.API.Elements;

/// <summary>
/// Static member for the system used by <see cref="DynamicElement"/>.
/// </summary>
public static class UIStatic
{
    /// <summary>
    /// The UI element to use.
    /// </summary>
    /// <param name="hub">Player who is calling.</param>
    /// <returns>The string to display.</returns>
    public static string Footer(ReferenceHub hub)
    {
        if (!KillEventsHandler.Kills.ContainsKey(hub) || !KillEventsHandler.Deaths.ContainsKey(hub))
            return string.Empty;

        if (hub.IsAlive())
        {
            return LukeMain.Instance!.Config.AliveUI
                .Replace("%roleColor%", hub.roleManager.CurrentRole.RoleColor.ToHex())
                .Replace("%roleDisplayName%", hub.roleManager.CurrentRole.RoleName)
                .Replace("%tps%", $"{Server.SmoothTps:0.0}")
                .Replace("%roundTime%", Round.ElapsedTime.ToString(LukeMain.Instance.Config.FormatRoundTime))
                .Replace("%id%", hub.PlayerId.ToString())
                .Replace("%kills%", KillEventsHandler.Kills[hub].ToString())
                .Replace("%deaths%", KillEventsHandler.Deaths[hub].ToString());
        }

        ReferenceHub? spected = null;

        if (hub.roleManager.CurrentRole is not SpectatorRole sr)
            return string.Empty;

        if (ReferenceHub.TryGetHubNetID(sr.SyncedSpectatedNetId, out ReferenceHub spectated))
            spected = spectated;

        return LukeMain.Instance!.Config.DeadUI
            .Replace("%generators%", Generator.List.Count.ToString())
            .Replace("%activeGenerators%", Generator.List.Count(x => x.IsEngaged).ToString())
            .Replace("%tps%", $"{Server.SmoothTps:0.0}")
            .Replace("%roundTime%", Round.ElapsedTime.ToString(LukeMain.Instance.Config.FormatRoundTime))
            .Replace("%warhead%", LukeMain.Instance.Config.WarheadTranslation[Warhead.Status])
            .Replace("%spectating%", spected == null ? "None" : spected.nicknameSync.DisplayName)
            .Replace("%id%", hub.PlayerId.ToString())
            .Replace("%role%", spected == null ? "<color=white>None</color>" : spected.roleManager.CurrentRole.GetColoredName())
            .Replace("%kills%", KillEventsHandler.Kills[hub].ToString())
            .Replace("%deaths%", KillEventsHandler.Deaths[hub].ToString());
    }
}
