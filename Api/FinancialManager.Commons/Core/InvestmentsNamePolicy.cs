using System;
using System.Text.Json;

namespace FinancialManager.Commons.Core;

public class InvestmentsNamePolicy : JsonNamingPolicy
{
    public override string ConvertName(string name) => name switch
    {
        "Code" => "CODIGO",
        "Logo" => "LOGO",
        "ResponsibleCode" => "COD_EMISSOR",
        "StockCode" => "COD_PAPEL",
        "StockDescription" => "DESC_PAPEL",
        "StockFcCode" => "FC_CODPAPEL",
        "Responsible" => "EMISSOR",
        "TaxRate" => "TAXA",
        "Index" => "INDICE",
        "Percentage" => "PERCENTUAL",
        "Deadline" => "PRAZO",
        "ExpireDate" => "VENCIMENTO",
        "Minimum" => "MINIMO",
        "Pu" => "PU",
        "StockIssueType" => "ATIVO",
        "Remuneration" => "REMUNERACAO",
        "Liquidity" => "LIQUIDEZ",
        "Ir" => "IR",
        "Aba" => "ABA",
        "Suitability" => "SUITABILITY",
        "Secured" => "ASSEGURADO",
        "Qualified" => "QUALIFICADO",
        "Rating" => "RATING",
        "Bond" => "LASTRO",
        "Selected" => "SELECIONADO",
        _ => name
    };
}

