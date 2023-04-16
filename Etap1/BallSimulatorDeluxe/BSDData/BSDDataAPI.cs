using System.Diagnostics;

namespace BSDData
{
    class BSDDataAPI : BSDAbstractDataAPI
    {
        BasicConstraintManager basicConstraintManager = new BasicConstraintManager();
        public BSDDataAPI() : base() { }

        public override BasicConstraintManager GetConstraintManager()
        {
            return basicConstraintManager;
        }
    }
}