using MediatR;

namespace PipeLine;

public class ModuleAService
{
    private readonly IMediator _mediator;

    public ModuleAService(IMediator mediator)
    {
        _mediator = mediator;
    }

    public async Task<string> GetData(string dataId)
    {
        return await _mediator.Send(new FetchDataQuery(dataId));
    }
}

