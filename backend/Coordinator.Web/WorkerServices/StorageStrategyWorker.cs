using Coordinator.Web.Data.Entities;
using Coordinator.Web.Repositories;
using Coordinator.Web.WorkerServices.Models;

namespace Coordinator.Web.WorkerServices;

public class StorageStrategyWorker : IWorker
{
    private readonly IFlowInstanceRepo _flowInstance;
    private readonly IHttpClientFactory _httpClientFactory;

    public StorageStrategyWorker(IFlowInstanceRepo flowInstance, 
        IHttpClientFactory httpClientFactory)
    {
        _flowInstance = flowInstance ?? throw new ArgumentNullException(nameof(flowInstance));
        _httpClientFactory = httpClientFactory ?? throw new ArgumentNullException(nameof(httpClientFactory));
    }

    public WorkerType WorkerType => WorkerType.StoragePolicymaker;

    public async Task ExecuteAsync(long instanceId)
    {
        var instance = await _flowInstance.GetAsync(instanceId);
        if (instance == null)
        {
            throw new InvalidOperationException();
        }

        var arg = StorageStrategyInputParameter.Build(instance.CurrentStep.Input);
        var value = await SendRequestAsync(arg);

        instance.CurrentStep.SetOutput(value.ToDictionary());
        instance.MoveNext();

        await _flowInstance.UnitOfWork.CommitAsync();
    }

    protected async Task<StorageStrategyOutputParameter> SendRequestAsync(StorageStrategyInputParameter arg)
    {
        using var client = _httpClientFactory.CreateClient();
        var resp = await client.PostAsJsonAsync("", arg);
        if (resp.IsSuccessStatusCode)
        {
            var value = await resp.Content.ReadFromJsonAsync<StorageStrategyOutputParameter>();
            if (value == null)
            {
                throw new InvalidOperationException();
            }

            return value;
        }

        throw new InvalidOperationException();
    }
}