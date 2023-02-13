using System;
using System.Text.Json.Serialization;

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
}
