using System.Collections.Generic;
using System.Linq;
using System.Security.Principal;
using System.Text;

public class DraftManager
{
    private double koefModeOre;
    private double koefModeEnergy;
    private double summedEnergyOutput;
    private double summedOreOutput;
    private double totalStoredEnergy;
    private double totalMinedOre;

    public DraftManager()
    {
        this.Harvesters = new List<Harvester>();
        this.Providers = new List<Provider>();
        this.koefModeOre = 1;
        this.koefModeEnergy = 1;
    }

    public List<Harvester> Harvesters { get; set; }
    public List<Provider> Providers { get; set; }
   
    public string RegisterHarvester(List<string> arguments)
    {

        try
        {
            Harvester harvester = HarvesterFactory.GetHarvester(arguments);
            Harvesters.Add(harvester);

        }
        catch (System.Exception e)
        {
            return e.Message;
        }

        return $"Successfully registered {arguments[0]} Harvester - {arguments[1]}";
    }
    public string RegisterProvider(List<string> arguments)
    {
        try
        {
            Provider provider = ProviderFactory.GetProvider(arguments);
            Providers.Add(provider);
        }
        catch (System.Exception ex)
        {
            return ex.Message;
        }
        return $"Successfully registered {arguments[0]} Provider - {arguments[1]}";
    }
    public string Day()
    {
        this.summedEnergyOutput = Providers.Select(p => p.EnergyOutput).Sum();
        this.totalStoredEnergy = this.totalStoredEnergy + this.summedEnergyOutput;
        double summedEnergyRequirement = Harvesters.Select(h => h.EnergyRequirement).Sum()*this.koefModeEnergy;

        if (summedEnergyRequirement <= totalStoredEnergy)
        {
            this.summedOreOutput = Harvesters.Select(h => h.OreOutput).Sum()*this.koefModeOre;
            this.totalMinedOre += this.summedOreOutput;
            this.totalStoredEnergy -= summedEnergyRequirement;
        }

        StringBuilder sb = new StringBuilder();
        sb.AppendLine("A day has passed.");
        sb.AppendLine($"Energy Provided: { this.summedEnergyOutput}");
        sb.AppendLine($"Plumbus Ore Mined: { this.summedOreOutput}");

        return sb.ToString().Trim();
    }
    public string Mode(List<string> arguments)
    {       
        switch (arguments[0])
        {
            case "Half":
                {
                    this.koefModeOre = 0.5;
                    this.koefModeEnergy = 0.6;
                }
                break;
            case "Energy":
                {
                    this.koefModeOre = 0;
                    this.koefModeEnergy = 0;
                }
                break;
            default:
                {
                    this.koefModeOre = 1;
                    this.koefModeEnergy = 1;
                }
                break;
        }

        return $"Successfully changed working mode to {arguments[0]} Mode";
    }
    public string Check(List<string> arguments)
    {
        var id = arguments[0];
        if (Harvesters.Any(h => h.Id == id))
        {
            return Harvesters.Where(h => h.Id == id).First().ToString().Trim();
        }
        else if (Providers.Any(p => p.Id == id))
        {
            return Providers.Where(p => p.Id == id).First().ToString().Trim();
        }
        return $"No element found with id - {id}";
    }
    public string ShutDown()
    {
        StringBuilder sb = new StringBuilder();
        sb.AppendLine("System Shutdown");
        sb.AppendLine($"Total Energy Stored: {this.totalStoredEnergy}");
        sb.AppendLine($"Total Mined Plumbus Ore: {this.totalMinedOre}");

        return sb.ToString().Trim();
    }

}