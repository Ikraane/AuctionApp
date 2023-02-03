using AutoMapper;
using Bid = ProjectApp.Core.Bid;
using ProjectApp.Persistence;


namespace ProjectApp.Mappings
{
    public class BidProfile : Profile
    {
        public BidProfile()
        {
            CreateMap<BidDB, Bid>()
                .ReverseMap();
        }
    }
}
