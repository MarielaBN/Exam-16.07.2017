using System;
using System.Security.AccessControl;

public abstract class Harvester : Miner
{
    
    private double oreOutput;
    private double energyRequirement;

    protected Harvester(string id, double oreOutput, double energyRequirement) 
        : base(id)
    {

        this.oreOutput = oreOutput;
        this.energyRequirement = energyRequirement;
    }
    public double OreOutput
    {
        get { return this.oreOutput; }
        protected set
        {
            if (value < 0)
            {
                throw new ArgumentException(@"Harvester is not registered, because of it's OreOutput");
            }
            this.oreOutput = value; 
        } 
    }
    public virtual double EnergyRequirement
    {
        get { return this.energyRequirement; }
        protected set
        {
            if (value < 0 )
            {
                throw new ArgumentException(@"Harvester is not registered, because of it's EnergyRequirement");
            }
            if (value > 20000)
            {
                throw new ArgumentException(@"Harvester is not registered, because of it's EnergyRequirement");
            }
            this.energyRequirement = value; 
        } 
    }
}