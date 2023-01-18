using GraphQL;
using GraphQL.Client.Http;
using GraphQL.Client.Serializer.Newtonsoft;
using Maui.FinancialManager.Models;
using Maui.FinancialManager.Searchers.Base;
using Maui.FinancialManager.Serializers;

namespace Maui.FinancialManager.Searchers;

public class DrogaRaiaSearcher : IMedicineSearcher
{
    const string URL = @"https://app-api-m2-prod.drogaraia.com.br/graphql";

    public async Task<IEnumerable<Medicine>> SearchAsync(string searchTerm)
    {
        var httpClient = new HttpClient();
        httpClient.DefaultRequestHeaders.Add("x-api-key", "5f308895c59fadb0b9ed43341c6eb33e41e78394d3ca970c5a285e91d25bc9cd");

        var graphQLHttpClientOptions = new GraphQLHttpClientOptions
        {
            EndPoint = new Uri(URL)
        };

        var graphQLClient = new GraphQLHttpClient(graphQLHttpClientOptions, new NewtonsoftJsonSerializer(), httpClient);
        var request = new GraphQLRequest
        {
            Query = @"
            {
                search(search: {term: ""!term!""} ,isStixNewAccelerator: true, token: """") {
                    products {
                        name,
                        image,
                        packageQty,
                        availability {
                            hasStock
                        },
                        oldPrice {
                            value
                        },
                        price {
                            value
                        }
                    }
                }
            }".Replace("!term!", searchTerm)
        };

        var graphQLResponse = await graphQLClient.SendQueryAsync<dynamic>(request);
        if (graphQLResponse.Data != null)
        {
            return DrogaraiaSerializer.Deserialize(graphQLResponse.Data.ToString());
        }
        else
        {
            return new List<Medicine>();
        }
    }
}

