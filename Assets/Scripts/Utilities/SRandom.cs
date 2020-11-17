using VRF.BaseClass;


namespace VRF.Util
{
    public class SRandom : Singleten<SRandom>
    {
        private System.Random rand;

        SRandom()
        {
            rand = new System.Random();
        }

        public int GetRandom(int min, int max)
        {
            return rand.Next(min, max);
        }
    }
}
