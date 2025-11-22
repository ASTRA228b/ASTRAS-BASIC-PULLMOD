using HarmonyLib;
using Astra.info.HIIIII;

namespace PATCHESS
{
    public class patches
    {
        public static void Patchall()
        {
            var harmoney2 = new Harmony(INFO1.GUID);
            harmoney2.PatchAll();
        }
    }

}
