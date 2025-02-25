using MediatR;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace PipeLine;

public class FetchDataQueryHandler : IRequestHandler<FetchDataQuery, string>
{
    public Task<string> Handle(FetchDataQuery request, CancellationToken cancellationToken)
    {
        return Task.FromResult($"Data for {request.DataId}");
    }
}