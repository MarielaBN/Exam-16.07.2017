using System;
using System.Text;

public class SonicHarvester : Harvester
{
    private int sonicFactor;
    public SonicHarvester(string id, double oreOutput, double energyRequirement, int sonicFactor) 
        : base(id, oreOutput, energyRequirement)
    {
        this.Id = id;
        this.sonicFactor = sonicFactor;
        this.EnergyRequirement = energyRequirement;
    }

    public override double EnergyRequirement
    {
        get
        {
            return base.EnergyRequirement;
        }

        protected set
        {
            if (value > 20000)
            {
                throw new ArgumentException(@"Harvester is not registered, because of it's EnergyRequirement");
            }
            base.EnergyRequirement = value / this.sonicFactor;
        }
    }

    public override string ToString()
    {
        StringBuilder sb = new StringBuilder();
        sb.AppendLine($"Sonic Harvester - {this.Id}");
        sb.AppendLine($"Ore Output: {this.OreOutput}");
        sb.AppendLine($"Energy Requirement: {this.EnergyRequirement}");
        return sb.ToString().Trim();
    }
}