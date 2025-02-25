using MediatR;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace PipeLine;

public record FetchDataQuery(string DataId) : IRequest<string>;

