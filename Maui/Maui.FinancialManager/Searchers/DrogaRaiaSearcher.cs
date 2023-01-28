using System.Text;
using Maui.FinancialManager.Models;
using Maui.FinancialManager.Resources;
using Maui.FinancialManager.Searchers.Base;
using Maui.FinancialManager.Serializers;

namespace Maui.FinancialManager.Searchers;

public class DrogaRaiaSearcher : IMedicineSearcher
{
    const string URL = @"https://app-api-m2-prod.drogaraia.com.br/graphql";
    readonly DrogaraiaSerializer serializer;

    public DrogaRaiaSearcher(DrogaraiaSerializer serializer)
    {
        this.serializer = serializer;
    }

    public async Task<IEnumerable<Medicine>> SearchAsync(string searchTerm)
    {
        var httpClient = new HttpClient();
        httpClient.DefaultRequestHeaders.Add("x-api-key", "5f308895c59fadb0b9ed43341c6eb33e41e78394d3ca970c5a285e91d25bc9cd");

        var content = new StringContent(SearchUrls.DrogaRaia.Replace("!searchTerm!", searchTerm), Encoding.UTF8, "application/json");

        var response = await httpClient.PostAsync(string.Format(URL, searchTerm), content);

        if (response.IsSuccessStatusCode)
        {
            return serializer.Deserialize(await response.Content.ReadAsStringAsync());
        }
        else
        {
            return new List<Medicine>();
        }
    }
}

//Issue on GraphQL Client to query on IOS because JIT and AOT https://learn.microsoft.com/en-us/xamarin/ios/internals/limitations
//public class DrogaRaiaSearcher : IMedicineSearcher
//{
//    const string URL = @"https://app-api-m2-prod.drogaraia.com.br/graphql";
//    readonly DrogaraiaSerializer serializer;

//    public DrogaRaiaSearcher(DrogaraiaSerializer serializer)
//    {
//        this.serializer = serializer;
//    }

//    public async Task<IEnumerable<Medicine>> SearchAsync(string searchTerm)
//    {
//        var httpClient = new HttpClient();
//        httpClient.DefaultRequestHeaders.Add("x-api-key", "5f308895c59fadb0b9ed43341c6eb33e41e78394d3ca970c5a285e91d25bc9cd");

//        var graphQLHttpClientOptions = new GraphQLHttpClientOptions
//        {
//            EndPoint = new Uri(URL)
//        };

//        var graphQLClient = new GraphQLHttpClient(graphQLHttpClientOptions, new NewtonsoftJsonSerializer(), httpClient);
//        var request = new GraphQLRequest
//        {
//            Query = @"
//            {
//                search(search: {term: ""!term!""} ,isStixNewAccelerator: true, token: """") {
//                    products {
//                        name,
//                        image,
//                        gallery,
//                        packageQty,
//                        description,
//                        availability {
//                            hasStock
//                        },
//                        oldPrice {
//                            value
//                        },
//                        price {
//                            value
//                        }
//                    }
//                }
//            }".Replace("!term!", searchTerm)
//        };

//        var graphQLResponse = await graphQLClient.SendQueryAsync<dynamic>(request);
//        if (graphQLResponse.Data != null)
//        {
//            return serializer.Deserialize(graphQLResponse.Data.ToString());
//        }
//        else
//        {
//            return new List<Medicine>();
//        }
//    }
//}

