using EA.CommonLib.Messages;
using Orders.Application.DTOs;
using System.Collections.Generic;

namespace Orders.Application.Queries.GetVoucherByCode
{
    public class GetVoucherByCodeQuery : Query<GetVoucherByCodeQuery, VoucherDTO>
    {
        public GetVoucherByCodeQuery(string code)
        {
            AggregateId = Guid.NewGuid();
            Code = code;
        }
        public string Code { get; private set; }
    }
}
