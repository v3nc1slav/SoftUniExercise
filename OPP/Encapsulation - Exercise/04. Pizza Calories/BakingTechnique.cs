namespace AnimalFarm
{
    using System;

    public class BakingTechnique
    {
        public double crispy { get; set; } = 0.9;
        public double chewy { get; set; } = 1.1;
        public double homemade { get; set; } = 1.0;

        public BakingTechnique(string bakingTechnique)
        {
            bakingTechnique = bakingTechnique.ToLower();
            if (bakingTechnique == "crispy"
                && bakingTechnique == "chewy"
                && bakingTechnique == "homemade")
            {
                throw new ArgumentException("Invalid type of dough.");
            }
        }

        public double CalcoleitBakingTechnique(string bakingTechnique)
        {
            bakingTechnique = bakingTechnique.ToLower();
            if (bakingTechnique == "crispy")
            {
                return crispy;
            }
            else if (bakingTechnique == "chewy")
            {
                return chewy;
            }
            else
            {
                return homemade;
            }
        }
    }
}
