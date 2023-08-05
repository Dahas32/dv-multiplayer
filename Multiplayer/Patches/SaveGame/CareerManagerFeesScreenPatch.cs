using DV.ServicePenalty.UI;
using HarmonyLib;
using Multiplayer.Components.Networking;

namespace Multiplayer.Patches.SaveGame;

[HarmonyPatch(typeof(CareerManagerFeesScreen), nameof(CareerManagerFeesScreen.Activate))]
public static class CareerManagerFeesScreenPatch
{
    private static bool Prefix(CareerManagerFeesScreen __instance)
    {
        if (NetworkLifecycle.Instance.IsHost())
            return true;
        __instance.infoScreen.SetInfoData(__instance.mainScreen, CareerManagerLocalization.FEES, "Only the host can manage fees!");
        __instance.screenSwitcher.SetActiveDisplay(__instance.infoScreen);
        return false;
    }
}
