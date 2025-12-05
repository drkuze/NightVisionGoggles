using Exiled.API.Features;

using HarmonyLib;

using InventorySystem.Items.Usables.Scp1344;

using static NightVisionGoggles.NightVisionGoggles;

namespace NightVisionGoggles.Patchs
{
    [HarmonyPatch(typeof(Scp1344Item), nameof(Scp1344Item.CanStartUsing), MethodType.Getter)]
    public class CanStartUsingPatch
    {
        public static void Postfix(Scp1344Item __instance, ref bool __result)
        {
            if (!__result)
                return;

            if (!NVG.TrackedSerials.Contains(__instance.ItemSerial))
                return;

            Player player = Player.Get(__instance.Owner);
            if (NVG.Lights.ContainsKey(player))
                __result = false;
        }
    }
}
