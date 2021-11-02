using System;
using System.Collections.Generic;
using System.Linq;
using System.Linq.Expressions;
using System.Text;
using System.Threading.Tasks;
using AutoMapper;

namespace CanWeFixItService
{
    public class AutoMapperProfile :  Profile 
    {        

        public AutoMapperProfile()
        {
            CreateMap<MarketData, MarketDataDto>()
                 .ReverseMap()
                 .ForMember(destination => destination.Sedol, member => member.Ignore()); 
        } 
    }
}
