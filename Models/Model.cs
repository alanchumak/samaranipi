namespace samaranipi.Models;

public class Contract{
    public int Id { get; set; }
    public string? Code { get; set; }
    public string? Name { get; set; }
    public string? Customer { get; set; }
    public List<ContractStage> Stages { get; set; } = new();

}

public class ContractStage{
    public int Id { get; set; }
    public string? Name { get; set; }

    public string? StartDate { get; set; }
    public string? EndDate { get; set; }
    public int ContractId { get; set; }
    public Contract? Contract { get; set; } 

}

