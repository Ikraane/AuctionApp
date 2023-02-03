using AutoMapper;
using ProjectApp.Core;
using ProjectApp.Persistence;

namespace ProjectApp.Mappings
{
    public class AuctionProfile : Profile
    {
        public AuctionProfile()
        {
            CreateMap<AuctionDB, Auction>()
                .ReverseMap();
        }
    }
}
