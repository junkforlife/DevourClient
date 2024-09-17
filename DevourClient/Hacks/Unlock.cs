namespace DevourClient.Hacks
{
    public class Unlock
    {
        public static void Achievements()
        {
            Il2Cpp.AchievementHelpers ah = UnityEngine.Object.FindObjectOfType<Il2Cpp.AchievementHelpers>();

            string[] achievements = {"ACH_ALL_CLIPBOARDS_READ", "ACH_ALL_NOTES_READ", "ACH_UNLOCKED_CAGE", "ACH_UNLOCKED_ATTIC_CAGE", "ACH_CALMED_ANNA", "ACH_FRIED_RAT", "ACH_BURNT_GOAT", "ACH_KNOCKED_OUT_BY_ANNA", "ACH_KNOCKOUT_OUT_BY_DEMON", "ACH_KNOCKED_OUT_IN_HIDING", "STAT_NUM_BLEACH_USED", "ACH_WON_SP", "ACH_WIN_NIGHTMARE", "ACH_WON_HARD_SP", "ACH_WON_COOP", "ACH_WON_HARD", "ACH_WIN_NIGHTMARE_SP", "ACH_LOST", "ACH_NEVER_KNOCKED_OUT", "ACH_ONLY_ONE_KNOCKED_OUT", "ACH_WON_HARD_NO_MEDKITS", "ACH_WON_NO_MEDKITS", "ACH_WON_NO_BATTERIES", "ACH_WON_NIGHTMARE_NO_MEDKITS", "ACH_WON_NO_KNOCKOUT_COOP", "ACH_WON_HARD_NO_BATTERIES", "ACH_WON_HARD_{0}", "ACH_WON_NIGHTMARE_{0}", "ACH_WON_NIGHTMARE_NO_BATTERIES", "ACH_SURVIVED_TO_7_GOATS", "ACH_SURVIVED_TO_5_GOATS", "ACH_SURVIVED_TO_3_GOATS", "ACH_WON_Manor_NIGHTMARE_SP", "ACH_WON_NIGHTMARE_", "ACH_WON_MANOR_NIGHTMARE_SP", "ACH_WON_TOWN_HARD", "ACH_WON_INN_HARD_SP", "ACH_ALL_FEATHERS", "ACH_WON_SLAUGHTERHOUSE_COOP", "ACH_ALL_BARBED_WIRES", "ACH_WON_INN_HARD", "ACH_WON_MOLLY_HARD", "ACH_ALL_HORSESHOES", "ACH_WON_MOLLY_HARD_SP", "ACH_WON_TOWN_NIGHTMARE_SP", "ACH_100_GASOLINE_USED", "ACH_WON_INN_SP", "ACH_WON_MANOR_HARD_SP", "ACH_WON_MOLLY_SP", "ACH_1000_PIGS_DESTROYED", "ACH_1000_MIRRORS_DESTROYED", "ACH_100_EGGS_DESTROYED", "ACH_WON_SLAUGHTERHOUSE_HARD_SP", "ACH_WON_TOWN_COOP", "ACH_100_FUSES_USED", "ACH_WON_MOLLY_COOP", "ACH_WON_MOLLY_NIGHTMARE_SP", "ACH_1000_BOOKS_DESTROYED", "ACH_ALL_PATCHES", "ACH_WON_SLAUGHTERHOUSE_SP", "ACH_WON_TOWN_NIGHTMARE", "ACH_WON_INN_COOP", "ACH_ALL_CHERRY_BLOSSOM", "ACH_WON_TOWN_HARD_SP", "ACH_WON_MOLLY_NIGHTMARE", "ACH_WON_INN_NIGHTMARE_SP", "ACH_ALL_ROSES", "ACH_WON_TOWN_SP", "ACH_WON_SLAUGHTERHOUSE_NIGHTMARE_SP", "ACH_WON_INN_NIGHTMARE", "ACH_WON_MANOR_COOP", "ACH_WON_SLAUGHTERHOUSE_HARD", "ACH_WON_SLAUGHTERHOUSE_NIGHTMARE", "ACH_WON_MANOR_HARD", "ACH_WON_MANOR_NIGHTMARE", "ACH_WON_MANOR_SP", };

            for (int i = 0; i < achievements.Length; i++)
            {
                ah.Unlock(achievements[i]);
            }
        }

        public static void Doors()
        {
            //Pour chaques portes, on les ouvre
            foreach (Il2CppHorror.DoorBehaviour doorBehaviour in UnityEngine.Object.FindObjectsOfType<Il2CppHorror.DoorBehaviour>())
            {
                doorBehaviour.state.Locked = false;
                if (doorBehaviour.IsOpen())
                {
                    doorBehaviour.m_DoorGraphUpdate.DoorOpening();
                }
                else
                {
                    doorBehaviour.m_DoorGraphUpdate.DoorClosed();
                }
                doorBehaviour.Unlock();
            }
        }
    }
}
