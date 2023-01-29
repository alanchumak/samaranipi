using Microsoft.AspNetCore.Mvc;
using samaranipi.Models;
using ClosedXML.Excel;


namespace samaranipi.Controllers;

public class ImportController : Controller
{
    MyAppContext db;

    public ImportController(MyAppContext db) => this.db = db;

    [HttpPost]
    // [Route("api/Import/UploadFile")]
    public IActionResult UploadFile(IFormFile file){ 
        if(file == null) return new EmptyResult();
        ImportExcelToDb(file.OpenReadStream());
        return new CreatedResult(@"api/Import/UploadFile", null);
    }

     void ImportExcelToDb(Stream stream){
        using (var workbook = new XLWorkbook(stream)){
            var worksheet = workbook.Worksheet(1);
            var rows = worksheet.RangeUsed().RowsUsed().Skip(1);
            SaveToDb(rows);
        }
    }

    async void SaveToDb(IEnumerable<IXLRangeRow> rows)
    {
        var constracts = new List<Contract>();
        foreach (var row in rows)
        {
            var contract = GetContract(constracts, row);
            var stage = GetContractStage(row, contract);
            db.Contracts.Add(contract);
            db.ContractStages.Add(stage);
        }
        await db.SaveChangesAsync();
    }

    Contract GetContract(List<Contract> constracts, IXLRangeRow row)
    {
        var code = row.Cell(1).GetValue<string>();
        var contract = constracts.FirstOrDefault(c => c.Code == code);
        if (contract == null)
        {
            contract = new Contract();
            contract.Code = code;
            contract.Name = row.Cell(2).GetValue<string>();
            contract.Customer = row.Cell(3).GetValue<string>();
            constracts.Add(contract);
        }
        return contract;
    }

    ContractStage GetContractStage(IXLRangeRow row, Contract contract)
    {
        var stage = new ContractStage();
        stage.Name = row.Cell(4).GetValue<string>();
        stage.StartDate = row.Cell(5).GetValue<DateTime>().ToShortDateString();
        stage.EndDate = row.Cell(6).GetValue<DateTime>().ToShortDateString();
        stage.Contract = contract;
        return stage;
    }


}