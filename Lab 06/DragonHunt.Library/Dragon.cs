namespace DragonHunt.Library
{
    // delegate used by the dragon fire breath event
    public delegate void FireBreathHandler(int fireIntensity);

    public class Dragon : Character
    {
        public int ExperienceReward { get; set; }

        // event raised when the dragon breathes fire
        public event FireBreathHandler OnFireBreath;

        // computes fire intensity and notifies subscribers
        public int BreatheFire()
        {
            int intensity = Level * 5 + Strength / 2 + Intelligence / 3;

            // fire the event if anyone listens
            if (OnFireBreath != null)
            {
                OnFireBreath(intensity);
            }

            return intensity;
        }

        public override string ToString()
        {
            return base.ToString() + $" | Reward {ExperienceReward} exp";
        }
    }
}
