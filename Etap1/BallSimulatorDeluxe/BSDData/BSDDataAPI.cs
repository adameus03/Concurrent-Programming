using System.Diagnostics;

namespace BSDData
{
    public interface BSDDataAPI
    {
        public static void Ok()
        {

        }
        public void Good()
        {
            Debug.Close();  
        }
    }
}