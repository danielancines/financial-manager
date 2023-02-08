using System;
namespace Maui.FinancialManager.Services.Base;

public abstract class BaseService
{
    public HttpClient GetClient()
    {
        var client = new HttpClient();
        client.DefaultRequestHeaders.Add("authorization", "Bearer eyJhbGciOiJIUzI1NiIsInR5cCI6IkpXVCJ9.eyJ1bmlxdWVfbmFtZSI6ImRhbmllbC5hbmNpbmVzQGdtYWlsLmNvbSIsIm5iZiI6MTY3NTY3ODM0NiwiZXhwIjoxNjc1Njg1NTQ2LCJpYXQiOjE2NzU2NzgzNDZ9.NogQy341WQHQDTIa6gknmt8Z8tgGzp8LKVGipfrGyQE");
        return client;
    }
}

