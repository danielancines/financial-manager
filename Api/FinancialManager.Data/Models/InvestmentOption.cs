namespace FinancialManager.Data.Models;

public class InvestmentOption
{
    public int Code { get; init; }
    public string Logo { get; init; } = string.Empty;
    public int ResponsibleCode { get; init; }
    public int StockCode { get; init; }
    public string StockDescription { get; init; } = string.Empty;
    public int StockFcCode { get; init; }
    public string Responsible { get; init; } = string.Empty;
    public double TaxRate { get; init; }
    public string Index { get; init; } = string.Empty;
    public double Percentage { get; init; }
    public int Deadline { get; init; }
    public string ExpireDate { get; init; } = string.Empty;
    public double Minimum { get; init; }
    public double Pu { get; init; }
    public string StockIssueType { get; init; } = string.Empty;
    public string Remuneration { get; init; } = string.Empty;
    public string Liquidity { get; init; } = string.Empty;
    public string Ir { get; init; } = string.Empty;
    public string Aba { get; init; } = string.Empty;
    public int Suitability { get; init; }
    public string Secured { get; init; } = string.Empty;
    public string Qualified { get; init; } = string.Empty;
    public string Rating { get; init; } = string.Empty;
    public double Bond { get; init; }
    public bool Selected { get; init; }
    public double SelicRate { get; set; }
    public double IpcaRate { get; set; }
    public double AnnualTaxRate => this.Index switch
    {
        "IPC-A" => ((Math.Pow(1 + (this.IpcaRate / 100d), 1 * 12d) - 1) * 100) + this.TaxRate,
        "CDI" => this.Percentage * this.SelicRate / 100,
        "PRE" => this.TaxRate,
        _ => this.TaxRate
    };

    public double MonthTaxRate => (Math.Pow(1 + (this.AnnualTaxRate / 100d), 1 / 12d) - 1) * 100;
    public double DayTaxRate => (Math.Pow(1 + (this.MonthTaxRate / 100d), 1 / 30d) - 1) * 100;
    public double IrTaxeRate => this.GetIrTaxeRate(this.Deadline);

    double GetIrTaxeRate(int deadLine)
    {
        if (deadLine <= 180)
        {
            return 0.2250;
        }
        else if (deadLine > 180 && deadLine <= 365)
        {
            return 0.20;
        }
        else if (deadLine > 365 && deadLine <= 720)
        {
            return 0.1750;
        }
        else if (deadLine > 720)
        {
            return 0.15;
        }
        else
        {
            return 0.2250;
        }
    }
}

