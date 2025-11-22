using HarmonyLib;
using Astra.info.HIIIII;

namespace PATCHESS
{
    public class patches
    {
        public static void Patchall()
        {
            var harmoney = new Harmony(info2.GUID);
            var harmoney2 = new Harmony(INFO1.GUID);
            harmoney.PatchAll();
            harmoney2.PatchAll();
        }
    }
}