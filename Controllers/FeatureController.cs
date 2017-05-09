using System.Collections.Generic;
using System.Threading.Tasks;
using AutoMapper;
using Microsoft.EntityFrameworkCore;
using VEGA.Controllers.Resources;
using VEGA.Models;
using VEGA.Persistence;

namespace VEGA.Controllers
{
    public class FeatureController
    {
        private readonly IMapper mapper;
        private readonly VegaDbContext contex;
        public FeatureController(VegaDbContext contex, IMapper mapper)
        {
            this.contex = contex;
            this.mapper = mapper;
        }

        public async Task<IEnumerable<FeatureResource>> GetFeatures()
        {
            var features = await contex.Features.ToListAsync();

            return mapper.Map<List<Feature>, List<FeatureResource>>(features);
        }


    }
}