using Microsoft.AspNetCore.Mvc;
using Microsoft.EntityFrameworkCore;
using samaranipi.Models;

namespace samaranipi.Controllers;

public class ContractsController : Controller {
    MyAppContext db;

    public ContractsController(MyAppContext db) => this.db = db;

    public async Task Index()
    {
        await Response.SendFileAsync("html/index.html");
    }


    public async Task Import(){
         await Response.SendFileAsync("html/import.html");
    }

    //  api/Contracts/GetContracts
    public async Task<IEnumerable<Contract>> GetContracts()
        => await db.Contracts.ToListAsync();
    
    public async Task<IEnumerable<ContractStage>> GetContractStages()
        => await db.ContractStages.ToListAsync();

    public async Task<IEnumerable<TableRow>> GetTableRows(){
        var contracts = await db.Contracts.Include(c => c.Stages).ToListAsync();
        var rows = new List<TableRow>();
        foreach (var c in contracts){
            var stages = c.Stages;
            if(stages.Count == 0){
                rows.Add(new TableRow(c.Code, c.Name, c.Customer, null, null, null));
            } else if(stages.Count == 1) {
                var stage = stages[0];
                rows.Add(new TableRow(c.Code, c.Name, c.Customer, stage.Name, stage.StartDate, stage.EndDate));
            } else if (stages.Count > 1) {
                foreach (var stage in stages) {
                    rows.Add(new TableRow(c.Code, c.Name, c.Customer, stage.Name, stage.StartDate, stage.EndDate));
                }
            }
        }

        return rows;
    }
    //     => await db.ContractStages.Include(c => c.Contract).ToListAsync();

}

public record class TableRow(string? Code, string? Name, string? Customer, string? StageName, string? StartDate, string? EndDate);

