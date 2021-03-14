using System;
using System.Collections.Generic;
using System.Text;

namespace Dominio.Dtos.Base
{
    public class PaginacaoDTO
    {
        public PaginacaoDTO(int pageNumber, int pageSize)
        {
            PageNumber = pageNumber;
            PageSize = pageSize;
        }

        public int? PageNumber { get; set; }
        public int? PageSize { get; set; }
        public override string ToString()
        {
            return $"{PageNumber}-{PageSize}";
        }
    }
}
